
--create database OOP;
--go
--use OOP;
--go

--drop database OOP;

create table [GROUP] (
	GroupID int primary key identity,
	Profession varchar(10),
)

create table STUDENT (
	StudentID int primary key identity,
	[Name] varchar(25) not null,
	Course int not null,
	GroupID int references [GROUP] (GroupID),
	--Photo varbinary
)

insert into [GROUP] (Profession) values
	('ИСиТ'),
	('ПОИТ'),
	('ПОИБМС'),
	('ДЭиВИ');
	
insert into STUDENT ([Name], Course, GroupID) values
	('Студент 1', 1, 1),
	('Студент 2', 1, 1),
	('Студент 3', 1, 1),
	('Студент 4', 1, 2),
	('Студент 5', 1, 2),
	('Студент 6', 1, 2),
	('Студент 7', 1, 3),
	('Студент 8', 1, 3),
	('Студент 9', 1, 3),
	('Студент 10', 1, 4),
	('Студент 11', 1, 4),
	('Студент 12', 1, 4);

go

create proc sp_AddStudent
	@Name varchar(15),
	@Course int,
	@GroupID int
as
insert into STUDENT ([Name], Course, GroupID) values (@Name, @Course, @GroupID);
go

create proc sp_UpdStudent
	@ID int,
	@Name varchar(15),
	@Course int,
	@GroupID int
as
update STUDENT set [Name] = @Name, GroupID = @GroupID, Course = @Course where Student.StudentID = @ID;
go

create proc sp_DelStudent
	@ID int
as
delete STUDENT where Student.StudentID = @ID;

--use OOP;
select * from [GROUP];
select * from STUDENT;