IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesPorGrupo') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesPorGrupo
;

CREATE TABLE dbo.EstudiantesPorGrupo
(
	Id int identity(1,1)  NOT NULL,
    IdEstudiante INT NOT NULL, 
    IdGrupo INT NOT NULL,

	CONSTRAINT PK_EstudiantesPorGrupo PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesPorGrupo_Estudiante FOREIGN KEY (IdEstudiante) REFERENCES EstudiantesDatosPersonales (Id),
	CONSTRAINT FK_EstudiantesPorGrupo_Grupo FOREIGN KEY (IdGrupo) REFERENCES Grupos (Id),
)
GO