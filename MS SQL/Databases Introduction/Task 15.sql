--Problem 15.	Hotel Database
/*
Using SQL queries create Hotel database with the following entities:
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
•	RoomStatus (RoomStatus, Notes)
•	RoomTypes (RoomType, Notes)
•	BedTypes (BedType, Notes)
•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
*/

CREATE DATABASE Hotel
USE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

--RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus
(
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

--RoomTypes (RoomType, Notes)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

--BedTypes (BedType, Notes)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal DECIMAL(15,2) NOT NULL,
	Notes VARCHAR(MAX)
)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Pesho', 'Petrov', 'Manager', null),
(2, 'Georgi', 'Petrov', 'Receptionist', 'default note'),
(3, 'Maria', 'Ivanova', 'Hostes', null)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(1, 'Pesho', 'Petrov', 0888080808, 'Maria', 05555555, null),
(2, 'Georgi', 'Petrov', 0898989898, 'Petar', 061855555, 'some note'),
(3, 'Maria', 'Ivanova', 052161616, 'Ivana', 0855555, 'other note')

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
(1, 'Room Ready'),
(0, 'Room NOT Ready'),
(1, 'Room Ready')

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Double', 'twin beds'),
('Tripple', 'three single beds'),
('Apartment', 'family apartment')

INSERT INTO BedTypes(BedType, Notes) VALUES
('Queen', 'large queen bed'),
('Single', 'single bed'),
('Sofa', 'sofa bed')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(101, 'Double', 'Queen', 1, 1, 'some note'),
(102, 'Tripple', 'Single', 2, 1, null),
(103, 'Double', 'Queen', 3, 0, 'some note')

INSERT INTO Payments(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, 3, '1/12/2022', 1, '1/1/22', '1/12/2022', 12, 84, 20, 16.80, 100.80, 'some note'),
(2, 2, '1/12/2022', 1, '1/1/22', '1/12/2022', 12, 84, 20, 16.80, 100.80, 'some note'),
(3, 1, '1/12/2022', 1, '1/1/22', '1/12/2022', 12, 84, 20, 16.80, 100.80, 'some note')

INSERT INTO Occupancies(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, 2, '1/11/2022', 2, 101, 2, NULL, NULL),
(2, 1, '1/11/2022', 2, 101, 2, 15.50, NULL),
(3, 3, '1/11/2022', 2, 101, 2, 2.30, NULL)
