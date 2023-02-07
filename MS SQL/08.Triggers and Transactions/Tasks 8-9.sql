--Part III - Queries for SoftUni Database
USE SoftUni

/*
8.	Employees with Three Projects
Create a procedure usp_AssignProject(@emloyeeId, @projectID) that assigns projects to an employee.
If the employee has more than 3 project throw exception and rollback the changes.
The exception message must be: "The employee has too many projects!" with Severity = 16, State = 1.
*/

GO
CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
	DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)
	
	DECLARE @countProjects INT = (SELECT COUNT(*)FROM EmployeesProjects 
								  WHERE EmployeeID = @emloyeeId)

	IF (@employee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid employee or project', 2
	END
	IF (@countProjects) >= 3
	BEGIN
		ROLLBACK;
		THROW 50002, 'The employee has too many projects!', 1
	END
	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
	(@emloyeeId, @projectID)
COMMIT
GO

/*
9.	Delete Employees
Create a table Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
that will hold information about fired (deleted) employees from the Employees table.
Add a trigger to Employees table that inserts the corresponding information
about the deleted records in Deleted_Employees.
*/

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(150) NOT NULL,
	DepartmentId INT REFERENCES Departments(DepartmentID),
	Salary MONEY NOT NULL
)

GO
CREATE TRIGGER tr_LogDeletedEmployees
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted
GO