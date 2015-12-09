/*
	<Summary>Almacena la información de los países habilitados en Libellus.<Summary>
*/ 

CREATE TABLE Paises ( 
	Id smallint identity(1,1)  NOT NULL,    -- Identificador interno. 
	Nombre varchar(70) NOT NULL    -- Nombre del país. 
)
;

ALTER TABLE Paises
	ADD CONSTRAINT UQ_Paises_Nombre UNIQUE (Nombre)
;

ALTER TABLE Paises ADD CONSTRAINT PK_Paises 
	PRIMARY KEY CLUSTERED (Id)
;

