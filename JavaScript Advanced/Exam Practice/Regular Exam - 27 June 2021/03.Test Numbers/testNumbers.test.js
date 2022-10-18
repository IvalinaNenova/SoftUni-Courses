const {testNumbers} = require('./testNumbers');
const {expect} = require('chai');

describe('test testNumbers', () => {
    describe('test .sumNumbers(numq, num2)', () => {
        it('should return undefined if num1 is not a number', () => {
            expect(testNumbers.sumNumbers('15', 2)).to.equal(undefined);
        });
        it('should return undefined if num2 is not a number', () => {
            expect(testNumbers.sumNumbers(15, '2')).to.equal(undefined);
        });
        it('should return sum if nums are valid', () => {
            expect(testNumbers.sumNumbers(1, 2)).to.equal('3.00');
            expect(testNumbers.sumNumbers(-1, -2)).to.equal('-3.00');
            expect(testNumbers.sumNumbers(-1, 5)).to.equal('4.00');
        });
    });
    describe('test .numberChecker(input)', () => {
        it('should throw an error if input is NaN', () => {
            expect(() => testNumbers.numberChecker('five')).to.throw(Error, 'The input is not a number!');
            expect(() => testNumbers.numberChecker({})).to.throw(Error, 'The input is not a number!');
        });
        it('should return even for even number', () => {
            expect(testNumbers.numberChecker(40)).to.equal('The number is even!');
        });
        it('should return odd for odd number', () => {
            expect(testNumbers.numberChecker(-5)).to.equal('The number is odd!');
        });
    });
    describe('test .averageSumArray(arr)', () => {
        it('should calculate the average sum', () => {
            expect(testNumbers.averageSumArray([1, 2, 3, 4])).to.equal(2.5);
            expect(testNumbers.averageSumArray([-2, -3.4, 5.8, 6])).to.be.closeTo(1.6, 0.01);
        });
    });
});