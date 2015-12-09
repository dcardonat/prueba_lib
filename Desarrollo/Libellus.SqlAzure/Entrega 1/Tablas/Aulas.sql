/*
	<Summary>Permite almacenar las aulas.<Summary>
*/

IF OBJECT_ID('dbo.Aulas', 'U') IS NOT NULL
  DROP TABLE dbo.Aulas
GO

CREATE TABLE Aulas
(
	Id int IDENTITY(1,1) NOT NULL,
	Descripcion varchar(30) NOT NULL,
	IdMaestro int NOT NULL,
	IdSede int NOT NULL,
	Estado bit NOT NULL,

    CONSTRAINT PK_Aulas PRIMARY KEY (Id),
    CONSTRAINT FK_Aulas_Maestros FOREIGN KEY (IdMaestro) REFERENCES Maestros(Id), 
    CONSTRAINT FK_Aulas_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes(Id)
)
GO

ALTER TABLE Aulas ADD CONSTRAINT AK_Descripcion_Tipo UNIQUE (Descripcion, IdMaestro)
GO