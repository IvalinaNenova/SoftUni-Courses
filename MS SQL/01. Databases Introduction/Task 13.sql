CREATE DATABASE Movies

USE Movies

--•	Directors (Id, DirectorName, Notes)
CREATE TABLE Directors
(
	Id INT PRIMARY KEY,
	DirectorName NVARCHAR(80) NOT NULL,
	Notes NVARCHAR(MAX)
)
--•	Genres (Id, GenreName, Notes)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
--•	Categories (Id, CategoryName, Notes)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title VARCHAR(250) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear SMALLINT NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating TINYINT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (Id, DirectorName) VALUES
(1, 'Guy Ritchie'),
(2, 'Tarantino'),
(3, 'Peter Jackson'),
(4, 'Ben Aflec'),
(5, 'Martin Scorsese')

INSERT INTO Genres (Id, GenreName, Notes) VALUES
(1, 'Thriller', 'some note'),
(2, 'Mystery', null),
(3, 'Action', null),
(4, 'Romance', 'other note'),
(5, 'Fantasy', null)

INSERT INTO Categories (Id, CategoryName, Notes) VALUES
(1, 'Musicals', null),
(2, 'Comedy', 'note'),
(3, 'Sci-Fi', 'another note'),
(4, 'Horror', 'note'),
(5, 'Young Adult', null)

INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
(1, 'Harry Potter', 1, 2005, '1:45', 1, 2, 8, 'some note'),
(2, 'Lord of the Rings', 3, 2000, '1:45', 1, 2, 8, 'some note'),
(3, 'Argo', 4, 2006, '1:45', 1, 2, 8, 'some note'),
(4, 'Mission Impossible', 2, 2012, '1:45', 1, 2, 8, 'some note'),
(5, 'Wild Wild West', 5, 2000, '1:45', 1, 2, 8, 'some note')
