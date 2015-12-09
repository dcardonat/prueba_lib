/*
	<Summary>Almacena los archivos relacionados a un docente. Como fotos, firmas, entre otros.<Summary>
*/

CREATE TABLE DocentesArchivos ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	Foto image NOT NULL,    -- Foto del docente. 
	Firma image NOT NULL    -- Firma del docente. 
)
;

ALTER TABLE DocentesArchivos ADD CONSTRAINT PK_DocenteArchivos 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesArchivos ADD CONSTRAINT FK_DocenteArchivos_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

