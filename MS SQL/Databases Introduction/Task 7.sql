CREATE TABLE People 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	CHECK([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Height, [Weight], Gender, Birthdate)
	VALUES
('Pesho', 1.85, 78.50, 'm', '1988-09-27'),
('Gosho', 1.75, 98.50, 'm', '1983-09-05'),
('Maria', 1.68, 48.50, 'f', '1999-12-07'),
('Ivan', 1.95, 91.05, 'm', '1986-05-15'),
('Silvia', 1.77, 55.00, 'f', '1996-11-30')

SELECT * FROM People