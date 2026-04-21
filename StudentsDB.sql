use master;
go
create database StudentDB;
go 
use StudentDB;
go
CREATE TABLE Student (
Id INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(100),
BirthDate DATE
);
go
INSERT INTO Student (Name, BirthDate) VALUES
('John Doe', '2000-01-15'),
('Jane Smith', '1998-05-23'),
('Alice Johnson', '1999-03-12'),
('Bob Brown', '2001-07-19'),
('Charlie Davis', '1997-11-30'),
('Diana Evans', '2002-02-25'),
('Ethan Foster', '1996-09-10'),
('Fiona Green', '2000-12-05'),
('George Harris', '1998-04-18'),
('Hannah King', '1999-06-22');
go