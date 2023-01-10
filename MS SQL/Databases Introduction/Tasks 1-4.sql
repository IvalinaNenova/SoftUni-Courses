--1. Create Database
CREATE DATABASE Minions
USE Minions

-- 2.Create Tables
--add table Minions (Id, Name, Age)

CREATE TABLE Minions 
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	Age TINYINT
)

--add new table Towns (Id, Name)
CREATE TABLE Towns 
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(85)
)

--3. Minions table to have a new column TownId that would be of the same type as the Id column in Towns table.
--Add a new constraint that makes TownId foreign key and references to Id column in Towns table.

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--4. Populate both tables with sample records

--       Minions		                 Towns
--Id	Name	Age	  TownId		  Id	Name
--1	    Kevin	22	   1		       1	Sofia
--2	    Bob	    15	   3		       2	Plovdiv
--3	    Steward	NULL   2		       3	Varna

INSERT INTO Towns (Id, Name) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--5. Delete all the data from the Minions table using SQL query

DELETE FROM Minions

--6. Delete all tables from the Minions database using SQL query.

DROP TABLE Minions
DROP TABLE Towns