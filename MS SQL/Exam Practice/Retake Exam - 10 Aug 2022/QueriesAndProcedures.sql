--Section 3. Querying (40 pts)
--5.	Tourists

USE NationalTouristSitesOfBulgaria
SELECT Name, Age, PhoneNumber, Nationality
	FROM Tourists
	ORDER BY Nationality ASC, AGE DESC, Name ASC

--6.	Sites with Their Location and Category

SELECT s.Name, l.Name, s.Establishment, c.Name 
	FROM Sites AS s
	JOIN Locations AS l
	  ON l.Id = s.LocationId
	JOIN Categories AS c
	  ON c.Id = s.CategoryId
ORDER BY c.Name DESC, l.Name ASC, s.Name ASC

--7.	Count of Sites in Sofia Province

SELECT l.Province, l.Municipality, l.Name AS Location, COUNT(*) AS CountOfSites
	FROM Locations AS l
	JOIN Sites AS s
	  ON s.LocationId = l.Id
   WHERE l.Province = 'Sofia'
   GROUP BY l.Province, l.Municipality,l.Name
   ORDER BY CountOfSites DESC, l.Name ASC


--8.	Tourist Sites established BC

SELECT s.Name, l.Name, l.Municipality, l.Province, s.Establishment 
	FROM Sites AS s 
	JOIN Locations AS l
	  ON l.Id = s.LocationId
	WHERE s.Establishment LIKE '%BC'
	 AND l.Name NOT LIKE '[BMD]%'
ORDER BY s.Name

--9.	Tourists with their Bonus Prizes

SELECT t.Name, 
	   t.Age, 
	   t.PhoneNumber, 
	   t.Nationality, 
	   ISNULL(bp.Name, '(no bonus prize)')
	FROM Tourists AS t
	LEFT JOIN TouristsBonusPrizes AS tbp
	  ON tbp.TouristId = t.Id
	LEFT JOIN BonusPrizes AS bp
	  ON bp.Id = tbp.BonusPrizeId
	ORDER BY t.Name ASC


--10.   Tourists visiting History and Archaeology sites

SELECT SUBSTRING(t.Name, CHARINDEX(' ', t.Name, 1) + 1, LEN(t.Name)) AS LastName, 
	   t.Nationality, 
	   t.Age, 
	   t.PhoneNumber
	FROM Tourists AS t
	JOIN SitesTourists AS st
	  ON st.TouristId = t.Id
	JOIN Sites AS s
	  ON s.Id = st.SiteId
	JOIN Categories AS c
	  ON c.Id = s.CategoryId
	WHERE c.Name = 'History and archaeology'
	GROUP BY t.Name, t.Nationality, t.Age, t.PhoneNumber
	ORDER BY LastName
	 
--11.	Tourists Count on a Tourist Site
GO
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(t.Id)
						FROM Sites AS s
						JOIN SitesTourists AS st
						  ON st.SiteId = s.Id
						JOIN Tourists AS t
						  ON t.Id = st.TouristId
						WHERE s.Name = @Site)
	
	
END
GO
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')

--12.	Annual Reward Lottery

GO
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR (50))
AS
BEGIN

IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 100
	
	BEGIN
			UPDATE Tourists
			SET Reward = 'Gold badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 50
	
	BEGIN
			UPDATE Tourists
			SET Reward = 'Silver badge'
			WHERE Name = @TouristName
	END

ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 25
	
	BEGIN
			UPDATE Tourists
			SET Reward = 'Bronze badge'
			WHERE Name = @TouristName
	END

SELECT Name, Reward FROM Tourists
	WHERE Name = @TouristName

END
GO

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'

