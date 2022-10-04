const {rgbToHexColor} = require('../06.rgb-to-hex');
let {expect} = require('chai');

describe('Invalid input format', () => {
    it('Should return undefined if inputs are floats', () => {
        expect(rgbToHexColor(2.5, 3.8, 4.5)).to.be.equal(undefined);
    })

    it('Should return undefined if inputs are negative', () => {
        expect(rgbToHexColor(2, -2, -1)).to.be.equal(undefined);
    })

    it('Should return undefined if inputs are above 255', () => {
        expect(rgbToHexColor(255, 255, 256)).to.be.equal(undefined);
    })
    it('Should return undefined if one input missing', () => {
        expect(rgbToHexColor(255, 255)).to.be.equal(undefined);
    })
    it('Should return undefined if no input', () => {
        expect(rgbToHexColor()).to.be.equal(undefined);
    })
    it('Should return undefined if input is string', () => {
        expect(rgbToHexColor('0', '240', '15')).to.be.equal(undefined);
    })
})

describe('Valid input format', () => {
    it('Should work if inputs are integers', () => {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    })

    it('Should work with floating point integers', () => {
        expect(rgbToHexColor(0.0, 0.0, 0.0)).to.be.equal('#000000');
    });
})