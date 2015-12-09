IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesArchivos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesArchivos
GO

CREATE TABLE EstudiantesArchivos ( 
	Id int NOT NULL,
	Foto image,
	CONSTRAINT PK_EstudiantesArchivos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesArchivos_EstudiantesDatosPersonales FOREIGN KEY (Id) REFERENCES EstudiantesDatosPersonales (Id)
)
GO