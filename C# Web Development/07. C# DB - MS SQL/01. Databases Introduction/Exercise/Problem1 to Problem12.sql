-- Problem 1. - Create Database
CREATE DATABASE [Minions]

USE [Minions]

-- Problem 2. - Create Tables
CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT,
)

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
)

-- Problem 3. - Alter Minions Table
-- Add column 
ALTER TABLE [Minions]
ADD [TownId] INT

-- Add foreign key to the new column
ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

-- ( !!! BETTER !!! ) Add column and instantly add foreign key to it
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

-- Problem 4. - Insert Records in Both Tables
INSERT INTO [Towns]([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

-- Problem 5. - Truncate Table Minions
TRUNCATE TABLE [Minions]

-- Problem 6. - Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

-- Problem 7. - Create Table People
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK (DATALENGTH([Picture]) <= 2 * 1024 * 1024),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR CHECK([Gender] = 'm' OR [Gender] = 'f') NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX),
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate]) VALUES
('Pesho', 1.69, 59.0, 'm', '01.01.2000'),
('Gosho', NULL, NULL, 'm', '08.22.1999'),
('Maria', 1.69, 59.0, 'f', '11.15.1990'),
('Ivan', 1.90, 90.3, 'm', '07.03.2000'),
('Ani', 1.90, 70.2, 'f', '09.09.2000')

-- Problem 8. - Create Table Users
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5) CHECK([IsDeleted] = 'true' OR [IsDeleted] = 'false') NOT NULL,
)

INSERT INTO [Users]([Username], [Password], [IsDeleted]) VALUES
('VanchoHacka', 'silnaparola123', 'false'),
('GoshoSekirata', 'posilnaparola123', 'false'),
('PeshoSlepoto', 'slabpass', 'true'),
('GoshkaManiqta', '123456789', 'false'),
('VladoMonitora', 'neznambrat', 'true')

-- Problem 9. - Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07C4BF7BDD]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY ([Id], [Username])

-- Problem 10. - Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [Check_UserPasswordLength] CHECK (DATALENGTH([Password]) >= 5)

-- Problem 11. - Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT [default_LastLoginTime] DEFAULT CURRENT_TIMESTAMP FOR [LastLoginTime]

-- Problem 12. - Se Unique Field
ALTER TABLE [Users]
ADD CONSTRAINT [Check_UserUsernameLength] CHECK (DATALENGTH([Username]) >= 3)