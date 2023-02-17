CREATE DATABASE WMS

USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL REFERENCES Models(ModelId),
	Status VARCHAR(11) 
	CHECK(Status IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
	ClientId INT NOT NULL REFERENCES Clients(ClientId),
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT 1
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	Description VARCHAR(255),
	Price MONEY CHECK(Price BETWEEN 1 AND 9999.99),
	VendorId INT NOT NULL REFERENCES Vendors(VendorId),
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL REFERENCES Orders(OrderId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1,
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1,
	PRIMARY KEY (JobId, PartId)
)

--2.	Insert

INSERT INTO Clients(FirstName, LastName, Phone) VALUES
('Teri',	'Ennaco',	'570-889-5187'),
('Merlyn',	'Lawler',	'201-588-7810'),
('Georgene',	'Montezuma',	'925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke',	'631-748-6479'),
('Melodie',	'Knipp',	'805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')

INSERT INTO Parts(SerialNumber, Description, Price, VendorId) VALUES
('WP8182119',	'Door Boot Seal',	117.86,	2),
('W10780048',	'Suspension Rod',	42.81,	1),
('W10841140',	'Silicone Adhesive', 	6.77,	4),
('WPY055980',	'High Temperature Adhesive',	13.94,	3)

--3.	Update

SELECT * FROM Mechanics
	WHERE FirstName = 'Ryan' AND LastName = 'Harnos'
	SELECT * FROM JOBS
UPDATE Jobs
	SET MechanicId = 3
	WHERE Status = 'Pending'

UPDATE Jobs
	SET Status = 'In Progress'
	WHERE Status = 'Pending'

