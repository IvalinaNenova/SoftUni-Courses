const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

const DEBUG = false;
const slowMo = 500;

const mockData = {
  profile: [
    {
      _id: '1001',
      username: 'John',
      email: 'john@users.bg',
      age: 31,
    },
  ],
};

const endpoints = {
  list: '/jsonstore/advanced/profiles',
};

let browser;
let context;
let page;

describe('E2E tests', function () {
  // Setup
  this.timeout(DEBUG ? 120000 : 7000);
  before(
    async () =>
      (browser = await chromium.launch(
        DEBUG ? { headless: false, slowMo } : {}
      ))
  );
  after(async () => await browser.close());
  beforeEach(async () => {
    context = await browser.newContext();
    setupContext(context);
    page = await context.newPage();
  });
  afterEach(async () => {
    await page.close();
    await context.close();
  });

  // Test proper
  describe('Profile Info', () => {
    it('Load profiles', async () => {
      const data = mockData.profile;
      const { get } = await handle(endpoints.list);
      get(data);

      await page.goto(host);
      await page.waitForSelector('.profile');

      const post = await page.$$eval(`.profile`, (t) =>
        t.map((s) => s.textContent)
      );
      expect(post.length).to.equal(data.length);
    });

    it('Check profile name', async () => {
      const data = mockData.profile;
      const { get } = await handle(endpoints.list);
      get(data);

      await page.goto(host);
      await page.waitForSelector('.profile');

      await page.click('input[value="unlock"]');
      await page.click('text=Show more');

      const post = await page.$$eval(`input[name="user1Username"]`, (t) =>
        t.map((s) => s.value)
      );

      expect(post[0]).to.equal(data[0].username);
    });

    it('Check isLocked', async () => {
      const data = mockData.profile;
      const { get } = await handle(endpoints.list);
      get(data);

      await page.goto(host);
      await page.waitForSelector('.profile');

      const post = await page.$$eval(`input:checked`, (t) =>
        t.map((s) => s.value)
      );
      expect(post[0]).to.equal('lock');
    });

    it('Check information when in unlock', async () => {
      const data = mockData.profile;
      const { get } = await handle(endpoints.list);
      get(data);

      await page.goto(host);
      await page.waitForSelector('.profile');

      await page.click('input[value="unlock"]');
      await page.click('text=Show more');
      const post = await page.$$eval(`input[type="email"]`, (t) =>
        t.map((s) => s.value)
      );
      expect(post[0]).to.equal(data[0].email);
      expect(post[1]).to.equal(`${data[0].age}`);
    });
  });
});

async function setupContext(context) {
  // Catalog and Details
  await handleContext(context, endpoints.list, { get: mockData.profile });
  await handleContext(context, endpoints.info('1001'), {
    get: mockData.details[0],
  });
  await handleContext(context, endpoints.info('1002'), {
    get: mockData.details[1],
  });

  await handleContext(context, endpoints.details('1001'), {
    get: mockData.catalog[0],
  });
  await handleContext(context, endpoints.details('1002'), {
    get: mockData.catalog[1],
  });
  await handleContext(context, endpoints.details('1003'), {
    get: mockData.catalog[2],
  });

  await handleContext(
    endpoints.profile('0001'),
    { get: mockData.catalog.slice(0, 2) },
    context
  );

  await handleContext(endpoints.total('1001'), { get: 6 }, context);
  await handleContext(endpoints.total('1002'), { get: 4 }, context);
  await handleContext(endpoints.total('1003'), { get: 7 }, context);

  await handleContext(endpoints.own('1001', '0001'), { get: 1 }, context);
  await handleContext(endpoints.own('1002', '0001'), { get: 0 }, context);
  await handleContext(endpoints.own('1003', '0001'), { get: 0 }, context);

  // Block external calls
  await context.route(
    (url) => url.href.slice(0, host.length) != host,
    (route) => {
      if (DEBUG) {
        console.log('Preventing external call to ' + route.request().url());
      }
      route.abort();
    }
  );
}

function handle(match, handlers) {
  return handleRaw.call(page, match, handlers);
}

function handleContext(context, match, handlers) {
  return handleRaw.call(context, match, handlers);
}

async function handleRaw(match, handlers) {
  const methodHandlers = {};
  const result = {
    get: (returns, options) => request('GET', returns, options),
    get2: (returns, options) => request('GET', returns, options),
    post: (returns, options) => request('POST', returns, options),
    put: (returns, options) => request('PUT', returns, options),
    patch: (returns, options) => request('PATCH', returns, options),
    del: (returns, options) => request('DELETE', returns, options),
    delete: (returns, options) => request('DELETE', returns, options),
  };

  const context = this;

  await context.route(urlPredicate, (route, request) => {
    if (DEBUG) {
      console.log('>>>', request.method(), request.url());
    }

    const handler = methodHandlers[request.method().toLowerCase()];
    if (handler == undefined) {
      route.continue();
    } else {
      handler(route, request);
    }
  });

  if (handlers) {
    for (let method in handlers) {
      if (typeof handlers[method] == 'function') {
        handlers[method](result[method]);
      } else {
        result[method](handlers[method]);
      }
    }
  }

  return result;

  function request(method, returns, options) {
    let handled = false;

    methodHandlers[method.toLowerCase()] = (route, request) => {
      handled = true;
      route.fulfill(respond(returns, options));
    };

    return {
      onRequest: () => context.waitForRequest(urlPredicate),
      onResponse: () => context.waitForResponse(urlPredicate),
      isHandled: () => handled,
    };
  }

  function urlPredicate(current) {
    if (current instanceof URL) {
      return current.href.toLowerCase().includes(match.toLowerCase());
    } else {
      return current.url().toLowerCase().includes(match.toLowerCase());
    }
  }
}

function respond(data, options = {}) {
  options = Object.assign(
    {
      json: true,
      status: 200,
    },
    options
  );

  const headers = {
    'Access-Control-Allow-Origin': '*',
  };
  if (options.json) {
    headers['Content-Type'] = 'application/json';
    data = JSON.stringify(data);
  }

  return {
    status: options.status,
    headers,
    body: data,
  };
}
