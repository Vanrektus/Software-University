CREATE DATABASE TableRelationsExercise

USE TableRelationsExercise


-- Problem 01. - One-To-One Relationship
CREATE TABLE Passports(
		PassportID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL
	   ,PassportNumber NVARCHAR(8) 
	    CONSTRAINT CC_PassportLength 
		CHECK (LEN(PassportNumber) = 8) NOT NULL
)

CREATE TABLE Persons(
		PersonID INT PRIMARY KEY IDENTITY NOT NULL
	   ,FirstName NVARCHAR(50) NOT NULL
	   ,Salary MONEY NOT NULL
	   ,PassportID INT CONSTRAINT FK_Persons_Passports
	   FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
)

INSERT INTO Persons VALUES
     ('Roberto', 43300, 102)
    ,('Tom', 56100, 103)
    ,('Yana', 60200, 101)

INSERT INTO Passports VALUES
     ('N34FG21B')
    ,('K65LO4R7')
    ,('ZE657QP2')
	

-- Problem 02. - One-To-Many Relationship
CREATE TABLE Manufacturers(
		ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL
	   ,[Name] NVARCHAR(15) NOT NULL
	   ,EstablishedOn DATE
)

CREATE TABLE Models(
		ModelID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL
	   ,[Name] NVARCHAR(15) NOT NULL
	   ,ManufacturerID INT
	   CONSTRAINT FK_Models_Manufacturers
	   FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers VALUES
     ('BMW', '07/03/1916')
    ,('Tesla', '01/01/2003')
    ,('Lada', '01/05/1966')

INSERT INTO Models VALUES
     ('X1', '1')
    ,('i6', '1')
    ,('Model S', '2')
	,('Model X', '2')
	,('Model 3', '2')
	,('Nova', '3')
	

-- Problem 03. - Many-To-Many Relationship
CREATE TABLE Students(
		StudentID INT PRIMARY KEY IDENTITY NOT NULL
	   ,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
		ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL
	   ,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	   StudentID INT
	   ,ExamID INT
	   ,CONSTRAINT PK_StudentsExams
	   PRIMARY KEY(StudentID, ExamID)
	   ,CONSTRAINT FK_StudentsExams_Students
	   FOREIGN KEY(StudentID)
	   REFERENCES Students(StudentID)
	   ,CONSTRAINT FK_StudentsExams_Exams
	   FOREIGN KEY(ExamID)
	   REFERENCES Exams(ExamID)
)

INSERT INTO Students VALUES
     ('Mila')
    ,('Toni')
    ,('Ron')

INSERT INTO Exams VALUES
     ('SpringMVC')
    ,('Neo4j')
    ,('Oracle 11g')

INSERT INTO StudentsExams VALUES
     (1, 101)
    ,(1, 102)
    ,(2, 101)
    ,(3, 103)
    ,(2, 102)
    ,(2, 103)
	

-- Problem 04. - Self-Referencing
CREATE TABLE Teachers(
		TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL
	   ,[Name] NVARCHAR(50) NOT NULL
	   ,ManagerID INT
	   ,CONSTRAINT FK_Teachers
	   FOREIGN KEY (ManagerID)
	   REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
     ('John', NULL)
    ,('Maya', NULL)
    ,('Silvia', NULL)
    ,('Ted', NULL)
    ,('Mark', 101)
    ,('Greta', 101)

UPDATE Teachers
SET ManagerID = 106
WHERE TeacherID IN (102, 103)

UPDATE Teachers
SET ManagerID = 105
WHERE TeacherID = 104


-- Problem 05. - Online Store Database
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities(
		CityID INT PRIMARY KEY IDENTITY NOT NULL
		,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
		CustomerID INT PRIMARY KEY IDENTITY NOT NULL
		,[Name] VARCHAR(50) NOT NULL
		,Birthday DATE
		,CityID INT
		CONSTRAINT FK_Customers_Cities
	    FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE ItemTypes(
		ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL
		,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
		ItemID INT PRIMARY KEY IDENTITY NOT NULL
		,[Name] NVARCHAR(50) NOT NULL
		,ItemTypeID INT
		CONSTRAINT FK_Items_ItemTypes
	    FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE Orders(
		OrderID INT PRIMARY KEY IDENTITY NOT NULL
		,CustomerID INT
		CONSTRAINT FK_Orders_Customers
	    FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE OrderItems(
		OrderID INT
		,ItemID INT
		,CONSTRAINT PK_OrderItems
	    PRIMARY KEY(OrderID, ItemID)
	    ,CONSTRAINT FK_OrderItems_Orders
	    FOREIGN KEY(OrderID)
	    REFERENCES Orders(OrderID)
	    ,CONSTRAINT FK_OrderItems_Items
	    FOREIGN KEY(ItemID)
	    REFERENCES Items(ItemID)
)

-- Problem 06. - Online Store Database
CREATE DATABASE University

USE University

CREATE TABLE Majors(
		MajorID INT PRIMARY KEY IDENTITY NOT NULL
		,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Subjects(
		SubjectID INT PRIMARY KEY IDENTITY NOT NULL
		,SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
		StudentID INT PRIMARY KEY IDENTITY NOT NULL
		,StudentNumber INT
		,StudentName NVARCHAR(50) NOT NULL
		,MajorID INT
		CONSTRAINT FK_Students_Majors
	    FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
		PaymentID INT PRIMARY KEY IDENTITY NOT NULL
		,PaymentDate DATE
		,PaymentAmount MONEY
		,StudentID INT
		CONSTRAINT FK_Payments_Students
	    FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Agenda(
		StudentID INT
		,SubjectID INT
		,CONSTRAINT PK_Agenda
	    PRIMARY KEY(StudentID, SubjectID)
	    ,CONSTRAINT FK_Agenda_Students
	    FOREIGN KEY(StudentID)
	    REFERENCES Students(StudentID)
	    ,CONSTRAINT FK_Agenda_Subjects
	    FOREIGN KEY(SubjectID)
	    REFERENCES Subjects(SubjectID)
)