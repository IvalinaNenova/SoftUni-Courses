CREATE DATABASE [Online Store]

USE [Online Store]

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(85) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID)
	CONSTRAINT PK_Order_Items PRIMARY KEY (OrderID, ItemID)
)