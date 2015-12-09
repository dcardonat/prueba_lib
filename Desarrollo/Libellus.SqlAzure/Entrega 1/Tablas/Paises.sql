/*
	<Summary>Almacena la informaci�n de los pa�ses habilitados en Libellus.<Summary>
*/ 

CREATE TABLE Paises ( 
	Id smallint identity(1,1)  NOT NULL,    -- Identificador interno. 
	Nombre varchar(70) NOT NULL    -- Nombre del pa�s. 
)
;

ALTER TABLE Paises
	ADD CONSTRAINT UQ_Paises_Nombre UNIQUE (Nombre)
;

ALTER TABLE Paises ADD CONSTRAINT PK_Paises 
	PRIMARY KEY CLUSTERED (Id)
;

