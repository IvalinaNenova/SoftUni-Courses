let { Repository } = require("./solution.js");
let { expect } = require("chai");

describe("Tests Repository", () => {
    describe("Test constructor", () => {
        let repo;
        beforeEach(function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            }
            repo = new Repository(properties);
        });

        it("It should instatiate class with props object", () => {
            expect(repo.props).is.instanceOf(Object);
        });
        it("It should instatiate class with data Map", () => {
            expect(repo.data).is.instanceOf(Map);
        });
        it("It should instatiate class with function nextId", () => {
            expect(typeof (repo.nextId)).is.equal('function')
        });
    });

    describe('test add', () => {
        let repo;
        beforeEach(function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            }
            repo = new Repository(properties);
        });
        // Add two entities
        let entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        it('should return the Id if valid data', () => {
            expect(repo.add(entity)).to.equal(0);
            expect(repo.add(entity)).to.equal(1);
        })
        it('should increase the size of the map', () => {
            expect(repo.count).to.equal(0);
            repo.add(entity);
            expect(repo.count).to.equal(1);
        });
        it('should throw error if entity has missing property', () => {
            let entity1 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity3 = {
                name: "Pesho",
                age: 22
            };
            expect(() => repo.add(entity1)).to.throw(Error, 'Property age is missing from the entity!');
            expect(() => repo.add(entity2)).to.throw(Error, 'Property name is missing from the entity!');
            expect(() => repo.add(entity3)).to.throw(Error, 'Property birthday is missing from the entity!');
        });
        it('should throw error if entity has wrong property type', () => {
            let e1 = {
                name: 22,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let e2 = {
                name: "Pesho",
                age: '58',
                birthday: '24.12.1989'
            };
            let e3 = {
                name: "Pesho",
                age: 22,
                birthday: '12.24.1989'
            };
            expect(() => repo.add(e1)).to.throw(TypeError, 'Property name is not of correct type!');
            expect(() => repo.add(e2)).to.throw(TypeError, 'Property age is not of correct type!');
            expect(() => repo.add(e3)).to.throw(TypeError, 'Property birthday is not of correct type!');
        });
    });
    describe('Test getId', () => {
        let repo;
        beforeEach(function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            }
            repo = new Repository(properties);
        });
        it('should return the entity with given id', () => {
            // Add two entities
            let entity1 = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: 'Marina',
                age: 32,
                birthday: new Date(1989, 12, 24)
            };
            repo.add(entity1);
            repo.add(entity2);

            expect(repo.getId(0)).to.deep.equal(entity1);
            expect(repo.getId(1)).to.deep.equal(entity2);
        });
    });
    describe('Test update', () => {
        let repo;
        beforeEach(function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            }
            repo = new Repository(properties);
        });
        // Add two entities
        let entity1 = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        let entity2 = {
            name: 'Marina',
            age: 32,
            birthday: new Date(1989, 12, 24)
        };
        let newEntity = {
            name: 'Ivan',
            age: 55,
            birthday: new Date(2002, 10, 3)
        }


        it('should throw error if id does not exist', () => {
            repo.add(entity1);
            repo.add(entity2);
            expect(() => repo.update(12, newEntity)).to.throw('Entity with id: 12 does not exist!');
        });
        it('should throw Error if newEntity has missing property', () => {
            repo.add(entity1);
            repo.add(entity2);
            let newEntity = {
                age: 55,
                birthday: new Date(2002, 10, 3)
            }
            expect(() => repo.update(1, newEntity)).to.throw(Error, 'Property name is missing from the entity!');
        })
        it('should throw TypeError if newEntity has wrong property type', () => {
            repo.add(entity1);
            repo.add(entity2);
            let newEntity = {
                name: 'Ivan',
                age: [],
                birthday: new Date(2002, 10, 3)
            }
            expect(() => repo.update(1, newEntity)).to.throw(Error, 'Property age is not of correct type!');
        })
        it('should update the entity on that id', () => {
            repo.add(entity1);
            repo.add(entity2);
            let newEntity = {
                name: 'Ivan',
                age: 58,
                birthday: new Date(2002, 10, 3)
            }
            expect(repo.getId(1)).to.deep.equals(entity2);
            repo.update(1, newEntity);
            expect(repo.getId(1)).to.deep.equal(newEntity);
        });
    });
    describe('Test delete', () => {
        let repo;
        beforeEach(function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            }
            let entity1 = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: 'Marina',
                age: 32,
                birthday: new Date(1989, 12, 24)
            };
            repo = new Repository(properties);
            repo.add(entity1);
            repo.add(entity2);
        });
        it('should throw error if id does not exist', () => {
            expect(() => repo.del(2)).to.throw(Error, 'Entity with id: 2 does not exist!');
        });
        it('should remove entity', () => {
            expect(repo.count).to.equal(2);
            repo.del(0);
            expect(() => repo.getId(0)).to.throw(Error, 'Entity with id: 0 does not exist!');
            expect(repo.count).to.equal(1);
        });
    })
});
