CREATE TABLE [dbo].[TipoEvento]
(
	[IdTipEve] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] NVARCHAR(50) NULL, 
    [Visible] BIT NULL
)
