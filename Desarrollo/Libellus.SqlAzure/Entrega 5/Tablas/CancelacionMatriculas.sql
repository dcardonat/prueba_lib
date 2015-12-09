IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CancelacionMatriculas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CancelacionMatriculas
;

CREATE TABLE dbo.CancelacionMatriculas
(
	Id int identity(1,1)  NOT NULL,
    IdMatricula INT NOT NULL, 
    IdMotivoRetiro INT NOT NULL,
	Observacion VARCHAR(1000) NULL,

	CONSTRAINT PK_CancelacionMatriculas PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_CancelacionMatriculas_Matriculas FOREIGN KEY (IdMatricula) REFERENCES Matriculas (Id),
	CONSTRAINT FK_CancelacionMatriculas_Maestros FOREIGN KEY (IdMotivoRetiro) REFERENCES Maestros (Id)
)
GO