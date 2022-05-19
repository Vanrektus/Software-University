-- Problem 01. - Records’ Count
USE Gringotts

SELECT 
	 COUNT(*) AS [Count]
FROM WizzardDeposits


-- Problem 02. - Longest Magic Wand
SELECT TOP(1)
	     MAX(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits


-- Problem 03. - Longest Magic Wand per Deposit Groups
SELECT
         DepositGroup,
	     Max(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY DepositGroup


-- Problem 04. - * Smallest Deposit Group per Magic Wand Size *
SELECT TOP(2)
         DepositGroup
    FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)


-- Problem 05. - Deposits Sum
SELECT
         DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
GROUP BY DepositGroup


-- Problem 06. - Deposits Sum for Ollivander Family
SELECT
         DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup


-- Problem 07. - Deposits Filter
SELECT
         DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family' 
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC


-- Problem 08. - Deposit Charge
SELECT
         DepositGroup,
		 MagicWandCreator,
		 MIN(DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC


-- Problem 09. - Age Groups
SELECT 
         AgeGrupTable.AgeGroup,
		 COUNT(AgeGrupTable.AgeGroup) AS WizardCount
    FROM 
	     (
		  SELECT
		    CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		  END AS AgeGroup
		    FROM WizzardDeposits
			     ) AS AgeGrupTable
GROUP BY AgeGroup
ORDER BY AgeGroup


-- Problem 10. - First Letter
-- Solution 1
SELECT
         DISTINCT LEFT(FirstName, 1)
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName

-- Solution 2
SELECT
         LEFT(FirstName, 1)
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)


-- Problem 11. - Average Interest
SELECT
         DepositGroup,
		 IsDepositExpired,
         AVG(DepositInterest) AS AverageInterest
    FROM WizzardDeposits
   WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC


-- Problem 12. - * Rich Wizard, Poor Wizard *
SELECT SUM([Difference]) AS SumDifference 
FROM 
       (
        SELECT w.FirstName AS [Host Wizzard],
               w.DepositAmount AS [Host Wizzard Deposit],
               wd.FirstName AS [Guest Wizzard],
               wd.DepositAmount AS [Guest Wizzard Deposit],
               w.DepositAmount - wd.DepositAmount AS [Difference]
          FROM WizzardDeposits AS w
          JOIN WizzardDeposits AS wd ON w.Id = wd.Id - 1
) AS WizardTable


-- Problem 13. - Departments Total Salaries
USE SoftUni

SELECT 
         DepartmentID,
         SUM(Salary) AS TotalSalary
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


-- Problem 14. - Employees Minimum Salaries
SELECT 
         DepartmentID,
         MIN(Salary) AS MinimumSalary
    FROM Employees
   WHERE HireDate > '01-01-2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)


-- Problem 15. - Employees Average Salaries
SELECT 
      * 
 INTO EmployeesWithHighSalary
 FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary
      WHERE ManagerID = 42

UPDATE EmployeesWithHighSalary
   SET Salary += 5000
 WHERE DepartmentID = 1

SELECT   DepartmentID,
         AVG(Salary) AS AverageSalary 
    FROM EmployeesWithHighSalary
GROUP BY DepartmentID


-- Problem 16. - Employees Maximum Salaries
SELECT 
         DepartmentID,
         MAX(Salary) AS MaxSalary
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


-- Problem 17. - Employees Count Salaries
SELECT 
      COUNT(Salary) AS [Count]
 FROM Employees
WHERE ManagerID IS NULL


-- Problem 18. - * 3rd Highest Salary *
SELECT DISTINCT RankedSalaries.DepartmentID
               ,RankedSalaries.Salary
FROM 
      (
       SELECT DepartmentID,
	          Salary,
	   		  DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
         FROM Employees
      ) AS RankedSalaries
WHERE RankedSalaries.SalaryRank = 3


-- Problem 19. - * Salary Challenge *
SELECT TOP (10) FirstName
               ,LastName
               ,DepartmentID
FROM Employees AS e
WHERE Salary > (	
                 SELECT AVG(Salary) 
                   FROM Employees AS em 
                  WHERE em.DepartmentID = e.DepartmentID
			   )