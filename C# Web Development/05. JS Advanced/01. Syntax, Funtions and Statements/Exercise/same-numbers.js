function solve(number){
    let numberString = String(number);
    let isSame = true;
    let totalSum = numberString.length > 0 ? Number(numberString[0]) : 0;
debugger;
    for(let i = 0; i < numberString.length - 1; i++){
        const element = Number(numberString[i]);
        const nextElement = Number(numberString[i + 1]);

        if (element !== nextElement) {
            isSame = false;
        }

        totalSum += nextElement;
    }

    console.log(isSame);
    console.log(totalSum);
}

solve(2222222);
solve(1234);
solve(232);