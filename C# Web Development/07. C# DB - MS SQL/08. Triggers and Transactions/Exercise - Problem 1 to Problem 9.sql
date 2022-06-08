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



-- Problem 03. - Deposit Money
-- Create Procedure
CREATE OR ALTER PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION

		DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

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

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

-- Execute Procedure
SELECT * FROM Accounts WHERE Id = 1
EXEC usp_DepositMoney 1, 234.14
SELECT * FROM Accounts WHERE Id = 1



-- Problem 04. - Withdraw Money Procedure



-- Problem 05. - Money Transfer



-- Problem 06. - Create Table Logs



-- Problem 07. - * Massive Shopping *



-- Problem 08. - Employees with Three Projects



-- Problem 09. - Delete Employees