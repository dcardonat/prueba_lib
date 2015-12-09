/*
	<Summary>Almacena la experiencia laboral de un docente.<Summary>
*/

CREATE TABLE DocentesExperienciaLaboral ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	NombreInstitucion varchar(150) NOT NULL,    -- Nombre de la �ltima institucion o empresa en la que labor�. 
	FechaIngreso date NOT NULL,    -- Fecha de ingreso a la �ltima institucion o empresa en la que labor�. 
	FechaRetiro date,    -- Fecha de salida de la �ltima institucion o empresa en la que labor�. 
	IdGradoEscalafon int NOT NULL,    -- Grado en el escalaf�n. 
	MotivoRetiro varchar(200),    -- Motivo del retiro. 
	AreasCompetencia varchar(200) NOT NULL,    -- �reas de competencia. 
	FechaUltimoAscenso date    -- Fecha del �ltimo ascenso. 
)
;

ALTER TABLE DocentesExperienciaLaboral ADD CONSTRAINT PK_DocenteExperienciaLaboral 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesExperienciaLaboral ADD CONSTRAINT FK_DocenteExperienciaLaboral_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

ALTER TABLE DocentesExperienciaLaboral ADD CONSTRAINT FK_DocenteExperienciaLaboral_Maestros 
	FOREIGN KEY (IdGradoEscalafon) REFERENCES Maestros (Id)
;