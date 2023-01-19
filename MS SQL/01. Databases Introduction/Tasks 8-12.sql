/* Problem 8.	Create Table Users
•	Id – unique number for every user. There will be no more than 263-1 users. (Auto incremented)
•	Username – unique identifier of the user. It will be no more than 30 characters (non Unicode). (Required)
•	Password – password will be no longer than 26 characters (non Unicode). (Required)
•	ProfilePicture – image with size up to 900 KB. 
•	LastLoginTime
•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
*/

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('fooling', 'fofdhgol123', 'https://avatars.githubusercontent.com/u/102156386?s=64&v=4', '5/25/2022', 0),
('mimi', 'fowerol123', 'https://avatars.githubusercontent.com/u/102156386?s=64&v=4', '11/22/2022', 0),
('farsecape', 'foofgfhl123', 'https://avatars.githubusercontent.com/u/102156386?s=64&v=4', '11/26/2022', 0),
('bananas', 'foodl123', 'https://avatars.githubusercontent.com/u/102156386?s=64&v=4', '11/25/2022', 0),
('prequel', 'foodsdsfl123', 'https://avatars.githubusercontent.com/u/102156386?s=64&v=4', '12/25/2022', 0)

--Problem 9.	Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07CD393CA3]

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

--Problem 10.	Add Check Constraint - values in the Password field are at least 5 symbols long.

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN ([Password]) > 5)

--Problem 11.	Set Default Value of a Field - default value of LastLoginTime field to be the current time.

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

/*Problem 12.	Set Unique Field
Remove Username field from the primary key
*/

ALTER TABLE Users
DROP CONSTRAINT [PK_IdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

--Add unique constraint to the Username field to ensure that the values there are at least 3 symbols long.

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN (Username) > 3)