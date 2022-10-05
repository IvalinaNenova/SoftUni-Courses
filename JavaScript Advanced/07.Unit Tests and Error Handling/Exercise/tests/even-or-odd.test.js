let{isOddOrEven} = require('../02.even-or-odd');
let {expect} = require('chai');

describe ('If invalid input', () => {

    it('should return undefined if input is number', () => {
        expect(isOddOrEven(5)).to.be.equal(undefined);
    })

    it('should return undefined if input is object', () => {
        expect(isOddOrEven({name: 'Pesho'})).to.be.equal(undefined);
    })
})

describe ('If valid input', () => {

    it('should return even if string has even number of symbols', () => {
        expect(isOddOrEven('Marina')).to.be.equal('even');
    })

    it('should return odd if string has odd number of symbols', () => {
        expect(isOddOrEven('Pesho')).to.be.equal('odd');
    })

    it('should should work correctly with sentences', () => {
        expect(isOddOrEven('Pesho loves JavaScript')).to.be.equal('even');
    })
})