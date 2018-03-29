CREATE PROCEDURE [dbo].[ClienteInterno_Seleccionar_PorId]
	@id int
AS
	SELECT IdCteInt, Descripcion, 
	CASE
		WHEN Visible = 1 THEN 'Activo' 
		WHEN Visible = 0 THEN 'Inactivo' END AS Visible 
	FROM ClienteInterno WHERE IdCteInt=@id
