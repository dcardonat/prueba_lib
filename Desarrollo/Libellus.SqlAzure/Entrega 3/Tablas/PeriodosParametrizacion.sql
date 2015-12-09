IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('PeriodosParametrizacion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE PeriodosParametrizacion
GO

CREATE TABLE PeriodosParametrizacion ( 
	Id int identity(1,1)  NOT NULL,
	Periodo tinyint NOT NULL,
	FechaInicial date NOT NULL,
	FechaFinal date NOT NULL,
	IdParametrizacionEscolar int NOT NULL,

	CONSTRAINT UQ_PeriodosParametrizacion UNIQUE (IdParametrizacionEscolar, Periodo),
	CONSTRAINT PK_PeriodosParametrizacion PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_PeriodosParametrizacion_ParametrizacionEscolar FOREIGN KEY (IdParametrizacionEscolar) REFERENCES ParametrizacionEscolar (Id)
)
GO