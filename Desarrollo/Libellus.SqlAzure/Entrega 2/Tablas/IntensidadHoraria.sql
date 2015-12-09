IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('IntensidadHoraria') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE IntensidadHoraria
GO

CREATE TABLE IntensidadHoraria ( 
	Id int identity(1,1)  NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdAsignatura int NOT NULL,
	IdGrado int NOT NULL,
	HorasSemana tinyint NOT NULL,
	IdSede int NOT NULL,

	CONSTRAINT PK_IntensidadHoraria PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_IntensidadHoraria_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id),
	CONSTRAINT FK_IntensidadHoraria_Asignaturas FOREIGN KEY (IdAsignatura) REFERENCES Asignaturas (Id),
	CONSTRAINT FK_IntensidadHoraria_Maestros FOREIGN KEY (IdGrado) REFERENCES Maestros (Id),
	CONSTRAINT FK_IntensidadHoraria_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes (Id),
	CONSTRAINT UQ_IntensidadHoraria_Registro UNIQUE (Anio, IdAsignatura, IdGrado)
)

GO