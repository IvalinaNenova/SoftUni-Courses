--Part I – Queries for Gringotts Database

/*
1. Records' Count
Import the database and send the total count of records from the one and only table to Mr. Bodrog.
Make sure nothing gets lost.
*/

USE Gringotts

SELECT COUNT(*) FROM [WizzardDeposits]

/*
2. Longest Magic Wand
Select the size of the longest magic wand. Rename the new column appropriately.
*/

SELECT MAX([MagicWandSize]) AS LongestMagicWand
	FROM [WizzardDeposits]

/*
3. Longest Magic Wand Per Deposit Groups
For wizards in each deposit group show the longest magic wand. Rename the new column appropriately.
*/

SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

/*
4. Smallest Deposit Group Per Magic Wand Size
Select the two deposit groups with the lowest average wand size.
*/

SELECT TOP(2) [DepositGroup] 
	FROM (
		SELECT [DepositGroup], AVG([MagicWandSize]) AS AvgSize
			FROM [WizzardDeposits]
			GROUP BY [DepositGroup]) AS t
	ORDER BY AvgSize ASC

/*
5. Deposits Sum
Select all deposit groups and their total deposit sums.
*/

SELECT [DepositGroup], SUM([DepositAmount]) AS TotalSum
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

/*
6. Deposits Sum for Ollivander Family
Select all deposit groups and their total deposit sums,
but only for the wizards, who have their magic wands crafted by the Ollivander family.
*/

SELECT [DepositGroup], SUM([DepositAmount]) AS TotalSum
	FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]

/*
7. Deposits Filter
Select all deposit groups and their total deposit sums, but only for the wizards,
who have their magic wands crafted by the Ollivander family. Filter total deposit amounts lower than 150000.
Order by total deposit amount in descending order.
*/
	
SELECT [DepositGroup], SUM([DepositAmount]) AS TotalSum
	FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]
	HAVING SUM([DepositAmount]) < 150000
	ORDER BY [TotalSum] DESC

/*
8.  Deposit Charge
Create a query that selects:
•	Deposit group 
•	Magic wand creator
•	Minimum deposit charge for each group 
Select the data in ascending order by MagicWandCreator and DepositGroup.
*/

SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge]
		FROM [WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]
	ORDER BY [MagicWandCreator] ASC, [DepositGroup] ASC

/*
9. Age Groups
Write down a query that creates 7 different groups based on their age.
Age groups should be as follows:
•	[0-10]
•	[11-20]
•	[21-30]
•	[31-40]
•	[41-50]
•	[51-60]
•	[61+]
The query should return
•	Age groups
•	Count of wizards in it
*/

SELECT [AgeGroup], COUNT(*) AS [WizardCount]
  FROM(SELECT [Age],
		CASE
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup]
		FROM [WizzardDeposits]) AS a
  GROUP BY [AgeGroup]

/*
10. First Letter
Create a query that returns all the unique wizard first letters of their first names
only if they have deposit of type Troll Chest. Order them alphabetically. Use GROUP BY for uniqueness.
*/

SELECT SUBSTRING([FirstName], 1, 1) AS [FirstLetter]
	FROM [WizzardDeposits]
	WHERE [DepositGroup] = 'Troll Chest'
	GROUP BY SUBSTRING([FirstName], 1, 1)

/*
11. Average Interest 
Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups,
split by whether the deposit has expired or not. But that's not all.
He wants you to select deposits with start date after 01/01/1985.
Order the data descending by Deposit Group and ascending by Expiration Flag.
*/

SELECT [DepositGroup], [IsDepositExpired], AVG(DepositInterest) AS [AverageInterest]
		 FROM [WizzardDeposits]
		WHERE [DepositStartDate] > '1985-01-01'
	 GROUP BY [DepositGroup], [IsDepositExpired]
	 ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC

/*
12. *Rich Wizard, Poor Wizard
Mr. Bodrog definitely likes his werewolves more than you. This is your last chance to survive!
Give him some data to play his favorite game Rich Wizard, Poor Wizard. The rules are simple: 
You compare the deposits of every wizard with the wizard after him.
If a wizard is the last one in the database, simply ignore it.
In the end you have to sum the difference between the deposits.
*/

SELECT SUM([guest].[DepositAmount] - [host].[DepositAmount]) AS [SumDifference]
	FROM [WizzardDeposits] AS host
	JOIN [WizzardDeposits] AS guest ON guest.Id + 1 = host.Id