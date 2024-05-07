
--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
select * from titles ; 
select * from titleauthor ; 
select * from authors ; 
select * from publishers ; 

create proc proc_getpubsfromauthor(@authorName varchar(20)) 
as 
begin 
select  t.title as 'book', p.pub_name as 'publisher name' from titles t
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
where a.au_fname = @authorName;
end 

exec proc_getpubsfromauthor 'Ann';

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price , quantity and the cost.
select * from employee ; 
select * from sales ; 
select * from titles ; 

create proc proc_getcostfromemployeename(@employeename varchar(20))
as
begin 
select t.title 'titles', price , qty , (qty*price) 'cost'  from employee e 
join titles t on t.pub_id=e.pub_id 
join sales s on s.title_id=t.title_id where e.fname=@employeename;
end 
exec proc_getcostfromemployeename 'Paolo'; 
--3) Create a query that will print all names from authors and employees
select au_fname as name from authors
union
select fname as name from employee;

--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
 
--print first 5 orders after sorting them based on the price of order

select top 5 t.title  'titlename',p.pub_name  'pub name',(a.au_fname+' '+a.au_lname)  'author name',s.qty ,t.price ,(s.qty * t.price) 'cost'
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
order by cost;

