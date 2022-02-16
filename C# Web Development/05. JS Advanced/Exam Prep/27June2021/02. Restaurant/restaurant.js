class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = Number(budgetMoney);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const currProduct of products) {
            let [name, quantity, totalPrice] = currProduct.split(' ');

            if (Number(totalPrice) <= this.budgetMoney) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += Number(quantity);
                this.budgetMoney -= Number(totalPrice);
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(mealName, neededProducts, price) {
        let meal = {
            mealName: mealName,
            mealProducts: [],
            mealPrice: Number(price),
        };

        for (const currProduct of neededProducts) {
            let [name, quantity] = currProduct.split(' ');

            meal.mealProducts.push({
                productName: name,
                productQuantity: Number(quantity),
            });
        }

        if (!this.menu[mealName]) {
            this.menu[mealName] = meal;

            let mealsCount = Object.keys(this.menu).length;

            return mealsCount == 1 ?
                `Great idea! Now with the ${mealName} we have 1 meal in the menu, other ideas?` :
                `Great idea! Now with the ${mealName} we have ${mealsCount} meals in the menu, other ideas?`;
        } else {
            return `The ${mealName} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length === 0) {
            return `Our menu is not ready yet, please come later...`;
        }

        let output = '';

        for (const currMeal of Object.values(this.menu)) {
            output += `${currMeal.mealName} - $ ${currMeal.mealPrice}\n`;
        }

        return output.trim();
    }

    makeTheOrder(mealName) {
        let meal = this.menu[mealName];

        if (!meal) {
            return `There is not ${mealName} yet in our menu, do you want to order something else?`;
        }

        let price = meal.mealPrice;
        let neededProducts = meal.mealProducts;

        for (const currProduct of neededProducts) {
            let name = currProduct.productName;
            let quantity = currProduct.productQuantity;

            if (!this.stockProducts[name] || this.stockProducts[name] < quantity) {
                return `For the time being, we cannot complete your order (${mealName}), we are very sorry...`;
            }

            this.stockProducts[name] -= quantity;
            this.budgetMoney += price;
        }

        return `Your order (${mealName}) will be completed in the next 30 minutes and will cost you ${meal.mealPrice}.`;
    }
}

// 1
let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));

// Your order (frozenYogurt) will be completed in the next 30 minutes and will cost you 9.99.

// 2
// let kitchen = new Restaurant(1000);
// console.log(kitchen.showTheMenu());
// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
// console.log(kitchen.showTheMenu());

// Great idea! Now with the frozenYogurt we have 1 meal in the menu, other ideas?
// Great idea! Now with the Pizza we have 2 meals in the menu, other ideas?

// 3
// let kitchen = new Restaurant(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// Successfully loaded 10 Banana
// Successfully loaded 20 Banana
// Successfully loaded 50 Strawberries
// Successfully loaded 10 Yogurt
// There was not enough money to load 500 Yogurt
// Successfully loaded 5 Honey


// 4
// let kitchen = new Restaurant(1000);
// console.log(kitchen.showTheMenu());

// frozenYogurt - $ 9.99
// Pizza - $ 15.55