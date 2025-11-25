-- After creating a database, update your connection string in StoreDbContext.cs
-- Example: options.UseSqlServer("your-connection-string-here");

create database console_online_store
use console_online_store
go

create table Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(200) NOT NULL
);

create table Manufacturers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ManufacturerName NVARCHAR(200) NOT NULL
);

create table UserRoles
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserRoleName NVARCHAR(100) NOT NULL UNIQUE
);

create table Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Login NVARCHAR(200) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(300) NOT NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT (0.00),
    UserRoleId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    IsBanned Bit not null DEFAULT 0,
    FOREIGN KEY (UserRoleId) REFERENCES UserRoles(Id)
);

create table ProductTitles
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductTitle NVARCHAR(300) NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
);

create table Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductTitleId INT NOT NULL,
    ManufacturerId INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    Stock INT NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    Description NVARCHAR(MAX),
    FOREIGN KEY (ProductTitleId) REFERENCES ProductTitles(Id) ON DELETE CASCADE,
    FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers(Id)
);

create table OrderStates
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StateName NVARCHAR(100) NOT NULL UNIQUE
);

create table Carts
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL UNIQUE,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

create table CartItems
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CartId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (CartId) REFERENCES Carts(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    CONSTRAINT UQ_Cart_Product UNIQUE (CartId, ProductId)
);

create table CustomerOrders
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OperationTime DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CustomerId INT NOT NULL,
    OrderStateId INT NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL CHECK (TotalAmount >= 0),
    FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    FOREIGN KEY (OrderStateId) REFERENCES OrderStates(Id)
);

create table CustomerOrderDetails
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerOrderId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    ProductAmount INT NOT NULL CHECK (ProductAmount > 0),
    FOREIGN KEY (CustomerOrderId) REFERENCES CustomerOrders(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

insert into UserRoles(UserRoleName) values
('Admin'),
('User'),
('Guest');

insert into OrderStates(StateName) values
('confirmed'),
('canceled by user'),
('canceled by administrator');

insert into Categories (CategoryName) values
('Electronics'),
('Computers & Laptops'),
('Mobile Phones'),
('Home Appliances'),
('Gaming'),
('Audio & Headphones'),
('Cameras & Photography'),
('Wearable Technology'),
('Office Supplies'),
('Furniture');

insert into Manufacturers (ManufacturerName) values
('Apple'),
('Samsung'),
('Sony'),
('Dell'),
('HP'),
('Lenovo'),
('LG'),
('Microsoft'),
('Asus'),
('Acer'),
('Canon'),
('Nikon'),
('Bose'),
('JBL'),
('Logitech');

insert into ProductTitles (ProductTitle, CategoryId) values
('MacBook Pro', 2),
('iPhone 15 Pro', 3),
('Galaxy S24 Ultra', 3),
('PlayStation 5', 5),
('Xbox Series X', 5),
('Dell XPS 15', 2),
('ThinkPad X1 Carbon', 2),
('Sony WH-1000XM5', 6),
('AirPods Pro', 6),
('LG OLED TV', 1),
('Samsung Smart TV', 1),
('Canon EOS R6', 7),
('Nikon Z6 II', 7),
('iPad Pro', 1),
('Surface Pro 9', 1),
('Apple Watch Series 9', 8),
('Galaxy Watch 6', 8),
('Bose QuietComfort 45', 6),
('Magic Mouse', 9),
('MX Master 3S', 9),
('Refrigerator Smart', 4),
('Washing Machine', 4),
('Office Chair Pro', 10),
('Standing Desk', 10),
('Mechanical Keyboard', 9);

insert into Products (ProductTitleId, ManufacturerId, UnitPrice, Stock, Description) values
(1, 1, 1999.99, 25, 'MacBook Pro 14-inch, M3 chip, 16GB RAM, 512GB SSD'),
(1, 1, 2499.99, 15, 'MacBook Pro 16-inch, M3 Pro chip, 32GB RAM, 1TB SSD'),
(2, 1, 999.99, 50, 'iPhone 15 Pro 128GB, Titanium Blue'),
(2, 1, 1199.99, 40, 'iPhone 15 Pro 256GB, Natural Titanium'),
(3, 2, 1199.99, 35, 'Galaxy S24 Ultra 256GB, Phantom Black'),
(3, 2, 1399.99, 20, 'Galaxy S24 Ultra 512GB, Titanium Gray'),
(4, 3, 499.99, 30, 'PlayStation 5 Console with DualSense Controller'),
(4, 3, 449.99, 25, 'PlayStation 5 Digital Edition'),
(5, 8, 499.99, 40, 'Xbox Series X 1TB Console'),
(6, 4, 1799.99, 18, 'Dell XPS 15, Intel i7, 16GB RAM, 512GB SSD, RTX 4050'),
(7, 6, 1599.99, 22, 'ThinkPad X1 Carbon Gen 11, Intel i7, 16GB RAM, 512GB SSD'),
(8, 3, 399.99, 45, 'Sony WH-1000XM5 Wireless Noise Canceling Headphones, Black'),
(8, 3, 399.99, 38, 'Sony WH-1000XM5 Wireless Noise Canceling Headphones, Silver'),
(9, 1, 249.99, 60, 'AirPods Pro 2nd Generation with MagSafe Charging Case'),
(10, 7, 1499.99, 12, 'LG OLED 55-inch 4K Smart TV'),
(10, 7, 2299.99, 8, 'LG OLED 65-inch 4K Smart TV'),
(11, 2, 899.99, 20, 'Samsung 55-inch QLED 4K Smart TV'),
(11, 2, 1299.99, 15, 'Samsung 65-inch QLED 4K Smart TV'),
(12, 11, 2499.99, 10, 'Canon EOS R6 Mirrorless Camera Body Only'),
(12, 11, 3299.99, 5, 'Canon EOS R6 with 24-105mm f/4L Lens Kit'),
(13, 12, 1999.99, 12, 'Nikon Z6 II Mirrorless Camera Body Only'),
(14, 1, 799.99, 30, 'iPad Pro 11-inch, M2 chip, 128GB, Wi-Fi'),
(14, 1, 1099.99, 25, 'iPad Pro 12.9-inch, M2 chip, 256GB, Wi-Fi'),
(15, 8, 999.99, 20, 'Microsoft Surface Pro 9, Intel i5, 8GB RAM, 256GB SSD'),
(16, 1, 399.99, 40, 'Apple Watch Series 9 GPS 41mm'),
(16, 1, 429.99, 35, 'Apple Watch Series 9 GPS 45mm'),
(17, 2, 299.99, 28, 'Samsung Galaxy Watch 6 40mm'),
(18, 13, 329.99, 32, 'Bose QuietComfort 45 Wireless Headphones'),
(19, 1, 79.99, 50, 'Apple Magic Mouse - White'),
(20, 15, 99.99, 45, 'Logitech MX Master 3S Wireless Mouse'),
(21, 7, 1899.99, 8, 'LG Smart Refrigerator 26 cu ft, French Door, Stainless Steel'),
(21, 2, 1699.99, 10, 'Samsung Family Hub Refrigerator 27 cu ft'),
(22, 7, 899.99, 15, 'LG Front Load Washing Machine 5.0 cu ft with Steam'),
(23, 4, 399.99, 25, 'Ergonomic Office Chair with Lumbar Support'),
(24, 4, 599.99, 12, 'Electric Height Adjustable Standing Desk 60x30 inch'),
(25, 15, 149.99, 40, 'Logitech Mechanical Gaming Keyboard RGB');

