-- Problem 01. - Employee Address
USE SoftUni

SELECT TOP (5)
	       EmployeeID,
	       JobTitle,
	       e.AddressID,
	       a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
  ORDER BY e.AddressID ASC


-- Problem 02. - Addresses with Towns
SELECT TOP (50)
	       FirstName,
	       LastName,
	       t.[Name] AS Town,
	       a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns     AS t ON a.TownID = t.TownID
  ORDER BY FirstName ASC, LastName ASC

-- Problem 03. - Sales Employees
SELECT
	       EmployeeID,
	       FirstName,
	       LastName,
		   d.[Name] AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     WHERE d.[Name] = 'Sales'
  ORDER BY EmployeeID ASC


-- Problem 04. - Employee Departments
SELECT TOP (5)
	       EmployeeID,
	       FirstName,
		   Salary,
		   d.[Name] AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     WHERE Salary > 15000
  ORDER BY e.DepartmentID ASC


-- Problem 05. - Employees Without Projects
SELECT TOP (3)
	       e.EmployeeID,
	       FirstName
     FROM Employees AS e
LEFT JOIN EmployeesProjects AS p ON e.EmployeeID = p.EmployeeID
    WHERE p.ProjectID IS NULL
 ORDER BY e.EmployeeID ASC


-- Problem 06. - Employees Hired After
SELECT 
		   e.FirstName,
		   e.LastName,
		   e.HireDate,
           d.[Name]    AS DeptName
      FROM Employees   AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     WHERE 
	       e.HireDate > '1999-01-01' 
	   AND (d.[Name] IN ('Sales', 'Finance'))
  ORDER BY e.HireDate ASC


-- Problem 07. - Employees With Project
SELECT TOP (5)
	       e.EmployeeID,
	       FirstName,
		   p.[Name] AS ProjectName
      FROM Employees AS e
 LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects          AS p  ON ep.ProjectID = p.ProjectID
     WHERE p.StartDate > '2002-08-13'
  ORDER BY e.EmployeeID ASC


-- Problem 08. - Employee 24
SELECT TOP (5)
	       e.EmployeeID,
	       FirstName,
		   CASE
			    WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			    ELSE p.[Name]
	     END AS [ProjectName]
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects          AS p  ON ep.ProjectID = p.ProjectID
     WHERE ep.EmployeeID = 24


-- Problem 09. - Employee Manager
SELECT
	       e.EmployeeID,
	       e.FirstName,
		   e.ManagerID,
		   m.FirstName AS ManagerName
      FROM Employees AS e
INNER JOIN Employees AS m ON e.ManagerID = m.EmployeeID
     WHERE e.ManagerID IN (3, 7)
  ORDER BY e.EmployeeID ASC


-- Problem 10. - Employees Summary
SELECT TOP (50)
	      e.EmployeeID,
	      CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	      CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
          d.[Name]                             AS DepartmentName
     FROM Employees AS e
LEFT JOIN Employees   AS m ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 ORDER BY e.EmployeeID


-- Problem 11. - Min Average Salary
-- Method 1 - With Subquery
SELECT 
       MIN(MinSal.AvgSal) AS MinAverageSalary
  FROM
(
	   SELECT 
			  AVG(Salary) AS AvgSal
	     FROM Employees  
	 GROUP BY DepartmentID
) AS MinSal

-- Method 2 - Withour Subquery
SELECT TOP (1)
	       AVG(e.Salary) AS MinAverageSalary
      FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
  GROUP BY d.DepartmentID
  ORDER BY AVG(e.Salary)


-- Problem 12. - Highest Peaks in Bulgaria
USE [Geography]

SELECT 
	       mc.CountryCode,
		   m.MountainRange,
		   p.PeakName,
		   p.Elevation
      FROM Peaks AS p
INNER JOIN Mountains          AS m  ON p.MountainId = m.Id
INNER JOIN MountainsCountries AS mc ON p.MountainId = mc.MountainId
     WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
  ORDER BY p.Elevation DESC



-- Problem 13. - Count Mountain Ranges
SELECT 
	       c.CountryCode,
		   COUNT(c.CountryCode) AS MountainRanges
      FROM Countries AS c
INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
  GROUP BY c.CountryCode


-- Problem 14. - Countries With or Without Rivers
SELECT TOP (5)
	       coun.CountryName,
		   r.RiverName
      FROM Continents AS con
INNER JOIN Countries       AS coun ON con.ContinentCode = coun.ContinentCode
 LEFT JOIN CountriesRivers AS cr   ON coun.CountryCode = cr.CountryCode
 LEFT JOIN Rivers          AS r    ON cr.RiverId = r.Id
     WHERE con.ContinentName = 'Africa'
  ORDER BY coun.CountryName ASC


-- Problem 15. - * Continents and Currencies *
SELECT
		MUC.ContinentCode,
		MUC.CurrencyCode,
		MUC.CurrencyUsage
FROM
(
	 SELECT 
			   c.ContinentCode,
			   c.CurrencyCode,
			   COUNT(c.CurrencyCode) AS CurrencyUsage,
			   DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
		  FROM Countries AS c
	  GROUP BY c.CurrencyCode, c.ContinentCode
	    HAVING COUNT(c.CurrencyCode) > 1
  )   AS MUC
   WHERE MUC.CurrencyRank = 1
ORDER BY MUC.ContinentCode, 
		 MUC.CurrencyUsage

-- Problem 16. - Countries Without any Mountains
SELECT
		  COUNT(*) AS [Count]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL


-- Problem 17. - Highest Peak and Longest River by Country
SELECT TOP (5)
		   c.CountryName,
		   MAX(p.Elevation) AS HighestPeakElevation,
		   MAX(r.[Length])  AS LongestRiverLength
      FROM Countries AS c
INNER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
INNER JOIN Peaks              AS p  ON mc.MountainId = p.MountainId
INNER JOIN CountriesRivers    AS cr ON c.CountryCode = cr.CountryCode
INNER JOIN Rivers             AS r  ON cr.RiverId = r.Id
  GROUP BY c.CountryName
  ORDER BY HighestPeakElevation DESC, 
		   LongestRiverLength DESC, 
		   c.CountryName ASC


-- Problem 18. - * Highest Peak Name and Elevation by Country *
SELECT TOP(5) k.CountryName
             ,ISNULL(k.PeakName, '(no highest peak)')  AS [Highest Peak Name]
             ,ISNULL(k.MaxElevation, 0)                AS [Highest Peak Elevation]
             ,ISNULL(k.MountainRange, '(no mountain)') AS [Mountain]
FROM
(
     SELECT 
	           c.CountryName,
	           MAX(p.Elevation) AS [MaxElevation],
			   p.PeakName,
			   m.MountainRange,
			   DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS ElevationRank
          FROM Countries AS c
     LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
     LEFT JOIN Mountains          AS m  ON m.Id = mc.MountainId
     LEFT JOIN Peaks              AS p  ON p.MountainId = m.Id
      GROUP BY c.CountryName, p.PeakName, m.MountainRange
    ) AS k
   WHERE k.ElevationRank = 1
ORDER BY k.CountryName, k.PeakName