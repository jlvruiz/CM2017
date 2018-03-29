CREATE TABLE [dbo].[Eventos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NombreEvento] NVARCHAR(50) NULL, 
    [FechaSolicitud] DATETIME NULL, 
    [FechaInicioEvento] DATETIME NULL, 
    [FechaFinEvento] DATETIME NULL, 
    [TipoEvento] INT NULL, 
    [FlujoAutorizacion] INT NULL, 
    [GteProducto] INT NULL, 
    [Producto] VARCHAR(50) NULL, 
    [TipoAudiencia] INT NULL, 
    [Invitados] INT NULL, 
    [Objetivo] NVARCHAR(50) NULL, 
    [Locacion1] INT NULL, 
    [Locacion2] INT NULL, 
    [Agenda] NVARCHAR(50) NULL, 
    [Division] INT NULL, 
    [AreaTerapeutica] INT NULL, 
    [TeamLeader] INT NULL, 
    [Estatus] INT NULL,
	CONSTRAINT [FK_Eventos_TipoEvento] FOREIGN KEY ([TipoEvento]) REFERENCES [TipoEvento]([IdTipEve]) /* referencia a la tabla para evitar meter datos no permitidos*/,
	CONSTRAINT [FK_Eventos_GteProducto] FOREIGN KEY ([GteProducto]) REFERENCES [Gerentes]([IdGerente]), 
	CONSTRAINT [FK_Eventos_Audiencia] FOREIGN KEY ([TipoAudiencia]) REFERENCES [Audiencia]([IdAudiencia]), 
	CONSTRAINT [FK_Eventos_Division] FOREIGN KEY ([Division]) REFERENCES [Divisiones]([IdDivision]), 
    CONSTRAINT [FK_Eventos_AreaTerapeutica] FOREIGN KEY ([AreaTerapeutica]) REFERENCES [AreaTerapeutica]([IdAT]),
	CONSTRAINT [FK_Eventos_TeamLeader] FOREIGN KEY ([TeamLeader]) REFERENCES [TeamLeaders]([IdTL])
    
)
