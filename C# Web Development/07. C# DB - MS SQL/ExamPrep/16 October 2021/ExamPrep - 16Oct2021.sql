CREATE DATABASE CigarShop

USE CigarShop

-- 01. DDL
CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Length] INT CHECK ([Length] BETWEEN 10 AND 25) NOT NULL,
	RingRange DECIMAL(3, 2) CHECK (RingRange >= 1.5 AND LEN(RingRange) <= 7.5) NOT NULL
	
)

CREATE TABLE Tastes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL,
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
)

CREATE TABLE ClientsCigars(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
	PRIMARY KEY(ClientId, CigarId),
)



-- 02. Insert
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
('COHIBA ROBUSTO', 9, 1, 5,	15.50,	'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5,	11,	7.50,	'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4,	15,	32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP) VALUES
('Sofia',	'Bulgaria', '18 Bul. Vasil levski',	1000),
('Athens',	'Greece',	'4342 McDonald Avenue',	10435),
('Zagreb',	'Croatia',	'4333 Lauren Drive',	10000)



-- 03. Update
UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2
WHERE TastId = (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL



-- 04. Delete
DELETE FROM Clients WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Country, 1) = 'C')
DELETE FROM Addresses WHERE LEFT(Country, 1) = 'C'



-- 05. Cigars by Price
  SELECT 
         CigarName,
		 PriceForSingleCigar,
		 ImageURL
    FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC



-- 06. Cigars by Taste
   SELECT 
          c.Id,
   	      c.CigarName,
   	      c.PriceForSingleCigar,
   	      t.TasteType,
   	      t.TasteStrength
     FROM Cigars AS c
     JOIN Tastes AS t ON t.Id = c.TastId
    WHERE t.TasteType IN ('Earthy', 'Woody')
 ORDER BY c.PriceForSingleCigar DESC



-- 07. Clients without Cigars
  SELECT 
         Id,
		 CONCAT(FirstName, ' ', LastName) AS ClientName,
		 Email
    FROM Clients
   WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName ASC



-- 08. First 5 Cigars
SELECT TOP(5)
              c.CigarName,
		      c.PriceForSingleCigar,
      		  c.ImageURL
         FROM Cigars AS c
         JOIN Sizes AS s ON s.Id = c.SizeId
        WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
     ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC



-- 09. Clients with ZIP Codes
  SELECT 
         CONCAT(cl.FirstName, ' ', cl.LastName) AS FullName,
		 a.Country,
		 a.ZIP,
		 CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
    FROM Clients AS cl
    JOIN Addresses AS a ON a.Id = cl.AddressId
    JOIN ClientsCigars AS cc ON cc.ClientId = cl.Id
    JOIN Cigars AS ci ON ci.Id = cc.CigarId
   WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY CONCAT(cl.FirstName, ' ', cl.LastName), a.Country, a.ZIP



-- 10. Cigars by Size
SELECT 
         cl.LastName,
		 AVG(s.[Length]) AS CiagrLength,
		 CEILING(AVG(s.RingRange)) AS CiagrRingRange
    FROM ClientsCigars AS cc
    JOIN Clients AS cl ON cl.Id = cc.ClientId
	JOIN Cigars AS ci ON ci.Id = cc.CigarId
	JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY cl.LastName
ORDER BY CiagrLength DESC

GO



-- 11. Client with Cigars
-- Create Function
CREATE OR ALTER FUNCTION udf_ClientWithCigars (@Name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @ClientId INT
	DECLARE @ClientCigarsCount INT

	SET @ClientId = (SELECT Id FROM Clients WHERE FirstName = @Name)
	SET @ClientCigarsCount = (SELECT COUNT(*) FROM ClientsCigars WHERE ClientId = @ClientId)

	RETURN @ClientCigarsCount
END

GO

-- Execute Function
SELECT dbo.udf_ClientWithCigars('Betty')

GO



-- 12. Search for Cigar with Specific Taste
-- Create Procedure
CREATE OR ALTER PROC usp_SearchByTaste (@Taste VARCHAR(20))
AS
BEGIN
	SELECT 
	          c.CigarName,
		      CONCAT('$', c.PriceForSingleCigar) AS Price,
		      t.TasteType,
		      b.BrandName,
		      CONCAT(s.[Length], ' cm') AS CigarLength,
		      CONCAT(s.RingRange, ' cm') AS CigarRingRange
	     FROM Tastes AS t
	     JOIN Cigars AS c ON c.TastId = t.Id
	     JOIN Brands AS b ON b.Id = c.BrandId
	     JOIN Sizes AS s ON s.Id = c.SizeId
	    WHERE t.TasteType = @Taste
	 ORDER BY s.[Length] ASC, s.RingRange DESC
END

-- Execute Function
EXEC usp_SearchByTaste 'Woody'