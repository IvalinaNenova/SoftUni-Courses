let { PaymentPackage } = require('./12.payment-package');
let { expect, assert } = require('chai');

describe('Name', () => {
    it('should throw error if name is empty string', () => {
        assert.throws(() => new PaymentPackage('', 1000), 'Name must be a non-empty string')
    });
    it('should throw error if name is not string', () => {
        assert.throws(() => new PaymentPackage(50, 1000), 'Name must be a non-empty string')
        assert.throws(() => new PaymentPackage({}, 1000), 'Name must be a non-empty string')
        assert.throws(() => new PaymentPackage([50], 1000), 'Name must be a non-empty string')
        assert.throws(() => new PaymentPackage(true, 1000), 'Name must be a non-empty string')
        assert.throws(() => new PaymentPackage(undefined, 1000), 'Name must be a non-empty string')
        assert.throws(() => new PaymentPackage(), 'Name must be a non-empty string')
    })
    it('should work correctly with valid data', () => {
        let package = new PaymentPackage('Something', 50);
        package.name = 'Something else';
        assert.equal(package.name, 'Something else');
    });
})

describe('Value', () => {
    it('should throw error if value is negative number', () => {
        assert.throws(() => new PaymentPackage('Something', -1), 'Value must be a non-negative number');
    });
    it('should throw error if value is not a number', () => {
        assert.throws(() => new PaymentPackage('Something', '15'), 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('Something', {}), 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('Something', [1000]), 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('Something', true), 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('Something', undefined), 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('Something'), 'Value must be a non-negative number');
    })
    it('should work correctly with valid data', () => {
        let package = new PaymentPackage('Something', 50);
        package.value = 1000;
        assert.equal(package.value, 1000);
    });
})

describe('VAT', () => {
    it('should have default value of 20', () => {
        let package = new PaymentPackage('Something', 50);
        assert.equal(20, package.VAT);
    });
    it('should throw error if value is not a number', () => {
        let package = new PaymentPackage('Something', 50);
        assert.throws(() => package.VAT = null, 'VAT must be a non-negative number');
        assert.throws(() => package.VAT = '1000', 'VAT must be a non-negative number');
        assert.throws(() => package.VAT = {}, 'VAT must be a non-negative number');
        assert.throws(() => package.VAT = [], 'VAT must be a non-negative number');
        assert.throws(() => package.VAT = undefined, 'VAT must be a non-negative number');
        assert.throws(() => package.VAT = true, 'VAT must be a non-negative number');
    })
    it('should throw error if value is negative number', () => {
        let package = new PaymentPackage('Something', 50);
        assert.throws(() => package.VAT = -50, 'VAT must be a non-negative number');
    })
    it('should work correctly with valid data', () => {
        let package = new PaymentPackage('Something', 50);
        package.VAT = 500;
        assert.equal(package.VAT, 500);
    });
})

describe('Active', () => {
    let package;
    beforeEach(() => { package = new PaymentPackage('Something', 50); });
    it('should have default value of true', () => {
        assert.equal(package.active, true);
    });
    it('should throw error if value is not a boolean', () => {
        assert.throws(() => package.active = 'true', 'Active status must be a boolean');
        assert.throws(() => package.active = 50, 'Active status must be a boolean');
        assert.throws(() => package.active = {}, 'Active status must be a boolean');
        assert.throws(() => package.active = [], 'Active status must be a boolean');
        assert.throws(() => package.active = undefined, 'Active status must be a boolean');
        assert.throws(() => package.active = null, 'Active status must be a boolean');
    })
    it('should work correctly with valid data', () => {
        let package = new PaymentPackage('Something', 50);
        package.active = false;
        assert.equal(package.active, false);
    });
})

describe('toString method', () => {
        let package;
        beforeEach(() => package  = new PaymentPackage('Fee', 1000));

    it('should return correct string representation', () => {
        let expected = 'Package: Fee\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200'
        let actual = package.toString();
        assert.equal(actual, expected);
    })
    it('should return correct string if active status is false', ()=>{
        package.active = false;
        let expected = 'Package: Fee (inactive)\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200'
        let actual = package.toString();
        assert.equal(actual, expected);
    })
    it('should return correct string if VAT is changed', () => {
        package.VAT = 27;
        let expected = 'Package: Fee\n- Value (excl. VAT): 1000\n- Value (VAT 27%): 1270'
        let actual = package.toString();
        assert.equal(actual, expected);
    });
})
describe('Constructor', () => {
    it('should create instance of package if 2 parameters', ()=>{
        let package = new PaymentPackage('Fee', 0);
        assert(package instanceof PaymentPackage);
        assert.equal(package.name, 'Fee');
        assert.equal(package.value, 0);
        assert.equal(package.VAT, 20);
        assert.equal(package.active, true);
    });
})