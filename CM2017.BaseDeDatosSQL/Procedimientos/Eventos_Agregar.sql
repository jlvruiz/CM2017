CREATE PROCEDURE [dbo].[Eventos_Agregar]
	@nombreevento nvarchar(50),
	@fechasolicitud datetime,
	@fechainicioevento datetime,
	@fechafinevento datetime,
	@idtipoevento int,
	@flujoautorizacion int,
	@idgerenteproducto int,
	@idproducto nvarchar(50),
	@idtipoaudiencia int,
	@invitados int,
	@objetivo nvarchar(50),
	@locacion1 int,
	@locacion2 int,
	@agenda nvarchar(50),
	@iddivision int,
	@idareaterapeutica int,
	@idteamleader int
AS
	INSERT into eventos (NombreEvento,FechaSolicitud,FechaInicioEvento,FechaFinEvento,TipoEvento,
    FlujoAutorizacion,GteProducto,Producto,TipoAudiencia,Invitados,Objetivo,Locacion1,Locacion2,Agenda,Division,
    AreaTerapeutica,TeamLeader) 
	VALUES (
	@nombreevento,
	@fechasolicitud,
	@fechainicioevento,
	@fechafinevento,
	@idtipoevento,
	@flujoautorizacion,
	@idgerenteproducto,
	@idproducto,
	@idtipoaudiencia,
	@invitados,
	@objetivo,
	@locacion1,
	@locacion2,
	@agenda,
	@iddivision,
	@idareaterapeutica,
	@idteamleader
	)
RETURN 0
