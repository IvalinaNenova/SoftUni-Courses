--Problem 16.	Create SoftUni Database

CREATE DATABASE SoftUni

USE SoftUni

--•	Towns (Id, Name)
CREATE TABLE Towns
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(85) NOT NULL
)
--•	Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(250) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)
--•	Departments (Id, Name)
CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25) NOT NULL,
	[MiddleName] NVARCHAR(25),
	[LastName] NVARCHAR(25) NOT NULL,
	[JobTitle] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	[HireDate] DATE,
	[Salary] DECIMAL(15,2),
	[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id)
)

--Problem 17.	Backup Database

--Backup the database SoftUni from the previous task into a file named “softuni-backup.bak”.
--Delete your database from SQL Server Management Studio.
USE [master]
DROP DATABASE SoftUni
--Then restore the database from the created backup.
RESTORE DATABASE SoftUni FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\SoftUni.bak' WITH RECOVERY

--Problem 18.	Basic Insert
--•	Towns: Sofia, Plovdiv, Varna, Burgas
USE SoftUni
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')
--•	Employees:
INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-01-02', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-02-03', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)
/*
       Name	               Job Title	         Department	        Hire Date	Salary
Ivan Ivanov Ivanov	      .NET Developer	Software Development	01/02/2013	3500.00
Petar Petrov Petrov	      Senior Engineer	Engineering	            02/03/2004	4000.00
Maria Petrova Ivanova	  Intern	        Quality Assurance	    28/08/2016	525.25
Georgi Teziev Ivanov	  CEO	            Sales	                09/12/2007	3000.00
Peter Pan Pan	          Intern	        Marketing	            28/08/2016	599.88
*/

--Problem 19.	Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

--Problem 20.	Basic Select All Fields and Order Them
SELECT * FROM [Towns] ORDER BY [Name] ASC;
SELECT * FROM [Departments] ORDER BY [Name] ASC;
SELECT * FROM [Employees] ORDER BY [Salary] DESC;

--Problem 21.	Basic Select Some Fields
SELECT [Name] FROM [Towns] ORDER BY [Name] ASC;
SELECT [Name] FROM [Departments] ORDER BY [Name] ASC;
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC;

--Problem 22.	Increase Employees Salary - increase the salary of all employees by 10%. 
UPDATE [Employees]
	SET [Salary] = [Salary] * 1.1

SELECT [Salary] FROM [Employees]