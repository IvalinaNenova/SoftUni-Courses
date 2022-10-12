const carService = require('./03. Car Service_Resources.js')
const { expect, assert } = require('chai');

describe("Car service tests", () => {
    describe("Test .isItExpensive(issue)", () => {

        it('shoud return correct result if issue is engine', () => {
            expect(carService.isItExpensive('Engine')).to.be.equal('The issue with the car is more severe and it will cost more money')
        });
        it('shoud return correct result if issue is transmission', () => {
            expect(carService.isItExpensive('Transmission')).to.be.equal('The issue with the car is more severe and it will cost more money')
        });
        it('shoud return correct result if issue different than engine or transmission', () => {
            expect(carService.isItExpensive('tire pressure')).to.be.equal('The overall price will be a bit cheaper')
        });
    });

    describe('Test .discount(numberOfParts, totalPrice)', () => {
        it('should throw error if number of parts or totalPrice is not a number', () => {
            expect(() => carService.discount('5', 58.00)).throws(Error, 'Invalid input');
            expect(() => carService.discount(5, 'zero')).throws(Error, 'Invalid input');
        });

        it('should calculate correct discount if parts in range [3,7]', () => {
            expect(carService.discount(3, 200)).to.eq(`Discount applied! You saved 30$`);
            expect(carService.discount(7, 1000)).to.eq(`Discount applied! You saved 150$`);
        });

        it('should calculate correct discount if parts more than 7', () => {
            expect(carService.discount(8, 200)).to.eq(`Discount applied! You saved 60$`);
            expect(carService.discount(88, 1000)).to.eq(`Discount applied! You saved 300$`);
        });

        it('should return correct message if parts less than 2',() => {
            expect(carService.discount(2, 100)).to.eq('You cannot apply a discount');
            expect(carService.discount(1, 100)).to.eq('You cannot apply a discount');
            expect(carService.discount(0, 100)).to.eq('You cannot apply a discount');
        })
    });

    describe('Test .partsToBuy(partsCatalog, neededParts)', () => {
        let partsCatalog = [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }];
        let neededParts = ["blowoff valve", "injectors", "coil springs"];
        it('should throw error if partsCatalog is not array', () => {
            expect(() => carService.partsToBuy('5', [{}, {}])).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy(5, [{}, {}])).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy(8.8, [{}, {}])).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy({}, [{}, {}])).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy(null, [{}, {}])).throws(Error, 'Invalid input');
        });

        it('should throw error if neededParts is not array', () => {
            expect(() => carService.partsToBuy(['5'], 'string')).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy([5], 5)).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy([8.8], 8.9)).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy([{}], {})).throws(Error, 'Invalid input');
            expect(() => carService.partsToBuy([null])).throws(Error, 'Invalid input');
        });

        it('should calculate correct amount', () => {
            expect(carService.partsToBuy(partsCatalog, neededParts)).to.eq(375);
            expect(carService.partsToBuy([], neededParts)).to.eq(0);
        });
    });

});
