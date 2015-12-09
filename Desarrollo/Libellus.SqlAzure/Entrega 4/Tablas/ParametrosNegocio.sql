IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('ParametrosNegocio') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ParametrosNegocio
;

CREATE TABLE ParametrosNegocio ( 
	Nombre varchar(50) NOT NULL,
	Valor varchar(100) NOT NULL,
);

ALTER TABLE ParametrosNegocio ADD CONSTRAINT PK_ParametrosNegocio
	PRIMARY KEY CLUSTERED (Nombre)
;

