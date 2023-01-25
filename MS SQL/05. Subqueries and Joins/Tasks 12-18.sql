--Part II – Queries for Geography Database

/*
12.	Highest Peaks in Bulgaria
Create a query that selects:
•	CountryCode
•	MountainRange
•	PeakName
•	Elevation
Filter all the peaks in Bulgaria, which have elevation over 2835. Return all the rows, sorted by elevation in descending order.
*/

USE Geography

SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].[Elevation]
		FROM [MountainsCountries] AS [mc]
		JOIN [Mountains] AS [m] 
		  ON [m].[Id] = [mc].[MountainId]
		JOIN [Peaks] AS [p]
		  ON [p].[MountainId] = [m].[Id]
	   WHERE [mc].[CountryCode] = 'BG'
	     AND [p].[Elevation] > 2835
	ORDER BY [p].[Elevation] DESC

/*
13.	Count Mountain Ranges
Create a query that selects:
•	CountryCode
•	MountainRanges
Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
*/

  SELECT [c].[CountryCode], COUNT([mc].[CountryCode]) AS [MountainRanges]
     FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
       ON [c].[CountryCode] = [mc].[CountryCode]
    WHERE [c].[CountryCode] IN ('BG', 'US', 'RU')
 GROUP BY [c].[CountryCode]
   
/*
14.	Countries With or Without Rivers
Create a query that selects:
•	CountryName
•	RiverName
Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
*/

	  SELECT TOP (5)
			 [c].[CountryName], [r].[RiverName]
		FROM [Countries] AS [c]
   LEFT JOIN [CountriesRivers] AS [cr]
		  ON [cr].[CountryCode] = [c].[CountryCode]
   LEFT JOIN [Rivers] AS [r]
		  ON [r].[Id] = [cr].[RiverId]
		WHERE [c].[ContinentCode] = 'AF'
	ORDER BY [c].[CountryName]

/*
15.	*Continents and Currencies
Create a query that selects:
•	ContinentCode
•	CurrencyCode
•	CurrencyUsage
Find all continents and their most used currency. Filter any currency, which is used in only one country.
Sort your results by ContinentCode.
*/

SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage]
	FROM(
		SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyUsage],
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT([CurrencyCode]) DESC) AS [Rank] 
			FROM [Countries]
		GROUP BY [ContinentCode], [CurrencyCode]
		) AS k
	WHERE [Rank] = 1 AND [CurrencyUsage] > 1
	ORDER BY [ContinentCode]

/*
16.	Countries Without Any Mountains
Create a query that returns the count of all countries, which don’t have a mountain.
*/

SELECT COUNT(*) AS [Count]
	FROM (
		SELECT [mc].[MountainId] AS [m]
			FROM [MountainsCountries] AS [mc]
	  RIGHT JOIN [Countries] AS [c]
			  ON [c].[CountryCode] = [mc].[CountryCode]
		WHERE [mc].[MountainId] IS NULL
		) AS k

/*
17.	Highest Peak and Longest River by Country
For each country, find the elevation of the highest peak and the length of the longest river,
sorted by the highest peak elevation (from highest to lowest),
then by the longest river length (from longest to smallest),
then by country name (alphabetically).
Display NULL when no data is available in some of the columns.
Limit only the first 5 rows.
*/

SELECT TOP(5)
				 [c].[CountryName],
			 MAX([p].[Elevation]) AS HighestPeakElevation,
			 MAX([r].[Length]) AS [LongestRiverLength]
			FROM [Countries] AS [c]
	   LEFT JOIN [MountainsCountries] AS [mc]
			  ON [mc].[CountryCode] = [c].[CountryCode]
	   LEFT JOIN [Peaks] AS [p]
			  ON [p].[MountainId] = [mc].[MountainId]
	   LEFT JOIN [CountriesRivers] AS [cr]
			  ON [cr].[CountryCode] = [c].[CountryCode]
	   LEFT JOIN [Rivers] AS [r]
			  ON [r].[Id] = [cr].[RiverId]
		GROUP BY [c].[CountryName]
		ORDER BY [HighestPeakElevation] DESC,
				 [LongestRiverLength] DESC,
			     [c].[CountryName]
		

/*
18.	Highest Peak Name and Elevation by Country
For each country, find the name and elevation of the highest peak, along with its mountain.
When no peaks are available in some countries, display elevation 0, "(no highest peak)" as peak name
and "(no mountain)" as a mountain name.
When multiple peaks in some countries have the same elevation, display all of them.
Sort the results by country name alphabetically, then by highest peak name alphabetically.
Limit only the first 5 rows.
*/

SELECT TOP(5) WITH TIES [c].[CountryName], 
				 ISNULL([p].[PeakName], '(no highest peak)') AS [Highest Peak Name],
				 ISNULL(MAX([p].[Elevation]), 0) AS [Highest Peak Elevation],
				 ISNULL([m].[MountainRange], '(no mountain)') AS [Mountain]
		FROM [Countries] AS [c]
		LEFT JOIN [MountainsCountries] AS [mc]
			ON [mc].[CountryCode] = [c].[CurrencyCode]
		LEFT JOIN [Mountains] AS [m]
			ON [m].[Id] = [mc].[MountainId]
		LEFT JOIN [Peaks] AS [p]
			ON [p].[MountainId] = [m].[Id]
	GROUP BY [c].[CountryName], [p].[PeakName], [m].[MountainRange]
	ORDER BY [c].[CountryName],
			 [Highest Peak Name]