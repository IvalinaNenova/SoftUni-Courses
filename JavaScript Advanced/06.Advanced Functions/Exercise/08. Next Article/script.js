function getArticleGenerator(articles) {
    let articlesArray = articles;

    let showNext = function displayArticle() {
        let contentElement = document.querySelector('#content');
        let article = document.createElement('article');
        if (articlesArray.length > 0) {
            article.textContent = articlesArray.shift();
            contentElement.appendChild(article);
        }
    }

    return showNext;
}
