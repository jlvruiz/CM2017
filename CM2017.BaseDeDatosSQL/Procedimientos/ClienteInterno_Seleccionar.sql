CREATE PROCEDURE [dbo].[ClienteInterno_Seleccionar]
AS
	SELECT IdCteInt, Descripcion, 
	CASE
		WHEN Visible = 1 THEN 'Activo'
		WHEN Visible = 0 THEN 'Inactivo' END AS Visible 
	FROM ClienteInterno ORDER BY Descripcion
