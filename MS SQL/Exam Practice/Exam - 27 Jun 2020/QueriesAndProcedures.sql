--5.     Mechanic Assignments

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   Status,
	   IssueDate
	FROM Mechanics AS m
	JOIN Jobs AS j
	  ON j.MechanicId = m.MechanicId
ORDER BY j.MechanicId,
		 j.IssueDate,
		 j.JobId

--6.	Current Clients

 SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
 	    DATEDIFF(DAY, IssueDate, '2017-04-24') AS [Days going],
 	    j.Status
		FROM Jobs AS j
		JOIN Clients AS c
		  ON c.ClientId = j.ClientId
	   WHERE j.Status NOT LIKE 'Finished'
	ORDER BY [Days going] DESC,
			 c.ClientId ASC

--7.	Mechanic Performance

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Mechanics AS m
	JOIN Jobs AS j
	  ON j.MechanicId = m.MechanicId
GROUP BY m.FirstName, m.LastName, m.MechanicId
ORDER BY m.MechanicId ASC

--8.	Available Mechanics

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
	 FROM Mechanics AS m
LEFT JOIN Jobs AS j
	   ON j.MechanicId = m.MechanicId
	WHERE m.MechanicId NOT IN (SELECT m.MechanicId
								 FROM Jobs AS j
								 JOIN Mechanics AS m
								   ON m.MechanicId = j.MechanicId
								 WHERE j.Status NOT LIKE 'Finished')
	GROUP BY m.FirstName, m.LastName, m.MechanicId
	ORDER BY m.MechanicId 

--9.	Past Expenses

SELECT j.JobId, SUM(p.Price * pn.Quantity) AS Total
	FROM Jobs AS j
	JOIN PartsNeeded AS pn
	  ON pn.JobId = j.JobId
	JOIN Parts AS p
	  ON p.PartId = pn.PartId
   WHERE j.Status LIKE 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC

--10.	Missing Parts

