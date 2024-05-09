 create table Doctor(
 Id int identity(101, 1 ) constraint pk_doc primary key , 
 Name varchar(100) not null , 
 specialization varchar(100) , 
 dob datetime , 
 age datetime 
 ) ; 


 create table patient(
 Id int identity(101 , 1 ) constraint pk_pt primary key , 
 Name varchar(100) not null , 
 dob datetime , 
 age datetime ) ; 

 create table Appointment(
 Id int identity(101 , 1 ) constraint pk_ap primary key , 
 date datetime , 
 reason varchar(100) , 
 docId int constraint fk_doc references Doctor(Id) , 
 patId int constraint fk_pt references Patient(Id) ) ; 
 
