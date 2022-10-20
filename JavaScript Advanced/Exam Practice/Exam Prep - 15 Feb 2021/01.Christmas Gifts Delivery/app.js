function solution() {
    let [listSection, sentSection, discardSection] = Array.from(document.querySelectorAll('section ul'));
    let inputElement = document.querySelector('input');
    let addButton = document.querySelector('button');
    let allGifts = [];

    addButton.addEventListener('click', () => {

        let giftName = inputElement.value;

        let listItem = createTag('li', giftName, 'gift');

        let sendButton = createTag('button', 'Send', null, 'sendButton');
        sendButton.addEventListener('click', onSend);

        let discardButton = createTag('button', 'Discard', null, 'discardButton');
        discardButton.addEventListener('click', onDiscard);

        listItem.appendChild(sendButton);
        listItem.appendChild(discardButton);

        allGifts.push(listItem);
        allGifts.sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => listSection.appendChild(li));

        inputElement.value = '';

        function onSend() {
            listItem.removeChild(sendButton);
            listItem.removeChild(discardButton);
            sentSection.appendChild(listItem);
            allGifts = allGifts.filter(li => li != listItem);
        };
        function onDiscard() {
            listItem.removeChild(sendButton);
            listItem.removeChild(discardButton);
            discardSection.appendChild(listItem);
            allGifts = allGifts.filter(li => li != listItem);
        };
    });

    function createTag(tag, text = null, className = null, id = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        return el;
    }
}