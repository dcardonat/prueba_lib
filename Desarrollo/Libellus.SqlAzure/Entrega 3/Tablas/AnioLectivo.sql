IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('AnioLectivo') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE AnioLectivo
GO

CREATE TABLE AnioLectivo ( 
	Id int identity(1,1)  NOT NULL,
	Anio smallint NOT NULL,
	FechaInicio datetime NOT NULL,
	Cerrado bit DEFAULT 0 NOT NULL,
	FechaCierre datetime,
	IdSede int NOT NULL,

	CONSTRAINT PK_AnioLectivo PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_AnioLectivo UNIQUE (Anio, IdSede),
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
)
GO