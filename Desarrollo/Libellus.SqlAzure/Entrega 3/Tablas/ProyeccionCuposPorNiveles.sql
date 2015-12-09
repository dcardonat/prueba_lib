IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('ProyeccionCuposPorNiveles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ProyeccionCuposPorNiveles
;

CREATE TABLE ProyeccionCuposPorNiveles ( 
	Id int identity(1,1)  NOT NULL,
	IdNivel int NOT NULL,
	EstudiantesGrupo int NOT NULL,
	EstudiantesEsperados int NOT NULL,
	IdSede int NOT NULL,
	IdAnioLectivo int NOT NULL

	CONSTRAINT UQ_ProyeccionCuposPorNiveles UNIQUE(IdAnioLectivo , IdNivel, IdSede)
)
;

ALTER TABLE ProyeccionCuposPorNiveles ADD CONSTRAINT PK_ProyeccionCuposPorNiveles 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE ProyeccionCuposPorNiveles ADD CONSTRAINT FK_ProyeccionCuposPorNiveles_Maestros 
	FOREIGN KEY (IdNivel) REFERENCES Maestros (Id)
;

ALTER TABLE ProyeccionCuposPorNiveles ADD CONSTRAINT FK_ProyeccionCuposPorNiveles_Sedes 
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
;

ALTER TABLE ProyeccionCuposPorNiveles ADD CONSTRAINT FK_ProyeccionCuposPorNiveles_AnioLectivo
	FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)
;


