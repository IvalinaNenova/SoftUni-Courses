function attachEvents() {
    //Get DOM elements
    let postsSelect = document.querySelector('select#posts');
    let btnLoadPosts = document.getElementById('btnLoadPosts');
    let btnViewPost = document.getElementById('btnViewPost');
    let postTitle = document.getElementById('post-title');
    let postContent = document.getElementById('post-body');


    //Add event listeners
    btnLoadPosts.addEventListener('click', handleLoadPosts);
    btnViewPost.addEventListener('click', handleViewPost);
    let commonData;

    function handleLoadPosts() {
        //Get posts
        fetch('http://localhost:3030/jsonstore/blog/posts')
        .then(res => res.json())
        .then(data => addPosts(data));

        function addPosts(data) {
            commonData = data;

            postsSelect.innerHTML = '';
            
            for (let [id, postInfo] of Object.entries(data)) {
                //Create option
                let option = document.createElement('option');
                option.value = id;
                option.textContent = postInfo.title;
                option.dataset.body = postInfo.body;
                postsSelect.appendChild(option);
            }
        }
    }

    function handleViewPost() {
        //Get post id
        let selectedPostId = document.getElementById('posts').value;

        postTitle.textContent = commonData[selectedPostId].title;
        postContent.textContent = commonData[selectedPostId].body;


        //Fetch comments
        fetch('http://localhost:3030/jsonstore/blog/comments')
        .then(res => res.json())
        .then(data => handleComments(data));

        //Handle comments
        function handleComments(data) {
            let commentsUl = document.getElementById('post-comments');
            commentsUl.innerHTML = '';
            
            for (let [commentInfo] of Object.entries(data)) {
                if (commentInfo.postId == selectedPostId) {
                    //Create comment li
                    let li = document.createElement('li');
                    li.id = commentInfo.id
                    li.textContent = commentInfo.text;
                    commentsUl.appendChild(li);
                }
            }
        }
    }
}

attachEvents();