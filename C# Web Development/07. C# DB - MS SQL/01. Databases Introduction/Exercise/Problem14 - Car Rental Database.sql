CREATE DATABASE [CarRental]

USE [CarRental]

-- Categories table
CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) CHECK (DATALENGTH([CategoryName]) >= 3) NOT NULL,
	[DailyRate] DECIMAL(2, 1),
	[WeeklyRate] DECIMAL(2, 1),
	[MonthlyRate] DECIMAL(2, 1),
	[WeekendRate] DECIMAL(2, 1)
)

INSERT INTO [Categories]([CategoryName]) VALUES
('Sedan'),
('Avant'),
('Minivan')

-- Cars table
CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(50) CHECK (DATALENGTH([PlateNumber]) >= 7),
	[Manufacturer] NVARCHAR(15) NOT NULL,
	[Model] NVARCHAR(15) NOT NULL,
	[CarYear] SMALLINT,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] BIT,
	[Picture] VARBINARY(MAX) CHECK (DATALENGTH([Picture]) <= 7 * 1024 * 1024),
	[Condition] VARCHAR(4) CHECK([Condition] = 'New' OR [Condition] = 'Used') NOT NULL,
	[Available] VARCHAR(5) CHECK([Available] = 'true' OR [Available] = 'false') NOT NULL,
)

INSERT INTO [Cars]([Manufacturer], [Model], [CategoryId], [Condition], [Available]) VALUES
('Mercedes-Benz', 'C Class', 2, 'New', 'true'),
('VW', 'Touran', 3, 'Used', 'false'),
('Tesla', 'Model S', 1, 'Used', 'true')

-- Employees table
CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) CHECK (DATALENGTH([FirstName]) >= 3) NOT NULL,
	[LastName] NVARCHAR(50) CHECK (DATALENGTH([LastName]) >= 3) NOT NULL,
	[Title] NVARCHAR(25) DEFAULT 'No title',
	[Notes] NVARCHAR(MAX) DEFAULT 'No employee description'
)

INSERT INTO [Employees]([FirstName], [LastName]) VALUES
('Ivan', 'Ivanov'),
('Petar', 'Petrov'),
('Georgi', 'Georgiev')

-- Customers table
CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(50) CHECK (DATALENGTH([DriverLicenceNumber]) >= 7) NOT NULL,
	[FullName] NVARCHAR(50) CHECK (DATALENGTH([FullName]) >= 3) NOT NULL,
	[Address] NVARCHAR(30) CHECK (DATALENGTH([Address]) >= 3) NOT NULL,
	[City] NVARCHAR(50) CHECK (DATALENGTH([City]) >= 3),
	[ZIPCode] SMALLINT CHECK (DATALENGTH([ZIPCode]) = 4),
	[Notes] NVARCHAR(MAX) DEFAULT 'No customer description'
)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address]) VALUES
('123456789', 'Vancho Vanchov', 'Sofia'),
('987654321', 'Gosho Goshov', 'Varna'),
('123987546', 'Ivanka Ivankova', 'Plovdiv')

-- RentalOrders table
CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] TINYINT,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATE,
	[EndDate] DATE,
	[TotalDays] SMALLINT,
	[RateApplied] DECIMAL(2, 1),
	[TaxRate] DECIMAL(10, 2),
	[OrderStatus] NVARCHAR(MAX) DEFAULT 'No order status',
	[Notes] NVARCHAR(MAX) DEFAULT 'No customer description'
)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId]) VALUES
(1, 2, 3),
(3, 2, 1),
(2, 1, 3)