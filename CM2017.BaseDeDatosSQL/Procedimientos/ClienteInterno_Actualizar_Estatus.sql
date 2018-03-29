CREATE PROCEDURE [dbo].[ClienteInterno_Actualizar_Estatus]
	@estatus int,
	@id int
AS
	UPDATE ClienteInterno SET Visible=@estatus WHERE IdCteInt=@id
