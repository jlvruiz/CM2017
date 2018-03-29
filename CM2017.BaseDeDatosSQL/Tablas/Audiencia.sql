CREATE TABLE [dbo].[Audiencia]
(
	[IdAudiencia] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] NVARCHAR(50) NULL, 
    [Visible] BIT NULL, 
    [Bloqueado] BIT NULL
)
