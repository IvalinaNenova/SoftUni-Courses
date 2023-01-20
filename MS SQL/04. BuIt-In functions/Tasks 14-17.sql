					--Part III – Queries for Diablo Database
USE Diablo
/*
14.	Games from 2011 and 2012 Year
Find and display the top 50 games which start date is from 2011 and 2012 year.
Order them by start date, then by name of the game.
The start date should be in the following format: "yyyy-MM-dd". 
*/

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE (SELECT YEAR([Start])) IN (2011, 2012)
	ORDER BY [Start], [Name]

/*
15.	 User Email Providers
Find all users with information about their email providers.
Display the username and email provider.
Sort the results by email provider alphabetically, then by username. 
*/
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
	AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username
/*
16.	 Get Users with IP Address Like Pattern
Find all users with their IP addresses, sorted by username alphabetically.
Display only the rows which IP address matches the pattern: "***.1^.^.***". 
Legend: 
* - one symbol
^ - one or more symbols
*/

SELECT Username, IpAddress
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

/*
17.	 Show All Games with Duration and Part of the Day
Find all games with part of the day and duration.
Sort them by game name alphabetically, then by duration (alphabetically, not by the timespan) and part of the day (all ascending).
Part of the Day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24).
Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration). 
*/
SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]