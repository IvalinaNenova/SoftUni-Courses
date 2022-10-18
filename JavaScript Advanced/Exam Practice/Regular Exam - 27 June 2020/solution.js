function solve() {
    let form = document.querySelector("#add");
    const adoptionSection = document.querySelector('#adoption ul');
    const adoptedSection = document.querySelector('#adopted ul');

    form.addEventListener("click", (e) => {
        e.preventDefault();

        let inputElements = Array.from(form.elements).slice(0, -1);
        let inputValues = inputElements.map(input => input.value);
        let [name, age, kind, currentOwner] = inputValues;
        age = Number(inputValues[1]);

        if (e.target.textContent != 'Add' || inputValues.includes('') || Number.isNaN(age)) return;

        let row = document.createElement('li');
        row.innerHTML = `<p><strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong></p>
          <span>Owner: ${currentOwner}</span>
        `
        let contactButton = document.createElement('button');
        contactButton.textContent = 'Contact with owner';
        contactButton.addEventListener('click', onContactOwner);
        row.appendChild(contactButton);
        adoptionSection.appendChild(row);
        let p = row.querySelector('p');
        console.log(p.textContent);


        function onContactOwner(e){
            contactButton.textContent = 'Yes! I take it!';
            contactButton.removeEventListener('click', onContactOwner);
            contactButton.addEventListener('click', onTakeIt);

            let divElement = document.createElement('div');
            divElement.innerHTML =`<input placeholder="Enter your names">`
            divElement.appendChild(contactButton);
            row.appendChild(divElement);
        }

        function onTakeIt(e){
            let input = row.querySelector('input').value;
            let divElement = row.querySelector('div');

            if (input == '') return;

            row.removeChild(divElement);
            contactButton.textContent = 'Checked';
            contactButton.removeEventListener('click', onTakeIt);
            contactButton.addEventListener('click', onChecked);
            row.appendChild(contactButton);

            let spanElement = row.querySelector('span');
            spanElement.textContent = `New Owner: ${input}`;

            adoptedSection.appendChild(row);
        }

        function onChecked(e){
            row.remove();
        }

        inputElements.forEach(e => e.value = '');
    });
}
