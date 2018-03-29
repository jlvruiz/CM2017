CREATE PROCEDURE [dbo].[AreaTerapeutica_Seleccionar_Activo]
AS
	SELECT IdAT, Descripcion, 
	CASE
		WHEN Visible = 1 THEN 'Activo'
		WHEN Visible = 0 THEN 'Inactivo' END AS Visible 
	FROM AreaTerapeutica WHERE Visible=1
