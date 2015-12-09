IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesDatosPersonales') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesDatosPersonales
GO

CREATE TABLE EstudiantesDatosPersonales ( 
	Id int NOT NULL,
	Nombre varchar(100) NOT NULL,
	PrimerApellido varchar(50) NOT NULL,
	SegundoApellido varchar(50) NULL,
	FechaNacimiento date NOT NULL,
	IdSexo int NOT NULL,
	IdGrupoSanguineo int NULL,
	IdMunicipioNacimiento smallint NULL,
	IdEstado int NOT NULL,
	IdEntidadPromotoraSalud int,
	FechaCreacion datetime NULL default GETDATE(),
	FechaActualizacion datetime NULL,

	CONSTRAINT PK_EstudiantesDatosPersonales PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesDatosPersonales_Usuarios FOREIGN KEY (Id) REFERENCES Usuarios (Id),
	CONSTRAINT FK_EstudiantesDatosPersonales_Sexo FOREIGN KEY (IdSexo) REFERENCES Maestros (Id),
	CONSTRAINT FK_EstudiantesDatosPersonales_GrupoSanguineo FOREIGN KEY (IdGrupoSanguineo) REFERENCES Maestros (Id),
	CONSTRAINT FK_EstudiantesDatosPersonales_Municipios FOREIGN KEY (IdMunicipioNacimiento) REFERENCES Municipios (Id),
	CONSTRAINT FK_EstudiantesDatosPersonales_EstadoEstudiante FOREIGN KEY (IdEstado) REFERENCES Maestros (Id)
)
GO