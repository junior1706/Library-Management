CREATE DATABASE Perpustakaan

USE Perpustakaan

create table NewBook(
bid int NOT NULL IDENTITY(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(250) not null,
bPubl varchar(250) not null,
bPDate varchar(250) not null,
bPrice bigint not null,
bQuant bigint not null
)

bName,bAuthor,bPubl,bPDate,bPrice,bQuant

select * from NewBook

 create table NewStudent (
 stuid int NOT NULL IDENTITY(1,1) primary key,
 sname varchar(250) not null,
 snumber varchar(250) not null,
 dep varchar(250) not null,
 sem varchar(250) not null,
 contact bigint not null,
 email varchar(250) not null
 )

sname, snumber, dep, sm, contact, email

select * from NewStudent

create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_number varchar(250) not null,
std_name varchar(250) not null,
std_dept varchar(250) not null,
std_sem varchar(250) not null,
std_contact bigint not null,
std_email varchar(250) not null,
book_name varchar(250) not null,
book_issue_date varchar(250) not null,
book_return_date varchar(250)
)

select * from IRBook

select * from IRBook where std_number = '1234'and book_return_date IS NULL

std_number,std_name,std_dept,std_sem,std_contact,std_email,book_name,book_issue_date


