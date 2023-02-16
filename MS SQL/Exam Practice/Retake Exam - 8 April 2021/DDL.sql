CREATE DATABASE Service

USE Service

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL,
	Name VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id))

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description VARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

--2.	Insert

INSERT INTO Employees(FirstName, LastName, Birthdate, Age, DepartmentId) VALUES
('Marlo', 'O''Malley',	'1958-9-21', NULL,	1),
('Niki', 'Stanaghan', '1969-11-26', NULL,	4),
('Ayrton', 'Senna',	'1960-03-21', NULL,	9),
('Ronnie', 'Peterson',	'1944-02-14', NULL,	9),
('Giovanna', 'Amati',	'1959-07-20', NULL,	5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1,	1,	'2017-04-13', NULL,	'Stuck Road on Str.133', 6, 2),
(6,	3,	'2015-09-05', '2015-12-06','Charity trail running',	3, 5),
(14, 2,	'2015-09-07', NULL,	'Falling bricks on Str.58',	5, 2),
(4,	3,	'2017-07-03',	'2017-07-06', 'Cut off streetlight on Str.11', 1, 1)


--3.	Update

UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

--4.	Delete

DELETE FROM Reports
	WHERE StatusId = 4

