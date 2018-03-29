CREATE PROCEDURE [dbo].[Eventos_Seleccionar_ValidarTipoAudiencia]
	@idtipoaudiencia int
AS
	SELECT tipoaudiencia FROM eventos WHERE tipoaudiencia=@idtipoaudiencia AND estatus=1
RETURN 0
