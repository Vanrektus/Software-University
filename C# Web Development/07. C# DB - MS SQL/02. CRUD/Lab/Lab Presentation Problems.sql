-- Problem - Employee Summary
SELECT [FirstName] + ' ' + [LastName] AS [Last Name]
      ,[JobTitle]
	  ,[Salary]
  FROM [SoftUni].[dbo].[Employees]
  ORDER BY EmployeeID


-- Problem - Highest Peak
CREATE VIEW v_HighestPeak AS
SELECT TOP (1) [Id]
      ,[PeakName]
      ,[Elevation]
      ,[MountainId]
  FROM [Geography].[dbo].[Peaks]
  ORDER BY Elevation DESC

  
-- Problem - Update Projects
UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL