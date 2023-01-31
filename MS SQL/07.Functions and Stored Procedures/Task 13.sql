--Part III – Queries for Diablo Database
USE Diablo

/*
1.	*Scalar Function: Cash in User Games Odd Rows
Create a function ufn_CashInUsersGames that sums the cash of the odd rows.
Rows must be ordered by cash in descending order.
The function should take a game name as a parameter and return the result as a table.
Submit only your function in.
Execute the function over the following game names, ordered exactly like: "Love in a mist".
*/

GO
CREATE FUNCTION dbo.ufn_CashInUsersGames(@game NVARCHAR(50))
RETURNS TABLE
AS
		RETURN (SELECT SUM([Cash]) AS [SumCash]
			FROM (SELECT [g].[Name], [ug].[Cash], ROW_NUMBER() OVER (ORDER BY [ug].[Cash] DESC) AS [Row]
					FROM [Games] AS [g]
					JOIN [UsersGames] AS [ug]
					  ON [ug].[GameId] = [g].[Id]
				   WHERE [g].[Name] = @game) AS [temp]
			WHERE [Row] % 2 != 0)

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')
