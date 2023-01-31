--Part II – Queries for Bank Database

/*
9.	Find Full Name
You are given a database schema with tables AccountHolders(Id (PK), FirstName, LastName, SSN)
and Accounts(Id (PK), AccountHolderId (FK), Balance).
Write a stored procedure usp_GetHoldersFullName that selects the full name of all people. 
*/
USE Bank

GO
CREATE PROC dbo.usp_GetHoldersFullName
AS 
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
		FROM [AccountHolders]
GO

EXEC dbo.usp_GetHoldersFullName

/*
10.	People with Balance Higher Than
Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan
that accepts a number as a parameter and returns all the people,
who have more money in total in all their accounts than the supplied number.
Order them by their first name, then by their last name.
*/

GO
CREATE PROC dbo.usp_GetHoldersWithBalanceHigherThan(@total DECIMAL(18, 4))
AS
	SELECT [FirstName], [LastName]
		FROM [AccountHolders] AS ah
		JOIN [Accounts] AS a 
		  ON a.[AccountHolderId] = ah.[Id]
	GROUP BY [FirstName], [LastName]
	HAVING SUM([Balance]) > @total
	ORDER BY [FirstName], [LastName]
GO

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 15000

/*
11.	Future Value Function
Your task is to create a function ufn_CalculateFutureValue that accepts as parameters
– sum (decimal), yearly interest rate (float), and the number of years (int).
It should calculate and return the future value of the initial sum
rounded up to the fourth digit after the decimal delimiter. Use the following formula:
FV=I×((1+R)^T)
	I – Initial sum
	R – Yearly interest rate
	T – Number of years
*/

GO
CREATE FUNCTION dbo.ufn_CalculateFutureValue(@Sum DECIMAL(15,4), @YearlyRate FLOAT, @Years INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	DECLARE @FutureReturn DECIMAL(15,4);
	SET @FutureReturn = @Sum * POWER((1+@YearlyRate), @Years);
RETURN @FutureReturn;
END
GO

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)

/*
1.	Calculating Interest
Your task is to create a stored procedure usp_CalculateFutureValueForAccount
that uses the function from the previous problem to give an interest to a person's account for 5 years,
along with information about their account id, first name, last name and current balance.
It should take the AccountId and the interest rate as parameters.
Again, you are provided with the dbo.ufn_CalculateFutureValue function, which was part of the previous task.
*/

GO
CREATE PROC dbo.usp_CalculateFutureValueForAccount (@AccountID INT, @InterestRate FLOAT)
AS
	SELECT [a].[Id] AS [Account Id],
		   [ah].[FirstName] AS [First Name],
		   [ah].[LastName] AS [Last Name],
		   [a].[Balance] AS [Current Balance],
		   (SELECT dbo.ufn_CalculateFutureValue ([a].[Balance], @InterestRate, 5)) AS [Balance in 5 years]
		FROM [Accounts] AS [a]
		JOIN [AccountHolders] AS [ah]
		  ON [ah].[Id] = [a].[AccountHolderId]
		WHERE [a].[Id] = @AccountID
GO

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1