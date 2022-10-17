class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture": 200, "photo": 50, "item": 250 };
        this.listOfArticles = [];
        this.guests = [];
        this.points = {
            Vip: 500,
            Middle: 250,
        }
    }

    addArticle(articleModel, articleName, quantity) {
        articleModel = articleModel.toLowerCase();
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }
        let existingArticle = this.listOfArticles.find(a => a.articleName === articleName);
        if (existingArticle) {
            existingArticle.quantity += quantity;
        } else {
            this.listOfArticles.push({
                articleModel,
                articleName,
                quantity
            });
        }
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }

    inviteGuest(guestName, personality) {
        let existingGuest = this.guests.find(a => a.guestName === guestName);
        let points = this.points[personality] ? this.points[personality] : 50;
        if (existingGuest) {
            throw new Error(`${guestName} has already been invited.`);
        }

        this.guests.push({ guestName, points, purchaseArticle: 0 });
        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        articleModel = articleModel.toLowerCase();
        let existingArticle = this.listOfArticles.find(a => a.articleName === articleName);
        let existingGuest = this.guests.find(a => a.guestName === guestName);

        if (!existingArticle || existingArticle.articleModel !== articleModel) {
            throw new Error('This article is not found.');
        }
        if (existingArticle.quantity == 0) {
            return `The ${articleName} is not available.`;
        }
        if (!existingGuest) {
            return "This guest is not invited.";
        }
        let pointsNeeded = this.possibleArticles[articleModel];
        if (existingGuest.points < pointsNeeded) {
            return 'You need to more points to purchase the article.';
        }
        existingGuest.points -= pointsNeeded;
        existingGuest.purchaseArticle += 1;
        existingArticle.quantity -= 1;
        return `${guestName} successfully purchased the article worth ${pointsNeeded} points.`;
    }
    
    showGalleryInfo(criteria) {
        let output = [];
        if (criteria == 'article') {
            output.push('Articles information:');
            this.listOfArticles.forEach(a => output.push(`${a.articleModel} - ${a.articleName} - ${a.quantity}`));
        } else if (criteria == 'guest') {
            output.push('Guests information:');
            this.guests.forEach(g => output.push(`${g.guestName} - ${g.purchaseArticle}`));
        }
        return output.join('\n');
    }
}

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip'));
// console.log(artGallery.inviteGuest('Peter', 'Middle'));
// console.log(artGallery.inviteGuest('John', 'Middle'));

// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John')); //This article is not found.

const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));
// Articles information:
// picture - Mona Liza - 3
// item - Ancient vase - 1
// Guests information:
// John - 1
// Peter - 1

