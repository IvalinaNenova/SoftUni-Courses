function solve(face, suit) {
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

solve('2', 'H').toString()
solve('K', 'C').toString()
solve('D', '10').toString()