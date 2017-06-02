USE [DVDLibrary]
GO

/****** Object:  Table [dbo].[DVDTable]    Script Date: 3/22/2017 1:39:32 PM ******/
DROP TABLE [dbo].[DVDTable]
GO

/****** Object:  Table [dbo].[DVDTable]    Script Date: 3/22/2017 1:39:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DVDTable](
	[Title] [varchar](30) NULL,
	[ReleaseDate] [varchar](10) NULL,
	[Director] [varchar](30) NULL,
	[Rating] [varchar](10) NULL,
	[DVDID] [int] IDENTITY(1,1)	Primary Key
) ON [PRIMARY]

GO

ALTER TABLE DVDTable
ADD Notes varchar(100);

SET ANSI_PADDING OFF
GO


--Creating the user and password--
USE master
GO
 
CREATE LOGIN DVDApp WITH PASSWORD='dvdapp123'
GO

USE DVDLibrary
GO
 
CREATE USER DVDApp FOR LOGIN DVDApp
GO

--Granting permissions

GRANT SELECT ON DVDTable TO DVDApp
GRANT INSERT ON DVDTable TO DVDApp
GRANT UPDATE ON DVDTable TO DVDApp
GRANT DELETE ON DVDTable TO DVDApp
GO

Grant Execute On GetAll To DVDApp
Grant Execute On GetById To DVDApp
Grant Execute On DeleteDVD To DVDApp
Grant Execute On EditDVD To DVDApp
Grant Execute On AddDVD To DVDApp
Go

--Creating Stored Procedures
Use DVDLibrary
Go
Create Procedure GetAll
As
Select * from DVDTable
Go

Use DVDLibrary
Go
Create Procedure GetByID(
	@DVDID int
)
As
Select * From DVDTable Where DVDID = @DVDID
Go

Use DVDLibrary
Go
Create Procedure DeleteDVD(
	@DVDID int
)
As
Delete From DVDTable Where DVDID = @DVDID
Go

Use DVDLibrary
Go
Create Procedure EditDVD(
	@DVDID int, @Title varchar(30), @Director varchar(30), @ReleaseDate varchar(30), @Rating varchar(10), @Notes varchar(100)
)
As
Update DVDTable Set Title = @Title, ReleaseDate = @ReleaseDate, Director = @Director, Rating = @Rating, Notes = @Notes Where DVDID = @DVDID
Go

Use DVDLibrary
Go
Create Procedure AddDVD(
	@Title varchar(30), @Director varchar(30), @ReleaseDate varchar(30), @Rating varchar(10), @Notes varchar(100)
)
As
Insert into DVDTable (Title, ReleaseDate, Director, Rating, Notes)
Values (@Title, @ReleaseDate, @Director, @Rating, @Notes)
Go

Select * from DVDTable