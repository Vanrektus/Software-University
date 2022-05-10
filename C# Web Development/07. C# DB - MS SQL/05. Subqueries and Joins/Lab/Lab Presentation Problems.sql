-- Problem: Addresses With Towns
SELECT 
		   e.FirstName,
		   e.LastName,
		   t.[Name]  AS Town,
		   a.AddressText
	  FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns	 AS t ON a.TownID = t.TownID
  ORDER BY e.FirstName ASC, 
		   e.LastName  ASC


-- Problem: Salse Employees
SELECT 
	       e.EmployeeID,
	       e.FirstName,
	       e.LastName,
	       d.[Name]    AS DepartmentName
      FROM Employees   AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     WHERE d.[Name] = 'Sales'
  ORDER BY e.EmployeeID ASC


-- Problem: Employees Hired After
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


-- Problem: Employee Summary
SELECT TOP (50)
	       e.EmployeeID,
	       CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	       CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	       d.[Name]                             AS DepartmentName
      FROM Employees   AS e
 LEFT JOIN Employees   AS m ON e.ManagerID = m.EmployeeID
 LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
  ORDER BY e.EmployeeID


-- Problem: Min Average Salary
SELECT 
       MIN(MinSal.AvgSal) AS MinAverageSalary
  FROM 
(
	  SELECT 
		     AVG(Salary) AS AvgSal
	    FROM Employees  
	GROUP BY DepartmentID
) AS MinSal