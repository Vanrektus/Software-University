  -- Problem 01. - Find Names of All Employees by First Name
  SELECT FirstName
	  ,LastName
  FROM Employees
  WHERE FirstName LIKE 'Sa%'


  -- Problem 02. - Find Names of All Employees by Last Name
  SELECT FirstName
	  ,LastName
  FROM Employees
  WHERE LastName LIKE '%ei%'

  -- Problem 03. - Find First Names of All Employess
  SELECT FirstName
  FROM Employees
  WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005


  -- Problem 04. - Find All Employees Except Engineers
  SELECT FirstName
	  ,LastName
  FROM Employees
  WHERE JobTitle NOT LIKE '%engineer%'


  -- Problem 05. - Find Towns with Name Length
  SELECT [Name]
  FROM Towns
  WHERE LEN([Name]) IN (5, 6)
  ORDER BY [Name] ASC


  -- Problem 06. - Find Towns Starting With
  SELECT TownID
	  ,[Name]
  FROM Towns
  WHERE [Name] LIKE '[MKBE]%'
  ORDER BY [Name] ASC


  -- Problem 07. - Find Towns Not Starting With
  SELECT TownID
	  ,[Name]
  FROM Towns
  WHERE [Name] LIKE '[^RBD]%'
  ORDER BY [Name] ASC


  -- Problem 08. - Create View Employees Hired After
  CREATE VIEW V_EmployeesHiredAfter2000 AS
  SELECT FirstName
	  ,LastName
  FROM Employees
  WHERE DATEPART(YEAR, HireDate) BETWEEN 2001 AND GETDATE()


  -- Problem 09. - Length of Last Name
  SELECT FirstName
	  ,LastName
  FROM Employees
  WHERE LEN(LastName) = 5


  -- Problem 10. - Rank Employees by Salary
  SELECT EmployeeID
	  ,FirstName
	  ,LastName
	  ,Salary
	  ,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000
  ORDER BY Salary DESC


  -- *Problem 11. - Find All Employees with Rank 2*
  SELECT * FROM
  (
	  SELECT EmployeeID
			,FirstName
			,LastName
	    	,Salary
			,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	  FROM Employees
	  WHERE Salary BETWEEN 10000 AND 50000
  ) AS RankedTable
  WHERE RankedTable.[Rank] = 2
  ORDER BY Salary DESC


  -- Problem 12. - Countries Holding 'A'
  USE Geography

  SELECT CountryName AS [Country Name]
	  ,IsoCode AS [ISO Code]
  FROM Countries
  WHERE CountryName LIKE '%a%a%a%'
  ORDER BY IsoCode ASC


  -- Problem 13. - Mix of Peak and River Names
  SELECT PeakName
	  ,RiverName
	  ,LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName)))) AS Mix
  FROM Peaks, Rivers
  WHERE RIGHT(PeakName, 1) = LOWER(LEFT(RiverName, 1))
  ORDER BY Mix


  -- Problem 14. - Games From 2011 and 2012 Year
  USE Diablo

  SELECT TOP (50) [Name]
	  ,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM Games
  WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
  ORDER BY [Start] ASC, [Name] ASC


  -- Problem 15. - User Email Providers
  SELECT Username
	  ,SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email)) AS [Email Provider]
  FROM Users
  ORDER BY [Email Provider], Username


  -- Problem 16. - Get Users with IPAddress Like Pattern
  SELECT Username
	  ,IpAddress AS [IP Address]
   FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
   ORDER BY Username


  -- Problem 17. - Show All Games with Duration
  SELECT [Name] AS Game
	  ,[Part of the Day] =
			CASE
				WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
				WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
				ELSE 'Evening'
			END
	  ,Duration = 
			CASE
				WHEN Duration <= 3 THEN 'Extra Short'
				WHEN Duration <= 6 THEN 'Short'
				WHEN Duration > 6 THEN 'Long'
				ELSE 'Extra Long'
			END
  FROM Games
  ORDER BY Game ASC, Duration ASC, [Part of the Day] ASC


  -- Problem 18. - Orders Table
  USE Orders

  SELECT ProductName
	  ,OrderDate
	  ,DATEADD(DAY, 3, OrderDate) AS [Pay Due]
	  ,DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders


  -- Problem 19. - People Table
  CREATE TABLE People (
      Id INT PRIMARY KEY IDENTITY,
      [Name] NVARCHAR(100) NOT NULL,
      Birthdate DATETIME NOT NULL
  )

  INSERT INTO People VALUES
       ('Ivan', '1995-02-17')
      ,('Gosho', '1991-10-10')
      ,('Ayk', '1996-06-20')
      ,('Yanka', '2001-01-16')

  SELECT [Name],
      DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
      DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
      DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
      DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
  FROM People