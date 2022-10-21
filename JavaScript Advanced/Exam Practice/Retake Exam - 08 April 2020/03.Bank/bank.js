class Bank {
    #bankName;
    constructor(bankName) {
        this.#bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer) {
        //{firstName, lastName, personalId}
        if (this.allCustomers.find(c => c.firstName === customer.firstName && c.lastName === customer.lastName)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }
        this.allCustomers.push(customer);
        return customer;
    }
    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }
        if (!customer.hasOwnProperty('totalMoney')) {
            customer['transactions'] = [];
            customer['totalMoney'] = 0;
        }
        customer.totalMoney += amount;
        customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`)
        return `${customer.totalMoney}$`;
    }
    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }
        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }
        customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
        customer.totalMoney -= amount;
        return `${customer.totalMoney}$`;
    }
    customerInfo(personalId) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }
        let output = [`Bank name: ${this.#bankName}`]
        output.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        output.push(`Customer ID: ${personalId}`);
        output.push(`Total Money: ${customer.totalMoney}$`);
        output.push('Transactions:');

        for (let i = customer.transactions.length; i > 0; i--) {
            output.push(`${i}. ${customer.transactions[i - 1]}`);
        }

        return output.join('\n');
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

