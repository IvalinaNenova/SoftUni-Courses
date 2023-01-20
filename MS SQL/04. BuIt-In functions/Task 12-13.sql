				--Part II – Queries for Geography Database
USE Geography
/*
12.	Countries Holding 'A' 3 or More Times
Find all countries which hold the letter 'A' at least 3 times in their name (case-insensitively).
Sort the result by ISO code and display the "Country Name" and "ISO Code". 
*/

SELECT CountryName, IsoCode
	FROM Countries
		WHERE CountryName LIKE '%a%a%a%'
		ORDER BY IsoCode


/*
13.	 Mix of Peak and River Names
Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name.
Display the peak names, river names and the obtained mix (mix should be in lowercase).
Sort the results by the obtained mix.
*/

SELECT p.PeakName,
	   r.RiverName,
	   LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
	FROM Peaks AS p,
		 Rivers AS r
		 WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
		 ORDER BY Mix
		