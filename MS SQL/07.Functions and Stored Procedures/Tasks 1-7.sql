--Part I – Queries for SoftUni Database

/*
1.	Employees with Salary Above 35000
Create stored procedure usp_GetEmployeesSalaryAbove35000 that returns all employees' first and last names,
whose salary above 35000. 
*/

USE SoftUni

GO
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
	SELECT [FirstName], [LastName]
		FROM Employees
	   WHERE [Salary] > 35000
GO

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

/*
2.	Employees with Salary Above Number
Create a stored procedure usp_GetEmployeesSalaryAboveNumber that accepts a number (of type DECIMAL(18,4))
as parameter and returns all employees' first and last names, whose salary is above or equal to the given number. 
*/
GO
CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber(@MinSalary DECIMAL(18,4))
AS
	SELECT [FirstName], [LastName]
		FROM [Employees]
		WHERE [Salary] >= @MinSalary
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

/*
3.	Town Names Starting With
Create a stored procedure usp_GetTownsStartingWith that accepts a string as parameter
and returns all town names starting with that string. 
*/

GO
CREATE OR ALTER PROC dbo.usp_GetTownsStartingWith(@StartsWith VARCHAR(50))
AS
	SELECT [Name]
		FROM [Towns]
		WHERE LEFT([Name], LEN(@StartsWith)) = @StartsWith
GO

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

/*
4.	Employees from Town
Create a stored procedure usp_GetEmployeesFromTown that accepts town name as parameter
and returns the first and last name of those employees, who live in the given town. 
*/

GO
CREATE PROC dbo.usp_GetEmployeesFromTown (@TownName VARCHAR(85))
AS
SELECT e.[FirstName], e.[LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
	JOIN [Towns] AS t ON t.[TownID] = a.[TownID]
	WHERE t.[Name] = @TownName
GO

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'

/*
5.	Salary Level Function
Create a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee
and returns the level of the salary.
•	If salary is < 30000, return "Low"
•	If salary is between 30000 and 50000 (inclusive), return "Average"
•	If salary is > 50000, return "High"
*/

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
		IF @salary < 30000
			RETURN 'Low'
		ELSE IF @salary <= 50000
			RETURN 'Average'
		ELSE
			RETURN 'High'
RETURN ''
END

SELECT [Salary],  [dbo].[ufn_GetSalaryLevel]([Salary]) AS [SalaryLevel]
	FROM [Employees]

/*
6.	Employees by Salary Level
Create a stored procedure usp_EmployeesBySalaryLevel that receives as parameter level of salary
(low, average, or high) and print the names of all employees, who have the given level of salary.
You should use the function - "dbo.ufn_GetSalaryLevel(@Salary)", which was part of the previous task,
inside your "CREATE PROCEDURE …" query.
*/

GO
CREATE PROC dbo.usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
	SELECT [FirstName], [LastName]
		FROM [Employees]
		WHERE (SELECT dbo.ufn_GetSalaryLevel([Salary])) = @Level
GO

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

/*
7.	Define Function
Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false,
depending on that if the word is comprised of the given set of letters. 
*/

GO
CREATE FUNCTION dbo.ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @count INT = 1;
	WHILE @count <= LEN(@word)
	BEGIN
		IF (CHARINDEX(SUBSTRING(@word, @count, 1), @setOfLetters)) = 0
			RETURN 0;
		SET @count += 1;
	END
	RETURN 1;
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

/*
1.	Delete Employees and Departments
Create a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT)
which deletes all Employees from a given department.
Delete these departments from the Departments table too.
Finally, SELECT the number of employees from the given department.
If the delete statements are correct the select query should return 0.
After completing that exercise restore your database to revert all changes.
Hint:
You may set ManagerID column in Departments table to nullable (using query "ALTER TABLE …").
*/

ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

SELECT * FROM Departments

