USE [master]
GO

/*
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [FinalProject225]    Script Date: 2020-12-10 1:03:27 AM ******/
CREATE LOGIN [FinalProject225] WITH PASSWORD==', DEFAULT_DATABASE=[225Final], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [FinalProject225] DISABLE
GO

The User that is Built into the App.Config File

*/


Create Database [225Final];
go
use [225Final];
go
--Primary Tables are generated from within the Solution!

Create Table LogLevel (
[ID] int NOT NULL IDENTITY (0,1),
[ErrorLevel] varchar(12) NOT NULL,
[ErrorName] varchar(14) NOT NULL
);
INSERT INTO LogLevel 
Values 
(69,'StartUp'),
(70,'Debug'),
(0,'None'),
(1,'Minor'),
(2,'Intermediate'),
(3,'Major'),
(4,'Extreme')