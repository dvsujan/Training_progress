select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders
select productname from products where supplierId=(select SupplierID from suppliers where companyName = 'Tokyo Traders' ) ; 

select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')


select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')


select * from customers; 
select * from products ; 
--select the product id and the quantity ordered by customrs from France

select ProductID, Quantity from [Order Details] where OrderID IN (

    select OrderID

    from Orders

    where CustomerID IN (

        select CustomerID

        from Customers

        where Country = 'France'

    )

);

--Get the products that are priced above the average price of all the products	\
select * from products where unitprice>(select avg(UnitPrice) from products) ; 

--select the latest order by every employee 
select EmployeeId , max(orderDate) from orders group by employeeid


select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--select the maxium priced product in every category 
select * from products p1 where UnitPrice=(select max(unitPrice) from products p2 where p1.CategoryID=p2.CategoryID) ;



--select 
select * from orders o1 where Freight=(select max(Freight) from orders o2 where o1.customerid=o2.customerid) order by o1.customerid;


--cross join
select * from Categories,customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select categoryName,ProductName from Categories, Products 
where Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select companyname,ContactName,ProductName,UnitsOnOrder
 from Suppliers s join Products p
 on s.SupplierID = p.SupplierID
 order by UnitsOnOrder desc

 --print the order id , customername and the fright cost for all the orders 
 select orderId , contactName , Freight from orders join customers on orders.CustomerID=Customers.CustomerID ; 

 --produtname , quantity sold , Discount Price , Order Id , Fright for all orders 
 select po.orderid , .productname , from orders o joi[Order Details] od on o.orderId = od.orderId join products p on p.productId = od.productid ; 

 
 --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 --select customer name , product name , quantity sold and the frieght 
 -- total price(unitprice * quantity + freight) 
 -- customer product 
 select c.ContactName "Customer name" ,p.ProductName , od.Quantity , o.Freight , (p.UnitPrice * od.Quantity + o.Freight) "Total Price" from Orders o join [Order Details] od on o.OrderID=od.OrderID 
join Products p on p.ProductID = od.ProductID
join customers c on c.customerID = o.CustomerID
order by o.OrderID
--Print the product name and the total quantity sold 
select productName , sum(quantity) from Products p join [order Details] od 
on p.productId = od.productId 
group by ProductName 
order by 2 ; 

--customer name and the number of products bought for every order 
select o.OrderID ,c.ContactName, count(ProductID) from [Order Details] od join Orders o on 
o.OrderID=od.OrderID join Customers c on o.CustomerID=c.CustomerID
group by o.OrderID,c.ContactName

