function calculateMoneyNeeded(fruit, grams, price){
    let total = grams/1000 * price;

    console.log(`I need $${total.toFixed(2)} to buy ${(grams/1000).toFixed(2)} kilograms ${fruit}.`);
}

calculateMoneyNeeded('apple', 1563, 2.35)
