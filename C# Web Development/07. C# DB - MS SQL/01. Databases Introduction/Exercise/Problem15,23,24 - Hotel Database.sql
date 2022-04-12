CREATE DATABASE [Hotel]

USE [Hotel]

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
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) CHECK (DATALENGTH([FirstName]) >= 3) NOT NULL,
	[LastName] NVARCHAR(50) CHECK (DATALENGTH([LastName]) >= 3) NOT NULL,	
	[PhoneNumber] NVARCHAR(50) CHECK (DATALENGTH([PhoneNumber]) >= 7) NOT NULL,
	[EmergencyName] NVARCHAR(15),
	[EmergencyNumber] SMALLINT,
	[Notes] NVARCHAR(MAX) DEFAULT 'No customer description'
)

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber]) VALUES
('Ivan', 'Ivanov', '123456789'),
('Petar', 'Petrov', '987654321'),
('Georgi', 'Georgiev', '123987546')

-- RoomStatus table
CREATE TABLE [RoomStatuses](
	[RoomStatus] NCHAR(4) CHECK([RoomStatus] = 'Free' OR [RoomStatus] = 'Busy') PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No room description'
)

INSERT INTO [RoomStatuses]([RoomStatus]) VALUES
('Free'),
('Busy')

-- RoomTypes table
CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(25) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No room description'
)

INSERT INTO [RoomTypes]([RoomType]) VALUES
('Single Room'),
('Double Room'),
('Suite')

-- BedTypes table
CREATE TABLE [BedTypes](
	[BedType] NVARCHAR(25) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No room description'
)

INSERT INTO [BedTypes]([BedType]) VALUES
('Single bedded'),
('Twin bedded'),
('King-sized bed')

-- Rooms table
CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomTypeId] NVARCHAR(25) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
	[BedTypeId] NVARCHAR(25) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
	[Rate] DECIMAL(2, 1),
	[RoomStatusId] NCHAR(4) FOREIGN KEY REFERENCES [RoomStatuses]([RoomStatus]) NOT NULL,
	[Notes] NVARCHAR(MAX) DEFAULT 'No room description'
)

INSERT INTO [Rooms]([RoomTypeId], [BedTypeId], [RoomStatusId]) VALUES
('Single Room', 'Single bedded', 'Busy'),
('Double Room', 'Twin bedded', 'Busy'),
('Suite', 'King-sized bed', 'Free')

-- Payments table
CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[PaymentDate] DATETIME NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays] AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied]),
	[AmountCharged] DECIMAL(7, 2) NOT NULL,
	[TaxRate] DECIMAL(6,2),
	[TaxAmount] AS [AmountCharged] * [TaxRate],
	[PaymentTotal] AS [AmountCharged] + [AmountCharged] * [TaxRate],
	[Notes] NVARCHAR(MAX) DEFAULT 'No payment description'
)

INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber], [AmountCharged]) VALUES
(1, '2011-11-25', 1, 200.0),
(2, '2014-06-03', 2, 440.0),
(3, '2016-02-25', 3, 870.0)

-- Occupancies table
CREATE TABLE [Occupancies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
	[RateApplied] DECIMAL(7, 2),
	[PhoneCharge] DECIMAL(8, 2),
	[Notes] NVARCHAR(MAX) DEFAULT 'No occupancy description'
)

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber]) VALUES
(1, '2011-02-04', 1, 1),
(2, '2015-04-09', 2, 2),
(3, '2012-06-08', 3, 3)

-- Problem 23. - Decrease Tax Rate
UPDATE [Payments]
SET [TaxRate] -= [TaxRate] * 0.03

SELECT [TaxRate] FROM [Payments]

-- Problem 24. - Delete All Records
TRUNCATE TABLE [Occupancies]


-- =========================== !!! NOT MINE !!! =========================== --
CREATE TABLE Employees (
	 Id INT CONSTRAINT PK_Employees PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,Title NVARCHAR(50) CONSTRAINT UC_Title UNIQUE NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Customers (
	 AccountNumber INT CONSTRAINT PK_Customers PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,PhoneNumber NVARCHAR(30)
	,EmergencyName NVARCHAR(50)
	,EmergencyNumber NVARCHAR(50)
	,Notes NVARCHAR(200) 
)

CREATE TABLE RoomStatus (
	 RoomStatus NVARCHAR(50) CONSTRAINT PK_RoomStatus PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE RoomTypes (
	 RoomType NVARCHAR(50) CONSTRAINT PK_RoomTypes PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE BedTypes (
	 BedType NVARCHAR(50) CONSTRAINT PK_BedType PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Rooms (
	 RoomNumber INT CONSTRAINT PK_Rooms PRIMARY KEY NOT NULL
	,RoomType NVARCHAR(50) CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL
	,BedType NVARCHAR(50) CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL
	,Rate DECIMAL(6,2) NOT NULL
	,RoomStatus BIT NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Payments (
	 Id INT CONSTRAINT PK_Payments PRIMARY KEY IDENTITY
	,EmployeeId INT CONSTRAINT FK_Payments_Employees FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,PaymentDate DATETIME NOT NULL
	,AccountNumber INT CONSTRAINT FK_Payments_Customers FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,FirstDateOccupied DATE NOT NULL
	,LastDateOccupied DATE NOT NULL
	,TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied)
	,AmountCharged DECIMAL(7, 2) NOT NULL
	,TaxRate DECIMAL(6,2) NOT NULL
	,TaxAmount AS AmountCharged * TaxRate
	,PaymentTotal AS AmountCharged + AmountCharged * TaxRate
	,Notes NVARCHAR(200)
)

CREATE TABLE Occupancies (
	 Id INT CONSTRAINT PK_Occupancies PRIMARY KEY IDENTITY
	,EmployeeId INT CONSTRAINT FK_Occupancies_Employees FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,DateOccupied DATE NOT NULL
	,AccountNumber INT CONSTRAINT FK_Occupancies_Customers FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,RoomNumber INT CONSTRAINT FK_Occupancies_Rooms FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL
	,RateApplied DECIMAL(7, 2) NOT NULL
	,PhoneCharge DECIMAL(8, 2) NOT NULL
	,Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
	('Ivan', 'Ivanov', 'Physicist'),
	('Stoyan', 'Georgiev', 'Biologist'),
	('Petar', 'Stoychev', 'Programmer')

INSERT INTO Customers(FirstName, LastName) VALUES
	('Stoycho', 'Stoychev'),
	('Krasimir', 'Botev'),
	('Gencho', 'Dimitrov')

INSERT INTO RoomStatus(RoomStatus) VALUES
	('Occupied'),
	('Free'),
	('In Repair')

INSERT INTO RoomTypes(RoomType) VALUES
	('Single'),
	('Double'),
	('Appartment')

INSERT INTO BedTypes(BedType) VALUES
	('Single'),
	('Double'),
	('Couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
	(2245, 'Single', 'Single', 30.0, 1),
	(2552, 'Double', 'Double', 45.0, 0),
	(5522, 'Appartment', 'Double', 90.0, 1)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
	(1, '2011-11-25', 1, '2017-11-30', '2017-12-04', 200.0, 0.1),
	(2, '2014-06-03', 2, '2014-06-06', '2014-06-09', 440.0, 0.2),
	(3, '2016-02-25', 3, '2016-02-27', '2016-03-04', 870.0, 0.5)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
	(1, '2011-02-04', 1, 2245, 40.0, 12.54),
	(2, '2015-04-09', 2, 2552, 70.0, 11.22),
	(3, '2012-06-08', 3, 5522, 110.0, 10.05)