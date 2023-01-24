--Part I – Queries for SoftUni Database

/*
1.	Employee Address
Create a query that selects:
•	EmployeeId
•	JobTitle
•	AddressId
•	AddressText
Return the first 5 rows sorted by AddressId in ascending order.
*/

USE SoftUni

SELECT TOP(5)
	EmployeeId, JobTitle, e.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON A.[AddressID] = e.[AddressID]
	ORDER BY a.AddressID ASC

/*
2.	Addresses with Towns
Write a query that selects:
•	FirstName
•	LastName
•	Town
•	AddressText
Sort them by FirstName in ascending order, then by LastName. Select the first 50 employees.
*/

SELECT TOP(50) FirstName, LastName, t.Name AS Town, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY FirstName ASC, LastName

/*
3.	Sales Employee
Create a query that selects:
•	EmployeeID
•	FirstName
•	LastName
•	DepartmentName
Sort them by EmployeeID in ascending order. Select only employees from the "Sales" department.
*/

SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName 
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
		WHERE d.Name = 'Sales'
		ORDER BY e.EmployeeID ASC

/*
4.	Employee Departments
Create a query that selects:
•	EmployeeID
•	FirstName 
•	Salary
•	DepartmentName
Filter only employees with a salary higher than 15000. Return the first 5 rows, sorted by DepartmentID in ascending order.
*/

SELECT TOP(5) [EmployeeID], [FirstName], [Salary], [d].[Name] AS [DepartmentName]
		FROM [Employees] AS [e]
		JOIN [Departments] AS [d]
			ON [d].[DepartmentID] = [e].[DepartmentID]
		WHERE [e].[Salary] > 15000
		ORDER BY [d].[DepartmentID] ASC

/*
5.	Employees Without Project
Create a query that selects:
•	EmployeeID
•	FirstName
Filter only employees without a project. Return the first 3 rows, sorted by EmployeeID in ascending order.
*/

SELECT TOP(3) [e].EmployeeID, [e].[FirstName] 
			FROM [Employees] AS [e]
	LEFT JOIN [EmployeesProjects] AS [p] 
			ON [p].[EmployeeID] = [e].[EmployeeID]
		 WHERE [p].[EmployeeID] IS NULL
	  ORDER BY [e].[EmployeeID] ASC

/*
6.	Employees Hired After
Create a query that selects:
•	FirstName
•	LastName
•	HireDate
•	DeptName
Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" department.
Sort them by HireDate (ascending).
*/

SELECT [e].[FirstName], [e].[LastName], [e].[HireDate], [d].[Name] AS [DeptName]
		FROM [Employees] AS [e]
		JOIN [Departments] AS [d] 
			ON [d].[DepartmentID] = [e].[DepartmentID]
		 WHERE [e].[HireDate] > '1999-01-01'
			AND [d].[Name] IN ('Sales', 'Finance')
	ORDER BY [e].[HireDate] ASC

/*
7.	Employees with Project
Create a query that selects:
•	EmployeeID
•	FirstName
•	ProjectName
Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.
*/

SELECT TOP(5) 
			 [e].[EmployeeID], [e].[FirstName], [p].[Name] AS [ProjectName]
		FROM [Employees] AS [e]
		JOIN [EmployeesProjects] AS [ep]
		  ON [ep].[EmployeeID] = [e].[EmployeeID]
		JOIN [Projects] AS [p]
		  ON [p].[ProjectID] = [ep].[ProjectID]
	   WHERE [p].[StartDate] > '2002-08-13'
		 AND [p].[EndDate] IS NULL
	ORDER BY [e].[EmployeeID] ASC
		  
/*
8.	Employee 24
Create a query that selects:
•	EmployeeID
•	FirstName
•	ProjectName
Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.
*/

SELECT [e].[EmployeeID], [e].[FirstName],
		CASE	
			WHEN DATEPART(YEAR, [p].[StartDate]) > '2004' THEN NULL
			ELSE [p].[Name]
		END AS [ProjectName]
		FROM [Employees] AS [e]
		JOIN [EmployeesProjects] AS [ep]
		  ON [ep].[EmployeeID] = [e].[EmployeeID]
		JOIN [Projects] AS [p]
		  ON [p].[ProjectID] = [ep].[ProjectID]
	   WHERE [e].[EmployeeID] = 24
	 
/*
9. Employee Manager 
Create a query that selects:
•	EmployeeID
•	FirstName
•	ManagerID
•	ManagerName
Filter all employees with a manager who has ID equals to 3 or 7.
Return all the rows, sorted by EmployeeID in ascending order.
*/

SELECT [e].[EmployeeID], [e].[FirstName], [e].[ManagerID], [m].[FirstName] AS [ManagerName]
		FROM [Employees] AS [e]
		JOIN [Employees] AS [m]
		  ON [m].[EmployeeID] = [e].[ManagerID]
	   WHERE [m].[EmployeeID] IN (3, 7)
	ORDER BY [e].[EmployeeID] ASC

/*
10.	Employees Summary
Create a query that selects:
•	EmployeeID
•	EmployeeName
•	ManagerName
•	DepartmentName
Show the first 50 employees with their managers and the departments they are in (show the departments of the employees).
Order them by EmployeeID.
*/

SELECT TOP(50)	
		[e].[EmployeeID],
	   CONCAT([e].[FirstName],' ', [e].[LastName]) AS [EmployeeName],
	   CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName],
			  [d].[Name] AS [DepartmentName]
		FROM [Employees] AS [e]
		JOIN [Employees] AS [m]
		  ON [m].[EmployeeID] = [e].[ManagerID]
		JOIN [Departments] AS [d]
		  ON [d].[DepartmentID] = [e].[DepartmentID]
	ORDER BY [e].[EmployeeID]

/*
11.	Min Average Salary
Create a query that returns the value of the lowest average salary of all departments.
*/

SELECT MIN([Avg]) AS [MinAverageSalary]
	FROM(
	SELECT AVG([Salary]) AS [Avg]
		  FROM [Employees]
	  GROUP BY [DepartmentID]
	) AS [AverageSalaries]