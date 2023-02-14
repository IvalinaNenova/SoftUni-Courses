	--Section 3. Querying (40 pts)
--5. 	Cigars by Price

SELECT CigarName, PriceForSingleCigar, ImageUrl
	FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC

--6.	Cigars by Taste

SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
	FROM Cigars AS c
	JOIN Tastes AS t
	  ON t.Id = c.TastId
	WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
 ORDER BY c.PriceForSingleCigar DESC

 --7.	Clients without Cigars

 SELECT c.Id,
		CONCAT(c.FirstName, ' ', c.LastName) AS ClientName,
		c.Email
	FROM Clients AS c
	LEFT JOIN ClientsCigars AS cc
	  ON cc.ClientId = c.Id
	WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

--8.	First 5 Cigars

SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageUrl
	FROM Cigars AS c
	JOIN Sizes AS s
	  ON s.Id = c.SizeId
   WHERE s.Length >=12 AND (c.CigarName LIKE '%ci%'
	  OR c.PriceForSingleCigar > 50) AND RingRange > 2.55
ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC

--9.	Clients with ZIP Codes

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	   a.Country,
	   a.ZIP,
	   FORMAT(MAX(cig.PriceForSingleCigar), 'c' ) AS CigarPrice
	FROM Clients AS c
	JOIN Addresses AS a
	  ON a.Id = c.AddressId
	JOIN ClientsCigars AS cc
	  ON cc.ClientId = c.Id
	JOIN Cigars AS cig
	  ON cig.Id = cc.CigarId
   WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName ASC

--10.	Cigars by Size

SELECT c.LastName,
	   AVG(s.Length) AS CigarLength,
	   CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients AS c
	JOIN ClientsCigars AS cc
	  ON cc.ClientId = c.Id
	JOIN Cigars AS cig
	  ON cig.Id = cc.CigarId
	JOIN Sizes AS s
	  ON s.Id = cig.SizeId
GROUP BY c.LastName
ORDER BY CigarLength DESC

    --Section 4. Programmability (20 pts)

--11.	Client with Cigars

GO
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	
RETURN (SELECT COUNT(*)
	FROM ClientsCigars AS cc
	JOIN Clients AS c
	  ON c.Id = cc.ClientId
	WHERE c.FirstName = @name
	GROUP BY cc.ClientId)
END
GO

--12.	Search for Cigar with Specific Taste

GO
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName,
	   FORMAT(c.PriceForSingleCigar, 'c') AS Price,
	   t.TasteType,
	   b.BrandName,
	   CONCAT(CAST(s.Length AS VARCHAR(10)), ' ', 'cm') AS CigarLength,
	   CONCAT(CAST(s.RingRange AS VARCHAR(10)), ' ', 'cm') AS CigarRingRange
		FROM Cigars AS c
		JOIN Tastes AS t
		  ON t.Id = c.TastId
		JOIN Sizes AS s
		  ON s.Id = c.SizeId
		JOIN Brands AS b
		  ON b.Id = c.BrandId
		WHERE t.TasteType = @taste
	 ORDER BY s.Length ASC, s.RingRange DESC
GO

EXEC usp_SearchByTaste 'Woody'