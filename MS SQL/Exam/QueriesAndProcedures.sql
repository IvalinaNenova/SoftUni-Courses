--05.

SELECT Name, Rating
	FROM Boardgames
	ORDER BY YearPublished, Name DESC

--06.

SELECT b.Id, b.Name, b.YearPublished, c.Name AS CategoryName
	FROM Boardgames AS b
	JOIN Categories AS c
	  ON c.Id = b.CategoryId
   WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC

--07.

SELECT c.Id,
	   CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
	   c.Email
	FROM Creators AS c
	LEFT JOIN CreatorsBoardgames AS cb
	  ON cb.CreatorId = c.Id
	WHERE cb.BoardgameId IS NULL
	ORDER BY CreatorName ASC

--08.

SELECT TOP(5) b.Name, b.Rating, c.Name
	FROM Boardgames AS b
	JOIN PlayersRanges AS pr
	  ON pr.Id = b.PlayersRangeId
	JOIN Categories AS c
	  ON c.Id = b.CategoryId
	WHERE (b.Rating > 7 AND b.Name LIKE '%a%')
	   OR (b.Rating > 7.50 AND (pr.PlayersMin = 2 AND pr.PlayersMax = 5))
ORDER BY b.Name ASC, b.Rating DESC

--09.

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, 
	   c.Email, 
	   MAX(b.Rating) AS Rating
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cb
	  ON cb.CreatorId = c.Id
	JOIN Boardgames AS b
	  ON b.Id = cb.BoardgameId
	WHERE Email LIKE '%.com'
 GROUP BY c.FirstName, c.LastName, c.Email
 ORDER BY FullName ASC

 --10. 

 SELECT c.LastName,
	    CEILING(AVG(b.Rating)) AS AverageRating, p.Name AS PublisherName
	FROM Creators AS c
	JOIN CreatorsBoardgames cb
	  ON cb.CreatorId = c.Id
	JOIN Boardgames AS b
	  ON b.Id = cb.BoardgameId
	JOIN Publishers AS p
	  ON p.Id = b.PublisherId
	WHERE p.Name = 'Stonemaier Games'
	GROUP BY c.LastName, p.Name
	ORDER BY AVG(b.Rating) DESC


--11.
GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(cb.BoardgameId)
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cb
	  ON cb.CreatorId = c.Id
	WHERE c.FirstName = @name)
END
GO

--12
GO
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
	SELECT b.Name,
	   b.YearPublished,
	   b.Rating,
	   c.Name AS CategoryName,
	   p.Name AS PublisherName,
	   CONCAT(CAST(pr.PlayersMin AS VARCHAR(2)), ' ', 'people') AS MinPlayers,
	   CONCAT(CAST(pr.PlayersMax AS VARCHAR(2)), ' ', 'people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c
	  ON c.Id = b.CategoryId
	JOIN Publishers AS p
	  ON p.Id = b.PublisherId
	JOIN PlayersRanges AS pr
	  ON pr.Id = b.PlayersRangeId
	WHERE c.Name = @category
	ORDER BY p.Name ASC, b.YearPublished DESC

GO

SELECT b.Name,
	   b.YearPublished,
	   b.Rating,
	   c.Name AS CategoryName,
	   p.Name AS PublisherName,
	   CONCAT(CAST(pr.PlayersMin AS VARCHAR(2)), ' ', 'people') AS MinPlayers,
	   CONCAT(CAST(pr.PlayersMax AS VARCHAR(2)), ' ', 'people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c
	  ON c.Id = b.CategoryId
	JOIN Publishers AS p
	  ON p.Id = b.PublisherId
	JOIN PlayersRanges AS pr
	  ON pr.Id = b.PlayersRangeId
	WHERE c.Name = 'Wargames'
	ORDER BY p.Name ASC, b.YearPublished DESC