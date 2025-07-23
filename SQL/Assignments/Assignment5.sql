use assignments

create or alter procedure GeneratePayslip
    @EMPNO int
as
begin
    declare @ENAME varchar(100),
            @SAL float,
            @HRA float,
            @DA float,
            @PF float,
            @IT float,
            @DEDUCTIONS float,
            @GROSS float,
            @NET float
    select @ENAME = ENAME,
           @SAL = SAL
    from emp
    where EMPNO = @EMPNO

 if @SAL is null
    begin
        print 'Employee not found.'
        return
    end

    set @HRA = @SAL * 0.10
    set @DA = @SAL * 0.20
    set @PF = @SAL * 0.08
    set @IT = @SAL * 0.05
    set @DEDUCTIONS = @PF + @IT
    set @GROSS = @SAL + @HRA + @DA
    set @NET = @GROSS - @DEDUCTIONS

    print 'Employee Number   : ' + cast(@EMPNO as varchar)
    print 'Employee Name     : ' + @ENAME
    print 'Basic Salary      : ₹' + cast(@SAL as varchar(10))
    print 'HRA (10%)         : ₹' + cast(@HRA as varchar(10))
    print 'DA (20%)          : ₹' + cast(@DA as varchar(10))
    print 'PF (8%)           : ₹' + cast(@PF as varchar(10))
    print 'IT (5%)           : ₹' + cast(@IT as varchar(10))
 
    print 'Gross Salary      : ₹' + cast(@GROSS as varchar(10))
    print 'Deductions        : ₹' + cast(@DEDUCTIONS as varchar(10))
    print 'Net Salary        : ₹' + cast(@NET as varchar(10))
end
exec GeneratePayslip @EMPNO = 7521
select * from emp

--2.trigger to block dml on holidays
create table Holiday (
    Holiday_Date date primary key,
    Holiday_Name varchar(100))

insert into Holiday values
('2025-01-26', 'Republic Day'),
('2025-08-15', 'Independence Day'),
('2025-10-23', 'Diwali'),
('2025-12-25', 'Christmas')

create or alter trigger trg_BlockEmployeeDML_OnHoliday
on emp
for insert, update, delete
as
begin
    declare @reason varchar(100)
    select @reason = Holiday_Name
    from Holiday
    where Holiday_Date = cast(getdate() as date)
    if @reason is not null
    begin
        raiserror('Due to %s, you cannot manipulate data today.', 16, 1, @reason)
        rollback
        return
    end
end
--to check 
insert into Holiday values (cast(getdate() as date), 'Test Holiday')

update emp set sal = sal + 100 where empno = 7369

delete from Holiday where Holiday_Name = 'Test Holiday'


