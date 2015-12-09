/*
	<Summary>Almacena la información de los departamentos habilitados en Libellus.<Summary>
*/

CREATE TABLE Departamentos ( 
	Id smallint identity(1,1)  NOT NULL,    -- Identificador interno. 
	IdPais smallint NOT NULL,    -- Identificador interno del país al que pertenece. 
	Nombre varchar(100) NOT NULL    -- Nombre del departamento. 
)
;

ALTER TABLE Departamentos
	ADD CONSTRAINT UQ_Departamentos_Nombre UNIQUE (IdPais, Nombre)
;

ALTER TABLE Departamentos ADD CONSTRAINT PK_Departamentos 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE Departamentos ADD CONSTRAINT FK_Departamentos_Paises 
	FOREIGN KEY (IdPais) REFERENCES Paises (Id)
;