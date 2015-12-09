/*
	<Summary>Almacena la experiencia laboral de un docente.<Summary>
*/

CREATE TABLE DocentesExperienciaLaboral ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	NombreInstitucion varchar(150) NOT NULL,    -- Nombre de la última institucion o empresa en la que laboró. 
	FechaIngreso date NOT NULL,    -- Fecha de ingreso a la última institucion o empresa en la que laboró. 
	FechaRetiro date,    -- Fecha de salida de la última institucion o empresa en la que laboró. 
	IdGradoEscalafon int NOT NULL,    -- Grado en el escalafón. 
	MotivoRetiro varchar(200),    -- Motivo del retiro. 
	AreasCompetencia varchar(200) NOT NULL,    -- Áreas de competencia. 
	FechaUltimoAscenso date    -- Fecha del último ascenso. 
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