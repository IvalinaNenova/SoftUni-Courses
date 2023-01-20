				--Part IV – Date Functions Queries
/*
18.	 Orders Table
You are given a table Orders(Id, ProductName, OrderDate) filled with data.
Consider that the payment for that order must be accomplished within 3 days after the order date.
Also the delivery date is up to 1 month.
Write a query to show each product's name, order date, pay and deliver due dates.
*/
USE Orders

SELECT ProductName, OrderDate,
	   DATEADD(DAY, 3, OrderDate ) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM Orders