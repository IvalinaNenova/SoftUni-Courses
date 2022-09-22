function create(words) {
   let divsArray = [];
   let contentElement = document.getElementById('content');

   let displayParagraph = function (e) {
      e.target.firstChild.style.display = 'block';
   }
   words.forEach(el => {
      divElement = document.createElement('div');
      paragraphElement = document.createElement('p');

      paragraphElement.textContent = el;
      paragraphElement.style.display = 'none';

      divElement.appendChild(paragraphElement);
      contentElement.appendChild(divElement);
      
      divElement.addEventListener('click', displayParagraph);
   });
}