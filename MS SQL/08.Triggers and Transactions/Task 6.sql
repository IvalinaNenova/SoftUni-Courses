--Part II - Queries for Diablo Database
USE Diablo
/* 6.*Massive Shopping
User Stamat in Safflower game wants to buy some items. He likes all items from Level 11 to 12
as well as all items from Level 19 to 21. As it is a bulk operation you have to use transactions. 
A transaction is the operation of taking out the cash from the user in the current game as well
as adding up the items. 
Write transactions for each level range. If anything goes wrong turn back the changes inside of the transaction.
Extract all of Stamat's item names in the given game sorted by name alphabetically.
*/

--GameID = 87
--StamatID = 9

DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
DECLARE @cash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @itemsPrice MONEY = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END


SET @cash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.Name
	FROM Users AS u
	JOIN UsersGames AS ug
	  ON ug.UserId = u.Id
	JOIN Games AS g
	  ON g.Id = ug.GameId	   
	JOIN UserGameItems AS ugi
	  ON ugi.UserGameId = ug.Id
	JOIN Items AS i
	  ON i.Id = ugi.ItemId
	WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
	ORDER BY i.Name
