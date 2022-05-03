-- Problem: Objuscate CC Numbers
CREATE VIEW v_CustomerPaymentInfo AS
SELECT [CustomerID]
      ,[FirstName]
      ,[LastName]
      ,CONCAT(LEFT([PaymentNumber], 6), REPLICATE('*', 10)) AS [PaymentNumber]
	  ,LEFT([PaymentNumber], 6)  AS [FirstSix]
	  ,RIGHT([PaymentNumber], 10)  AS [LastTen]
	  ,REPLICATE('*', 10)  AS [Only*]
  FROM [Demo].[dbo].[Customers]

-- Problem: Pallets
SELECT Name
	  ,Quantity
	  ,BoxCapacity
	  ,PalletCapacity 
	  ,CEILING(CEILING(CAST(Quantity AS float) / BoxCapacity) / PalletCapacity) AS NumberOfPallets
	--,CEILING(CEILING(CONVERT(float, Quantity) / BoxCapacity) / PalletCapacity) AS NumberOfPallets
	--,CEILING(CEILING(Quantity * 1.0 / BoxCapacity) / PalletCapacity) AS NumberOfPallets
  FROM Products

-- Problem: Quarterly Report
USE Orders

SELECT [Id]
      ,[ProductName]
      ,DATEPART(QUARTER, [OrderDate]) AS Quarter
	  ,DATEPART(MONTH, [OrderDate]) AS Month
	  ,DATEPART(YEAR, [OrderDate]) AS Year
	  ,DATEPART(DAY, [OrderDate]) AS Day
  FROM [Orders]