function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';
    const selectMenu = document.querySelector('#posts');
    const titleElement = document.querySelector('#post-title');
    const pElement = document.querySelector('#post-body');
    const commentsUl = document.querySelector('#post-comments');

    const loadButton = document.querySelector('#btnLoadPosts');
    loadButton.addEventListener('click', onLoad);
    const viewButton = document.querySelector('#btnViewPost');
    viewButton.addEventListener('click', onView);

    async function onLoad() {
        let result = await fetch(postsUrl);
        let data = Object.values(await result.json());
        selectMenu.innerHTML = '';
        data.forEach(post => {
            let option = document.createElement('option');
            option.value = post.id;
            option.textContent = post.title;

            selectMenu.appendChild(option);
        })

        //onView();
    }

    async function onView() {
        commentsUl.innerHTML = '';
        let selectedId = selectMenu.value;
        let postResult = await fetch(`${postsUrl}/${selectedId}`);
        let postData = await postResult.json();

        titleElement.textContent = postData.title;
        pElement.textContent = postData.body;

        let commentsResult = await fetch(commentsUrl);
        let commentsData = Object.values(await commentsResult.json());

        commentsData.forEach(comment => {
            if (comment.postId === selectedId) {
                let listElement = document.createElement('li');
                listElement.id = comment.id;
                listElement.textContent = comment.text;
                commentsUl.appendChild(listElement);
            }
        })
    }
}

attachEvents();