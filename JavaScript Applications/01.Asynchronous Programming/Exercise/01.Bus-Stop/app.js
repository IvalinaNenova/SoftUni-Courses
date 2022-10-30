async function getInfo() {
    let stopId = document.getElementById('stopId').value;
    const stopName = document.getElementById('stopName');
    const listOfStops = document.getElementById('buses');

    try {
        let result = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);

        if (result.ok == false || result.status != 200) {
            throw new Error('Error')
        }

        listOfStops.innerHTML = '';
        let data = await result.json();

        stopName.textContent = data.name;
        for (const bus in data.buses) {
            let row = document.createElement('li');
            row.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
            listOfStops.appendChild(row);
        }
    } catch (error) {
        stopName.textContent = error.message;
        listOfStops.innerHTML = '';
    }
}