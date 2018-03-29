CREATE PROCEDURE [dbo].[AreaTerapeutica_Actualizar]
	@descripcion nvarchar(50),
	@visible bit,
	@id int
AS
	UPDATE AreaTerapeutica SET Descripcion=@descripcion, Visible=@visible WHERE IdAT=@id
