CREATE PROCEDURE [dbo].[Eventos_Actualizar_Terminar]
AS
	UPDATE eventos SET estatus=2 WHERE format([fechafinevento], 'dd/mm/yyyy')< date() and estatus=1
RETURN 0
