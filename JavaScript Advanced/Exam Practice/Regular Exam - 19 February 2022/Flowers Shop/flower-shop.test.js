const flowerShop = require('./flowerShop.js');
const { expect, assert } = require('chai');

describe('Tests for flowerShop', () => {
    describe('Test functionality of .calcPriceOfFlowers(flower, price, quantity) function', () => {
        it('should throw error if flower is not string', () => {
            expect(() => flowerShop.calcPriceOfFlowers(50, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers([50], 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers({}, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(false, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(undefined, 50, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(null, 50, 50)).to.throw(Error, 'Invalid input!');
        });
        it('should throw error if price is not number', () => {
            expect(() => flowerShop.calcPriceOfFlowers('tulip', '50', 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', [], 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', {}, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 5.5, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', true, 50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', undefined, 50)).to.throw(Error, 'Invalid input!');
        });
        it('should throw error if quantity is not number', () => {
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50, '50')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50, [50])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50, {})).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50, true)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50, 5.5)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('tulip', 50)).to.throw(Error, 'Invalid input!');
        });
        it('should work properly with valid data', () => {
            expect(flowerShop.calcPriceOfFlowers('tulip', 5, 20)).to.equal('You need $100.00 to buy tulip!');
            expect(flowerShop.calcPriceOfFlowers('tulip', 10, 15.0)).to.equal('You need $150.00 to buy tulip!');
        })
    });
    describe('Test functionality of .checkFlowersAvailable(flower, gardenArr) function', () => {
        let garden = ["Rose", "Lily", "Orchid"];
        it('should return correct message if flower is available', () => {
            expect(flowerShop.checkFlowersAvailable('Lily', garden)).to.equal('The Lily are available!');
            expect(flowerShop.checkFlowersAvailable('Orchid', garden)).to.equal('The Orchid are available!');
        });
        it('should return correct message if flower is NOT available', () => {
            expect(flowerShop.checkFlowersAvailable('Tulip', garden)).to.equal('The Tulip are sold! You need to purchase more!');

        });
    })
    describe('Test functionality of .sellFlowers(gardenArr, space) function', () => {
        let garden = ["Rose", "Lily", "Orchid"];
        it('should throw error if gardenArr is not Array', () => {
            expect(() => flowerShop.sellFlowers('tulip', 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(5, 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(true, 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers({}, 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(undefined, 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(null, 2)).to.throw(Error, 'Invalid input!');
        });
        it('should throw error if space is not integer', () => {
            expect(() => flowerShop.sellFlowers(garden, '2')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, 2.5)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, true)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, [2])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, {})).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden)).to.throw(Error, 'Invalid input!');
         });
        it('should throw error if space is not in range of gardenArr', () => { 
            expect(() => flowerShop.sellFlowers(garden, 3)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, -1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(garden, 5)).to.throw(Error, 'Invalid input!');
        });
        it('should work properly with valid data', () => {
            expect(flowerShop.sellFlowers(garden, 1)).to.equal('Rose / Orchid');
            expect(flowerShop.sellFlowers(garden, 0)).to.equal('Lily / Orchid');
        });
    })
})