-- Problem: Salary Level Function
-- Create Function
CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)

	IF(@Salary < 30000)
	BEGIN
		SET @result = 'Low'
	END
	ELSE IF(@Salary <= 50000)
	BEGIN
		SET @result = 'Average'
	END
	ELSE
	BEGIN
		SET @result = 'High'
	END

	RETURN @result
END

-- Create function WITHOUT begin and end
CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@Salary MONEY)
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

-- Execute function
SELECT 
     *, 
     dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel 
FROM Employees



-- Stored procedures test
-- Create
CREATE OR ALTER PROC usp_EmployeesProjects
AS
SELECT 
     CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
	 p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID

-- Execute
EXEC dbo.usp_EmployeesProjects



-- Stored procedures with multiple result set
-- Create
CREATE OR ALTER PROC usp_AddNumbers (@Num1 INT, @Num2 INT, @Res INT OUTPUT)
AS
BEGIN
	SET @Res = @Num1 + @Num2
	SELECT @Num1, @Num2
END

-- Execute
DECLARE @result INT
EXEC usp_AddNumbers 23, 12, @result OUTPUT

SELECT 'The result is:', @result



-- Problem: Employees with Three Projects
-- Create
CREATE OR ALTER PROCEDURE usp_AddEmployeeToProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT
	SET @employeeProjectsCount = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = @EmployeeID)
   
	IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
		THROW 50001, 'The employee has too many projects!', 1;

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)VALUES (@EmployeeID, @ProjectID)
END

-- Execute
SELECT EmployeeID FROM EmployeesProjects GROUP BY EmployeeID HAVING COUNT(*) = 2

SELECT * FROM EmployeesProjects WHERE EmployeeID = 240

EXEC dbo.usp_AddEmployeeToProject 240, 41