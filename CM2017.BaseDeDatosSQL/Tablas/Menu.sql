CREATE TABLE [dbo].[Menu]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Titulo] NVARCHAR(50) NULL, 
    [Descripcion] NVARCHAR(50) NULL, 
    [URL] NVARCHAR(50) NULL, 
    [Roles] INT NULL, 
    [Padre] INT NULL
)
