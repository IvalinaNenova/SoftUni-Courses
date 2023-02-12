CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL REFERENCES Cages(Id),
	AnimalId INT NOT NULL REFERENCES Animals(Id)
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)



CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
	AnimalId INT REFERENCES Animals(Id),
	DepartmentId INT NOT NULL REFERENCES VolunteersDepartments(Id)
)

--2.	Insert

INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
('Anita Kostova',	'0896365412',	'Sofia, 5 Rosa str.',	15,	1),
('Dimitur Stoev',	'0877564223',	null,	42,	4),
('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.',	18,	8),
('Boryana Mileva',	'0888112233',	null,	31,	5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2,	4)

--3.  Update
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

--4.  Delete
--ID 2
--SELECT * FROM Volunteers
--DELETE FROM Volunteers
--WHERE DepartmentId = 2

--DELETE FROM VolunteersDepartments
--WHERE Id = 2