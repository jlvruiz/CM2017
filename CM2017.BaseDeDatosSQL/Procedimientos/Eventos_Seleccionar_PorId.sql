CREATE PROCEDURE [dbo].[Eventos_Seleccionar_PorId]
	@id int
AS
	SELECT * FROM Eventos WHERE Id=@id

