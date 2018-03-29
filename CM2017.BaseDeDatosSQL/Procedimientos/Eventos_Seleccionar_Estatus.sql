CREATE PROCEDURE [dbo].[Eventos_Seleccionar_Estatus]
	@estatus int
AS
	SELECT a.Id, a.NombreEvento as [Nombre Evento], a.FechaSolicitud as [Solicitado],
    a.FechaInicioEvento as [Inicia], a.FechaFinEvento as [Termina], 
    b.Descripcion as [Tipo de Evento], c.Nombre as [Nombre Gerente], 
    CASE 
		WHEN a.Estatus = 1 THEN 'Activo'
		WHEN a.Estatus = 0 THEN 'Inactivo'
		WHEN a.Estatus = 2 THEN 'Terminado' END AS Estatus 
    FROM Eventos a, TipoEvento b, Gerentes c 
    WHERE b.IdTipEve = a.TipoEvento 
    AND c.IdGerente = a.GteProducto 
    AND a.Estatus = @estatus  --0 inactivo 1 activo 2 terminado 
RETURN 0
