
--CREATE DATABASE PizzaOrderingDB;
--GO

--USE PizzaOrderingDB;
--GO

-- Customer Table
--CREATE TABLE Customers (
--    CustomerID INT PRIMARY KEY IDENTITY,
--    FName NVARCHAR(50),
--    LName NVARCHAR(50),
--    Address NVARCHAR(100),
--    PhoneNo NVARCHAR(20),
--    City NVARCHAR(50),
--    Email NVARCHAR(100)
--);

-- Employee Table
--CREATE TABLE Employees (
--    EmployeeID INT PRIMARY KEY IDENTITY,
--    UserName NVARCHAR(50),
--    Password NVARCHAR(100),
--    FName NVARCHAR(50),
--    LName NVARCHAR(50),
--    Address NVARCHAR(100),
--    PhoneNo NVARCHAR(20),
--    City NVARCHAR(50),
--    Email NVARCHAR(100)
--);

-- Pizza Table
--CREATE TABLE Pizzas (
--    PizzaID INT PRIMARY KEY IDENTITY,
--    Name NVARCHAR(100),
--    ImageURL NVARCHAR(255),
--    Category NVARCHAR(50),
--    Price DECIMAL(10, 2)
--);

-- Order Table
--CREATE TABLE Orders (
--    OrderID INT PRIMARY KEY IDENTITY,
--    OrderStatus NVARCHAR(50),
--    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
--    PizzaID INT FOREIGN KEY REFERENCES Pizzas(PizzaID),
--    TotalPrice DECIMAL(10,2),	
--    DeliveryDateTime DATETIME,
--    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
--);

