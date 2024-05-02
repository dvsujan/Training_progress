use NorthWind

select * from Products ; 

select ProductName , QuantityPerUnit from products ;

select ProductName as 'Name_Of_Product' , QuantityPerUnit as Quantity_Per_Unit from Products ; 

select * from Products where UnitPrice>10 ; 

select * from Products where UnitsInStock=0 ; 

--select the products that will no more be stocked
select * from Products where Discontinued=1 ; 

--select products that will be in clerance 
select * from Products where Discontinued=1 and UnitPrice>0 ; 

--select products that are in the range of 10 to 30 

select * from Products where UnitsInStock>10 and UnitsInStock<30 ; 
select * from Products where UnitPrice between 10 and 30 ; 


select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) as "Amount worth"
from products where CategoryID =3

select * from products where QuantityPerUnit like '%boxes%'
select * from products where QuantityPerUnit like '__ boxes'

select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Avreage price of products supplied by supplier 2
select AVG(UnitPrice)as "average price of suppiler2" from Products where SupplierID=2 ; 

--Worth of products in order
select sum(unitsInStock*ReorderLevel) "expected amount to be paind" from Products ; 

select categoryId , sum(UnitsInStock) "Stock Available" from products group by categoryId ; 

-- Get the average price of products supplied by every supplier 
select supplierId , avg(unitprice) "avg price" from products group by supplierId ; 



select supplierID,
count(ProductName) NO_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

select supplierID,
ProductName,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

select supplierId , CategoryId , avg(UnitPrice) Average_Price from Products group by categoryId , supplierId ; 

--select category ID and Sum of products avaible if the total number of products than 10 

select categoryid , sum(unitsinstock)  "sum of products" from products group by categoryId having count(productName)>10 ; 


select * from products order by categoryId , SupplierID, productName ;

select * from products order by productName ; 
select productName, UnitPrice from products where unitPrice>15 order by categoryId ; 

--get the products sorder by the price . Fetch only those products that will be discontinued 

select * from products where discontinued=1 order by unitPrice ; 

