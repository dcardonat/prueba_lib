IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('ParametrizacionEscolar') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ParametrizacionEscolar
GO

CREATE TABLE ParametrizacionEscolar ( 
	Id int identity(1,1)  NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdTipoParametrizacion int NOT NULL,
	IdSemestre int,
	IdJornadaAcademica int NOT NULL,
	IdSemanasLectivas int NOT NULL,
	PorcentajeInasistencia tinyint NOT NULL,

	CONSTRAINT PK_ParametrizacionEscolar PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_ParametrizacionEscolar UNIQUE (IdAnioLectivo, IdTipoParametrizacion, IdSemestre),
	CONSTRAINT FK_ParametrizacionEscolar_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id),
	CONSTRAINT FK_ParametrizacionEscolar_TipoParametrizacion FOREIGN KEY (IdTipoParametrizacion) REFERENCES Maestros (Id),
	CONSTRAINT FK_ParametrizacionEscolar_Semestre FOREIGN KEY (IdSemestre) REFERENCES Maestros (Id),
	CONSTRAINT FK_ParametrizacionEscolar_JornadaAcademica FOREIGN KEY (IdJornadaAcademica) REFERENCES Maestros (Id),
	CONSTRAINT FK_ParametrizacionEscolar_SemanasLectivas FOREIGN KEY (IdSemanasLectivas) REFERENCES Maestros (Id),
)
GO