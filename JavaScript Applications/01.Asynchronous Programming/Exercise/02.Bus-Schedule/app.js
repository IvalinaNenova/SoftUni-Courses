function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule';
    const departButton = document.querySelector('#depart');
    const arriveButton = document.querySelector('#arrive');
    const infoDiv = document.querySelector('.info');

    let stopId = 'depot';
    let stopName = '';

    async function depart() {
        let info = await fetch(`${baseUrl}/${stopId}`);
        let result = await info.json();
        stopName = result.name;

        infoDiv.textContent = `Next stop ${stopName}`;
        stopId = result.next;

        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    function arrive() {
        infoDiv.textContent = `Arriving at ${stopName}`;

        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();