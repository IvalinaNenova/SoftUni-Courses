USE Hotel

--Problem 23.	Decrease Tax Rate: decrease tax rate by 3%

UPDATE [Payments]
	SET [TaxRate] = [TaxRate] * 0.97

SELECT [TaxRate] FROM [Payments]

--Problem 24.	Delete All Records
TRUNCATE TABLE Occupancies
