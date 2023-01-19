CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(10) NOT NULL,
	EstablishedOn DATE
)
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name])
	 VALUES
('BMW'),
('Tesla'),
('Lada')


INSERT INTO Models([Name], ManufacturerID)
	 VALUES
('X1', 1),
('i6', 1),
('ModelS', 2),
('ModelX', 2),
('Model3', 2),
('Nova', 3)