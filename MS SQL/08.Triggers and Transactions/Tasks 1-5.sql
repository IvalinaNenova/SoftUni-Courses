--Part I - Queries for Bank Database

USE Bank

/*
1.	Create Table Logs
Create a table – Logs (LogId, AccountId, OldSum, NewSum).
Add a trigger to the Accounts table that enters a new entry into the Logs table
every time the sum on an account change. Submit only the query that creates the trigger.
*/

CREATE TABLE [Logs]
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES [Accounts](Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO
CREATE TRIGGER tr_OnAccountBalanceAddLog
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
		SELECT [i].[Id], [d].[Balance], [i].[Balance] 
			FROM inserted AS i
			JOIN deleted AS d
			  ON d.Id = i.Id
			WHERE [i].Balance != [d].[Balance]
GO

/*
2.	Create Table Emails
Create another table – NotificationEmails(Id, Recipient, Subject, Body).
Add a trigger to logs table and create new email whenever new record is inserted in logs table.
The following data is required to be filled for each email:
•	Recipient – AccountId
•	Subject – "Balance change for account: {AccountId}"
•	Body - "On {date} your balance was changed from {old} to {new}."
*/

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES [Accounts](Id),
	[Subject] NVARCHAR (MAX) NOT NULL, 
	Body NVARCHAR (MAX) NOT NULL
)


GO
CREATE TRIGGER tr_OnNewLogAddEmailNotification
ON [Logs] FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP(1) [AccountId] FROM inserted);
	DECLARE @OldSum MONEY = (Select TOP(1) [OldSum] FROM inserted);
	DECLARE @NewSum MONEY = (Select TOP(1) [NewSum] FROM inserted);

	INSERT INTO [NotificationEmails](Recipient, Subject, Body) 
	VALUES
	(
		@AccountId,
		'Balance change for account: ' + CAST(@AccountId AS NVARCHAR(50)),
		CONCAT('On',' ', GETDATE(), ' your balance was changed from ', CAST(@OldSum AS NVARCHAR(50)), ' to ', CAST(@NewSum AS NVARCHAR(50)), ' .')
	)
GO

/*
3.	Deposit Money
Add stored procedure usp_DepositMoney(AccountId, MoneyAmount) that deposits money to an existing account.
Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after the decimal point.
The procedure should produce exact results working with the specified precision.
*/

GO
CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT [Id] FROM [Accounts] WHERE [Id] = @accountId )
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid Account Number', 1
	END

	IF @moneyAmount < 0
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid deposit amount', 2
	END

UPDATE [Accounts]
	SET [Balance] += @moneyAmount
	WHERE [Id] = @accountId
COMMIT
GO

SELECT * FROM Accounts

EXEC usp_DepositMoney 1, 1000

/*
4.	Withdraw Money Procedure
Add stored procedure usp_WithdrawMoney (AccountId, MoneyAmount) that withdraws money from an existing account.
Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after decimal point.
The procedure should produce exact results working with the specified precision.
*/

GO
CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT [Id] FROM [Accounts] WHERE [Id] = @accountId )
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid Account Number', 1
	END

	IF (SELECT [Balance] FROM [Accounts] WHERE [Id] = @accountId ) < @moneyAmount
	BEGIN
		ROLLBACK;
		THROW 50002, 'Not enough funds!', 2
	END

UPDATE [Accounts]
	SET [Balance] -= @moneyAmount
	WHERE [Id] = @accountId
COMMIT
GO

SELECT * FROM Accounts WHERE Id = 1

EXEC usp_WithdrawMoney 1, 2000

/*
5.	Money Transfer
Create stored procedure usp_TransferMoney(SenderId, ReceiverId, Amount) that transfers money from one account
to another. Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign
after the decimal point. Make sure that the whole procedure passes without errors and if an error occurs
make no change in the database. You can use both: "usp_DepositMoney", "usp_WithdrawMoney"
(look at the previous two problems about those procedures). 
*/

GO
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @senderId, @amount
		EXEC usp_DepositMoney @receiverId, @amount
	COMMIT
GO

SELECT * FROM Accounts WHERE Id IN (1,2)
EXEC usp_TransferMoney 1, 2, 1000