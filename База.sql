Set ANSI_Padding on
GO

Set Quoted_Identifier on
GO

Set ANSI_NULLS on
GO

create database Abiturient_MPT
GO

use [Abiturient_MPT]
GO

create table [Speciality_Group](
	[ID_Speciality_Group] Int Not NULL Identity(1, 1),
	[Code] VarChar(8) Not NULL,
	[Name] VarChar(500) Not NULL,
	Constraint PK_Spec_Group Primary Key Clustered(ID_Speciality_Group),
	Constraint UN_Spec_Group__Code Unique(Code),
	Constraint UN_Spec_Group__Name Unique(Name)
)
GO
create table [Speciality](
	[ID_Speciality] [int] Not NULL Identity(1, 1),
	[Code] VarChar(8) Not NULL,
	[Name] VarChar(500) Not Null,
	[Group_ID] Int Not NULL,
	Constraint PK_Speciality Primary Key Clustered(ID_Speciality ASC),
	Constraint FK_Spec__Spec_Group Foreign Key (Group_ID) References Speciality_Group (ID_Speciality_Group) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint UN_Spec__Code Unique(Code),
	Constraint UN_Spec__Name Unique(Name)
)
GO

create table [Discipline](
	[ID_Discipline] Int Not NULL Identity(1, 1),
	[Name] VarChar(50),
	Constraint PK_Discipline Primary Key Clustered(ID_Discipline),
	Constraint UN_Discipline__Name Unique(Name)
)
GO

create table [Enrollee](
	[ID_Enrollee] Int Not NULL Identity(1, 1),
	[Surname] VarChar(50) Not NULL,
	[Name] VarChar(50) Not NULL,
	[Patronymic] VarChar(50) NULL,
	[Birth_Date] VarChar(10) Not NULL,
	[Pass_Series] VarChar(4) Not NULL,
	[Pass_Number] VarChar(6) Not NULL,
	[Pass_Issued_By] VarChar(100) Not NULL,
	[Pass_Issue_Date] VarChar(10) Not NULL,
	[Subdiv_Code] VarChar(7) Not NULL,
	[Education] Int Not NULL,
	[Certificate_Num] VarChar(14) Not NULL,
	[Issue_Date] VarChar(10) Not NULL,
	[End_Year] VarChar(4) Not NULL,
	[Cert_Issued_By] VarChar(100) Not NULL,
	[Targeted_Learning] Int Not NULL,
	Constraint PK_Enrollee Primary Key Clustered(ID_Enrollee),
)
GO

create table [Enrollee_Mark](
	[ID_Mark] Int Not NULL Identity(1, 1),
	[Enrollee_ID] Int Not NULL,
	[Discipline_ID] Int Not NULL,
	[Mark] float Not NULL,
	Constraint PK_Mark Primary Key Clustered([ID_Mark]),
	Constraint FK_Mark__Enr Foreign Key([Enrollee_ID]) References [Enrollee]([ID_Enrollee]) ON DELETE CASCADE,
	Constraint FK_Mark__Discip Foreign Key([Discipline_ID]) References [Discipline]([ID_Discipline]) ON UPDATE CASCADE,
	Constraint UN_Enrollee_Mark__EnrID_DispID Unique(Enrollee_ID, Discipline_ID)
)
GO

create table [Discipline_Priority](
	[ID_Priority] Int Not NULL Identity(1, 1),
	[Speciality_Group_ID] Int Not NULL,
	[Discipline_ID] Int Not NULL,
	[Priority] Int Not NULL,
	[Start_Date] VarChar(10) Not NULL,
	[End_Date] VarChar(10) Not NULL,
	Constraint PK_Priority Primary Key Clustered(ID_Priority),
	Constraint FK_Disp_Prior__Sper_Group Foreign Key (Speciality_Group_ID) References Speciality_Group (ID_Speciality_Group) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint FK_Disp_Prior__Discipline Foreign Key (Discipline_ID) References Discipline (ID_Discipline) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint UN_Discipline__SpecGroupID_DispID Unique(Speciality_Group_ID, Discipline_ID)
)
GO

