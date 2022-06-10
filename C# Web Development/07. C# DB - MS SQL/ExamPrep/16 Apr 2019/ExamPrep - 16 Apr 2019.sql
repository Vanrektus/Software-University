-- 01. DDL
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) CHECK(LEN(PassportId) = 11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)



-- 02. Insert ( !!! INSERT DATASET BEFORE THAT !!! )
INSERT INTO Planes ([Name], Seats, [Range]) VALUES
('Airbus 123', 123, 1234),
('Airbus 234', 123, 1234),
('Boeing 123', 123, 1234),
('Stelt 123', 123, 1234),
('Boeing 234', 123, 1234),
('Airbus 345', 123, 1234),
('Boeing 345', 123, 1234);

INSERT INTO LuggageTypes([Type]) VALUES
('Bag'),
('Backpack'),
('Sac');



-- 03. Update
UPDATE Tickets SET Price = Price * 1.13 
 WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')



-- 04. Delete
DELETE FROM Tickets WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim');
DELETE FROM Flights WHERE Destination = 'Ayn Halagim';



-- 05. The 'Tr' Planes
SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]



-- 06. Flight Profits
SELECT 
         FlightId, SUM(Price) AS TotalPrice
    FROM Tickets
GROUP BY FlightId
ORDER BY TotalPrice DESC, FlightId



-- 07. Passenger Trips
SELECT 
		 CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
		 f.Origin,
		 f.Destination
	FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name], Origin, Destination



-- 08. Non Adventures People
-- Solution 1
SELECT 
	 	  FirstName,
	 	  LastName,
	 	  Age
	 FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
    WHERE t.Id IS NULL
 ORDER BY Age DESC, FirstName, LastName

 -- Solution 2
 SELECT 
	 	  FirstName,
	 	  LastName,
	 	  Age
	 FROM Passengers
    WHERE Id NOT IN (SELECT PassengerId FROM Tickets)
 ORDER BY Age DESC, FirstName, LastName



-- 09. Full Info
SELECT 
		 CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
		 pl.[Name] AS [Plane Name],
		 CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
		 lt.[Type] AS [Luggage Type]
	FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
	JOIN Luggages AS l ON l.Id = t.LuggageId
	JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
	JOIN Planes AS pl ON pl.Id = f.PlaneId
ORDER BY [Full Name], [Plane Name], Trip, [Luggage Type]



-- 10. PSP
SELECT 
          pl.[Name],
		  pl.Seats,
		  COUNT(t.Id) AS [Passengers Count]
     FROM Planes AS pl
LEFT JOIN Flights AS f ON f.PlaneId = pl.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
 GROUP BY pl.Id, pl.[Name], pl.Seats
 ORDER BY [Passengers Count] DESC, [Name], Seats



-- 11. Vacation
-- Create Function
CREATE OR ALTER FUNCTION udf_CalculateTickets (@Origin VARCHAR(50), @Destination VARCHAR(50), @PeopleCount INT)
RETURNS VARCHAR(50) 
AS
	IF (@PeopleCount <= 0) 
		RETURN 'Invalid people count!'

	IF (NOT EXISTS (SELECT 1 FROM Flights WHERE Origin = @Origin AND Destination = @Destination))
		RETURN 'Invalid flight!'

	RETURN CONCAT('Total price ', 
	(SELECT TOP(1)
		  t.Price
	 FROM Tickets AS t
	 JOIN Flights AS f ON f.Id = t.FlightId
	WHERE f.Origin = @Origin AND f.Destination = @Destination) * @PeopleCount)
END

-- Execute Function
SELECT dbo.udf_CalculateTickets('Kolyshley', 'Rancabolang', 7)
SELECT dbo.udf_CalculateTickets('Kolyshley', 'Rancabolang', -7)
SELECT dbo.udf_CalculateTickets('Invalid', 'Rancabolang', 33)



-- 12. Wrong Data
-- Create Procedure
CREATE OR ALTER PROC usp_CancelFlight
AS
	UPDATE Flights
	   SET DepartureTime = NULL, ArrivalTime = NULL
	 WHERE ArrivalTime > DepartureTime

-- Execute Procedure
EXEC usp_CancelFlight