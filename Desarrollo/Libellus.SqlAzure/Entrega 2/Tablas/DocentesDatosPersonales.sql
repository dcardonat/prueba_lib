/*
	<Summary>Almacena la información de los datos personales de un docente.<Summary>
*/

CREATE TABLE DocentesDatosPersonales ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdTipoDocumento int NOT NULL,    -- Tipo de documento. 
	DocumentoIdentidad varchar(12) NOT NULL,    -- Documento de identidad del docente. 
	Nombres varchar(50) NOT NULL,    -- Nombres de pila. 
	Apellidos varchar(50) NOT NULL,    -- Apellidos del docente. 
	IdSexo int NOT NULL,    -- Sexo. 
	IdGrupoSanguineo int NULL,    -- Grupo sanguineo. 
	IdEstadoCivil int NOT NULL,    -- Estado civil. 
	IdRolInstitucional int NOT NULL,    -- Rol institucional. 
	FechaNacimiento date NOT NULL,    -- Fecha de nacimiento. 
	IdMunicipioNacimiento smallint NOT NULL,    -- Municipio de nacimiento. 
	CorreoElectronico varchar(150) NOT NULL    -- Correo electrónico personal. 
)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT PK_DocenteDatosPersonales 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Maestros_EstadoCivil 
	FOREIGN KEY (IdEstadoCivil) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Maestros_GrupoSanguineo 
	FOREIGN KEY (IdGrupoSanguineo) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Maestros_RolInstitucional 
	FOREIGN KEY (IdRolInstitucional) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Municipios 
	FOREIGN KEY (IdMunicipioNacimiento) REFERENCES Municipios (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Maestros_TipoDocumento 
	FOREIGN KEY (IdTipoDocumento) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesDatosPersonales ADD CONSTRAINT FK_DocenteDatosPersonales_Maestros_Sexo 
	FOREIGN KEY (IdSexo) REFERENCES Maestros (Id)
;