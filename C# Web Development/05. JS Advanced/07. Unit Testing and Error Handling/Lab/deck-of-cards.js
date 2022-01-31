function print(cards) {
    let resultCards = [];

    try {
        cards.forEach(currCard => {
            const face = currCard.slice(0, currCard.length - 1);
            const suit = currCard.slice(currCard.length - 1);

            resultCards.push(solve(face, suit).toString());
        })

        console.log(resultCards.join(' '));
    } catch (error) {
        console.log(error.message);
    }

    function solve(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuitsObj = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };

        if (!validFaces.includes(face) || !Object.keys(validSuitsObj).includes(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
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
}

print(['AS', '10D', 'KH', '2C']);
print(['5S', '3D', 'QD', '1C']);