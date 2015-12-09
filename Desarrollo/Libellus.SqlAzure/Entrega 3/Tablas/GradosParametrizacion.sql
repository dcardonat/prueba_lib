IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GradosParametrizacion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GradosParametrizacion
GO

CREATE TABLE GradosParametrizacion ( 
	Id int identity(1,1)  NOT NULL,
	IdParametrizacionEscolar int NOT NULL,
	IdGrado int NOT NULL,

	CONSTRAINT PK_GradosParametrizacion PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_GradosParametrizacion UNIQUE (IdParametrizacionEscolar, IdGrado),
	CONSTRAINT FK_GradosParametrizacion_Maestros FOREIGN KEY (IdGrado) REFERENCES Maestros (Id),
	CONSTRAINT FK_GradosParametrizacion_ParametrizacionEscolar FOREIGN KEY (IdParametrizacionEscolar) REFERENCES ParametrizacionEscolar (Id)
)
GO