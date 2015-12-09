IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('AperturaExtemporaneaPeriodos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE AperturaExtemporaneaPeriodos
GO

CREATE TABLE AperturaExtemporaneaPeriodos ( 
	Id int identity(1,1)  NOT NULL,
	IdPeriodo int NOT NULL,
	FechaInicial datetime NOT NULL,
	FechaFinal datetime NOT NULL,
	MotivoApertura varchar(50) NOT NULL,

	CONSTRAINT PK_AperturaExtemporaneaPeriodo PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_AperturaExtemporaneaPeriodos_IdPeriodo UNIQUE (IdPeriodo),
	CONSTRAINT FK_AperturaExtemporaneaPeriodo_PeriodosParametrizacion FOREIGN KEY (IdPeriodo) REFERENCES PeriodosParametrizacion (Id)
)
GO






