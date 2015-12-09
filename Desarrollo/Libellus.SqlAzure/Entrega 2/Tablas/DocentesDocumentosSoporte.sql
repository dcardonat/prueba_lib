/*
	<Summary>Almacena la información de los documentos de soporte de un docente.<Summary>
*/

CREATE TABLE DocentesDocumentosSoporte ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	IdDocumento int NOT NULL    -- Tipo de documento de soporte para el rol. 
)
;

ALTER TABLE DocentesDocumentosSoporte ADD CONSTRAINT PK_DocenteDocumentosSoporte 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesDocumentosSoporte ADD CONSTRAINT FK_DocenteDocumentosSoporte_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

ALTER TABLE DocentesDocumentosSoporte ADD CONSTRAINT FK_DocenteDocumentosSoporte_SoportePorRolesDocumentos 
	FOREIGN KEY (IdDocumento) REFERENCES SoportePorRolesDocumentos (Id)
;