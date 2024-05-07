select * from Categories 
select * from Suppliers 

select categoryId , categoryName  from Categories 
union
select SupplierId , CompanyName from Suppliers ; 

select * from Orders where ShipCountry = 'Spain'
intersect
select * from orders where Freight>50 ; 

--get the order id , productname , quantitysold of products that have price greater than 15 
select * from [Order Details]
select * from products ; 
select OrderId , ProductName , Quantity from [Order Details] od join products p on od.productid = p.productid where p.UnitPrice>15; 

--get order id , productNam , quantitySold of the product that are from category 'dairy' and within range 10 and 20 ; 
select * from Categories ; 
select * from products ; 
select * from [Order Details];
select OrderId , ProductName , Quantity from [Order Details] od join products p on od.productid = p.productid join Categories c on p.CategoryID=c.CategoryID where c.Categoryname like '%dairy%' and p.UnitPrice between 10 and 20  ;  


select OrderId , ProductName , Quantity , p.UnitPrice from [Order Details] od join products p on od.productid = p.productid where p.UnitPrice>15
union
select OrderId , ProductName , Quantity, p.UnitPrice from [Order Details] od join products p on od.productid = p.productid join Categories c on p.CategoryID=c.CategoryID where c.Categoryname like '%dairy%' and p.UnitPrice between 10 and 20
order by p.unitprice desc; 

--CTE (common table expression) 

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc


create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select * from vwOrderDetails ; 
--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA

select * from products ; 

with orderDetailsCTE as
	(select o.OrderId, c.ContactName, p.ProductName
	from orders o join Customers c on o.CustomerID = c.CustomerID
	join [Order Details] od on o.OrderID = od.OrderId
	join Products p on od.ProductID = p.ProductID
	where c.Country = 'USA'
	Union
	select o.OrderId, c.ContactName, p.ProductName
	from orders o join Customers c on o.CustomerID = c.CustomerID
	join [Order Details] od on o.OrderID = od.OrderId
	join Products p on od.ProductID = p.ProductID
	where o.Freight < 20 and c.Country = 'France')
 
	select top 10 * from  OrderDetailsCTE;