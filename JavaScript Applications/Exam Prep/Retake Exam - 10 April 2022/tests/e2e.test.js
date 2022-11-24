const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)
const interval = 500;
const DEBUG = false;
const slowMo = 500;

const mockData = require('./mock-data.json');

const endpoints = {
  register: '/users/register',
  login: '/users/login',
  logout: '/users/logout',
  catalog: '/data/posts?sortBy=_createdOn%20desc',
  create: '/data/posts',
  donate: '/data/donations',
  details: (id) => `/data/posts/${id}`,
  delete: (id) => `/data/posts/${id}`,
  profile: (id) => `/data/posts?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`,
  own: (postId, userId) =>
    `/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
  total: (postId) => `/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`,
};

let browser;
let context;
let page;

describe('E2E tests', function () {
  // Setup
  this.timeout(DEBUG ? 120000 : 7000);
  before(async () => (browser = await chromium.launch(DEBUG ? { headless: false, slowMo } : {})));
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

  describe('Authentication [ 20 Points ]', () => {
    it('Register does NOT work with empty fields [ 2.5 Points ]', async () => {
      const { post } = await handle(endpoints.register);
      const isCalled = post().isHandled;

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Register');

      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      expect(isCalled()).to.be.false;
    });

    it('Register makes correct API call [ 5 Points ]', async () => {
      const data = mockData.users[0];
      const { post } = await handle(endpoints.register);
      const { onRequest } = post(data);

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Register');

      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);
      await page.fill('[name="repeatPassword"]', data.password);

      const [request] = await Promise.all([onRequest(), page.click('[type="submit"]')]);

      const postData = JSON.parse(request.postData());

      expect(postData.email).to.equal(data.email);
      expect(postData.password).to.equal(data.password);
    });

    it('Login does NOT work with empty fields [ 2.5 Points ]', async () => {
      const { post } = await handle(endpoints.login);
      const isCalled = post().isHandled;

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');

      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      expect(isCalled()).to.be.false;
    });

    it('Login makes correct API call [ 5 Points ]', async () => {
      const data = mockData.users[0];
      const { post } = await handle(endpoints.login);
      const { onRequest } = post(data);

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');

      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);

      const [request] = await Promise.all([onRequest(), page.click('[type="submit"]')]);

      const postData = JSON.parse(request.postData());
      expect(postData.email).to.equal(data.email);
      expect(postData.password).to.equal(data.password);
    });

    it('Logout makes correct API call [ 5 Points ]', async () => {
      const data = mockData.users[0];
      const { post } = await handle(endpoints.login);
      const { get } = await handle(endpoints.logout);
      const { onResponse } = post(data);
      const { onRequest } = get('', { json: false, status: 204 });

      await page.goto(host);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);

      await Promise.all([onResponse(), page.click('[type="submit"]')]);

      await page.waitForTimeout(interval);

      const [request] = await Promise.all([onRequest(), page.click('nav >> text=Logout')]);

      const token = request.headers()['x-authorization'];
      expect(request.method()).to.equal('GET');
      expect(token).to.equal(data.accessToken);
    });
  });

  describe('Navigation bar [ 5 Points ]', () => {
    it('Logged user should see correct navigation [ 2.5 Points ]', async () => {
      // Login user
      const data = mockData.users[0];
      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);

      await page.click('[type="submit"]');

      //Test for navigation
      await page.waitForTimeout(interval);
      expect(await page.isVisible('nav >> text=Dashboard')).to.be.true;
      expect(await page.isVisible('nav >> text=My Posts')).to.be.true;
      expect(await page.isVisible('nav >> text=Create Post')).to.be.true;
      expect(await page.isVisible('nav >> text=Logout')).to.be.true;

      expect(await page.isVisible('nav >> text=Login')).to.be.false;
      expect(await page.isVisible('nav >> text=Register')).to.be.false;
    });

    it('Guest user should see correct navigation [ 2.5 Points ]', async () => {
      await page.goto(host);
      await page.waitForTimeout(interval);
      expect(await page.isVisible('nav >> text=Dashboard')).to.be.true;
      expect(await page.isVisible('nav >> text=My Posts')).to.be.false;
      expect(await page.isVisible('nav >> text=Create Post')).to.be.false;
      expect(await page.isVisible('nav >> text=Logout')).to.be.false;

      expect(await page.isVisible('nav >> text=Login')).to.be.true;
      expect(await page.isVisible('nav >> text=Register')).to.be.true;
    });
  });

  describe('Dashboard Page [ 15 Points ]', () => {
    it('Show dashboard page [ 2.5 Points ]', async () => {
      await page.goto(host);
      await page.waitForTimeout(interval);

      expect(await page.isVisible('text=All Posts')).to.be.true;
    });

    it('Check dashboard page with 0 posts [ 2.5 Points ]', async () => {
      const { get } = await handle(endpoints.catalog);
      get([]);

      await page.goto(host);
      await page.waitForTimeout(interval);

      const visible = await page.isVisible('text=No posts yet');
      expect(visible).to.be.true;
    });

    it('Check home page with 2 posts [ 2.5 Points ]', async () => {
      const { get } = await handle(endpoints.catalog);
      get(mockData.catalog.slice(0, 2));
      const data = mockData.catalog.slice(0, 2);

      await page.goto(host);
      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      const names = await page.$$eval('.post .post-title', (t) => t.map((s) => s.textContent));

      expect(names.length).to.equal(2);
      expect(names[0]).to.contains(`${data[0].title}`);
      expect(names[1]).to.contains(`${data[1].title}`);
    });

    it('Show details button [ 2.5 Points ]', async () => {
      await page.goto(host);
      await page.waitForTimeout(interval);

      expect(await page.isVisible('text="Details"')).to.be.true;
    });

    it('Check dashboard info [ 5 Points ]', async () => {
      const { get } = await handle(endpoints.catalog);
      get(mockData.catalog.slice(0, 1));
      const data = mockData.catalog.slice(0, 1);

      await page.goto(host);
      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      const titles = await page.$$eval('.post .post-title', (t) => t.map((s) => s.textContent));
      const images = await page.$$eval('.post .post-image', (t) => t.map((s) => s.src));

      expect(titles).to.contains(data[0].title);
      expect(images[0]).to.contains(data[0].imageUrl);
    });
  });

  describe('CRUD [ 50 Points ]', () => {
    // Login user
    beforeEach(async () => {
      const data = mockData.users[0];
      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);
      await page.click('[type="submit"]');
      await page.waitForTimeout(interval);
    });

    it('Create does NOT work with empty fields [ 5 Points ]', async () => {
      const { post } = await handle(endpoints.create);
      const isCalled = post().isHandled;

      await page.click('text=Create Post');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');

      page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      expect(isCalled()).to.be.false;
    });

    it('Create makes correct API call for logged in user [ 10 Points ]', async () => {
      const data = mockData.catalog[0];
      const { post } = await handle(endpoints.create);
      const { onRequest } = post(data);

      await page.click('text=Create Post');
      await page.waitForTimeout(interval);

      await page.waitForSelector('form');
      await page.fill('[name="title"]', data.title);
      await page.fill('[name="description"]', data.description);
      await page.fill('[name="imageUrl"]', data.imageUrl);
      await page.fill('[name="address"]', data.address);
      await page.fill('[name="phone"]', data.phone);

      const [request] = await Promise.all([onRequest(), page.click('[type="submit"]')]);

      const postData = JSON.parse(request.postData());

      expect(postData.title).to.equal(data.title);
      expect(postData.description).to.equal(data.description);
      expect(postData.imageUrl).to.equal(data.imageUrl);
      expect(postData.address).to.equal(data.address);
      expect(postData.phone).to.equal(data.phone);
    });

    it('Check details information [ 5 Points ]', async () => {
      const data = mockData.catalog[1];
      const user = mockData.users[0];
      const { get } = await handle(endpoints.details(data._id));
      get(data);

      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.waitForTimeout(interval);

      const title = await page.$$eval('#details-page .post-title', (t) =>
        t.map((s) => s.textContent)
      );
      const image = await page.$$eval('#details-page .post-image', (t) => t.map((s) => s.src));
      const description = await page.$$eval('#details-page .post-description', (t) =>
        t.map((s) => s.textContent)
      );
      const address = await page.$$eval('#details-page .post-address', (t) =>
        t.map((s) => s.textContent)
      );
      const phone = await page.$$eval('#details-page .post-number', (t) =>
        t.map((s) => s.textContent)
      );

      expect(title).to.contains(data.title);
      expect(image[0]).to.contains(data.imageUrl);
      expect(description).to.contains(`Description: ${data.description}`);
      expect(address).to.contains(`Address: ${data.address}`);
      expect(phone[0]).to.contains(`Phone number: ${data.phone}`);
    });

    it('Non-author does NOT see delete and edit buttons [ 2.5 Points ]', async () => {
      const data = mockData.catalog[2];
      const user = mockData.users[0];
      const { get } = await handle(endpoints.details(data._id));
      get(data);

      await page.waitForTimeout(interval);
      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForSelector('.all-posts');
      await page.waitForTimeout(interval);

      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      expect(await page.isVisible('text="Delete"')).to.be.false;
      expect(await page.isVisible('text="Edit"')).to.be.false;
    });

    it('Author see delete and edit buttons [ 2.5 Points ]', async () => {
      const data = mockData.catalog[1];
      const user = mockData.users[0];
      const { get } = await handle(endpoints.details(data._id));
      get(data);

      await page.waitForTimeout(interval);
      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.waitForTimeout(interval);

      expect(await page.isVisible('text="Delete"')).to.be.true;
      expect(await page.isVisible('text="Edit"')).to.be.true;
    });

    it('Edit should populate form with correct data [ 5 Points ]', async () => {
      const data = mockData.catalog[1];
      const user = mockData.users[0];
      const { get } = await handle(endpoints.details(data._id));
      get(data);

      await page.waitForTimeout(interval);
      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.click('text=Edit');
      await page.waitForTimeout(interval);

      await page.waitForSelector('form');

      const inputs = await page.$$eval('#edit input', (t) => t.map((i) => i.value));
      expect(inputs[0]).to.contains(data.title);
      expect(inputs[1]).to.contains(data.description);
      expect(inputs[2]).to.contains(data.imageUrl);
      expect(inputs[3]).to.contains(data.address);
      expect(inputs[4]).to.contains(data.phone);
    });

    it('Edit does NOT work with empty fields [ 5 Points ]', async () => {
      const data = mockData.catalog[0];
      const user = mockData.users[0];
      const { get, put } = await handle(endpoints.delete(data._id));
      get(data);
      const { isHandled } = put();

      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);
      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.click('text=Edit');
      await page.waitForTimeout(interval);

      await page.waitForSelector('form');

      await page.fill('[name="title"]', '');
      await page.fill('[name="description"]', '');
      await page.fill('[name="imageUrl"]', '');
      await page.fill('[name="address"]', '');
      await page.fill('[name="phone"]', '');

      await page.click('[type="submit"]');
      await page.waitForTimeout(interval);

      expect(isHandled()).to.be.false;
    });

    it('Edit makes correct API call for logged in user [ 5 Points ]', async () => {
      const data = mockData.catalog[0];
      const user = mockData.users[0];

      const { get, put } = await handle(endpoints.delete(data._id));
      get(data);
      const { onRequest } = put();

      await page.waitForTimeout(interval);
      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);
      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.click('text=Edit');
      await page.waitForTimeout(interval);

      await page.waitForSelector('form');

      await page.fill('[name="title"]', data.title + 'edit');
      await page.fill('[name="description"]', data.description + 'edit');
      await page.fill('[name="address"]', data.address + 'edit');

      const [request] = await Promise.all([onRequest(), page.click('[type="submit"]')]);

      const postData = JSON.parse(request.postData());

      expect(postData.title).to.contains(data.title + 'edit');
      expect(postData.description).to.contains(data.description + 'edit');
      expect(postData.address).to.contains(data.address + 'edit');
    });

    it('Delete makes correct API call for logged in user [ 10 Points ]', async () => {
      const data = mockData.catalog[0];
      const user = mockData.users[0];

      const { get, del } = await handle(endpoints.delete(data._id));
      get(data);
      const { onResponse, isHandled } = del({ _id: data._id });

      await page.waitForTimeout(interval);
      await page.click('text=Dashboard');
      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.click('text=Delete');

      page.on('dialog', (dialog) => dialog.accept());
      await Promise.all([onResponse(), page.click('text="Delete"')]);

      expect(isHandled()).to.be.true;
    });
  });

  describe('User Profile Page [ 10 Points ]', () => {
    // Login user
    beforeEach(async () => {
      const data = mockData.users[0];
      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', data.email);
      await page.fill('[name="password"]', data.password);
      await page.click('[type="submit"]');
      await page.waitForTimeout(interval);
    });

    it('Check profile page for with 0 posts [ 2.5 Points ]', async () => {
      const { get } = await handle(endpoints.profile(mockData.users[0]._id));
      get([]);

      await page.click('text=My Posts');
      await page.waitForTimeout(interval);

      const visible = await page.isVisible('text=You have no posts yet!');
      expect(visible).to.be.true;
    });

    it('Check profile page with 2 posts [ 5 Points ]', async () => {
      const { get } = await handle(endpoints.profile(mockData.users[0]._id));
      get(mockData.catalog.slice(0, 2));
      const data = mockData.catalog.slice(0, 2);

      await page.click('text=My Posts');
      await page.waitForTimeout(interval);

      const titles = await page.$$eval('.my-posts .post', (t) => t.map((s) => s.textContent));

      expect(titles.length).to.equal(2);
      expect(titles[0]).to.contains(`${data[0].title}`);
      expect(titles[1]).to.contains(`${data[1].title}`);
    });

    it('Check profile page information [ 2.5 Points ]', async () => {
      const { get } = await handle(endpoints.profile(mockData.users[0]._id));
      get(mockData.catalog.slice(0, 1));
      const data = mockData.catalog.slice(0, 1);

      await page.click('text=My Posts');
      await page.waitForTimeout(interval);

      const titles = await page.$$eval('.post .post-title', (t) => t.map((s) => s.textContent));
      const images = await page.$$eval('.post .post-image', (t) => t.map((s) => s.src));

      expect(titles[0]).to.contains(data[0].title);
      expect(images[0]).to.contains(data[0].imageUrl);
    });
  });

  describe('BONUS : Donate functionality  [ 15 Points ]', () => {
    it('Donate button is NOT visible for guest users [ 2.5 Points ]', async () => {
      await page.goto(host);
      await page.waitForTimeout(interval);

      const data = mockData.catalog[2];
      const { get } = await handle(endpoints.details(data._id));
      get(data);

      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.waitForTimeout(interval);

      expect(await page.isVisible('.donate-btn')).to.be.false;
    });

    it('Donate button is visible for the non-creator user [ 2.5 Points ]', async () => {
      // Login user
      const user = mockData.users[0];
      const data = mockData.catalog[2];

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', user.email);
      await page.fill('[name="password"]', user.password);
      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);
      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);
      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.waitForTimeout(interval);

      expect(await page.isVisible('.donate-btn')).to.be.true;
    });

    it('Donate button is NOT visible for the creator [ 2.5 Points ]', async () => {
      // Login user
      const user = mockData.users[0];
      const data = mockData.catalog[0];

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', user.email);
      await page.fill('[name="password"]', user.password);
      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      own(0);
      total(5);

      await page.waitForTimeout(interval);
      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);

      await page.waitForTimeout(interval);

      expect(await page.isVisible('.donate-btn btn')).to.be.false;
    });

    it('Donate button should be hidden(not visible) after a click on it [ 2.5 Points ]', async () => {
      // Login user
      const user = mockData.users[0];
      const data = mockData.catalog[2];

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', user.email);
      await page.fill('[name="password"]', user.password);
      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      const { post } = await handle(endpoints.donate, { post: mockData.donations[2] });
      const { onRequest } = post({ postId: mockData.donations[2].postId });
      own(0);
      total(5);

      await page.waitForTimeout(interval);

      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);
      await page.waitForTimeout(interval);
      expect(await page.isVisible('.donate-btn')).to.be.true;
      await page.waitForTimeout(interval);

      own(1);
      total(6);

      const [request] = await Promise.all([onRequest(), page.click('.donate-btn')]);

      await page.waitForTimeout(interval);

      expect(await page.isVisible('.donate-btn')).to.be.false;
    });

    it('Donate button should increase total donation by 1 after a click on it [ 5 Points ]', async () => {
      // Login user
      const user = mockData.users[0];
      const data = mockData.catalog[2];

      await page.goto(host);
      await page.waitForTimeout(interval);
      await page.click('text=Login');
      await page.waitForTimeout(interval);
      await page.waitForSelector('form');
      await page.fill('[name="email"]', user.email);
      await page.fill('[name="password"]', user.password);
      await page.click('[type="submit"]');

      await page.waitForTimeout(interval);

      const { get: own } = await handle(endpoints.own(data._id, user._id));
      const { get: total } = await handle(endpoints.total(data._id));
      await page.waitForTimeout(interval);
      const { post } = await handle(endpoints.donate, { post: mockData.donations[2] });
      const { onRequest } = post({ postId: mockData.donations[2].postId });
      own(0);
      total(5);

      await page.waitForTimeout(interval);
      await page.waitForSelector('.all-posts');
      await page.click(`.all-posts .post:has-text("${data.title}") >> .details-btn`);
      await page.waitForTimeout(interval);

      let likes = await page.$$eval('.donate-Item', (t) => t.map((s) => s.textContent));
      await page.waitForTimeout(interval);
      expect(likes[0]).to.contains('Donate Materials: 5');
      own(1);
      total(6);
      await page.waitForTimeout(interval);

      const [request] = await Promise.all([onRequest(), page.click('.donate-btn')]);
      await page.waitForTimeout(interval);
      likes = await page.$$eval('.donate-Item', (t) => t.map((s) => s.textContent));
      expect(likes[0]).to.contains('Donate Materials: 6');
    });
  });
});

async function setupContext(context) {
  // Authentication
  await handleContext(context, endpoints.login, { post: mockData.users[0] });
  await handleContext(context, endpoints.register, { post: mockData.users[0] });
  await handleContext(context, endpoints.logout, {
    get: (h) => h('', { json: false, status: 204 }),
  });

  // Catalog and Details
  await handleContext(context, endpoints.catalog, { get: mockData.catalog });
  await handleContext(context, endpoints.details('1001'), { get: mockData.catalog[0] });
  await handleContext(context, endpoints.details('1002'), { get: mockData.catalog[1] });
  await handleContext(context, endpoints.details('1003'), { get: mockData.catalog[2] });

  await handleContext(endpoints.profile('0001'), { get: mockData.catalog.slice(0, 2) }, context);

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
