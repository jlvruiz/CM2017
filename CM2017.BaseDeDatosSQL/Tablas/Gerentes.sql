CREATE TABLE [dbo].[Gerentes]
(
	[IdGerente] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(50) NULL, 
    [Correo] NVARCHAR(50) NULL, 
    [Activo] BIT NULL
)
