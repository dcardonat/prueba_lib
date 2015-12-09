IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('NivelesParametrizacion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE NivelesParametrizacion
GO

CREATE TABLE NivelesParametrizacion ( 
	Id int identity(1,1)  NOT NULL,
	IdNivel int NOT NULL,
	IdParametrizacionEscolar int NOT NULL,

	CONSTRAINT PK_NivelesParametrizacion PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_NivelesParametrizacion_Maestros FOREIGN KEY (IdNivel) REFERENCES Maestros (Id),
	CONSTRAINT FK_NivelesParametrizacion_ParametrizacionEscolar FOREIGN KEY (IdParametrizacionEscolar) REFERENCES ParametrizacionEscolar (Id)
)
GO