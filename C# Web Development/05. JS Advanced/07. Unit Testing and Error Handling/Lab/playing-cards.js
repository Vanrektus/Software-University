function solve(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validSuitsObj = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663',
    };

    if (!validFaces.includes(face) || !Object.keys(validSuitsObj).includes(suit)) {
        throw new Error();
    }

    let card = {
        face,
        suit: validSuitsObj[suit],
        toString() {
            return `${this.face}${this.suit}`;
        },
    };

    return card;
}

solve('A', 'S');
solve('10', 'H');
solve('q', 'S');
solve('1', 'C');