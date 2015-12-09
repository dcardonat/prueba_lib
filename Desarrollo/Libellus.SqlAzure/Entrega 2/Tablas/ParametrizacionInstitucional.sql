/*
	<Summary>Almacena la parametrización institucional de cada sede.<Summary>
*/

CREATE TABLE ParametrizacionInstitucional ( 
	Id int identity(1,1) NOT NULL,    -- Identificador interno.
	IdSede int NOT NULL,    -- Identificador interno de la sede.
	IdAnioLectivo int NOT NULL,    -- Año escolar en curso. 
	IdHorario int NOT NULL,    -- Identificador interno del horario asociado. 
	IdNivelEducativo int NOT NULL,    -- Identificador interno del nivel educativo. 
	HoraInicial time(7) NOT NULL,    -- Hora inicial establecida. 
	HoraFinal time(7) NOT NULL,    -- Hora final establecida. 
	MomentosSemana tinyint NOT NULL,    -- Define los momentos en semanales. 
	TiempoDescansos int NOT NULL,    -- Define el tiempo de descanso en minutos. 
	Estado bit NOT NULL    -- Establece el estado del registro
)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT UQ_ParametrizacionInstitucional_IdAnioLectivo_Horario_NivelEducativo 
	UNIQUE (IdAnioLectivo, IdHorario, IdNivelEducativo)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT PK_ParametrizacionInstitucional 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT FK_ParametrizacionInstitucional_Maestros_Horario 
	FOREIGN KEY (IdNivelEducativo) REFERENCES Maestros (Id)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT FK_ParametrizacionInstitucional_Maestros_Horarios 
	FOREIGN KEY (IdHorario) REFERENCES Maestros (Id)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT FK_ParametrizacionInstitucional_Sedes_IdSede 
	FOREIGN KEY (IdSede) REFERENCES Sedes (Id)
;

ALTER TABLE ParametrizacionInstitucional ADD CONSTRAINT FK_ParametrizacionInstitucional_AnioLectivo 
	FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo(Id)
;