IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Matriculas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Matriculas
;

CREATE TABLE dbo.Matriculas
(
	Id int IDENTITY(1,1) NOT NULL,
    IdCupo INT NOT NULL, 
    IdEstado INT NOT NULL,

	CONSTRAINT PK_Matriculas PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Matriculas_Cupos FOREIGN KEY (IdCupo) REFERENCES Cupos (Id),
	CONSTRAINT FK_Matriculas_Maestros FOREIGN KEY (IdEstado) REFERENCES Maestros (Id)
)
GO