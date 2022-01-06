function solve(input) {
    
    let formattedWords = [];
    let words = input.split(/\W+/g);

    for (const currentWord of words) {
        if (currentWord !== '') {
            formattedWords.push(currentWord.toUpperCase());
        }
    }

    console.log(formattedWords.join(', '));
}

solve('Hi, how are you?');
solve('hello');