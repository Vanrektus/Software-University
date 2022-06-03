-- Problem 01. - Employees with Salary Above 35000
USE SoftUni
-- Create
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT 
		 FirstName,
		 LastName
	FROM Employees
	WHERE Salary > 35000
END

-- Execute
EXEC dbo.usp_GetEmployeesSalaryAbove35000

-- Problem 02. - Employees with Salary Above Number
-- Create
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber (@SalaryNumber DECIMAL(18,4))
AS
BEGIN
	SELECT 
		  FirstName,
		  LastName
	FROM  Employees
	WHERE Salary >= @SalaryNumber
END

-- Execute
EXEC dbo.usp_GetEmployeesSalaryAboveNumber 70000


-- Problem 03. - Town Names Starting With
-- Create
CREATE OR ALTER PROC usp_GetTownsStartingWith (@StartString NVARCHAR(50))
AS
BEGIN
	SELECT 
		  [Name]
	FROM  Towns
	WHERE LEFT([Name], LEN(@StartString)) = @StartString
END

-- Execute
EXEC dbo.usp_GetTownsStartingWith bo


-- Problem 04. - Employees from Town
-- Create
CREATE OR ALTER PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(50))
AS
BEGIN
	SELECT 
		  e.FirstName AS [Frist Name],
		  e.LastName AS [Last Name]
	FROM  Towns AS t
	JOIN  Addresses AS a ON t.TownID = a.TownID
	JOIN  Employees AS e ON e.AddressID = a.AddressID
	WHERE t.[Name] = @TownName
END


-- Problem 05. - Salary Level Function
-- Create
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)

	IF(@Salary < 30000)
		SET @result = 'Low'
	ELSE IF(@Salary <= 50000)
		SET @result = 'Average'
	ELSE
		SET @result = 'High'

	RETURN @result
END


-- Problem 06. - Employees by Salary Level
-- Create
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel (@SalaryLevel NVARCHAR(50))
AS
BEGIN
	SELECT 
		  FirstName AS [Frist Name],
		  LastName AS [Last Name]
	FROM  Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END


-- Problem 07. - Define Function
-- Create
CREATE OR ALTER FUNCTION ufn_IsWordComprised (@SetOfLetters NVARCHAR(50), @Word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1
	DECLARE @wordMatch NVARCHAR(50)

	WHILE (@index <= LEN(@Word))
	BEGIN
		DECLARE @letter NCHAR(1) = SUBSTRING(@Word, @index, 1)

		IF (@SetOfLetters LIKE '%' + @letter + '%')
			SET @wordMatch = CONCAT(@wordMatch, @letter)
		
		SET @index += 1
	END

	IF (@Word = @wordMatch)
		RETURN 1

	RETURN 0
END

-- Execute
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS Result
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS Result
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy') AS Result


-- Problem 08. - Delete Employees and Departments
-- Create
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @DepartmentId

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

	SELECT 
	      COUNT(*)
	FROM  Employees
	WHERE DepartmentID = @departmentId
END

-- Problem 09. - Find Full Name
USE Bank
-- Create

CREATE OR ALTER PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT 
		 CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

-- Execute
EXEC usp_GetHoldersFullName


-- Problem 10. - People with Balance Higher Than
-- Create
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number MONEY)
AS
BEGIN
	SELECT 
		     ah.FirstName,
			 ah.LastName
	FROM     Accounts AS a
	JOIN     AccountHolders AS ah ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING   SUM(a.Balance) > @Number
	ORDER BY ah.FirstName ASC, ah.LastName ASC
END

-- Execute
EXEC usp_GetHoldersWithBalanceHigherThan 10000


-- Problem 11. - Future Value Function
-- Create



-- Problem 12. - Calculating Interest
-- Create



-- Problem 13. - * Cash in User Games Odd Rows *
-- Create