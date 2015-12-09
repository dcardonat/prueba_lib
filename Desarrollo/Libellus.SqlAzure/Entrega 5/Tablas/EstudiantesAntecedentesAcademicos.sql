IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesAntecedentesAcademicos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesAntecedentesAcademicos
GO

CREATE TABLE EstudiantesAntecedentesAcademicos ( 
	Id int identity(1,1)  NOT NULL,
	IdEstudiante int NOT NULL,
	InstitucionEducativa varchar(100) NOT NULL,
	IdTipoInstitucion int NOT NULL,
	Anio int NOT NULL,
	IdGrado int NOT NULL,
	IdMotivoRetiro int NOT NULL,
	Observacion varchar(600),
	CONSTRAINT PK_EstudiantesAntecedentesAcademicos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesAntecedentesAcademicos_EstudiantesDatosPersonales FOREIGN KEY (IdEstudiante) REFERENCES EstudiantesDatosPersonales (Id),
	CONSTRAINT FK_EstudiantesAntecedentesAcademicos_TipoInstitucion FOREIGN KEY (IdTipoInstitucion) REFERENCES Maestros (Id),
	CONSTRAINT FK_EstudiantesAntecedentesAcademicos_Grado FOREIGN KEY (IdGrado) REFERENCES Maestros (Id),
	CONSTRAINT FK_EstudiantesAntecedentesAcademicos_MotivoRetiro FOREIGN KEY (IdMotivoRetiro) REFERENCES Maestros (Id)
)
GO