create table [Enrollee_Speciality](
	[ID_Enrollee_Spec] Int Not NULL Identity(1, 1),
	[Enrollee_ID] Int Not NULL,
	[Speciality_ID] Int Not NULL,
	[Date] VarChar(10) Not NULL,
	Constraint PK_Enr_Spec Primary Key Clustered(ID_Enrollee_Spec),
	Constraint FK_Enr_Spec__Enrollee Foreign Key (Enrollee_ID) References Enrollee(ID_Enrollee) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint FK_Enr_Spec__Spec Foreign Key (Speciality_ID) References Speciality(ID_Speciality) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint UN_Enrollee_Specialities Unique(Enrollee_ID, Speciality_ID)
)
GO

create table [Achievement](
	[ID_Achievement] Int Not NULL Identity(1, 1),
	[Name] VarChar(500) Not NULL,
	Constraint PK_Achievement Primary Key Clustered(ID_Achievement),
	Constraint UN_Achievement_Name Unique(Name),
)
GO

create table [Recorded_Achievement](
	[ID_Achievement_Rec] Int Not NULL Identity(1, 1),
	[Start_Date] VarChar(10) Not NULL,
	[End_Date] VarChar(10) Not NULL,
	[Achievement_ID] Int Not NULL,
	Constraint PK_Achievement_Rec Primary Key Clustered(ID_Achievement_Rec),
	Constraint FK_Ach_Rec__Achievement Foreign Key (Achievement_ID) References Achievement(ID_Achievement) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO

create table [Olympiad](
	[ID_Olympiad] Int Not NULL Identity(1, 1),
	[Name] VarChar(500) Not NULL,
	[Organizer] VarChar(500) Not NULL,
	Constraint PK_Olympiad Primary Key Clustered(ID_Olympiad),
	Constraint UN_Olympiad__Name Unique(Name)
)
GO

create table [Recorded_Olympiad](
	[ID_Olympiad_Rec] Int Not NULL Identity(1, 1),
	[Start_Date] VarChar(10) Not NULL,
	[End_Date] VarChar(10) Not NULL,
	[Olympiad_ID] Int Not NULL,
	Constraint PK_Olimpiad_Rec Primary Key Clustered(ID_Olympiad_Rec),
	Constraint FK_Olimp_Rec__Olimpiad Foreign Key (Olympiad_ID) References Olympiad(ID_Olympiad) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO

create table [Individual_Achievements](
	[ID_Individual_Achievement] Int Not NULL Identity(1, 1),
	[Enrollee_ID] Int Not NULL,
	[Achievement_Rec_ID] Int Not NULL,
	Constraint PK_Individual_Achievements Primary Key Clustered(ID_Individual_Achievement),
	Constraint FK_Ind_Achieve__Enrollee Foreign Key (Enrollee_ID) References Enrollee(ID_Enrollee) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint FK_Ind_Achieve__Achievement_Rec Foreign Key (Achievement_Rec_ID) References Recorded_Achievement(ID_Achievement_Rec) ON UPDATE CASCADE,
	Constraint UN_Individual_Achievements Unique(Enrollee_ID, Achievement_Rec_ID)
)
GO

create table [Winned_Olympiad](
	[ID_Winned_Olympiad] Int Not NULL Identity(1, 1),
	[Olympiad_Rec_ID] Int Not NULL,
	[Individual_Achievement_ID] Int Not NULL,
	Constraint PK_Winned_Olympiad Primary Key Clustered(ID_Winned_Olympiad),
	Constraint FK_WinOlymp__Olymp_Rec Foreign Key (Olympiad_Rec_ID) References Recorded_Olympiad(ID_Olympiad_Rec) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint FK_WinOlymp__IndivAchieve Foreign Key (Individual_Achievement_ID) References Individual_Achievements(ID_Individual_Achievement) ON DELETE CASCADE ON UPDATE CASCADE,
	Constraint UN_WinOlymp__EnrID_DispID Unique(Olympiad_Rec_ID, Individual_Achievement_ID)
)
GO

Create Table [Roles]
(
	[ID_Role] [Int] Not NULL Identity(1, 1),
	[Name] VarChar(50) Not NULL,
	CONSTRAINT uniqueRoleName unique (Name),
	Constraint[PK_Role] Primary Key Clustered(ID_Role),
)
GO
Create Table [Accounts]
(
	[ID_Account] [Int] Not NULL Identity(1, 1),
	[Login] VarChar(50) Not NULL,
	[Password] Varchar(50) Not NULL,
	[ID_Role] [Int] Not NULL, 
	CONSTRAINT uniqueLogin unique ([Login]),
	Constraint PK_Account Primary Key Clustered(ID_Account),
	Constraint FK_Acc_ID_Role Foreign Key(ID_Role) References dbo.Roles(ID_Role)
)
GO


--Функция авторизации
Create Function dbo.Auth(@Login varchar(50), @Password varchar(50)) returns int 
as 
begin 
	declare @index int = 
	(select [ID_Account] from [dbo].[Accounts] where [Login] = @Login and [Password] = @Password) 
	return @index 
end
GO


--Процедура регистрации
Create Procedure dbo.Registration(@Login varchar(50), @Password varchar(50), @Role_ID int) 
as 
begin 
if ((select count([Login]) from [dbo].[Accounts] where [Login] = @Login) > 0) 
	select 0 
else 
	begin 
		insert into [dbo].[Accounts] ([Login],[Password],[ID_Role]) 
		values(@Login, @Password, @Role_ID) 
		select 1 
	end 
end
GO


--Процедуры для таблицы абитуриента

--Вставка новой записи
alter Procedure Insert_Enrollee
	@Surname VarChar(50),
	@Name VarChar(50),
	@Patronymic VarChar(50),
	@Birth_Date VarChar(10),
	@Pass_Series VarChar(4),
	@Pass_Number VarChar(6),
	@Pass_Issued_By VarChar(100),
	@Pass_Issue_Date VarChar(10),
	@Subdiv_Code VarChar(7),
	@Education Int,
	@Certificate_Num VarChar(14),
	@Issue_Date VarChar(10),
	@End_Year VarChar(4),
	@Cert_Issued_By VarChar(100),
	@Targeted_Learning Int
	--@ID_Enrollee int OUTPUT 
as
declare @ID_Enrollee int; 
	insert into Enrollee (Surname, Name, Patronymic, Birth_Date, Pass_Series, Pass_Number, Pass_Issued_By, Pass_Issue_Date, Subdiv_Code, Education, Certificate_Num, Issue_Date, End_Year, Cert_Issued_By, Targeted_Learning)
	values (@Surname, @Name, @Patronymic, @Birth_Date, @Pass_Series, @Pass_Number, @Pass_Issued_By, @Pass_Issue_Date, @Subdiv_Code, @Education, @Certificate_Num, @Issue_Date, @End_Year, @Cert_Issued_By, @Targeted_Learning);
	--select @ID_Enrollee = 
	select IDENT_CURRENT ('Enrollee');
GO



--Изменение записи
Create Procedure Update_Enrollee
	@ID_Enrollee Int,
	@Surname VarChar(50),
	@Name VarChar(50),
	@Patronymic VarChar(50),
	@Birth_Date VarChar(10),
	@Pass_Series VarChar(4),
	@Pass_Number VarChar(6),
	@Pass_Issued_By VarChar(100),
	@Pass_Issue_Date VarChar(10),
	@Subdiv_Code VarChar(7),
	@Education Int,
	@Certificate_Num VarChar(14),
	@Issue_Date VarChar(10),
	@End_Year VarChar(4),
	@Cert_Issued_By VarChar(100),
	@Targeted_Learning int
as
	Update dbo.Enrollee set  
	Surname = @Surname,
	Name = @Name,
	Patronymic = @Patronymic,
	Birth_Date= @Birth_Date,
	Pass_Series = @Pass_Series,
	Pass_Number = @Pass_Number,
	Pass_Issued_By = @Pass_Issued_By,
	Pass_Issue_Date = @Pass_Issue_Date,
	Subdiv_Code = @Subdiv_Code,
	Education = @Education,
	Certificate_Num = @Certificate_Num,
	Issue_Date = @Issue_Date,
	End_Year = @End_Year,
	Cert_Issued_By = @Cert_Issued_By,
	Targeted_Learning = @Targeted_Learning
	where
	ID_Enrollee = @ID_Enrollee
GO

--Удаление записи
Create Procedure dbo.Delete_Enrollee
@ID_Enrollee [int]
as
	delete from dbo.Enrollee
	where
	ID_Enrollee=@ID_Enrollee

GO



--Процедуры для таблицы групп специальностей

--Вставка новой записи
Create Procedure Insert_Speciality_Group
	@Code VarChar(8),
	@Name VarChar(500)
as
	insert into Speciality_Group (Code, Name)
	values (@Code, @Name)
GO

--Изменение записи
Create Procedure Update_Speciality_Group
	@ID_Speciality_Group Int,
	@Code VarChar(8),
	@Name VarChar(500)
as
	Update dbo.Speciality_Group set  
	Code = @Code,
	Name = @Name
	where
	ID_Speciality_Group = @ID_Speciality_Group
GO

--Удаление записи
Create Procedure dbo.Delete_Speciality_Group
@ID_Speciality_Group [int]
as
	delete from dbo.Speciality_Group
	where
	ID_Speciality_Group = @ID_Speciality_Group

GO



--Процедуры для таблицы специальностей

--Вставка новой записи
Create Procedure Insert_Speciality
	@Code VarChar(8),
	@Name VarChar(500),
	@Group_ID int
as
	insert into Speciality (Code, Name, Group_ID)
	values (@Code, @Name, @Group_ID)
GO

--Изменение записи
Create Procedure Update_Speciality
	@ID_Speciality Int,
	@Code VarChar(8),
	@Name VarChar(500),
	@Group_ID int
as
	Update dbo.Speciality set  
	Code = @Code,
	Name = @Name,
	Group_ID = @Group_ID
	where
	ID_Speciality = @ID_Speciality
GO

--Удаление записи
Create Procedure dbo.Delete_Speciality
@ID_Speciality [int]
as
	delete from dbo.Speciality
	where
	ID_Speciality = @ID_Speciality

GO



--Процедуры для таблицы специальностей абитуриента

--Вставка новой записи
ALTER Procedure [dbo].[Insert_Enrollee_Speciality]
	@Enrollee_ID Int,
	@Speciality_ID Int
	--@Date VarChar(10)
as
	insert into dbo.Enrollee_Speciality(Enrollee_ID, Speciality_ID, Date)
	values (@Enrollee_ID, @Speciality_ID, concat(DATEPART(day,GETDATE ()), '.' , MONTH(GETDATE ()), '.', YEAR(GETDATE ())))
GO

--Изменение записи
Create Procedure Update_Enrollee_Speciality
	@ID_Enrollee_Spec Int,
	@Enrollee_ID VarChar(8),
	@Speciality_ID VarChar(100),
	@Date int
as
	Update dbo.Enrollee_Speciality set  
	Enrollee_ID = @Enrollee_ID,
	Speciality_ID = @Speciality_ID,
	Date = @Date
	where
	ID_Enrollee_Spec = @ID_Enrollee_Spec
GO

--Удаление записи
Create Procedure dbo.Delete_Enrollee_Speciality
@ID_Enrollee_Spec int
as
	delete from dbo.Enrollee_Speciality
	where
	ID_Enrollee_Spec = @ID_Enrollee_Spec

GO



--Процедуры для таблицы предметов

--Вставка новой записи
Create Procedure Insert_Discipline
	@Name VarChar(50)
as
	insert into dbo.Discipline (Name)
	values (@Name)
GO

--Изменение записи
Create Procedure Update_Discipline
	@ID_Discipline Int,
	@Name VarChar(50)
as
	Update dbo.Discipline set  
	Name = @Name
	where
	ID_Discipline = @ID_Discipline
GO

--Удаление записи
Create Procedure dbo.Delete_Discipline
@ID_Discipline [int]
as
	delete from dbo.Discipline
	where
	ID_Discipline = @ID_Discipline

GO



--Процедуры для таблицы оценок абитуриента

--Вставка новой записи
Create Procedure Insert_Enrollee_Mark
	@Enrollee_ID int,
	@Discipline_ID int,
	@Mark Int
as
	insert into dbo.Enrollee_Mark(Enrollee_ID, Discipline_ID, Mark)
	values (@Enrollee_ID, @Discipline_ID, @Mark)
GO

--Изменение записи
Create Procedure Update_Enrollee_Mark
	@ID_Mark int,
	@Enrollee_ID int,
	@Discipline_ID int,
	@Mark Int
as
	Update dbo.Enrollee_Mark set  
	Enrollee_ID = @Enrollee_ID,
	Discipline_ID = @Discipline_ID,
	Mark = @Mark
	where
	ID_Mark = @ID_Mark
GO

--Удаление записи
Create Procedure dbo.Delete_Enrollee_Mark
@ID_Mark [int]
as
	delete from dbo.Enrollee_Mark
	where
	ID_Mark = @ID_Mark

GO



--Процедуры для таблицы достижений

--Вставка новой записи
Create Procedure Insert_Achievement
	@Name VarChar(500)
as
	insert into dbo.Achievement (Name)
	values (@Name)
GO

--Изменение записи
Create Procedure Update_Achievement
	@ID_Achievement Int,
	@Name VarChar(500)
as
	Update dbo.Achievement set  
	Name = @Name
	where
	ID_Achievement = @ID_Achievement
GO

--Удаление записи
Create Procedure dbo.Delete_Achievement
@ID_Achievement [int]
as
	delete from dbo.Achievement
	where
	ID_Achievement = @ID_Achievement

GO



--Процедуры для таблицы учитываемых достижений

--Вставка новой записи
Create Procedure Insert_Recorded_Achievement
	@Start_Date VarChar(10),
	@End_Date VarChar(10),
	@Achievement_ID Int
as
	insert into dbo.Recorded_Achievement (Start_Date, End_Date, Achievement_ID)
	values (@Start_Date, @End_Date, @Achievement_ID)
GO

--Изменение записи
Create Procedure Update_Recorded_Achievement
	@ID_Achievement_Rec Int,
	@Start_Date VarChar(10),
	@End_Date VarChar(10),
	@Achievement_ID Int
as
	Update dbo.Recorded_Achievement set  
	Start_Date = @Start_Date,
	End_Date = @End_Date,
	Achievement_ID = @Achievement_ID
	where
	ID_Achievement_Rec = @ID_Achievement_Rec
GO

--Удаление записи
Create Procedure dbo.Delete_Recorded_Achievement
@ID_Achievement_Rec int
as
	delete from dbo.Recorded_Achievement
	where
	ID_Achievement_Rec = @ID_Achievement_Rec

GO



--Процедуры для таблицы индивидуальных достижений

--Вставка новой записи
Create Procedure Insert_Individual_Achievement
	@Enrollee_ID Int,
	@Achievement_ID Int
as
	insert into dbo.Individual_Achievements (Enrollee_ID, Achievement_Rec_ID)
	values (@Enrollee_ID, @Achievement_ID)
GO

--Изменение записи
Create Procedure Update_Individual_Achievement
	@ID_Achievement Int,
	@Name VarChar(50)
as
	Update dbo.Achievement set  
	Name = @Name
	where
	ID_Achievement = @ID_Achievement
GO

--Удаление записи
Create Procedure dbo.Delete_Individual_Achievement
@ID_Achievement [int]
as
	delete from dbo.Achievement
	where
	ID_Achievement = @ID_Achievement

GO



--Процедуры для таблицы олимпиад

--Вставка новой записи
Create Procedure Insert_Olympiad
	@Name VarChar(500),
	@Organizer VarChar(500)
as
	insert into dbo.Olympiad(Name, Organizer)
	values (@Name, @Organizer)
GO

--Изменение записи
Create Procedure Update_Olympiad
	@ID_Olympiad Int,
	@Name VarChar(500),
	@Organizer VarChar(500)
as
	Update dbo.Olympiad set  
	Name = @Name,
	Organizer = @Organizer
	where
	ID_Olympiad = @ID_Olympiad
GO

--Удаление записи
Create Procedure dbo.Delete_Olympiad
@ID_Olympiad [int]
as
	delete from dbo.Olympiad
	where
	ID_Olympiad = @ID_Olympiad

GO


--Процедуры для таблицы учитываемых олимпиад

--Вставка новой записи
Create Procedure Insert_Recorded_Olympiad
	@Start_Date VarChar(10),
	@End_Date VarChar(10),
	@Olympiad_ID Int
as
	insert into dbo.Recorded_Olympiad (Start_Date, End_Date, Olympiad_ID)
	values (@Start_Date, @End_Date, @Olympiad_ID)
GO

--Изменение записи
Create Procedure Update_Recorded_Olympiad
	@ID_Olympiad_Rec Int,
	@Start_Date VarChar(10),
	@End_Date VarChar(10),
	@Olympiad_ID Int
as
	Update dbo.Recorded_Olympiad set  
	Start_Date = @Start_Date,
	End_Date = @End_Date,
	Olympiad_ID = @Olympiad_ID
	where
	ID_Olympiad_Rec = @ID_Olympiad_Rec
GO

--Удаление записи
Create Procedure dbo.Delete_Recorded_Olympiad
@ID_Olympiad_Rec int
as
	delete from dbo.Recorded_Olympiad
	where
	ID_Olympiad_Rec = @ID_Olympiad_Rec

GO



--Процедуры для таблицы выигранных олимпиад

--Вставка новой записи
Create Procedure Insert_Winned_Olimpiad
	@Individual_Achievement_ID VarChar(10),
	@Olympiad_Rec_ID Int
as
	insert into dbo.Winned_Olympiad(Olympiad_Rec_ID, Individual_Achievement_ID)
	values (@Olympiad_Rec_ID, @Individual_Achievement_ID)
GO

--Изменение записи
Create Procedure Update_Winned_Olimpiad
	@ID_Winned_Olympiad Int,
	@Individual_Achievement_ID Int,
	@Olympiad_Rec_ID Int
as
	Update dbo.Winned_Olympiad set  
	Individual_Achievement_ID = @Individual_Achievement_ID,
	Olympiad_Rec_ID = @Olympiad_Rec_ID
	where
	ID_Winned_Olympiad = @ID_Winned_Olympiad
GO

--Удаление записи
Create Procedure dbo.Delete_Winned_Olimpiad
@ID_Olympiad_Rec int
as
	delete from dbo.Recorded_Olympiad
	where
	ID_Olympiad_Rec = @ID_Olympiad_Rec

GO



--Процедура для таблицы приоритетов

--Вставка новой записи
Create Procedure Insert_Priority
	@Speciality_Group_ID Int,
	@Discipline_ID Int,
	@Priority Int,
	@Start_Date VarChar(10),
	@End_Date VarChar(10)
as
	insert into dbo.Discipline_Priority(Speciality_Group_ID, Discipline_ID, Priority, Start_Date, End_Date)
	values (@Speciality_Group_ID, @Discipline_ID, @Priority, @Start_Date, @End_Date)
GO

--Изменение записи
Create Procedure Update_Priority
	@ID_Priority int,
	@Speciality_Group_ID Int,
	@Discipline_ID Int,
	@Priority Int,
	@Start_Date VarChar(10),
	@End_Date VarChar(10)
as
	Update dbo.Discipline_Priority set  
	Speciality_Group_ID = @Speciality_Group_ID,
	Discipline_ID = @Discipline_ID,
	Priority = @Priority,
	Start_Date = @Start_Date,
	End_Date = @End_Date
	where
	ID_Priority = @ID_Priority
GO

--Удаление записи
Create Procedure dbo.Delete_Priority
@ID_Priority int
as
	delete from dbo.Discipline_Priority
	where
	ID_Priority = @ID_Priority

GO

Create Procedure dbo.GetEnrollees
as
	SELECT e.ID_Enrollee as 'ID', Surname as 'Фамилия', e.Name as 'Имя', e.Patronymic as 'Отчество', e.Birth_Date as 'Дата рождения', e.Pass_Series as 'Серия паспорта', 
	e.Pass_Number as 'Номер паспорта', e.Pass_Issued_By as 'Кем выдан', e.Pass_Issue_Date as 'Дата выдачи', e.Subdiv_Code as 'Код подразделения', e.Education as 'Образование', 
	e.Certificate_Num as 'Номер аттестата', e.Issue_Date as 'Когда выдан', e.End_Year as 'Год окончания', e.Cert_Issued_By as 'Кем выдан', REPLACE(REPLACE(e.Targeted_Learning, '1', 'Да'), '0', 'Нет') as 'Целевое обучение' FROM dbo.Enrollee e
go

--exec GetEnrollees

--SELECT *,
--CASE  Targeted_Learning 
--WHEN '0' then 'Нет'
--end
--from Enrollee

--GO

Create Procedure dbo.GetRecordedAchievements
as
SELECT rec.ID_Achievement_Rec as 'ID', ach.Name as 'Название', rec.Start_Date as 'Дата начала', rec.End_Date as 'Дата окончания'
FROM Achievement ach
INNER JOIN Recorded_Achievement rec
ON rec.Achievement_ID = ach.ID_Achievement
order by ach.Name 
go

Create Procedure dbo.GetRecordedOlympiad
as
SELECT rec.ID_Olympiad_Rec as 'ID', olymp.Name as 'Название', rec.Start_Date as 'Организатор', rec.End_Date as 'Дата окончания'
FROM Olympiad olymp
INNER JOIN Recorded_Olympiad rec
ON rec.Olympiad_ID = olymp.ID_Olympiad
order by olymp.Name 
go

Alter Procedure dbo.GetAchievements
as
SELECT ach.ID_Achievement as 'ID', ach.Name as 'Название'
FROM Achievement ach
order by ach.Name 
go

Create Procedure dbo.GetOlympiads
as
SELECT olymp.ID_Olympiad as 'ID', olymp.Name as 'Название', olymp.Organizer as 'Организатор'
FROM Olympiad olymp
order by olymp.Name 
go

Create Procedure dbo.GetCurrentOlympiad
@ID_Olympiad Int
as
SELECT * FROM dbo.Olympiad where ID_Olympiad = @ID_Olympiad 
go



Create Procedure dbo.GetCurrentEnrollee
@ID_Enrollee Int
as
select * from dbo.Enrollee where ID_Enrollee = @ID_Enrollee
go
	   --SELECT id, REPLACE(e.Targeted_Learning, '0', 'Нет') as text FROM texts

Create Procedure dbo.GetCurrentEnrollee
@ID_Enrollee Int
as
select * from dbo.Enrollee where ID_Enrollee = @ID_Enrollee
go


Create Procedure dbo.GetDiscipline
as
SELECT disp.ID_Discipline as 'ID', disp.Name as 'Название'
FROM Discipline disp
order by disp.Name 
go

Create Procedure dbo.GetCurrentDiscipline
@ID_Discipline Int
as
select name from dbo.Discipline where ID_Discipline = @ID_Discipline
go

Create Procedure dbo.GetCurrentAchievement
@ID_Achievement Int
as
select name from dbo.Achievement where ID_Achievement = @ID_Achievement
go

ALTER TABLE Achievement ALTER COLUMN Name VarChar(500) Not Null

select * from dbo.Achievement where ID_Achievement = 1

exec dbo.GetCurrentAchievement 1
Go

Create Procedure dbo.GetEnrolleeAchievements
@ID_Enrollee Int
as
select * from dbo.Individual_Achievements where Enrollee_ID = @ID_Enrollee
go

Create Procedure dbo.GetCurrentRecAchievement
@ID_RecAchievement Int
as
select * from dbo.Recorded_Achievement where ID_Achievement_Rec = @ID_RecAchievement
go
exec GetAchievements
GO

Create Procedure dbo.GetCurrentRecAchievement1
@ID_RecAchievement Int
as
SELECT rec.ID_Achievement_Rec as 'ID', ach.Name as 'Имя', rec.Start_Date as 'Дата начала', rec.End_Date as 'Дата окончания'
FROM Achievement ach
INNER JOIN Recorded_Achievement rec
ON rec.Achievement_ID = ach.ID_Achievement
where rec.ID_Achievement_Rec = @ID_RecAchievement
go

Create Procedure dbo.GetOlympiads
@ID_RecOlympiad int
as
SELECT rec.ID_Olympiad_Rec as 'ID', olymp.Name as 'Название', rec.Start_Date as 'Дата начала', rec.End_Date as 'Дата окончания'
FROM Olympiad olymp
INNER JOIN Recorded_Olympiad rec
ON rec.Olympiad_ID = olymp.ID_Olympiad
where rec.ID_Olympiad_Rec = @ID_RecOlympiad
go

Create Procedure dbo.GetSpecialityGroup
as
SELECT ID_Speciality_Group as 'ID', Code as 'Код', Name as 'Название'
FROM Speciality_Group
go

Create Procedure dbo.GetCurrentSpecialityGroup
@ID_Speciality_Group Int
as
SELECT ID_Speciality_Group as 'ID', Code as 'Код', Name as 'Название'
FROM Speciality_Group
where ID_Speciality_Group = @ID_Speciality_Group
go

Create Procedure dbo.GetSpeciality
as
SELECT spec.ID_Speciality as 'ID', spec.Code as 'Код', spec.Name as 'Название', spec_group.Code as 'Группа'
FROM Speciality spec
INNER JOIN Speciality_Group spec_group
ON spec.Group_ID = spec_group.ID_Speciality_Group
go

Create Procedure dbo.GetCurrentSpeciality
@ID_Speciality Int
as
SELECT ID_Speciality as 'ID', Code as 'Код', Name as 'Название', Group_ID as 'Группа специальностей'
FROM Speciality
where ID_Speciality = @ID_Speciality
go

Create Procedure dbo.GetSpecialityGroupShort
as
SELECT ID_Speciality_Group as 'ID', concat(Code, ' ' ,Name) as 'Название'
FROM Speciality_Group
go

Create Procedure dbo.GetDisciplinePriority
as
SELECT dis_pri.ID_Priority as 'ID', spec_group.Code as 'Код группы специальностей', dis.Name as 'Название предмета', dis_pri.Priority as 'Приоритет', 
dis_pri.Start_Date as 'Дата начала действия', dis_pri.End_Date as 'Дата окончания действия'
FROM Discipline_Priority dis_pri
INNER JOIN Speciality_Group spec_group
ON dis_pri.Speciality_Group_ID = spec_group.ID_Speciality_Group
INNER JOIN Discipline dis
ON dis_pri.Discipline_ID = dis.ID_Discipline
go

Alter Procedure dbo.GetCurrentPriority
@ID_Priority int
as
SELECT dis_pri.ID_Priority as 'ID', concat(spec_group.Code, ' ' ,spec_group.Name) as 'Группа специальностей', dis.Name as 'Название предмета', dis_pri.Priority as 'Приоритет', 
dis_pri.Start_Date as 'Дата начала действия', dis_pri.End_Date as 'Дата окончания действия'
FROM Discipline_Priority dis_pri
INNER JOIN Speciality_Group spec_group
ON dis_pri.Speciality_Group_ID = spec_group.ID_Speciality_Group
INNER JOIN Discipline dis
ON dis_pri.Discipline_ID = dis.ID_Discipline
WHERE ID_Priority = @ID_Priority
go

Create Procedure dbo.GetIndividualAchievements
@ID_Enrollee int
as
SELECT ind_ach.ID_Individual_Achievement as 'ID', ach.Name as 'Название'
FROM Individual_Achievements ind_ach
INNER JOIN Enrollee e
ON ind_ach.Enrollee_ID = e.ID_Enrollee
INNER JOIN Recorded_Achievement rec_ach
ON ind_ach.Achievement_Rec_ID = rec_ach.ID_Achievement_Rec
INNER JOIN Achievement ach
ON rec_ach.Achievement_ID = ach.ID_Achievement
WHERE ind_ach.Enrollee_ID = @ID_Enrollee
GO

Create Procedure dbo.GetEnrolleeMarks
@ID_Enrollee int
as
SELECT enr_mark.ID_Mark as 'ID', disp.Name as 'Предмет', enr_mark.Mark as 'Оценка'
FROM Enrollee_Mark enr_mark
INNER JOIN Enrollee e
ON enr_mark.Enrollee_ID = e.ID_Enrollee
INNER JOIN Discipline disp
ON enr_mark.Discipline_ID = disp.ID_Discipline
WHERE enr_mark.Enrollee_ID = @ID_Enrollee
GO

--exec GetSpeciality 

--Create Procedure dbo.GetDisciplinePriority
--as
--SELECT dis_pri.ID_Priority as 'ID', spec_group.Code as 'Код группы специальностей', dis.Name as 'Название предмета', dis_pri.Priority as 'Приоритет', 
--dis_pri.Start_Date as 'Дата начала действия', dis_pri.End_Date as 'Дата окончания действия'
--FROM Discipline_Priority dis_pri
--INNER JOIN Speciality_Group spec_group
--ON dis_pri.Speciality_Group_ID = spec_group.ID_Speciality_Group
--INNER JOIN Discipline dis
--ON dis_pri.Discipline_ID = dis.ID_Discipline
--group by spec_group.Code
--go

GO
Create Procedure dbo.GetEnrolleeSpeciality
@ID_Enrollee int
as
SELECT en_sp.ID_Enrollee_Spec as 'ID', spec.Name as 'Название', en_sp.Date as 'Дата'
FROM Enrollee_Speciality en_sp
INNER JOIN Speciality spec
ON en_sp.Speciality_ID = spec.ID_Speciality
WHERE en_sp.Enrollee_ID = @ID_Enrollee
GO

--SELECT DAY('2015-04-30 01:01:01.1234567');  

Create Procedure dbo.GetAcceptedEnrolleeList
@Amount int
as
select top (@Amount) e.Surname, e.Name, e.Patronymic, em.[Средний балл] from Enrollee e
inner join (select Enrollee_ID, AVG(Mark) as 'Средний балл' from Enrollee_Mark Group By Enrollee_ID) em
on e.ID_Enrollee = em.Enrollee_ID
go

--Go
--select AVG(Mark) as 'Средний балл' from Enrollee_Mark

--alter table Enrollee_Mark alter column Mark float not null

--go
--select e.Surname, e.Name, e.Patronymic, AVG(em.Mark) as 'Средний балл' from Enrollee e
--inner join Enrollee_Mark em
--on e.ID_Enrollee = em.Enrollee_ID

exec GetAcceptedEnrolleeList 10