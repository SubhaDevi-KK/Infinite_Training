--T-sql program to find factorial of given number
declare @num int=6
declare @fact bigint=1
while @num>1
begin
set @fact=@fact*@num
set @num=@num-1
end
print 'factorial is:' + cast(@fact as varchar)

--2.stored procedure for multiplication table
create procedure sp_multiplicationtable
@base int,
@limit int
as
begin
declare @counter int = 1
while @counter <= @limit
begin
print cast(@base as varchar) + ' x ' + cast(@counter as varchar) + ' = ' + cast(@base * @counter as varchar)
set @counter = @counter + 1
end
end
exec sp_multiplicationtable @base = 6, @limit = 10

--function to determine pass/fail status of student
create table student (
 sid int primary key,
 sname varchar(50)
)


create table marks (
  mid int primary key,
  sid int,
  score int,
  foreign key (sid) references student(sid)
)

insert into student values (1, 'Jack'), (2, 'Rithvik'), (3, 'Jaspreeth'), (4, 'Praveen'), (5, 'Bisa'), (6, 'Suraj')
insert into marks values (1, 1, 23), (2, 6, 95), (3, 4, 98), (4, 2, 17), (5, 3, 53), (6, 5, 13)
create function fn_getstatus (@score int)
returns varchar(10)
as
begin
    declare @result varchar(10)

    if @score >= 50
        set @result = 'Pass'
    else
        set @result = 'Fail'

    return @result
end

select s.sid, 
    s.sname, 
    m.score, 
    dbo.fn_getstatus(m.score) as status
from student s
join marks m on s.sid = m.sid
order by s.sid
