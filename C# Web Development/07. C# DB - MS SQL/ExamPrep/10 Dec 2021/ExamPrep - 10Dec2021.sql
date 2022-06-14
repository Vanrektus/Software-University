CREATE DATABASE Airport

USE Airport

-- 01. DDL
CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18, 2) DEFAULT(15) NOT NULL
)



-- 02. Insert
INSERT INTO Passengers (FullName, Email)
(
	(SELECT 
		    CONCAT_WS(' ', FirstName, LastName),
		    CONCAT(FirstName, LastName, '@gmail.com')
	   FROM Pilots
	  WHERE [Id] BETWEEN 5 AND 15)
)



-- 03. Update
UPDATE Aircraft
   SET Condition = 'A'
 WHERE Condition IN ('C', 'B') 
   AND (FlightHours IS NULL OR FlightHours <= 100) 
   AND [Year] >= 2013



-- 04. Delete
DELETE FROM Passengers WHERE LEN(FullName) <= 10



-- 05. Aircraft
  SELECT 
         Manufacturer,
		 Model,
		 FlightHours,
		 Condition
    FROM Aircraft
ORDER BY FlightHours DESC



-- 06. Pilots and Aircraft
SELECT 
         p.FirstName,
  	     p.LastName,
  	     a.Manufacturer,
  	     a.Model,
  	     a.FlightHours
    FROM Pilots AS p
    JOIN PilotsAircraft AS pa ON pa.PilotId = p.Id
    JOIN Aircraft AS a ON a.Id = pa.AircraftId
   WHERE a.FlightHours IS NOT NULL AND a.FlightHours <= 304
ORDER BY a.FlightHours DESC, p.FirstName ASC



-- 07. Top 20 Flight Destinations
SELECT TOP(20) 
               fd.Id AS DestinationId,
			   fd.[Start],
			   p.FullName,
			   a.AirportName,
			   fd.TicketPrice
          FROM FlightDestinations AS fd
		  JOIN Passengers AS p ON p.Id = fd.PassengerId
		  JOIN Airports AS a ON a.Id = fd.AirportId
         WHERE DAY([Start]) % 2 = 0
	  ORDER BY fd.TicketPrice DESC, a.AirportName ASC



-- 08. Number of Flights for Each Aircraft
  SELECT 
         a.Id,
		 a.Manufacturer,
		 a.FlightHours,
         COUNT(fd.AircraftId) AS FlightDestinationsCount,
		 ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
    FROM Aircraft AS a
    JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
  HAVING COUNT(fd.AircraftId) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id ASC



-- 09. Regular Passengers
SELECT 
         p.FullName,
		 COUNT(p.FullName) AS CountOfAircraft,
		 SUM(fd.TicketPrice) AS TotalPayed
    FROM FlightDestinations AS fd
    JOIN Passengers AS p ON p.Id = fd.PassengerId
GROUP BY p.FullName
  HAVING SUBSTRING(p.FullName, 2, 1) = 'a' AND COUNT(p.FullName) > 1
ORDER BY p.FullName ASC




-- 10. Full Info for Flight Destinations
SELECT 
         ap.AirportName,
  	     fd.[Start] AS DayTime,
  	     fd.TicketPrice,
  	     p.FullName,
  	     ac.Manufacturer,
  	     ac.Model
    FROM FlightDestinations AS fd
    JOIN Airports AS ap ON ap.Id = fd.AirportId
    JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
    JOIN Passengers AS p ON p.Id = fd.PassengerId
   WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20 AND TicketPrice > 2500
ORDER BY ac.Model

GO



-- 11. Find all Destinations by Email Address
-- Create Function
CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail (@Email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @PassengerId INT
	DECLARE @PassengerFlightDestCount INT

	SET @PassengerId = (SELECT Id FROM Passengers WHERE Email = @Email)
	SET @PassengerFlightDestCount = (SELECT COUNT(*) FROM FlightDestinations WHERE PassengerId = @PassengerId)

	RETURN @PassengerFlightDestCount
END

GO

-- Execute
SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com') -- 1
SELECT dbo.udf_FlightDestinationsByEmail ('Montacute@gmail.com') -- 3
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com') -- 0

GO



-- 12. Full Info for Airports
-- Create Procedure
CREATE OR ALTER PROC usp_SearchByAirportName (@AirportName VARCHAR(70))
AS
BEGIN
	SELECT 
	         ap.AirportName,
			 p.FullName,
			 CASE
				WHEN fd.TicketPrice <= 400 THEN 'Low'
				WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
				WHEN fd.TicketPrice > 1500 THEN 'High'
			 END,
			 ac.Manufacturer,
			 ac.Condition,
			 [at].TypeName
	    FROM Airports AS ap
	    JOIN FlightDestinations AS fd ON fd.AirportId = ap.Id
	    JOIN Passengers AS p ON p.Id = fd.PassengerId
	    JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
	    JOIN AircraftTypes AS [at] ON [at].Id = ac.TypeId
	   WHERE ap.AirportName = @AirportName
	ORDER BY ac.Manufacturer ASC, p.FullName ASC
END

-- Execute Procedure
EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'