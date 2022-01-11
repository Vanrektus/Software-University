function solve(playersInputArray) {
    let playingBoard = [
        ["false", "false", "false"],
        ["false", "false", "false"],
        ["false", "false", "false"],
    ];
    debugger;

    let isPlayerX = true;

    for (let i = 0; i < playersInputArray.length; i++) {
        let currentPlayerMove = playersInputArray[i]
            .split(" ")
            .map((x) => Number(x));
        let row = currentPlayerMove[0];
        let col = currentPlayerMove[1];

        if (playingBoard[row][col] !== "false") {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        playingBoard[row][col] = isPlayerX ? "X" : "O";
        isPlayerX = !isPlayerX;
        let gameEnded = hasGameEnded(playingBoard);

        if (gameEnded) {
            break;
        }
    }

    for (let row = 0; row < playingBoard.length; row++) {
        console.log(playingBoard[row].join("\t"));
    }

    function hasGameEnded(playingBoard) {
        for (let row = 0; row < playingBoard.length; row++) {
            let isSameX = playingBoard[row].every((x) => x === "X");
            let isSameO = playingBoard[row].every((x) => x === "O");

            if (isSameX || isSameO) {
                console.log(`Player ${isSameX ? "X" : "O"} wins!`);
                return true;
            }
        }

        for (let col = 0; col < playingBoard.length; col++) {
            if (
                playingBoard[0][col] === playingBoard[1][col] &&
                playingBoard[1][col] === playingBoard[2][col] &&
                playingBoard[0][col] !== "false"
            ) {
                console.log(`Player ${playingBoard[col][0]} wins!`);
                return true;
            }
        }

        if (
            playingBoard[0][0] === playingBoard[1][1] &&
            playingBoard[1][1] === playingBoard[2][2] &&
            playingBoard[0][0] !== "false"
        ) {
            console.log(`Player ${playingBoard[0][0]} wins!`);
            return true;
        }

        if (
            playingBoard[2][0] === playingBoard[1][1] &&
            playingBoard[1][1] === playingBoard[0][2] &&
            playingBoard[2][0] !== "false"
        ) {
            console.log(`Player ${playingBoard[2][0]} wins!`);
            return true;
        }

        if (
            playingBoard[0].every((x) => x !== "false") &&
            playingBoard[1].every((x) => x !== "false") &&
            playingBoard[2].every((x) => x !== "false")
        ) {
            console.log("The game ended! Nobody wins :(");
            return true;
        }

        return false;
    }
}

solve(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);
solve(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);
solve(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]);
