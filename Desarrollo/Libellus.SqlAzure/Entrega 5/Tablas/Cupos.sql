IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Cupos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Cupos
GO

CREATE TABLE Cupos ( 
	Id int identity(1,1)  NOT NULL,
	IdEstudiante int NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdGradoPorNivel int NOT NULL,
	IdSede int NOT NULL,
	IdTipoEstudiante int NOT NULL,
	TrasladoEstudiante bit NOT NULL,
	IdSalidaOcupacional int NULL,
	IdProfundizacion int NULL

	CONSTRAINT PK_Cupos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Cupos UNIQUE (IdEstudiante, IdAnioLectivo, IdSede),
	CONSTRAINT FK_Cupos_EstudiantesDatosPersonales FOREIGN KEY (IdEstudiante) REFERENCES EstudiantesDatosPersonales (Id),
	CONSTRAINT FK_Cupos_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id),
	CONSTRAINT FK_Cupos_GradosPorNivel FOREIGN KEY (IdGradoPorNivel) REFERENCES GradosPorNivel (Id),
	CONSTRAINT FK_Cupos_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes (Id),
	CONSTRAINT FK_Cupos_Maestros FOREIGN KEY (IdTipoEstudiante) REFERENCES Maestros (Id),
	CONSTRAINT FK_Cupos_SalidasOcupacionales FOREIGN KEY (IdSalidaOcupacional) REFERENCES SalidasOcupacionales(Id),
	CONSTRAINT FK_Cupos_Profundizacion FOREIGN KEY (IdProfundizacion) REFERENCES Maestros (Id)
)
GO