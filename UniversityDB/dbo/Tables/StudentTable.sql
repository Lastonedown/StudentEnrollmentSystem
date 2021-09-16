CREATE TABLE [dbo].[StudentTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] NCHAR(10) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [Gender] NCHAR(6) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [EmailAddress] NCHAR(50) NOT NULL, 
    [PhoneNumber] NCHAR(10) NOT NULL
)
