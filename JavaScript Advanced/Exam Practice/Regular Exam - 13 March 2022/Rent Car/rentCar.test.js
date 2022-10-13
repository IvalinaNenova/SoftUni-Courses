let rentCar = require('./rentCar');
let { expect, assert } = require('chai');

describe('Test rentCar', () => {
    describe('test method searchCar(shop, model)', () => {
        let shop = ["Volkswagen", "BMW", "Audi", "Audi", "Audi"];

        it('should throw error if shop is not array', () => {
            expect(() => rentCar.searchCar('string', 'model')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar(55, 'model')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar({}, 'model')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar(undefined, 'model')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar(null, 'model')).to.throw(Error, 'Invalid input!');
        })

        it('should throw error if model is not string', () => {
            expect(() => rentCar.searchCar([], [])).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar([], {})).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar([], 555)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar([], undefined)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.searchCar([])).to.throw(Error, 'Invalid input!');
        })

        it('should return correct message if matching models', () => {
            expect(rentCar.searchCar(shop, 'Audi')).to.be.equal('There is 3 car of model Audi in the catalog!')
        });
        it('should return correct message if no matches', () => {
            expect(() => rentCar.searchCar(shop, 'Toyota')).to.throw(Error, 'There are no such models in the catalog!');
        });
    })

    describe('Test method .calculatePriceOfCar(model, days)', () => {
        it('should throw error if model is not string', () => {
            expect(() => rentCar.calculatePriceOfCar([], 5)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar(55, 5)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar({}, 5)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar(undefined, 5)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar(null, 5)).to.throw(Error, 'Invalid input!');
        });

        it('should throw error if days is not number', () => {
            expect(() => rentCar.calculatePriceOfCar('string', '5')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar('string', [])).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar('string', {})).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar('string', null)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.calculatePriceOfCar('string')).to.throw(Error, 'Invalid input!');
        });

        it('should throw error if model is not in catalogues', () => {
            expect(() => rentCar.calculatePriceOfCar('Lada', 5)).to.throw(Error, 'No such model in the catalog!');
        });

        it('shoud return correct message if car in catalogue', () => {
            expect(rentCar.calculatePriceOfCar('Audi', 5)).to.equal('You choose Audi and it will cost $180!')
            expect(rentCar.calculatePriceOfCar('Volkswagen', 6)).to.equal('You choose Volkswagen and it will cost $120!')
            expect(rentCar.calculatePriceOfCar('Toyota', 5)).to.equal('You choose Toyota and it will cost $200!')
            expect(rentCar.calculatePriceOfCar('BMW', 8)).to.equal('You choose BMW and it will cost $360!')
            expect(rentCar.calculatePriceOfCar('Mercedes', 12)).to.equal('You choose Mercedes and it will cost $600!')
        })
    })

    describe('Test method .checkBudget(costPerDay, days, budget)', () => {
        it('should throw error if costPerDay is not number', () => {
            expect(() => rentCar.checkBudget({}, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget([], 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget('50', 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(undefined, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(null, 50, 50)).to.throw(Error, 'Invalid input!');
        });

        it('should throw error if days is not number', () => {
            expect(() => rentCar.checkBudget(20, {}, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(20, []), 50).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(20, '50', 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(20, undefined, 50)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(20, null, 50)).to.throw(Error, 'Invalid input!');
        });

        it('should throw error if budget is not number', () => {
            expect(() => rentCar.checkBudget(50, 50, {})).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(50, 50, [])).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(50, 50, 'string')).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(50, 50, undefined)).to.throw(Error, 'Invalid input!');
            expect(() => rentCar.checkBudget(50, 50)).to.throw(Error, 'Invalid input!');
        });

        it('should return correct message if money is enough', () => {
            expect(rentCar.checkBudget(40, 5, 200)).to.equal('You rent a car!')
            expect(rentCar.checkBudget(40, 5, 2000)).to.equal('You rent a car!')
        })

        it('should return correct message if money is NOT enough', () => {
            expect(rentCar.checkBudget(40, 5, 199)).to.equal('You need a bigger budget!')
            expect(rentCar.checkBudget(40, 6, 20)).to.equal('You need a bigger budget!')
        })
    })
});