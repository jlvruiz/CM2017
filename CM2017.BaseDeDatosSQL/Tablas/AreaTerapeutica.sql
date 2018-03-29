CREATE TABLE [dbo].[AreaTerapeutica]
(
	[IdAT] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] NVARCHAR(50) NULL, 
    [Visible] BIT NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_AreaTerapeutica]
    ON [dbo].[AreaTerapeutica]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END