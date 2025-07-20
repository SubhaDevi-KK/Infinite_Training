drop table emp
drop table dept
create table emp(
empno int,
ename varchar(10),
job varchar(15),
mgr_id int,
hiredate datetime,
sal  int,
comm int,
deptno int)
insert into emp(EMPNO, ENAME, JOB, MGR_id, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)
create table  dept(
deptno int primary key,
dname varchar(30),
loc varchar(30))
insert into DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON')

--1.Retrieve a list of MANAGERs
select * from emp where job in
(select distinct job from  emp where job='manager')

--2. Find out the names and salaries of all employees earning more than 1000 per month
select * from emp where sal>
(select min(sal) from emp where sal>1000)

--3. Display the names and salaries of all employees except JAMES. 
select * from emp where empno 
not in(select empno from emp where ename='james')

--4. Find out the details of employees whose names begin with ‘S’. 
select * from emp where ename
in (select ename from emp where ename like 's%')

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select * from emp where ename
in( select ename from emp where ename like '%a%')
--6. Find out the names of all employees that have ‘L’ as their third character in mtheir name. 
select * from emp where ename
in(select ename from emp where ename like '__l%')

--7. Compute daily salary of JONES.
select sal/30 as daily_salary from emp where empno=
(select empno from emp where ename ='jones')

--8. Calculate the total monthly salary of all employees. 
select sum(sal) from emp
where deptno in (select deptno from dept)

--9. Print the average annual salary .
select avg(sal*12) as average salary from emp
where sal is not null

--10. Select the name, job, salary, department number of all employees except  SALESMAN from department number 30. 
select name,job,sal,deptno from emp where job !='salesman' and deptno in
(select deptno from dept where deptno=30)

--11. List unique departments of the EMP table.
select distinct deptno from emp where deptno in
(select deptno from dept)

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as employee,sal as monthly salary from emp where sal> 1500 and deptno in
(select deptno from dept where deptno=10 or deptno=30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename ,job,sal from emp where job in
('manager','analyst') and sal not in
(select sal from emp where sal in(1000,3000,5000)

--14. Display the name, salary and commission for all employees whose commission  amount is greater than their salary increased by 10%. 
select ename, sal, comm from emp 
where comm > sal * 1.1


--15. Display the name of all employees who have two Ls in their name and are in  department 30 or their manager is 7782. 
select ename from emp 
where ename like '%l%l%'
and (deptno in (select deptno from dept where deptno = 30) or mgr_id = 7782)

--16. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
-- employees with experience between 30 and 40 years
select ename 
from emp 
where datediff(year, hiredate, getdate()) between 31 and 39

-- total count of such employees
select count(*) as totalemployees 
from emp 
where datediff(year, hiredate, getdate()) between 31 and 39



--17. Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename 
from dept d 
inner join emp e on d.deptno = e.deptno 
order by d.dname asc, e.ename desc


--18. Find out experience of MILLER. 
select ename, datediff(year, hiredate, getdate()) as YearsOfExperience
from emp 
where ename = 'miller'
