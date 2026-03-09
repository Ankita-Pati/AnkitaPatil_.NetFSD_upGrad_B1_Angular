create database SQLAssignment2
use SQLAssignment2

CREATE TABLE Customers (
customer_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50),last_name VARCHAR(50)
);

CREATE TABLE Stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

CREATE TABLE Brands (
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(100)
);

CREATE TABLE Categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100)
);

CREATE TABLE Products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    store_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Order_Items (
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Stocks (
store_id INT,product_id INT,
quantity INT,
PRIMARY KEY (store_id, product_id),
FOREIGN KEY (store_id) REFERENCES Stores(store_id),
FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Customers (first_name, last_name) VALUES
('John','Smith'),('Emma','Johnson'),('Michael','Brown'),('Sophia','Williams');

INSERT INTO Stores (store_name) VALUES('Central Store'),('City Mall Store'),('Downtown Store');

INSERT INTO Brands (brand_name) VALUES('Nike'),('Adidas'),('Puma');

INSERT INTO Categories (category_name) VALUES ('Shoes'),('Clothing'),('Accessories');

INSERT INTO Products (product_name, brand_id, category_id, model_year, list_price) VALUES
('Running Shoes',1,1,2024,650),('Training Shoes',2,1,2024,800),('Sports Jacket',2,2,2023,450),
('Cap',3,3,2022,300),('Football Shoes',1,1,2025,900);

INSERT INTO Orders (customer_id, store_id, order_date, order_status) VALUES
(1,1,'2026-03-01',1),(2,2,'2026-03-02',4),(3,1,'2026-03-03',4),
(4,3,'2026-03-04',2),(1,2,'2026-03-05',4);

INSERT INTO Order_Items (order_id, product_id, quantity, list_price, discount) VALUES
(1,1,2,650,0.10),(2,2,1,800,0.05),(3,1,3,650,0.00),(3,5,1,900,0.10),(5,2,2,800,0.15);

INSERT INTO Stocks (store_id, product_id, quantity) VALUES
(1,1,50),(1,2,30),(2,1,40),(2,3,20),(3,5,25);

--Problem1
SELECT c.first_name,c.last_name,o.order_id,o.order_date,o.order_status
FROM Customers c INNER JOIN Orders o ON c.customer_id = o.customer_id
WHERE o.order_status = 1 OR o.order_status = 4
ORDER BY o.order_date DESC;

--Problem2
SELECT p.product_name,b.brand_name,c.category_name,p.model_year,p.list_price
FROM Products p INNER JOIN Brands b ON p.brand_id = b.brand_id
INNER JOIN Categories c ON p.category_id = c.category_id
WHERE p.list_price > 500 ORDER BY p.list_price ASC;

--Problem3
SELECT s.store_name,SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM Stores s INNER JOIN Orders o ON s.store_id = o.store_id
INNER JOIN Order_Items oi ON o.order_id = oi.order_id
WHERE o.order_status = 4 GROUP BY s.store_name
ORDER BY total_sales DESC;

--Problem4
SELECT p.product_name,s.store_name,st.quantity AS available_stock,
SUM(oi.quantity) AS total_quantity_sold FROM Stocks st INNER JOIN Products p
ON st.product_id = p.product_id INNER JOIN Stores s
ON st.store_id = s.store_id LEFT JOIN Order_Items oi
ON st.product_id = oi.product_id GROUP BY p.product_name,s.store_name,
st.quantity ORDER BY p.product_name;

