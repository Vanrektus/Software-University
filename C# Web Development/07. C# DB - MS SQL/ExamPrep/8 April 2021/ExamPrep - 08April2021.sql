CREATE DATABASE [Service]

USE [Service]

-- 01. DDL
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)



-- 02. Insert
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo',	'O''Malley',	'1958-9-21',	1),
('Niki',	'Stanaghan',	'1969-11-26',	4),
('Ayrton',	'Senna',	'1960-03-21',	9),
('Ronnie',	'Peterson',	'1944-02-14',	9),
('Giovanna',	'Amati',	'1959-07-20',	5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId) VALUES
(1,	1,	2017-04-13,	NULL,	'Stuck Road on Str.133',	6,	2),
(6,	3,	2015-09-05,	2015-12-06,	'Charity trail running',	3,	5),
(14,	2,	2015-09-07,	NULL,	'Falling bricks on Str.58',	5,	2),
(4,	3,	2017-07-03,	2017-07-06,	'Cut off streetlight on Str.11',	1,	1)



-- 03. Update
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL



-- 04. Delete
DELETE FROM Reports WHERE StatusId = 4



-- 05. Unassigned Reports
SELECT 
         [Description],
		 CONVERT(VARCHAR(10), OpenDate, 105)
    FROM Reports
   WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, [Description] ASC



-- 06. Reports & Categories
SELECT 
         r.[Description],
		 c.[Name] AS CategoryName
    FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.[Description] ASC, c.[Name] ASC



-- 07. Most Reported Category
SELECT TOP(5)
              c.[Name] AS CategoryName,
     		  COUNT(c.[Name]) AS ReportsNumber
         FROM Reports AS r
     	JOIN Categories AS c ON c.Id = r.CategoryId
     GROUP BY c.[Name]
     ORDER BY ReportsNumber DESC, c.[Name] ASC



-- 08. Birthday Report
SELECT 
         u.Username,
		 c.[Name] AS CategoryName
    FROM Reports AS r
    JOIN Users AS u ON u.Id = r.UserId
    JOIN Categories AS c ON c.Id = r.CategoryId
   WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate) AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
ORDER BY u.Username ASC, c.[Name] ASC



-- 09. User per Employee
SELECT
         CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
		 (SELECT DISTINCT COUNT(UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount
    FROM Employees AS e
GROUP BY e.FirstName, e.LastName, e.Id
ORDER BY UsersCount DESC, FullName ASC



-- 10. Full Info
SELECT 
          CASE
		      WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
			  ELSE CONCAT(e.FirstName, ' ', e.LastName)
		  END AS Employee,
		  ISNULL(d.[Name], 'None') AS Department,
		  ISNULL(c.[Name], 'None') AS Category,
		  ISNULL(r.[Description], 'None') AS [Description],
		  CASE
			  WHEN r.OpenDate IS NULL THEN 'None'
			  ELSE CONVERT(VARCHAR(10), r.OpenDate, 104)
		  END AS OpenDate,
		  ISNULL(s.[Label], 'None') AS [Status],
		  ISNULL(u.[Name], 'None') AS [User]
     FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN [Status] AS s ON s.Id = r.StatusId
LEFT JOIN Users AS u ON u.Id = r.UserId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
 ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, [Description], OpenDate, s.[Label], u.[Name]



-- 11. Hours to Complete
GO
-- Create Function
CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME2, @EndDate DATETIME2) 
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL) RETURN 0
		
	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

GO

-- Execute
SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours  FROM Reports



-- 12. Assign Employee
GO
-- Create Procedure
CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @categoryDepartmentId INT = (SELECT c.DepartmentId 
										 FROM Reports AS r 
										 JOIN Categories AS c ON c.Id = r.CategoryId 
										 WHERE r.Id = @ReportId)
	DECLARE @employeeDepartmentId INT = (SELECT d.Id 
										 FROM Employees AS e 
										 JOIN Departments AS d ON d.Id = e.DepartmentId 
										 WHERE e.Id = @EmployeeId)
	
	IF (@categoryDepartmentId != @employeeDepartmentId)
		THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1; 
	ELSE
		BEGIN
			UPDATE Reports
			SET EmployeeId = @EmployeeId
		    WHERE Id = @ReportId
		END
END

-- Execute Procedure
EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2