function solve(array, chriteria){

    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let ticketCollection = [];
    for (let ticketData of array) {
        let[destination, price, status] = ticketData.split('|');
        ticketCollection.push(new Ticket(destination, Number(price), status));
    }
    let sorted;
    chriteria != 'price' ? sorted = ticketCollection.sort((a, b) => a[chriteria].localeCompare(b[chriteria]))
    : sorted = ticketCollection.sort((a, b) => a[chriteria] - b[chriteria])
    
    return sorted;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);

solve(['Philadelphia|96.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price'
);