function printDeckOfCards(cards) {
    function createCard(face, suit) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
        let suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        }
        if (!validFaces.includes(face) || suits[suit] == undefined) {
            throw new Error('Error');
        }

        let card = {
            face,
            suit: suits[suit],
            toString() { return this.face + this.suit }
        }
        return card;
    }

    let deck = [];
    for (const card of cards) {
        
        let face = card.substring(0, card.length - 1);
        let suit = card[card.length - 1]

        try {
            let validCard = createCard(face, suit);
            deck.push(validCard.toString());
        } catch (error) {
            console.log(`Invalid card: ${face + suit}`);
            return;
        }
    }

    console.log(deck.join(' '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);


