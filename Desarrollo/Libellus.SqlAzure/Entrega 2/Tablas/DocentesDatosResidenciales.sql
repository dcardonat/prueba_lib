/*
	<Summary>Almacena la información residencial de un docente.<Summary>
*/

CREATE TABLE DocentesDatosResidenciales ( 
	Id int identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdDocente int NOT NULL,    -- Identificador interno del docente. 
	Direccion varchar(100) NOT NULL,    -- Dirección de residencia. 
	Barrio varchar(50) NOT NULL,    -- Barrio de residencia. 
	IdEstrato int NOT NULL,    -- Estrato de vivienda. 
	IdMunicipio smallint NOT NULL,    -- Municipio de residencia. 
	Telefono varchar(10) NOT NULL,    -- Teléfono de residencia. 
	TelefonoMovil varchar(12)    -- Teléfono móvil. 
)
;

ALTER TABLE DocentesDatosResidenciales ADD CONSTRAINT PK_DocenteDatosResidenciales 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE DocentesDatosResidenciales ADD CONSTRAINT FK_DocenteDatosResidenciales_DocenteDatosPersonales 
	FOREIGN KEY (IdDocente) REFERENCES DocentesDatosPersonales (Id)
;

ALTER TABLE DocentesDatosResidenciales ADD CONSTRAINT FK_DocenteDatosResidenciales_Maestros 
	FOREIGN KEY (IdEstrato) REFERENCES Maestros (Id)
;

ALTER TABLE DocentesDatosResidenciales ADD CONSTRAINT FK_DocenteDatosResidenciales_Municipios 
	FOREIGN KEY (IdMunicipio) REFERENCES Municipios (Id)
;