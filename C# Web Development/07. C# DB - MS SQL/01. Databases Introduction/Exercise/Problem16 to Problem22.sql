-- Problem 16.
CREATE DATABASE [SoftUni]

USE [SoftUni]

-- Towns table
CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) CHECK (DATALENGTH([Name]) >= 3) NOT NULL,
)

-- Addresses table
CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(50) CHECK (DATALENGTH([AddressText]) >= 3) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

-- Departments table
CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) CHECK (DATALENGTH([Name]) >= 3) NOT NULL,
)

-- Employees table
CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) CHECK (DATALENGTH([FirstName]) >= 3) NOT NULL,
	[MiddleName] NVARCHAR(50) CHECK (DATALENGTH([MiddleName]) >= 3) NOT NULL,
	[LastName] NVARCHAR(50) CHECK (DATALENGTH([LastName]) >= 3) NOT NULL,
	[JobTitle] NVARCHAR(50) CHECK (DATALENGTH([JobTitle]) >= 3) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
	[HireDate] DATE,
	[Salary] DECIMAL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

-- Problem 19. - Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

-- Problem 20. - Basic Select All Fields and Order Them
SELECT * FROM [Towns] ORDER BY [Name]
SELECT * FROM [Departments] ORDER BY [Name]
SELECT * FROM [Employees] ORDER BY [Salary] DESC

-- Problem 21. - Basic Select Some Fields
SELECT [Name] FROM [Towns] ORDER BY [Name]
SELECT [Name] FROM [Departments] ORDER BY [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC

-- Problem 22. - Increase Employees Salary
UPDATE [Employees]
SET [Salary] = [Salary] * 1.1

SELECT [Salary] FROM [Employees]