CREATE PROCEDURE [dbo].[AreaTerapeutica_Actualizar_Estatus]
	@estatus int,
	@id int
AS
	UPDATE AreaTerapeutica SET Visible=@estatus WHERE IdAT=@id 
