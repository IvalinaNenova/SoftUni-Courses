--Part II – Queries for SoftUni Database

USE SoftUni

/*
13. Departments Total Salaries
Create a query that shows the total sum of salaries for each department. Order them by DepartmentID.
Your query should return:	
•	DepartmentID
*/
SELECT [DepartmentID], SUM([Salary])
		FROM [Employees]
	GROUP BY [DepartmentID]
	ORDER BY [DepartmentID]

/*
14. Employees Minimum Salaries
Select the minimum salary from the employees for departments with ID (2, 5, 7)
but only for those, hired after 01/01/2000.
Your query should return:	
•	DepartmentID
*/

SELECT [DepartmentID], MIN(Salary)
	  FROM [Employees]
	 WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '2000-01-01'
  GROUP BY [DepartmentID]

/*
15. Employees Average Salaries
Select all employees who earn more than 30000 into a new table.
Then delete all employees who have ManagerID = 42 (in the new table).
Then increase the salaries of all employees with DepartmentID = 1 by 5000.
Finally, select the average salaries in each department.
*/

SELECT * INTO [AverageSalaries]
	FROM [Employees]
   WHERE [Salary] > 30000

DELETE FROM [AverageSalaries]
	WHERE [ManagerID] = 42

UPDATE [AverageSalaries]
	SET [Salary] += 5000
	WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
	FROM [AverageSalaries]
	GROUP BY [DepartmentID]

/*
16. Employees Maximum Salaries
Find the max salary for each department.
Filter those, which have max salaries NOT in the range 30000 – 70000.
*/

SELECT [DepartmentID], MAX([Salary])
	FROM [Employees]
	GROUP BY [DepartmentID]
	HAVING (MAX([Salary]) NOT BETWEEN 30000 AND 70000)

/*
17. Employees Count Salaries
Count the salaries of all employees, who don’t have a manager.
*/
SELECT COUNT(*) AS [Count]
	FROM [Employees]
	WHERE [ManagerID] IS NULL

/*
18. *3rd Highest Salary
Find the third highest salary in each department if there is such. 
*/

SELECT [DepartmentID], [Salary] AS [ThirdHighestSalary]
	FROM(
		SELECT [DepartmentID], [Salary],
		DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
		FROM [Employees]
		GROUP BY DepartmentID, Salary) AS t
	WHERE [Rank] = 3

/*
19. **Salary Challenge
Create a query that returns:
•	FirstName
•	LastName
•	DepartmentID
Select all employees who have salary higher than the average salary of their respective departments.
Select only the first 10 rows. Order them by DepartmentID.
*/

SELECT TOP(10) [FirstName], [LastName], [DepartmentID]
	FROM [Employees] AS [emp]
	WHERE [Salary] > (SELECT AVG([Salary])
						FROM [Employees]
					   WHERE [DepartmentID] = [emp].[DepartmentID]
					GROUP BY ([DepartmentID]))
	ORDER BY [DepartmentID]
