-- Creación de Base de datos
CREATE DATABASE DBTechProducts;
GO

-- Usar la base de datos
USE DBTechProducts;
GO

-- Crear la tabla de usuarios
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(50) UNIQUE NOT NULL,
    Passwd VARCHAR(100) NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    statusUser BIT DEFAULT 1
);
GO

-- Crear tabla de productos
CREATE TABLE Product (
    ProductId INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(50) NOT NULL,
    Brand VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT DEFAULT 0,
    CreationAt DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Product (ProductName, Brand, Price, Stock, CreationAt) VALUES
('Gaming Laptop X1', 'Asus', 4200, 8),
('Mechanical Keyboard RGB', 'Corsair', 1500, 20),
('Wireless Gaming Mouse', 'Logitech', 800, 25),
('Curved 4K Monitor', 'LG', 2500, 10),
('High-Speed SSD 1TB', 'Samsung', 180, 15),
('Gaming Headset 7.1', 'Razer', 120, 30),
('Ultra HD Webcam', 'Logitech', 200, 12),
('Ergonomic Office Chair', 'Secretlab', 450, 5),
('RTX 4080 Graphics Card', 'Nvidia', 1200, 7),
('Portable External Hard Drive 2TB', 'Western Digital', 100, 20),
('iPad Pro 12.9"', 'Apple', 1300, 10),
('Smartphone Galaxy S23 Ultra', 'Samsung', 1400, 15),
('MacBook Pro M2', 'Apple', 2500, 6),
('Mechanical Gaming Chair', 'DXRacer', 3500, 8),
('Curved Ultrawide Monitor 34"', 'Dell', 1800, 5),
('Gaming Router Wi-Fi 6', 'TP-Link', 2500, 10),
('Noise Cancelling Headphones', 'Sony', 300, 15),
('4K Streaming Webcam', 'Razer', 1800, 12),
('Programmable Macro Keyboard', 'SteelSeries', 1700, 18);
GO

SELECT * FROM [User];

SELECT * FROM Product;
GO
