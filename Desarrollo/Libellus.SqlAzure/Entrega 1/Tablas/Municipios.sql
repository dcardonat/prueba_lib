/*
	<Summary>Almacena la información de los municipios habilitados en Libellus.<Summary>
*/

CREATE TABLE Municipios ( 
	Id smallint identity(1,1)  NOT NULL,    -- Identificador interno del municipio. 
	IdDepartamento smallint NOT NULL,    -- Identificador interno del departamento al que pertenece. 
	Nombre varchar(100) NOT NULL    -- Nombre del municipio. 
)
;

ALTER TABLE Municipios
	ADD CONSTRAINT UQ_Municipios_Nombre UNIQUE (IdDepartamento, Nombre)
;

ALTER TABLE Municipios ADD CONSTRAINT PK_Municipios 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE Municipios ADD CONSTRAINT FK_Municipios_Departamentos 
	FOREIGN KEY (IdDepartamento) REFERENCES Departamentos (Id)
;

EXEC sp_addextendedproperty 'MS_Description', 'Almacena la información de los municipios habilitados en Libellus.', 'Schema', dbo, 'table', Municipios
;
EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno del municipio.', 'Schema', dbo, 'table', Municipios, 'column', Id
;

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno del departamento al que pertenece.', 'Schema', dbo, 'table', Municipios, 'column', IdDepartamento
;

EXEC sp_addextendedproperty 'MS_Description', 'Nombre del municipio.', 'Schema', dbo, 'table', Municipios, 'column', Nombre
;

