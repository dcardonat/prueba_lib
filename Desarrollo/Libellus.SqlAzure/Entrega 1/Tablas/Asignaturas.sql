/*
	<Summary>Almacena las asignaturas.<Summary>
*/

IF OBJECT_ID('dbo.Asignaturas', 'U') IS NOT NULL
  DROP TABLE dbo.Asignaturas
GO

CREATE TABLE dbo.Asignaturas 
( 
	Id int identity(1,1)  NOT NULL,
	Descripcion varchar(50) NOT NULL,
	IdMaestro int NOT NULL,
	IdSede int NOT NULL,
	Estado bit NOT NULL,

	CONSTRAINT PK_Asignaturas PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Asignaturas_Maestros FOREIGN KEY (IdMaestro) REFERENCES Maestros (Id),
	CONSTRAINT FK_Asignaturas_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
)
GO

ALTER TABLE Asignaturas ADD CONSTRAINT AK_Descripcion_TipoAsignatura UNIQUE (Descripcion, IdMaestro)
GO