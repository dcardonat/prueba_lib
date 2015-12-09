IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FamiliaresEstudiente') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE FamiliaresEstudiente
GO

CREATE TABLE FamiliaresEstudiente ( 
	Id int identity(1,1)  NOT NULL,
	Identificacion varchar(15) NOT NULL,
	IdTipoIdentificacion int NOT NULL,
	Nombres varchar(100) NOT NULL,
	IdMunicipio smallint,
	Direccion varchar(50),
	Barrio varchar(30),
	IdEstrato int,
	Telefono varchar(15) NOT NULL,
	Celular varchar(15),
	Correo varchar(50),
	IdNivelEscolaridad int NOT NULL,
	IdEstadoCivil int,
	EsAcudiente bit,
	Vive bit,
	IdParentesco int,

	CONSTRAINT UQ_FamiliaresEstudiente UNIQUE (Identificacion),
	CONSTRAINT PK_FamiliaresEstudiente PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_FamiliaresEstudiente_Municipios FOREIGN KEY (IdMunicipio) REFERENCES Municipios (Id),
	CONSTRAINT FK_FamiliaresEstudiente_TipoIdentificacion FOREIGN KEY (IdTipoIdentificacion) REFERENCES Maestros (Id),
	CONSTRAINT FK_FamiliaresEstudiente_Estrato FOREIGN KEY (IdEstrato) REFERENCES Maestros (Id),
	CONSTRAINT FK_FamiliaresEstudiente_NivelEscolaridad FOREIGN KEY (IdNivelEscolaridad) REFERENCES Maestros (Id),
	CONSTRAINT FK_FamiliaresEstudiente_EstadoCivil FOREIGN KEY (IdEstadoCivil) REFERENCES Maestros (Id),
	CONSTRAINT FK_FamiliaresEstudiente_Parentesco FOREIGN KEY (IdParentesco) REFERENCES Maestros (Id)
)
GO

















