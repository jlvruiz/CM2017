CREATE PROCEDURE [dbo].[Eventos_Seleccionar_ValidarTipoEvento]
	@idtipoevento int
AS
	SELECT tipoevento FROM eventos WHERE tipoevento=@idtipoevento AND estatus=1
RETURN 0
