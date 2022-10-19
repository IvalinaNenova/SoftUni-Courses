class Story {
    #comments = [];
    #likes = [];
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
    }

    get likes() {
        if (this.#likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this.#likes.length === 1) {
            return `${this.#likes[0]} likes this story!`;
        }

        return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`;
    }
    like(username) {
        if (this.#likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }
        if (username == this.creator) {
            throw new Error("You can't like your own story!");
        }
        this.#likes.push(username);
        return `${username} liked ${this.title}!`;
    }
    dislike(username) {
        if (!this.#likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }
        this.#likes = this.#likes.filter(u => u != username);
        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id) {
        let existingComment = this.#comments.find(c => c.id == id);
        if (id === undefined || !existingComment) {
            id = this.#comments.length == 0 ? 1 : this.#comments.length + 1;
            this.#comments.push({
                id,
                username,
                content,
                replies: []
            });
            return `${username} commented on ${this.title}`;
        }
        let commentId = existingComment.id;
        let replies = existingComment.replies;

        let replyId = replies.length == 0
            ? commentId + 0.1
            : (replies[replies.length - 1].replyId * 10 + 0.1 * 10) / 10;

        existingComment.replies.push({
            replyId,
            username,
            content
        });

        return 'You replied successfully'
    }
    toString(sortingType) {

        let output = [`Title: ${this.title}`, `Creator: ${this.creator}`, `Likes: ${this.#likes.length}`, `Comments:`];
        if (this.#comments.length == 0) {
            return output.join('\n');
        }
        if (sortingType === 'desc') {
            this.#comments.forEach(c => c.replies.sort((a, b) => b.replyId - a.replyId));
            this.#comments.sort((a, b) => b.id - a.id);
        } else if (sortingType === 'asc') {
            this.#comments.forEach(c => c.replies.sort((a, b) => a.replyId - b.replyId));
            this.#comments.sort((a, b) => a.id - b.id);
        } else if (sortingType == 'username') {
            this.#comments.forEach(c => c.replies.sort((a, b) => a.username.localeCompare(b.username)));
            this.#comments.sort((a, b) => a.username.localeCompare(b.username));
        }

        this.#comments.forEach(c => {
            output.push(`-- ${c.id}. ${c.username}: ${c.content}`)
            c.replies.forEach(r => output.push(`--- ${r.replyId}. ${r.username}: ${r.content}`));
        });
        return output.join('\n');
    }
}

let art = new Story("My Story", "Anny");
console.log(art.like("John"));                    //"John liked My Story!"
console.log(art.likes);                         //"John likes this story!"
//art.dislike("Sally");                           //"You can't dislike this story!"
console.log(art.like("Ivan"));                  //"Ivan liked My Story!"
console.log(art.like("Steven"));                 //"Steven liked My Story!"
console.log(art.likes);                          //John and 2 others like this story!"
console.log(art.comment("Anny", "Some Content"));      //"Anny commented on My Story"
console.log(art.comment("Ammy", "New Content", 1));       //"You replied successfully")
console.log(art.comment("Zane", "Reply", 2));      //"Zane commented on My Story"
console.log(art.comment("Jessy", "Nice :)"));       //"Jessy commented on My Story"
console.log(art.comment("SAmmy", "Reply@", 2));       //"You replied successfully"
console.log(art.toString('asc'));
//`Title: My Story
// Creator: Anny
// Likes: 3
// Comments:
// -- 1. Anny: Some Content
// --- 1.1. Ammy: New Content
// -- 2. Zane: Reply
// --- 2.1. SAmmy: Reply@
// -- 3. Jessy: Nice :)`);


// let art = new Story("My Story", "Anny");
// art.like("John");
// console.log(art.likes);
// art.dislike("John");
// console.log(art.likes);
// art.comment("Sammy", "Some Content");
// console.log(art.comment("Ammy", "New Content"));
// art.comment("Zane", "Reply", 1);
// art.comment("Jessy", "Nice :)");
// console.log(art.comment("SAmmy", "Reply@", 1));
// console.log()
// console.log(art.toString('username'));
// console.log()
// art.like("Zane");
// console.log(art.toString('desc'));
