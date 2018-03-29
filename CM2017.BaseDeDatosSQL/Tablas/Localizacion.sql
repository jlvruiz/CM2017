CREATE TABLE [dbo].[Localizacion]
(
	[IdLoc] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(50) NULL, 
    [Tipo] INT NULL, 
    [Motivo] NVARCHAR(50) NULL, 
    [Visible] BIT NULL
)
