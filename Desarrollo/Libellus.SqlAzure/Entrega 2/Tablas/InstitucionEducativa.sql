IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('InstitucionEducativa') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE InstitucionEducativa
GO

CREATE TABLE InstitucionEducativa ( 
	Id int identity(1,1)  NOT NULL,
	Nombre varchar(100) NOT NULL,
	ResolucionAprobacion varchar(600),
	Nit varchar(15),
	CodigoDane varchar(15),
	Rut varchar(200),
	Logo image,
	Direccion varchar(50) NOT NULL,
	IdPais int NOT NULL,
	IdDepartamento int NOT NULL,
	IdMunicipio int NOT NULL,
	Telefono varchar(15) NOT NULL,
	Fax varchar(15),
	PaginaWeb varchar(100),

	CONSTRAINT PK_InstitucionEducativa PRIMARY KEY CLUSTERED (Id)
)
GO