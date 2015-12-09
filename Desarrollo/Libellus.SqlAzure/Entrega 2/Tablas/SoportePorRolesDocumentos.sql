IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SoportePorRolesDocumentos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SoportePorRolesDocumentos
GO

CREATE TABLE SoportePorRolesDocumentos ( 
	Id int identity(1,1)  NOT NULL,
	IdSoportePorRoles int NOT NULL,
	IdTipoDocumentoSoporte int NOT NULL,

	CONSTRAINT PK_SoportePorRolesDocumentos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_SoportePorRolesDocumentos_Maestros FOREIGN KEY (IdTipoDocumentoSoporte) REFERENCES Maestros (Id),
	CONSTRAINT FK_SoportePorRolesDocumentos_SoportePorRoles FOREIGN KEY (IdSoportePorRoles) REFERENCES SoportePorRoles (Id)
)
GO




