create database assesments
use assesments
create table books(
id int primary key,
author varchar(100),
isbn bigint unique,
published_date datetime)
alter table books
add title varchar(150)
insert into books(id,title,author,isbn,published_date)
values
(1,'My First SQL book','Mary parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')
--books by authors whose names end with 'er'
select*from books
where author like '%er'
--creating review table
create table reviews(
id int,
book_id int,
reviewer_name varchar(100),
content varchar(500),
rating int,
published_date datetime,
constraint pk_reviews primary key(id),
constraint fk_book foreign key(book_id) references books(id))
insert into reviews 
values
(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12'),
(3,2,'Alice Walker','Another review',1,'2017-10-20 23:47:10')
select b.title,b.author,r.reviewer_name
from books b,reviews r
where b.id=r.book_id
--query 2 (reviwer name who reviewed more than one book)
select reviewer_name from reviews 
group by reviewer_name
having count(*)>1
--query 3(customer table,displaying value with 'o')
create table customer(
id int,
name varchar(20),
age int,
address varchar(50),
salary decimal(6,2),
constraint pk_customer primary key(id))
insert into customer (id,name,age,address,salary)
values
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)
alter table customer
alter column salary decimal(8,2)
select name from customer where address like '%o'
--query4 (date ,number of customer who placed order)
create table orders(
OID int,
ORDER_DATE date,
CUSTOMER_ID int,
AMOUNT decimal(8,2),
constraint pk_orders primary key(oid),
constraint fk_customer foreign key(customer_id) references customer(id))
insert into orders values
(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)
select ORDER_DATE,count(customer_id) as total_customers
from orders
group by order_date
--query 5(name of employee in lower case whose salary is null)
create table employee(
id int,
name varchar(50),
age int,
address varchar(50),
salary float)
insert into employee(id,name,age,address,salary)values
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',NULL),
(7,'Muffy',24,'Indore',NULL)
select lower(name) as lowercase_name
from employee where salary is null
--query 6
create table students(
register_no int,
name varchar(10),
age int,
qualification varchar(10),
mobile_no bigint,
mail_id varchar(100),
location varchar(10),
gender varchar(10))
insert into students(register_no,name,age,qualification,mobile_no,mail_id,location,gender)
values
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','M'),
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','F'),
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','M'),
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','F'),
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','M'),
(2,'sai',22,'B.E',987654,'sai@gmail.com','chennai','F')
select gender,count(*) as totalcount
from students
group by gender