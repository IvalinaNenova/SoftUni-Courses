const dealership = require('./dealership');
const {expect} = require('chai');

describe('Test dealership', () => {
    describe('Test newCarCost: function (oldCarModel, newCarPrice)', ()=> {
        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        it('should return discounted price if old car is valid', () => {
            expect(dealership.newCarCost('Audi A4 B8', 24000)).to.equal(9000);
            expect(dealership.newCarCost('Audi A6 4K', 24000)).to.equal(4000);
            expect(dealership.newCarCost('Audi A8 D5', 24000)).to.equal(-1000);
            expect(dealership.newCarCost('Audi TT 8J', 24000)).to.equal(10000);
        })
        it('should return full price if old car is NOT valid', () => {
            expect(dealership.newCarCost('Audi A4 C5', 24000)).to.equal(24000);
        })
    });
    describe('Test carEquipment: function (extrasArr, indexArr)', ()=> {
        let extras = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
        it('should return array with correct extras', ()=> {
            expect (dealership.carEquipment(extras, [0, 1])).to.deep.equal(['heated seats', 'sliding roof']);
            expect (dealership.carEquipment(extras, [0, 3])).to.deep.equal(['heated seats', 'navigation']);
        })
    });
    describe('Test euroCategory: function (category)', ()=> {
        it('should return discount message if category is equal to 4', ()=> {
            expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.')
        });
        it('should return discount message if category is more than 4', ()=> {
            expect(dealership.euroCategory(6)).to.equal('We have added 5% discount to the final price: 14250.')
        });
        it('should return correct message if category is less than 4', ()=> {
            expect(dealership.euroCategory(3)).to.equal('Your euro category is low, so there is no discount from the final price!');
        });
    });
})