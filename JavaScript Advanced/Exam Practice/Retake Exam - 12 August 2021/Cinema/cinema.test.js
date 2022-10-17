const cinema = require('./cinema');
const { expect } = require('chai');

describe('Test cinema', () => {
    describe('Test showMovies(movieArray)', () => {
        let movieArray = ['King Kong', 'The Tomorrow War', 'Joker'];
        it('when empty array provided', () => {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        });
        it('when array provided', () => {
            expect(cinema.showMovies(movieArray)).to.equal('King Kong, The Tomorrow War, Joker');
        });
        it('when array with one movie', () => {
            expect(cinema.showMovies(['Harry Potter'])).to.equal('Harry Potter');
        });
    });
    describe('Test ticketPrice(projectionType)', () => {
        it('when wrong projectionType provided should throw error', () => {
            expect(() => cinema.ticketPrice('')).to.throw(Error, 'Invalid projection type.');
        });
        it('when projectionType is "Premiere", should return 12.00', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        });
        it('when projectionType is "Normal", should return 7.50', () => {
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        });
        it('when projectionType is "Discount", should return 5.50', () => {
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        });
    });
    describe('Test swapSeatsInHall(firstPlace, secondPlace)', () => {
        let errorMessage = "Unsuccessful change of seats in the hall.";
        let successMessage = "Successful change of seats in the hall.";
        it('when firstPlace is not integer should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1.5, 15)).to.equal(errorMessage);
        });
        it('when one of the inputs is missing should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(15)).to.equal(errorMessage);
        });
        it('when firstPlace is string should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall('1.5', 15)).to.equal(errorMessage);
        });
        it('when firstPlace is negative number Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(-1, 15)).to.equal(errorMessage);
        });
        it('when firstPlace is zero Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(0, 15)).to.equal(errorMessage);
        });
        it('when firstPlace is over 20 Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(21, 15)).to.equal(errorMessage);
        });
        it('when secondPlace is not integer should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1, 15.5)).to.equal(errorMessage);
        });
        it('when secondPlace is string should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1, '15')).to.equal(errorMessage);
        });
        it('when secondPlace is negative number Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1, -5)).to.equal(errorMessage);
        });
        it('when secondPlace is zero Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1, 0)).to.equal(errorMessage);
        });
        it('when secondPlace is over 20 Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(1, 25)).to.equal(errorMessage);
        });
        it('when secondPlace == firstPlace should return Unsuccessful change', () => {
            expect(cinema.swapSeatsInHall(13, 13)).to.equal(errorMessage);
        });
        it('when first and second place are valid should return Success message', () => {
            expect(cinema.swapSeatsInHall(1, 20)).to.equal(successMessage);
        });
    });
});
