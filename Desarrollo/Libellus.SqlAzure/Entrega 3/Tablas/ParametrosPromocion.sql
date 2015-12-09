IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('ParametrosPromocion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ParametrosPromocion
;

CREATE TABLE ParametrosPromocion ( 
	Id int identity(1,1)  NOT NULL,
	IdSede int NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdCalificacionMinima int NOT NULL,
	IdCalificacionMaxima int NOT NULL,
	MinimoAreasReprobadas int  NOT NULL,
	MaximoAreasMejoramiento int NOT NULL,
	MinimoAreaReprobacion int NOT NULL,
	PromedioPromocion int NOT NULL,
	PorcentajeInasistencia decimal(5,2) NOT NULL,
	IdEvaluacionAprendizaje int NOT NULL,
	PromedioPonderado bit NOT NULL,
	CalificacionMinimaAprobacion numeric(3,1) NOT NULL

	CONSTRAINT UQ_ParametrosPromocion UNIQUE(IdAnioLectivo, IdSede)
)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT PK_ParametrosPromocion 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocion_Maestros 
	FOREIGN KEY (IdEvaluacionAprendizaje) REFERENCES Maestros (Id)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocionCalificacionMaxima_Maestros 
	FOREIGN KEY (IdCalificacionMaxima) REFERENCES Maestros (Id)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocionCalificacionMinima_Maestros 
	FOREIGN KEY (IdCalificacionMinima) REFERENCES Maestros (Id)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocion_Sedes 
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
;

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocion_AnioLectivo 
	FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)
	;










