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
--Tables are generated from within the Solution!

