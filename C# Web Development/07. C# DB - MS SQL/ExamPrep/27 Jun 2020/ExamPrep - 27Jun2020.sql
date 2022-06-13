CREATE DATABASE WashingMachineService

USE WashingMachineService

-- 01. DDL
CREATE TABLE [Clients](
	[ClientId] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL,
	CHECK (LEN([Phone]) = 12)
)

CREATE TABLE [Mechanics](
	[MechanicId] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models](
	[ModelId] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Jobs](
	[JobId] INT PRIMARY KEY IDENTITY NOT NULL,
	[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
	[Status] VARCHAR(11) NOT NULL DEFAULT('Pending'),
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE,
	CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE [Orders](
	[OrderId] INT PRIMARY KEY IDENTITY NOT NULL,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT NOT NULL DEFAULT(0)
)

CREATE TABLE [Vendors](
	[VendorId] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Parts](
	[PartId] INT PRIMARY KEY IDENTITY NOT NULL,
	[SerialNumber] VARCHAR(50) NOT NULL UNIQUE,
	[Description] VARCHAR(255),
	[Price] DECIMAL(6, 2) NOT NULL,
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
	[StockQty] INT NOT NULL DEFAULT(0),
	CHECK ([Price] > 0),
	CHECK ([StockQty] >= 0)
)

CREATE TABLE [OrderParts](
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT NOT NULL DEFAULT(1),
	PRIMARY KEY([OrderId], [PartId]),
	CHECK([Quantity] > 0)
)

CREATE TABLE [PartsNeeded](
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT NOT NULL DEFAULT(1),
	PRIMARY KEY([JobId], [PartId]),
	CHECK([Quantity] > 0)
)



-- 02. Insert
INSERT INTO [Clients]([FirstName], [LastName], [Phone])
VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene'	,'Montezuma'	,'925-615-5185'),
('Jettie'	,'Mconnell'	,'908-802-3564'),
('Lemuel' ,'Latzke	','631-748-6479'),
('Melodie'	,'Knipp',	'805-690-1682'),
('Candida'	,'Corbley'	,'908-275-8357')

INSERT INTO [Parts]([SerialNumber], [Description], [Price], [VendorId])
VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048',	'Suspension Rod',	42.81, 1),
('W10841140', 'Silicone Adhesive' ,	6.77, 4),
('WPY055980',	'High Temperature Adhesive',	13.94, 3)



-- 03. Update
SELECT * FROM Mechanics AS m
WHERE FirstName = 'Ryan'

SELECT * FROM Jobs

UPDATE Jobs
   SET MechanicId = 3
 WHERE MechanicId IS NULL

 UPDATE Jobs
    SET [Status] = 'In Progress'
  WHERE [Status] = 'Pending'



-- 04. Delete
DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROM Orders WHERE OrderId = 19



-- 05. Mechanic Assignments
  SELECT CONCAT(m.[FirstName], ' ', m.[LastName]) AS [Mechanic],
         j.[Status],
		 j.[IssueDate]
    FROM [Mechanics] AS m
    JOIN [Jobs] AS j
      ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId]



-- 06. Current Clients
  SELECT 
         CONCAT(c.FirstName, ' ', c.LastName) AS Client,
		 DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
		 j.[Status]
    FROM Clients AS c
    JOIN Jobs AS j ON c.ClientId = j.ClientId
   WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.ClientId



-- 07. Mechanic Performance
  SELECT 
         CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		 AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
    FROM Jobs AS j
    JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
   WHERE j.MechanicId IS NOT NULL
GROUP BY j.MechanicId, m.FirstName, m.LastName
ORDER BY j.MechanicId



-- 08. Available Mechanics
SELECT CONCAT([FirstName], ' ', [LastName]) AS [Available] 
  FROM [Mechanics]
 WHERE [MechanicId] NOT IN (   SELECT [MechanicId] FROM [Jobs]
                                WHERE [Status] = 'In Progress'
                             GROUP BY [MechanicId]
                           )



-- 09. Past Expenses
   SELECT 
          j.[JobId],
          ISNULL(SUM(p.[Price] * op.[Quantity]), 0) AS [Total]
     FROM [Jobs] AS j
LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
LEFT JOIN [Parts] AS p ON op.[PartId] = p.[PartId]
    WHERE j.[Status] = 'Finished'
 GROUP BY j.[JobId]
 ORDER BY [Total] DESC, j.[JobId]



-- 10. Missing Parts
 SELECT *
   FROM (
		      SELECT 
		             p.[PartId],
		   	      p.[Description],
		   	      pn.[Quantity] AS [Required],
		   	      p.[StockQty] AS [In Stock],
		   	      ISNULL(op.[Quantity], 0) AS [Ordered]
		        FROM [Jobs] AS j
		   LEFT JOIN [PartsNeeded] AS pn ON j.[JobId] = pn.[JobId]
		   LEFT JOIN [Parts] AS p ON pn.[PartId] = p.[PartId]
		   LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
		   LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
		       WHERE j.[Status] <> 'Finished' AND (o.[Delivered] = 0 OR o.Delivered IS NULL)
         ) AS [PartsQuantitySubQuery]
   WHERE [Required] > [In Stock] + [Ordered]
ORDER BY [PartId]



-- 11. Place Order
CREATE OR ALTER PROCEDURE usp_PlaceOrder @jobID INT, @partSerialNumber VARCHAR(50), @quantity INT
AS
BEGIN
	IF (@quantity <= 0)
	BEGIN
		THROW 50012, 'Part quantity must be more than zero!', 1
	END

	IF((SELECT [Status] FROM [Jobs]
	    WHERE [JobId] = @jobID) = 'Finished')
	BEGIN
		THROW 50011, 'This job is not active!', 1
	END

	DECLARE @jobIdDb INT = (
							SELECT [JobId] FROM [Jobs]
							WHERE [JobId] = @jobID
						   )
	IF (@jobIdDb IS NULL)
	BEGIN
		THROW 50013, 'Job not found!', 1
	END

	DECLARE @partId INT = (
							SELECT [PartId] FROM [Parts]
							WHERE [SerialNumber] = @partSerialNumber
						  )
	IF (@partId IS NULL)
	BEGIN
		THROW 50014, 'Part not found!', 1
	END

	---There is no any orders for given @jobId and we should create a new order in all cases
	IF ((SELECT [OrderId] FROM [Orders]
		WHERE [JobId] = @jobID AND [IssueDate] IS NULL) IS NULL)
	BEGIN
		INSERT INTO [Orders]([JobId], [IssueDate], [Delivered])
		VALUES
		(@jobID, NULL, 0)
	END

	---It returns the OrderId of newly created or alredy existing order
	DECLARE @orderId INT = (SELECT [OrderId] FROM [Orders]
							WHERE [JobId] = @jobID AND [IssueDate] IS NULL
						   )

	DECLARE @orderedPartQuantity INT = (SELECT [Quantity] FROM [OrderParts]
										WHERE [OrderId] = @orderId AND [PartId] = @partId
									   )
	---There is no order for the given @partId and @orderId. We should order it with given @quantity
	IF (@orderedPartQuantity IS NULL)
	BEGIN
		INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
		VALUES
		(@orderId, @partId, @quantity)
	END
	ELSE
	BEGIN
		UPDATE [OrderParts]
		SET [Quantity] += @quantity
		WHERE [OrderId] = @orderId AND [PartId] = @partId
	END
END



-- 12. Cost of Order
CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(8, 2)
AS
BEGIN
	DECLARE @totalCost DECIMAL(8, 2)

	DECLARE @jobOrdersCount INT = (SELECT COUNT(OrderId) FROM [Jobs] AS j
									LEFT JOIN [Orders] AS o
									ON j.[JobId] = o.[JobId]
									WHERE j.[JobId] = @jobId
								  )
	
	IF @jobOrdersCount = 0
	BEGIN
		RETURN 0
	END

	SET @totalCost =   (SELECT SUM(p.[Price] * op.[Quantity]) FROM [Jobs] AS j
						LEFT JOIN [Orders] AS o
						ON j.[JobId] = o.[JobId]
						LEFT JOIN [OrderParts] AS op
						ON o.[OrderId] = op.[OrderId]
						LEFT JOIN [Parts] AS p
						ON op.[PartId] = p.[PartId]
						WHERE j.[JobId] = @jobId
					   )

	RETURN @totalCost
END