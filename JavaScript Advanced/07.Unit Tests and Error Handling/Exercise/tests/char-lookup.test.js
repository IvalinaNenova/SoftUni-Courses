let {lookupChar} = require('../03.char-lookup');
let {expect} = require('chai');

describe('Test incorect input', () => {

    it('should return undefined if string is object', () => {
        expect(lookupChar({}, 0)).to.be.equal(undefined);
    });
    it('should return undefined if string is number', () => {
        expect(lookupChar(555, 5)).to.be.equal(undefined);
    });

    it('should return undefined if index is float', () => {
        expect(lookupChar('abcde', 5.5)).to.be.equal(undefined);
    });
    it('should return undefined if index is string', () => {
        expect(lookupChar('abcde', '6')).to.be.equal(undefined);
    });
})

describe('Test incorect index', () => {

    it('should return "Incorrect index" if index is negative', () => {
        expect(lookupChar('Marina', -3)).to.be.equal('Incorrect index');
    });
    it('should return "Incorrect index" if index is outside of string', () => {
        expect(lookupChar('Marina', 6)).to.be.equal('Incorrect index');
    });
})

describe('Test correct input', () => {

    it('should return correct answer if valid string and index', () => {
        expect(lookupChar('Marina', 2)).to.be.equal('r');
    });
    it('should return correct answer if valid string and index', () => {
        expect(lookupChar('Marina', 4)).to.be.equal('n');
    });
})