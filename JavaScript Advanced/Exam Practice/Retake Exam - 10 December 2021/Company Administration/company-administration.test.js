const companyAdministration = require('./companyAdministration');
const { expect } = require('chai');

describe("Tests:", () => {
    describe("testing .hiringEmployee()", () => {
        it("input a non-programmer", () => {
            expect(() => companyAdministration.hiringEmployee('Peter', 'Manager', 3)).to.throw('We are not looking for workers for this position.');
        });

        it("input valid programmer", () => {
            expect(companyAdministration.hiringEmployee('Peter', 'Programmer', 3)).to.eq('Peter was successfully hired for the position Programmer.');
        });

        it("input valid programmer with insufficient experience", () => {
            expect(companyAdministration.hiringEmployee('Peter', 'Programmer', 2)).to.eq('Peter is not approved for this position.');
        });
    });
    
    describe("testing .calculateSalary()", () => {
        it("for 160 hours", () => {
            expect(companyAdministration.calculateSalary(160)).to.eq(2400);
        });

        it("for 160.5 hours", () => {
            expect(companyAdministration.calculateSalary(160.5)).to.eq(3407.5);
        });

        it("for 161 hours", () => {
            expect(companyAdministration.calculateSalary(161)).to.eq(3415);
        });

        it("for 0 hours", () => {
            expect(companyAdministration.calculateSalary(0)).to.eq(0);
        });

        it("input as negative number", () => {
            expect(() => companyAdministration.calculateSalary(-1)).to.throw('Invalid hours');
        });

        it("input as NaN", () => {
            expect(() => companyAdministration.calculateSalary('161')).to.throw('Invalid hours');
        });
    });

    describe("testing .firedEmployee()", () => {
        it("valid firing an employee", () => {
            expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 0)).to.eq('Ivan, George');
        });

        it("non-array", () => {
            expect(() => companyAdministration.firedEmployee('test', 0)).to.throw('Invalid input');
        });

        it("NaN index", () => {
            expect(() => companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 'string')).to.throw('Invalid input');
        });

        it("index outside lower boundary", () => {
            expect(() => companyAdministration.firedEmployee(["Petar", "Ivan", "George"], -1)).to.throw('Invalid input');
        });

        it("index outside upper boundary", () => {
            expect(() => companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 3)).to.throw('Invalid input');
        });
    });
});