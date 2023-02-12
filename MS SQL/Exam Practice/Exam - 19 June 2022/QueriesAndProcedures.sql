--Section 3. Querying (40 pts)

--5.  VOLUNTEERS

SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
	FROM Volunteers
	ORDER BY Name ASC, AnimalId ASC, DepartmentId ASC

--6. Animals data

SELECT a.Name,
	   at.AnimalType, 
	   FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
	FROM Animals AS a
	JOIN AnimalTypes AS at
	  ON at.Id = a.AnimalTypeId
	ORDER BY a.Name

--7.	Owners and Their Animals

SELECT TOP(5) o.Name, COUNT(a.Id) AS CountOfAnimals
	FROM Owners AS o
	JOIN Animals AS a
	  ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, o.Name

--8.	Owners, Animals and Cages

SELECT CONCAT(o.Name, '-', a.Name) AS OwnersAnimals,
	   o.PhoneNumber,
	   ac.CageId AS CageId
	FROM Owners AS o
	JOIN Animals AS a
	  ON a.OwnerId = o.Id
	JOIN AnimalTypes AS at
	  ON at.Id = a.AnimalTypeId
	JOIN AnimalsCages AS ac
	  ON ac.AnimalId = a.Id
	WHERE at.AnimalType = 'Mammals'
 ORDER BY o.Name ASC, a.Name DESC

 --9.	Volunteers in Sofia
 SELECT v.Name,
		v.PhoneNumber,
		SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 2, LEN(v.Address)) AS Address
	FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd
	  ON vd.Id = v.DepartmentId
   WHERE vd.Id = 2 AND v.Address LIKE '%Sofia%'
ORDER BY v.Name ASC

--10.	Animals for Adoption

SELECT a.Name,
	   FORMAT(a.BirthDate, 'yyyy') AS BirthYear,
	   at.AnimalType
	FROM Animals AS a
	JOIN AnimalTypes AS at
	  ON at.Id = a.AnimalTypeId
	WHERE a.OwnerId IS NULL 
	  AND at.AnimalType NOT LIKE 'Birds'
	  AND DATEPART(YEAR, BirthDate) > 2017
 ORDER BY a.Name 

 --    Section 4. Programmability (20 pts)

--11.	All Volunteers in a Department

GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT 
AS
BEGIN
	
DECLARE @count INT = (SELECT COUNT(*)
			FROM VolunteersDepartments AS vd
			JOIN Volunteers AS v
			  ON v.DepartmentId = vd.Id
		   WHERE vd.DepartmentName = @VolunteersDepartment
		GROUP BY DepartmentName)
RETURN @count
END
GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--12.	Animals with Owner or Not

GO
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
	SELECT a.Name,
	   ISNULL(o.Name, 'For adoption') AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o
	  ON o.Id = a.OwnerId
	WHERE a.Name = @AnimalName
GO

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
