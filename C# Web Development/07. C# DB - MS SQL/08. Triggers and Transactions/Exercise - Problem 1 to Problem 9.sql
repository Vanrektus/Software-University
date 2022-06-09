-- Problem 01. - Create Table Logs
USE Bank
GO

-- Create Table
CREATE TABLE Logs (
     LogId INT CONSTRAINT PK_Logs PRIMARY KEY IDENTITY NOT NULL
    ,AccountId INT CONSTRAINT FK_Logs_Accounts FOREIGN KEY REFERENCES Accounts(Id)
    ,OldSum DECIMAL(15,2) NOT NULL
    ,NewSum DECIMAL(15,2) NOT NULL
)
GO

-- Create Trigger
CREATE OR ALTER TRIGGER tr_AccountChangeLog
ON Accounts FOR UPDATE
AS
INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT d.AccountHolderId, d.Balance, i.Balance FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id AND d.Balance <> i.Balance

-- Execute Trigger
UPDATE Accounts
SET Balance += 10
WHERE Id = 1
   
SELECT * FROM Accounts
WHERE Id = 1

SELECT * FROM Logs



-- Problem 02. - Create Table Emails
-- Create Table
CREATE TABLE NotificationEmails (
     Id INT PRIMARY KEY IDENTITY
    ,Recipient INT FOREIGN KEY REFERENCES Accounts(Id)
    ,[Subject] VARCHAR(50)
    ,Body VARCHAR(MAX)
)
GO

-- Create Trigger
CREATE OR ALTER TRIGGER tr_NewRecordIntoLogs
ON Logs FOR INSERT
AS
INSERT INTO NotificationEmails (Recipient, [Subject], Body)
SELECT 
	 i.AccountId, 
	 CONCAT('Balance change for account: ', i.AccountId), 
	 CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, ' to ', i.NewSum) 
FROM inserted AS i

-- Execute Trigger
UPDATE Accounts
SET Balance += 100
WHERE Id = 1
	
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails

GO



-- Problem 03. - Deposit Money
-- Create Procedure
CREATE OR ALTER PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION

		IF(@AccountId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid account Id!', 16, 1)
			RETURN
		END

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Negative amount!', 16, 1)
			RETURN
		END
		
		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @accountId

	COMMIT

-- Execute Procedure
SELECT * FROM Accounts WHERE Id = 1
EXEC usp_DepositMoney 1, 234.14
SELECT * FROM Accounts WHERE Id = 1

GO



-- Problem 04. - Withdraw Money Procedure
-- Create Procedure
CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION

		IF(@AccountId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid account Id!', 16, 1)
			RETURN
		END

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Negative amount!', 16, 1)
			RETURN
		END

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Negative amount!', 16, 1)
			RETURN
		END
		
		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @accountId

	COMMIT

-- Execute Procedure
SELECT * FROM Accounts WHERE Id = 5
EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts WHERE Id = 5

GO



-- Problem 05. - Money Transfer
-- Create Procedure
CREATE OR ALTER PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION

		EXEC usp_WithdrawMoney @SenderId, @MoneyAmount
		EXEC usp_DepositMoney @ReceiverId, @MoneyAmount

	COMMIT

-- Execute Procedure
SELECT * FROM Accounts WHERE Id IN (11, 14)
EXEC usp_TransferMoney 11, 14, 5
SELECT * FROM Accounts WHERE Id IN (11, 14)

GO



-- Problem 06. - Trigger
USE Diablo
GO
-- Create Trigger
CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
	DECLARE @itemId INT = (SELECT ItemId FROM inserted)
	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

	IF(@userGameLevel >= @itemLevel)
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
			(@itemId, @userGameId)
END



-- Problem 07. - * Massive Shopping *
DECLARE @GameId INT, @Sum1 MONEY, @Sum2 MONEY

SELECT @GameId = usg.[Id]
  FROM UsersGames AS usg
  JOIN Games AS g ON usg.[GameId] = g.[Id]
 WHERE g.[Name] = 'Safflower'

SET @Sum1 = ( SELECT SUM(i.Price) 
                FROM Items AS i 
			   WHERE MinLevel BETWEEN 11 AND 12)

SET @Sum2 = ( SELECT SUM(i.Price) 
                FROM Items AS i 
			   WHERE MinLevel BETWEEN 19 AND 21)

BEGIN TRANSACTION

IF((SELECT Cash FROM UsersGames WHERE Id = @gameId) < @Sum1)
    BEGIN
        ROLLBACK
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @Sum1
        WHERE Id = @GameId

        INSERT INTO UserGameItems(UserGameId, ItemId )
               SELECT @GameId, Id
               FROM Items
               WHERE MinLevel BETWEEN 11 AND 12
        COMMIT
END

BEGIN TRANSACTION

IF((SELECT Cash FROM UsersGames WHERE Id = @GameId) < @Sum2)
    BEGIN
        ROLLBACK
	END
    ELSE
    BEGIN
        UPDATE UsersGames
        SET Cash = Cash - @Sum2
        WHERE Id = @GameId

        INSERT INTO UserGameItems(UserGameId, ItemId )
               SELECT @GameId, Id
               FROM Items
               WHERE MinLevel BETWEEN 19 AND 21
        COMMIT
END

SELECT i.[Name] AS 'Item Name'
  FROM UserGameItems AS ugi
  JOIN Items AS i ON ugi.ItemId = i.Id
 WHERE ugi.UserGameId = @GameId

 GO



-- Problem 08. - Employees with Three Projects
USE SoftUni
GO
-- Create Procedure
CREATE OR ALTER PROC usp_AssignProject (@EmployeeId INT, @ProjectId INT)
AS
BEGIN

	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT
	SET @employeeProjectsCount = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = @EmployeeID)
   
   BEGIN TRANSACTION

	IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END
    
	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)VALUES (@EmployeeID, @ProjectID)

	COMMIT
END

-- Execute Procedure
SELECT * FROM EmployeesProjects WHERE EmployeeID = 2
EXEC usp_AssignProject 2, 1
SELECT * FROM EmployeesProjects WHERE EmployeeID = 2

GO



-- Problem 09. - Delete Employees
-- Create Table
CREATE TABLE Deleted_Employees (
     EmployeeId INT CONSTRAINT PK_Logs PRIMARY KEY IDENTITY NOT NULL
    ,FirstName NVARCHAR(50)
    ,LastName NVARCHAR(50)
    ,MiddleName NVARCHAR(50)
	,JobTitle NVARCHAR(50)
	,DepartmentId INT CONSTRAINT FK_DepartmentId FOREIGN KEY REFERENCES Departments(DepartmentId)
	,Salary Money
)
GO

-- Create Trigger
CREATE OR ALTER TRIGGER tr_DeletedEmployees
ON Employees AFTER DELETE 
AS
	INSERT INTO Deleted_Employees
	SELECT 	
		d.FirstName, 
		d.LastName, 
		d.MiddleName, 
		d.JobTitle, 
		d.DepartmentID, 
		d.Salary
	FROM deleted as d