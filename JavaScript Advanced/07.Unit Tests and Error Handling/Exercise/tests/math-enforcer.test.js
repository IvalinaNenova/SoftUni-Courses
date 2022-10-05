let { mathEnforcer } = require('../04.math-enforcer');
let { expect } = require('chai');

describe('mathEnforcer', () => {

    describe('AddFive', () => {
        it('should return undefined if parameter is not a number', () => {
            expect(mathEnforcer.addFive('word')).to.be.equal(undefined);
            expect(mathEnforcer.addFive({})).to.be.equal(undefined);
            expect(mathEnforcer.addFive([1])).to.be.equal(undefined);
        })
        it('should work with floats', () => {
            expect(mathEnforcer.addFive(6.78)).to.be.closeTo(11.78, 0.01);
        })
        it('should work with positive integers', () => {
            expect(mathEnforcer.addFive(11)).to.be.equal(16);
        })
        it('should work with negative integers', () => {
            expect(mathEnforcer.addFive(-10)).to.be.equal(-5);
        })
    });

    describe('subtractTen', () => {
        it('should return undefined if parameter is not a number', () => {
            expect(mathEnforcer.subtractTen('word')).to.be.equal(undefined);
            expect(mathEnforcer.subtractTen({})).to.be.equal(undefined);
            expect(mathEnforcer.subtractTen([1])).to.be.equal(undefined);
        })
        it('should work with floats', () => {
            expect(mathEnforcer.subtractTen(66.78)).to.be.closeTo(56.78, 0.01);
        })
        it('should work with positive integers', () => {
            expect(mathEnforcer.subtractTen(11)).to.be.equal(1);
        })
        it('should work with negative integers', () => {
            expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
        })
    });

    describe('sum', () => {
        it('should return undefined if parameter is not a number', () => {
            expect(mathEnforcer.sum('word', 5)).to.be.equal(undefined);
            expect(mathEnforcer.sum(5, {})).to.be.equal(undefined);
            expect(mathEnforcer.sum([1], 34)).to.be.equal(undefined);
        })
        it('should work with floats', () => {
            expect(mathEnforcer.sum(66.78 ,33.52)).to.be.closeTo(100.3, 0.01);
        })
        it('should work with positive integers', () => {
            expect(mathEnforcer.sum(11, 15)).to.be.equal(26);
        })
        it('should work with negative integers', () => {
            expect(mathEnforcer.sum(-10, -60)).to.be.equal(-70);
        })
    });
});