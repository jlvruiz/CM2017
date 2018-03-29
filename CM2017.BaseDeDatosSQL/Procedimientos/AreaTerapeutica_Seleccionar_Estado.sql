CREATE PROCEDURE [dbo].[AreaTerapeutica_Seleccionar_Estado]
	@id int
AS
	SELECT visible FROM AreaTerapeutica WHERE IdAT=@id 
