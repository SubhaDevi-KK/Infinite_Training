use assesments

create table employee_details (
    empid int identity(1,1) primary key,
    name nvarchar(50),
    salary decimal(10,2),
    netsalary decimal(10,2),
    gender nvarchar(10)
)
--stored procedure to insert employee
create procedure insertemployee
    @name nvarchar(50),
    @salary decimal(10,2),
    @gender nvarchar(10),
    @newempid int output,
    @netsalary decimal(10,2) output
as
begin
    set nocount on;

    declare @calculatedsalary decimal(10,2)
    set @calculatedsalary = @salary - (@salary * 0.10)

    insert into employee_details (name, salary, netsalary, gender)
    values (@name, @salary, @calculatedsalary, @gender)

    set @newempid = scope_identity()
    set @netsalary = @calculatedsalary
end

select * from employee_details

--updating salary of existing employee
create procedure updateemployeesalary
    @empid int,
    @updatedsalary decimal(10,2) output
as
begin
    set nocount on;

    update employee_details
    set salary = salary + 100,
        netsalary = salary + 100 - ((salary + 100) * 0.10)
    where empid = @empid

    select @updatedsalary = salary from employee_details where empid = @empid
end
select * from employee_details where empid = 3
select * from employee_details


