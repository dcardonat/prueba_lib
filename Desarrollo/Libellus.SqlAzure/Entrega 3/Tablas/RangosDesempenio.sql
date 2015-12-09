IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('RangosDesempenio') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE RangosDesempenio
;

CREATE TABLE RangosDesempenio ( 
	Id int identity(1,1)  NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdDesempenio int NOT NULL,
	NotaMinima numeric(5,2) NOT NULL,
	NotaMaxima numeric(5,2) NOT NULL,
	IdSede int NOT NULL

	CONSTRAINT UQ_RangosDesempenio UNIQUE(IdAnioLectivo, IdDesempenio, IdSede)
;

ALTER TABLE RangosDesempenio ADD CONSTRAINT PK_RangosDesempenio 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE RangosDesempenio ADD CONSTRAINT FK_RangosDesempenio_Maestros 
	FOREIGN KEY (IdDesempenio) REFERENCES Maestros (Id)
;

ALTER TABLE RangosDesempenio ADD CONSTRAINT FK_RangosDesempenio_Sedes 
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
;

ALTER TABLE RangosDesempenio ADD CONSTRAINT FK_RangosDesempenio_AnioLectivo
	FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)
;



