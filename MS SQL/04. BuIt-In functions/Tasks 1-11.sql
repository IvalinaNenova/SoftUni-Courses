					--Part I – Queries for SoftUni Database

/*
1.	Find Names of All Employees by First Name
Create a SQL query that finds all employees whose first name starts with "Sa".
As a result, display "FirstName" and "LastName".
*/

USE SoftUni

SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'

/*
2.	Find Names of All Employees by Last Name 
Create a SQL query that finds all employees whose last name contains "ei".
As a result, display "FirstName" and "LastName".
*/

SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

/*
3.	Find First Names of All Employees
Create a SQL query that finds the first names of all employees whose department ID is 3 or 10,
and the hire year is between 1995 and 2005 inclusive.
*/

SELECT FirstName
	FROM Employees
		WHERE DepartmentID IN (3, 10)
		AND YEAR(HireDate) BETWEEN 1995 AND 2005

/*
4.	Find All Employees Except Engineers
Create a SQL query that finds the first and last names of every employee,
whose job title does not contain "engineer".
*/

SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

/*
5.	Find Towns with Name Length
Create a SQL query that finds all town names, which are 5 or 6 symbols long.
Order the result alphabetically by town name.  
*/

SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name] ASC


/*
6.	Find Towns Starting With
Create a SQL query that finds all towns with names starting with 'M', 'K', 'B' or 'E'.
Order the result alphabetically by town name. 
*/

SELECT *
	FROM Towns
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name] ASC

/*7.	Find Towns Not Starting With
Create a SQL query that finds all towns, which do not start with 'R', 'B' or 'D'.
Order the result alphabetically by name. 
*/

SELECT *
	FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name] ASC

/*
8.	Create View Employees Hired After 2000 Year
Create a SQL query that creates view "V_EmployeesHiredAfter2000"
with the first and the last name for all employees, hired after the year 2000. 
*/
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM Employees
		WHERE YEAR(HireDate) > 2000
GO

SELECT * from V_EmployeesHiredAfter2000

/*
9.	Length of Last Name
Create a SQL query that finds all employees, whose last name is exactly 5 characters long.
*/

SELECT FirstName, LastName
	FROM Employees
		WHERE LEN(LastName) = 5

/*
10.	Rank Employees by Salary
Write a query that ranks all employees using DENSE_RANK.
In the DENSE_RANK function, employees need to be partitioned by Salary and ordered by EmployeeID.
You need to find only the employees, whose Salary is between 10000 and 50000
and order them by Salary in descending order.
*/

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC
	
/*
11.	Find All Employees with Rank 2
Upgrade the query from the previous problem, so that it finds only the employees with a Rank 2.
Order the result by Salary (descending).
*/

SELECT * FROM 
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
) 
	AS Result
		WHERE [Rank] = 2
		ORDER BY Salary DESC