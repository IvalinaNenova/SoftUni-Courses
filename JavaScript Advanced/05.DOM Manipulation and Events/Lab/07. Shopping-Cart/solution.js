function solve() {
   let addButtonsElement = document.querySelectorAll('button[class="add-product"]');
   let textAreaElement = document.getElementsByTagName('textarea')[0];
   let checkOutButtonElement = document.getElementsByClassName('checkout')[0];

   let totalPriceToPay = 0;
   let productsBought = [];

   let addProductToCart = function (e) {
      let productName = e.currentTarget.parentNode.parentNode.getElementsByClassName('product-title')[0].textContent;
      let productPrice = e.currentTarget.parentNode.parentNode.getElementsByClassName('product-line-price')[0].textContent;

      totalPriceToPay += Number(productPrice);

      if (!productsBought.includes(productName)) {
         productsBought.push(productName);
      }

      textAreaElement.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
   }

   let checkOutHandler = function (e) {
      textAreaElement.textContent += `You bought ${productsBought.join(', ')} for ${totalPriceToPay.toFixed(2)}.`

      for (let button of addButtonsElement) {
         button.disabled = true;
      }
      e.target.disabled = true;
   }

   for (const button of addButtonsElement) {
      button.addEventListener('click', addProductToCart);
   }

   checkOutButtonElement.addEventListener('click', checkOutHandler);
}