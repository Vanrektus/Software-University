-- Create trigger
CREATE OR ALTER TRIGGER tr_FirstNamesChanged
ON Employees FOR UPDATE
AS
INSERT INTO FirstNamesChangeLog (OldFirstName, NewFirstName, UpdateDate)
SELECT d.FirstName, i.FirstName, GETDATE() FROM inserted AS i
JOIN deleted AS d ON d.EmployeeID = i.EmployeeID AND d.FirstName <> i.FirstName

GO

-- Execute and test trigger
SELECT * FROM Employees

UPDATE Employees SET FirstName = 'Pesho' WHERE EmployeeID IN (3, 4, 5)

-- Won't show in the log because we look only for first namess
UPDATE Employees SET LastName = 'Petrov' WHERE EmployeeID = 2

UPDATE Employees SET FirstName = 'Gosho' WHERE EmployeeID = 1

SELECT * FROM FirstNamesChangeLog