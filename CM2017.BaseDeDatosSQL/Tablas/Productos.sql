CREATE TABLE [dbo].[Productos]
(
	[IdProducto] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] NVARCHAR(50) NULL, 
    [Visible] BIT NULL
)
