CREATE PROCEDURE [dbo].[Eventos_Seleccionar_ValidarAreaTerapeutica]
	@idareaterapeutica int
AS
	SELECT areaterapeutica, nombreevento FROM eventos WHERE areaterapeutica=@idareaterapeutica AND estatus=1
RETURN 0
