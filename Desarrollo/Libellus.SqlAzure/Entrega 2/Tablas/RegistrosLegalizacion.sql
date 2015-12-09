IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('RegistrosLegalizacion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE RegistrosLegalizacion
GO

CREATE TABLE RegistrosLegalizacion ( 
	Id int identity(1,1)  NOT NULL,
	TipoRegistro varchar(50) NOT NULL,
	FechaExpedicion date NOT NULL,
	TextoLegalizacion varchar(600) NOT NULL,
	VigenciaDesde date NOT NULL,
	VigenciaHasta date NOT NULL,
	IdInstitucionEducativa int NOT NULL,

	CONSTRAINT PK_RegistrosLegalizacion PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_RegistrosLegalizacion_InstitucionEducativa FOREIGN KEY (IdInstitucionEducativa) REFERENCES InstitucionEducativa (Id),
	CONSTRAINT UQ_RegistrosLegalizacion_Unique UNIQUE (TipoRegistro, FechaExpedicion, TextoLegalizacion, VigenciaDesde, VigenciaHasta)
)
GO







