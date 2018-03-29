CREATE TABLE [dbo].[TeamLeaders]
(
	[IdTL] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(50) NULL, 
    [Correo] NVARCHAR(50) NULL, 
    [Activo] BIT NULL
)
