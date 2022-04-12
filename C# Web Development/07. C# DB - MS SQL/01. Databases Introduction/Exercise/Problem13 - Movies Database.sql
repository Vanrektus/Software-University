CREATE DATABASE [Movies]

USE [Movies]

-- Directors table
CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) CHECK (DATALENGTH([DirectorName]) >= 3) NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No director description'
)

INSERT INTO [Directors]([DirectorName]) VALUES
('Pesho'),
('Gosho'),
('Tosho'),
('Sasho'),
('Gesho')

-- Genres table
CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) CHECK (DATALENGTH([GenreName]) >= 3) NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No genre description'
)

INSERT INTO [Genres]([GenreName]) VALUES
('Action'),
('Horror'),
('Fantasy'),
('Sci-Fi'),
('Criminal')

-- Categories table
CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) CHECK (DATALENGTH([CategoryName]) >= 3) NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No category description'
)

INSERT INTO [Categories]([CategoryName]) VALUES
('Movie'),
('Series'),
('TV Show'),
('Documentary'),
('Short Video')

-- Movies table
CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) CHECK (DATALENGTH([Title]) >= 2) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] SMALLINT,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2, 1),
	[Notes] NVARCHAR(MAX) DEFAULT 'No movie description'
)

INSERT INTO [Movies]([Title], [DirectorId], [Length], [GenreId], [CategoryId]) VALUES
('Thor', 2, '02:12:30', 4, 1),
('Peaky Blinders', 1, '00:55:35', 5, 2),
('Asd', 4, '00:00:59', 3, 5),
('Test', 5, '00:45:00', 3, 4),
('Survivor', 3, '01:10:10', 1, 3)