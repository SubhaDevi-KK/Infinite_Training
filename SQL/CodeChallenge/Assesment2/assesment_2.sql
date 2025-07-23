--1.displaying birthday 
select datename(weekday, cast('2003-09-19' as date)) as birthday_of_week


--2.displaying age in days
select datediff(day, cast('2003-09-19' as date), getdate()) as age_in_days

--3.using employee table in assignment
create table emp (
    empno int,
    ename varchar(20),
    job varchar(20),
    mgr int,
    hiredate date,
    sal int,
    comm int,
    deptno int
)
insert into emp values
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, null, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, null, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, null, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, null, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, null, 20),
(7839, 'KING', 'PRESIDENT', null, '1981-11-17', 5000, null, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10)

--3.query to display all employees information those who joined 
--before 5 years in the current month

update emp set hiredate = '2016-07-20' where empno = 7654
update emp set hiredate = '2014-07-15' where empno = 7900
update emp set hiredate = '2012-07-10' where empno = 7839
select * 
from emp 
where datediff(year, hiredate, getdate()) >= 5
  and month(hiredate) = month(getdate())


  --4.insertion,updation and deletion
begin tran

-- inserting 3 rows
insert into emp (empno, ename, job, mgr, hiredate, sal, comm, deptno)
values 
(9001, 'RAJ', 'CLERK', 7900, '2020-01-01', 1000, null, 10),
(9002, 'DEEPU', 'SALESMAN', 7698, '2020-02-01', 1500, null, 30),
(9003, 'ANU', 'MANAGER', 7839, '2020-03-01', 2500, null, 20)
select* from emp

-- Update second row 
update emp 
set sal = (select sal * 1.15 from emp where empno = 9002)
where empno = 9002
select * from emp

-- Deleting first row
delete from emp where empno = 9001
select * from emp

-- resinserting
insert into emp 
select * from (
            select 9001 as empno, 'RAJ' as ename, 'CLERK' as job, 7900 as mgr,
           '2020-01-01' as hiredate, 1000 as sal, null as comm, 10 as deptno) as reinserted
select * from emp
commit tran



--5.user defined function to calculate bonus
create function calculate_bonus (@deptno int, @sal float)
returns float
as
begin
    declare @bonus float

    if @deptno = 10
        set @bonus = @sal * 0.15
    else if @deptno = 20
        set @bonus = @sal * 0.20
    else
        set @bonus = @sal * 0.05

    return @bonus
end

select empno, ename, sal, deptno, dbo.calculate_bonus(deptno, sal) as bonus from emp

--6.creating procedure for updatinf salary of the emp
create procedure update_salaryofemp
as
begin
    update emp
    set sal = sal + 500
    where job = 'SALESMAN'
	and sal < 1500
end
exec update_salaryofemp
select*from emp 
