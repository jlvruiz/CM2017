CREATE PROCEDURE [dbo].[Eventos_Actualizar_Estatus]
	@estatus int,
	@id int
AS
	UPDATE eventos SET Estatus=@estatus WHERE Id=@id
RETURN 0
