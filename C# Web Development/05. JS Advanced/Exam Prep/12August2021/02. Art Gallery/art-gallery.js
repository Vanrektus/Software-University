class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250,
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }

        let alreadyExists = false;

        for (const currArticle of this.listOfArticles) {
            if (currArticle.articleName === articleName &&
                currArticle.articleModel === articleModel.toLowerCase()) {

                currArticle.quantity += quantity;
                alreadyExists = true;
            }
        }

        if (!alreadyExists) {
            this.listOfArticles.push({
                articleModel: articleModel.toLowerCase(),
                articleName,
                quantity: Number(quantity),
            });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }

        this.guests.push({
            guestName,
            points: this.personalityPoints(personality),
            purchaseArticle: 0,
        });

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        if (!this.listOfArticles.some(x => x.articleName === articleName)) {
            throw new Error("This article is not found.");
        }

        let currFoundArticle = {};
        let sameNameAndModel = false;

        for (const currArticle of this.listOfArticles) {
            if (currArticle.articleName === articleName && currArticle.articleModel === articleModel) {
                currFoundArticle = currArticle;
                sameNameAndModel = true;
            }
        }

        if (!sameNameAndModel) {
            throw new Error("This article is not found.");
        }

        if (currFoundArticle.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        let currGuest = this.guests.find(x => x.guestName === guestName);

        if (!currGuest) {
            return "This guest is not invited.";
        }

        let neededPoints = this.possibleArticles[currFoundArticle.articleModel];

        if (currGuest.points < neededPoints) {
            return `You need to more points to purchase the article.`;
        }

        currGuest.points -= neededPoints;
        currFoundArticle.quantity--;
        currGuest.purchaseArticle++;

        return `${guestName} successfully purchased the article worth ${neededPoints} points.`;
    }

    showGalleryInfo(criteria) {
        let output = '';

        switch (criteria) {
            case 'article':
                output = 'Articles information:';

                for (const currArticle of this.listOfArticles) {
                    output += `\n${currArticle.articleModel} - ${currArticle.articleName} - ${currArticle.quantity}`;
                }

                return output;

            case 'guest':
                output = 'Guests information:';

                for (const currGuest of this.guests) {
                    output += `\n${currGuest.guestName} - ${currGuest.purchaseArticle}`;
                }

                return output;
        }
    }

    personalityPoints(personality) {
        switch (personality) {
            case 'Vip':
                return 500;

            case "Middle":
                return 250;

            default:
                return 50;
        }
    }
}

// 3
// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));
// John successfully purchased the article worth 200 points.
//  Peter successfully purchased the article worth 250 points. 
//  This article is not found.

// 1
// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));
// Successfully added article Mona Liza with a new quantity- 3.
// Successfully added article Ancient vase with a new quantity- 2.
// Successfully added article Mona Liza with a new quantity- 1.

// 2
// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip'));
// console.log(artGallery.inviteGuest('Peter', 'Middle'));
// console.log(artGallery.inviteGuest('Ivan', 'Bosss'));
// console.log(artGallery.inviteGuest('John', 'Middle'));
// You have successfully invited John!
// You have successfully invited Peter!
// John has already been invited.

// 4
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