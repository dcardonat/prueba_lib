IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('AspectosEvaluativos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE AspectosEvaluativos
;

CREATE TABLE AspectosEvaluativos ( 
	Id int identity(1,1)  NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdAspectoEvaluativo int NOT NULL,
	IdIntensidadHoraria int NOT NULL,
	Porcentaje decimal(5,2) NOT NULL,
	IdSede int NOT NULL,
	PruebasMinimas int NOT NULL
	CONSTRAINT UQ_AspectosEvaluativos UNIQUE(IdAnioLectivo, IdAspectoEvaluativo, IntensidadHoraria, IdSede)
)
;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT PK_AspectosEvaluativos 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_Maestros 
	FOREIGN KEY (IdAspectoEvaluativo) REFERENCES Maestros (Id)
;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_MaestrosIntensidadHoraria 
	FOREIGN KEY (IdIntensidadHoraria) REFERENCES Maestros (Id)
;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_Sedes 
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_AnioLectivo
	FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)
;







