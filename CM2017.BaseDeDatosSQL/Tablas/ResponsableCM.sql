CREATE TABLE [dbo].[ResponsableCM]
(
	[IdResCM] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(50) NULL, 
    [Correo] NVARCHAR(50) NULL, 
    [Activo] BIT NULL, 
    [Clave] NCHAR(10) NULL, 
    [Contra] NCHAR(10) NULL
)
