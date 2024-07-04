create table department (
    d_id serial primary key,
    d_name varchar(50) not null
);

create table employee (
    e_id serial primary key,
    d_id int references department(d_id),
    e_name varchar(50) not null,
    age int not null,
    phone varchar(15) not null
);

create table Salary (
    e_id int refrences employee(e_id),
    salary decimal(10, 2) not null,
    primary key (e_id)
);
