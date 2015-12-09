/*
	<Summary>Almacena los datos de estado y horario del docente.<Summary>
*/

CREATE TABLE DocentesEstados ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	Estado bit NOT NULL,    -- Estado del docente en el sistema. 
	ObservacionesEstado varchar(100),    -- Observaciones del por qué se inactiva el docente. 
	IdHorario int NOT NULL,    -- Horario en el que se encuentra asignado el docente. 
	FechaCreacion datetime NOT NULL,    -- Fecha en la que se creó el docente en el sistema. 
	FechaUltimaActualizacion datetime    -- Fecha en la que se realizó la última actualización. 
)
;

ALTER TABLE DocentesEstados ADD CONSTRAINT PK_DocenteEstados 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesEstados ADD CONSTRAINT FK_DocenteEstados_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

ALTER TABLE DocentesEstados ADD CONSTRAINT FK_DocenteEstados_Maestros 
	FOREIGN KEY (IdHorario) REFERENCES Maestros (Id)
;