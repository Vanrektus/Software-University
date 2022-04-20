/****** Script for SelectTopNRows command from SSMS  ******/
SELECT EmployeeID AS 'No.'
	  ,[FirstName] + ' ' + [LastName] AS [Last Name]
      ,[MiddleName]
      ,[JobTitle]
	  ,[Salary]
	  ,d.[Name] AS DepartmentName
  FROM [SoftUni].[dbo].[Employees] AS e
  JOIN Departments AS d ON e.DepartmentId = d.DepartmentId
  WHERE d.DepartmentId = 3
		OR e.ManagerId IN (16, 3)
  ORDER BY EmployeeId



CREATE VIEW v_EmployeesWithoutMiddleName AS
SELECT *
FROM Employees
WHERE MiddleName IS NULL

SELECT *
FROM v_EmployeesWithoutMiddleName
ORDER BY HireDate



SELECT EmployeeID, FirstName, d.Name AS [DepartmentName]
INTO EmployeeDepartmentInfo
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentId = d.DepartmentId