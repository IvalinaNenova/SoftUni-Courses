--5.	Unassigned Reports

SELECT Description,
	   FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
	FROM Reports AS r
   WHERE EmployeeId IS NULL
   ORDER BY r.OpenDate ASC, r.Description ASC

--6.	Reports & Categories

SELECT r.Description, c.Name
	FROM Reports AS r
	JOIN Categories AS c
	  ON c.Id = r.CategoryId
ORDER BY r.Description ASC, c.Name ASC

--7.	Most Reported Category

SELECT TOP(5)
	   c.Name AS CategoryName,
	   COUNT(*) AS ReportsNumber
	FROM Categories AS c
	JOIN Reports AS r
	  ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC

--8.	Birthday Report

SELECT u.Username, c.Name AS CategoryName
	FROM Reports AS r
	JOIN Users AS u
	  ON u.Id = r.UserId
	JOIN Categories AS c
	  ON c.Id = r.CategoryId
	WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate)
	  AND DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
 ORDER BY u.Username ASC, c.Name ASC 

 --9.	Users per Employee 

 SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
		COUNT(r.UserId) AS UsersCount
	FROM Reports AS r
	RIGHT JOIN Employees AS e
	  ON e.Id = r.EmployeeId
GROUP BY r.EmployeeId, e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName ASC

--10.	Full Info

 SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
		ISNULL(d.Name, 'None') AS Department,
		c.Name AS Category,
		r.Description,
		FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		s.[Label] AS [Status],
		ISNULL(u.Name, 'None') AS [User]
		FROM Reports AS r
   LEFT JOIN Employees AS e
		  ON e.Id = r.EmployeeId
   LEFT JOIN Categories AS c
		  ON c.Id = r.CategoryId
   LEFT JOIN Departments AS d
		  ON d.Id = e.DepartmentId
   LEFT JOIN Status AS s
		  ON s.Id = r.StatusId
   LEFT JOIN Users AS u
		  ON u.Id = r.UserId
   ORDER BY e.FirstName DESC,
			e.LastName DESC,
			d.Name ASC,
			c.Name ASC,
			r.Description ASC,
			r.OpenDate ASC,
			s.Id ASC,
			u.Name ASC

--11.	Hours to Complete

GO
CREATE FUNCTION dbo.udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
DECLARE @hoursToComplete INT = DATEDIFF(HOUR, @StartDate, @EndDate)
	IF (@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0
RETURN @hoursToComplete
END
GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12.	Assign Employee

GO
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @employeeDepartment INT = (SELECT DepartmentId
											FROM Employees
											WHERE Id = @EmployeeId)

	DECLARE @reportDepartment INT = (SELECT c.DepartmentId
										FROM Reports AS r
										JOIN Categories AS c
										  ON c.Id = r.CategoryId
									   WHERE r.Id = @ReportId)

IF @employeeDepartment != @reportDepartment
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

ELSE
	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
GO