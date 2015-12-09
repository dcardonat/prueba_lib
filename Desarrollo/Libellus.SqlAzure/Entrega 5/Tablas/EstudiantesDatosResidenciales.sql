IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesDatosResidenciales') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesDatosResidenciales
GO

CREATE TABLE EstudiantesDatosResidenciales ( 
	Id int NOT NULL,
	Direccion varchar(50) NULL,
	IdMunicipio smallint NULL,
	Barrio varchar(30) NULL,
	IdEstrato int NULL,
	TelefonoFijo varchar(15) NOT NULL,
	TelefonoMovil varchar(15),

	CONSTRAINT PK_EstudiantesDatosResidenciales PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesDatosResidenciales_EstudiantesDatosPersonales FOREIGN KEY (Id) REFERENCES EstudiantesDatosPersonales (Id),
	CONSTRAINT FK_EstudiantesDatosResidenciales_Municipios FOREIGN KEY (IdMunicipio) REFERENCES Municipios (Id),
	CONSTRAINT FK_EstudiantesDatosResidenciales_Maestros FOREIGN KEY (IdEstrato) REFERENCES Maestros (Id)
)
GO