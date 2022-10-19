function solution() {
    let [listSection, sentSection, discardSection] = Array.from(document.querySelectorAll('section ul'));
    console.log(listSection, sentSection, discardSection);
    let inputElement = document.querySelector('input');
    let addButton = document.querySelector('button');
    let listOfGifts = []
    addButton.addEventListener('click', (e)=>{
        let giftName = inputElement.value;
        let listItem = createTag('li', giftName, 'gift');
        let sendButton = createTag('button', 'Send', null, 'sendButton');
        let discardButton = createTag('button', 'Discard', null, 'discardButton');
        listItem.appendChild(sendButton);
        listItem.appendChild(discardButton);
        listSection.appendChild(listItem);
         
        



        inputElement.value = '';
    });

    function createTag(tag, text = null, className = null, id = null, type = null) { 
        let el = document.createElement(tag); 
        if (text) { el.textContent = text; } 
        if (type) { el.type = type; } 
        if (id) { el.id = id; } 
        if (className) { el.className = className; } 
        return el; 
    } 
}