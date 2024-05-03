use pubs; 

--1) Print the storeid and number of orders for the store

select stor_id, count(*) as 'no of orders' from sales group by stor_id ; 

--2) print the numebr of orders for every title
select * from sales ; 
select * from titles ; 

select t.title, count(s.ord_num) 'no of orders' from titles t join titleauthor ta on t.title_id = ta.title_id join sales s on t.title_id = s.title_id group by  t.title;

--3) print the publisher name and book name
select p.pub_name 'publisher name' , t.title 'book name' from titles t join publishers p on t.pub_id=p.pub_id ;

--4) Print the author full name for all the authors
select * from titleauthor ; 
select * from authors ; 

select (au_fname +' '+ au_lname) 'author full name' from authors ; 


--5) Print the price or every book with tax (price+price*12.36/100)
select * from titles ; 
select title ,price,(price+(price*(12.36/100))) 'price after tax' from titles ; 



--6) Print the author name, title name
	select * from titleauthor ; 
	select * from titles ; 
	select * from authors ; 

select au.au_fname, au.au_lname, t.title from titleauthor ta join titles t on ta.title_id = t.title_id join authors au on ta.au_id = au.au_id;

--7) print the author name, title name and the publisher name
select au.au_fname, au.au_lname, t.title, p.pub_name from titleauthor ta  join titles t on ta.title_id = t.title_id  join authors au on ta.au_id = au.au_id join publishers p on t.pub_id = p.pub_id;

--8) Print the average price of books pulished by every publicher
select p.pub_name, AVG(t.price) 'average price' from titles t join publishers p on t.pub_id = p.pub_id group by  p.pub_name;

--9) print the books published by 'Marjorie'
select * from titles ; 
select * from publishers ; 
select t.title from titles t join publishers p on t.pub_id=p.pub_id where p.pub_name='Marjorie'; 


--10) Print the order numbers of books published by 'New Moon Books'
select s.ord_num from sales s join titles t on s.title_id = t.title_id join publishers p on t.pub_id = p.pub_id where p.pub_name = 'New Moon Books';
--11) Print the number of orders for every publisher
select p.pub_name, count(s.ord_num) 'no of ordres' from publishers p join titles t on p.pub_id = t.pub_id join sales s on t.title_id = s.title_id group by  p.pub_name;


--12) print the order number , book name, quantity, price and the total price for all orders

select s.ord_num, t.title, s.qty, t.price, (s.qty * t.price) 'total prie' from sales s join titles t on s.title_id = t.title_id;


--13) print he total order quantity fro every book
select t.title, sum(s.qty) 'quantity' from titles t join sales s on t.title_id = s.title_id group by t.title;



--14) print the total ordervalue for every book
select t.title, sum(s.qty * t.price) 'total orer value' from titles t join sales s on t.title_id = s.title_id group by t.title;