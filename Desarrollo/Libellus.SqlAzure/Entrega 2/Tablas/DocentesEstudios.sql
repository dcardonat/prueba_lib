/*
	<Summary>Almacena los estudios realizados por un docente.<Summary>
*/

CREATE TABLE DocentesEstudios ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	InstitucionEducativa varchar(150) NOT NULL,    -- Nombre de la instituci�n educativa donde realiz� el estudio. 
	Titulo varchar(150) NOT NULL,    -- T�tulo otorgado. 
	IdClasificacion int NOT NULL,    -- Clasificaci�n del estudio. 
	FechaTerminacion date NOT NULL,    -- Fecha de terminaci�n del estudio. 
	IdEstado int NOT NULL    -- Estado del estudio. 
)
;

ALTER TABLE DocentesEstudios ADD CONSTRAINT PK_DocenteEstudios 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesEstudios ADD CONSTRAINT FK_DocenteEstudios_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

ALTER TABLE DocentesEstudios ADD CONSTRAINT FK_DocenteEstudios_Maestros_EstadoEstudio 
	FOREIGN KEY (IdEstado) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesEstudios ADD CONSTRAINT FK_DocenteEstudios_Maestros_ClasificacionEstudio 
	FOREIGN KEY (IdClasificacion) REFERENCES Maestros (Id)
;