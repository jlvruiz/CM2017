CREATE PROCEDURE [dbo].[Eventos_Seleccionar_Detalle]
	@id int
AS
	SELECT a.flujoautorizacion AS [Flujo Autorizacion], 
    a.producto as Producto,  c.descripcion AS Audiencia, 
    a.invitados AS invitados, a.objetivo AS Objetivo, 
    a.locacion1 AS [Locación 1], d.nombre AS [Locación 2], 
    a.agenda AS Agenda, 
    e.descripcion AS División, 
    f.descripcion AS [Area Terapéutica], 
    g.nombre AS [Team Leader] 
    FROM eventos a, audiencia c, localizacion d, divisiones e, areaterapeutica f, teamleaders g 
    WHERE Id=@id 
    AND c.idaudiencia = a.tipoaudiencia
    AND d.idloc = a.locacion2 
    AND e.iddivision = a.division
    AND f.idAT  = a.areaterapeutica
    AND g.idtl = a.teamleader
RETURN 0
