function solve(pieArray, startPie, endPie) {
    let startIndex = pieArray.indexOf(startPie);
    let endIndex = pieArray.indexOf(endPie);

    return pieArray.slice(startIndex, endIndex + 1);
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));

console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));