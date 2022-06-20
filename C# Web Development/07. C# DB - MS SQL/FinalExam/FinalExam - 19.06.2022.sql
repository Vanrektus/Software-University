CREATE DATABASE Zoo

USE Zoo

-- 01. DDL
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL,
)

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL,
)

CREATE TABLE AnimalsCages(
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL,
)



-- 02. Insert
INSERT INTO Volunteers ([Name], PhoneNumber, [Address], AnimalId, DepartmentId) VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals ([Name], BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)



-- 03. Update
UPDATE Animals
SET OwnerId = (SELECT Id FROM Owners WHERE [Name] = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL



-- 04. Delete
DELETE FROM Volunteers WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')
DELETE FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant'



-- 05. Volunteers
SELECT 
         [Name],
		 PhoneNumber,
		 [Address],
		 AnimalId,
		 DepartmentId
    FROM Volunteers
ORDER BY [Name] ASC, Id ASC, DepartmentId ASC



-- 06. Animals data
SELECT 
         a.[Name],
		 ant.AnimalType,
		 CONVERT(VARCHAR(10), a.BirthDate, 104) AS BirthDate
    FROM Animals AS a
    JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
ORDER BY a.[Name] ASC



-- 07. Owners and Their Animals
SELECT TOP(5)
         o.[Name],
		 COUNT(a.OwnerId) AS CountOfAnimals
    FROM Animals AS a
    JOIN Owners AS o ON o.Id = a.OwnerId
GROUP BY o.[Name]
ORDER BY COUNT(a.OwnerId) DESC, o.[Name] ASC



-- 08. Owners, Animals and Cages
SELECT 
         CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals,
		 o.PhoneNumber,
		 ac.CageId
    FROM Animals AS a
    JOIN Owners AS o ON o.Id = a.OwnerId
    JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
	JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
WHERE ant.AnimalType = 'Mammals'
ORDER BY o.[Name] ASC, a.[Name] DESC



-- 09. Volunteers in Sofia
SELECT
         v.[Name],
		 v.PhoneNumber,
		 TRIM(SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 1, LEN(v.[Address]))) AS Address
    FROM Volunteers AS v
    JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
   WHERE vd.DepartmentName = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name] ASC



-- 10. Animals for Adoption
SELECT 
         a.[Name],
		 DATEPART(YEAR, a.BirthDate) AS BirthYear,
		 ant.AnimalType
    FROM Animals AS a
    JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
   WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR, a.BirthDate, '2022-01-01') < 5 AND ant.AnimalType != 'Birds'
ORDER BY a.[Name]

GO



-- 11. All Volunteers in a Department
-- Create Function
CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @DepartmentId INT
	DECLARE @VolunteersCount INT

	SET @DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = @VolunteersDepartment)
	SET @VolunteersCount = (SELECT COUNT(*) FROM Volunteers WHERE DepartmentId = @DepartmentId)

	RETURN @VolunteersCount
END

GO

-- Execute Function
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant') -- 6
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement') -- 4
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events') -- 5

GO



-- 12. Animals with Owner or Not
-- Create Procedure
CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT 
	          a.[Name],
		      ISNULL(o.[Name], 'For adoption') AS OwnersName
	     FROM Animals AS a
	LEFT JOIN Owners AS o ON o.Id = a.OwnerId
	    WHERE a.[Name] = @AnimalName
END

-- Execute Function
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'