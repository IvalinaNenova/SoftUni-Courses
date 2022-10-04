const { expect } = require('chai')
const { sum } = require('../04.sum-of-numbers')

describe('Sum tests', () => {
    it('Sould return correct sum', () => {
        expect(sum([1, 2, 3, 4])).to.be.equal(10)
    })
    it('Should work with floating point numbers', () => {
        expect(sum([1.6, 1.5])).to.be.equal(3.1)
    })
    it('Should work with negative numbers', () => {
        expect(sum([-1, -1])).to.be.equal(-2)
    })
    it('Should work with one number', () => {
        expect(sum([1])).to.be.equal(1)
    })
    it('Should work with epmty array  ', () => {
        expect(sum([])).to.be.equal(0)
    })
})