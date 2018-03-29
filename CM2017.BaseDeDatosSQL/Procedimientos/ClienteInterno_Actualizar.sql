CREATE PROCEDURE [dbo].[ClienteInterno_Actualizar]
	@descripcion nvarchar(50),
	@estatus int,
	@id int
AS
	UPDATE ClienteInterno SET Descripcion=@descripcion, Visible=@estatus WHERE IdCteInt=@id
