const chooseYourCar = require('./chooseYourCar');
const { expect, assert } = require('chai');

describe('Test chooseYourCar functionality', () => {
    describe('Test choosingType(type, color, year)', () => {

        it('should throw error if year is below 1990', () => {
            expect(() => chooseYourCar.choosingType('Sedan', 'black', 1899)).to.throw(Error, 'Invalid Year!');
        });
        it('should throw error if year is above 2022', () => {
            expect(() => chooseYourCar.choosingType('Sedan', 'black', 2023)).to.throw(Error, 'Invalid Year!');
        });
        it('should throw error if type is not Sedan', () => {
            expect(() => chooseYourCar.choosingType('Truck', 'black', 2020)).to.throw(Error, 'This type of car is not what you are looking for.');
        });
        it('should return tooOld message if year is below 2010', () => {
            expect(chooseYourCar.choosingType('Sedan', 'black', 2009)).to.equal('This Sedan is too old for you, especially with that black color.')
            expect(chooseYourCar.choosingType('Sedan', 'black', 1900)).to.equal('This Sedan is too old for you, especially with that black color.')
        });
        it('should return requirementsMet message if year equal or above 2010', () => {
            expect(chooseYourCar.choosingType('Sedan', 'black', 2010)).to.equal('This black Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'black', 2022)).to.equal('This black Sedan meets the requirements, that you have.');
        });

    });
    describe('Test brandName(brands, brandIndex)', () => {

        it('shoud throw error if array is not Array', () => {
            expect(() => chooseYourCar.brandName('brand', 0)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(50, 0)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(true, 0)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(null, 0)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName('', 0)).to.throw(Error, 'Invalid Information!');
        });
        it('shoud throw error if brandIndex is below 0', () => {
            let brands = ["BMW", "Toyota", "Peugeot"];
            expect(() => chooseYourCar.brandName(brands, -1)).to.throw(Error, 'Invalid Information!');
        });
        it('shoud throw error if brandIndex is outside the array', () => {
            let brands = ["BMW", "Toyota", "Peugeot"];
            expect(() => chooseYourCar.brandName(brands, 3)).to.throw(Error, 'Invalid Information!');
        });
        it('shoud throw error if brandIndex is not a number', () => {
            let brands = ["BMW", "Toyota", "Peugeot"];
            expect(() => chooseYourCar.brandName(brands, 'three')).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(brands, [])).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(brands, {})).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(brands, true)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.brandName(brands)).to.throw(Error, 'Invalid Information!');
        });
        it('should return string of brands ', () => {
            let brands = ["BMW", "Toyota", "Peugeot"];
            expect(chooseYourCar.brandName(brands, 2)).to.equal('BMW, Toyota');
        });

    });
    describe('Test carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)', () => {

        it('should throw error if distanceInKilometers is not a number', () => {
            expect(() => chooseYourCar.carFuelConsumption('three', 50)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption([], 50)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption({}, 50)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(true, 50)).to.throw(Error, 'Invalid Information!');
        });
        it('should throw error if distanceInKilometers is negative number', () => { 
            expect(() => chooseYourCar.carFuelConsumption(-1, '50')).to.throw(Error, 'Invalid Information!');
        });
        it('should throw error if distanceInKilometers is zero', () => { 
            expect(() => chooseYourCar.carFuelConsumption(0, '50')).to.throw(Error, 'Invalid Information!');
        });
        it('should throw error if consumptedFuelInLiters is not a number', () => { 
            expect(() => chooseYourCar.carFuelConsumption(50, '50')).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(50, [])).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(50, {})).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(50,)).to.throw(Error, 'Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(50,true)).to.throw(Error, 'Invalid Information!');
        });
        it('should throw error if consumptedFuelInLiters is negative number', () => { 
            expect(() => chooseYourCar.carFuelConsumption(50, -0.1)).to.throw(Error, 'Invalid Information!');
        });
        it('should throw error if consumptedFuelInLiters is zero', () => { 
            expect(() => chooseYourCar.carFuelConsumption(50, 0)).to.throw(Error, 'Invalid Information!');
        });
        it('should return correct message if consumption less or equal to 7', ()=> {
            expect(chooseYourCar.carFuelConsumption(500, 35)).to.equal("The car is efficient enough, it burns 7.00 liters/100 km.");
            expect(chooseYourCar.carFuelConsumption(500, 32)).to.equal("The car is efficient enough, it burns 6.40 liters/100 km.");
        })
        it('should return correct message if consumption greater than 7', ()=> {
            expect(chooseYourCar.carFuelConsumption(500, 35.1)).to.equal("The car burns too much fuel - 7.02 liters!");
        })
    });
});