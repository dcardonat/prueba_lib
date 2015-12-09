IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('SoportePorRoles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE SoportePorRoles
GO

CREATE TABLE SoportePorRoles ( 
	Id int identity(1,1)  NOT NULL,
	IdAnioLectivo int NOT NULL,
	IdRolInstitucional int NOT NULL,
	IdNivelEducativo int NULL,
	IdSede int NOT NULL,
	Estado bit NOT NULL,

	CONSTRAINT PK_SoportePorRoles PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_SoportePorRoles_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id),
	CONSTRAINT FK_SoportePorRoles_MaestrosRol FOREIGN KEY (IdRolInstitucional) REFERENCES Maestros (Id),
	CONSTRAINT FK_SoportePorRoles_MaestrosNivel FOREIGN KEY (IdNivelEducativo) REFERENCES Maestros (Id),
	CONSTRAINT FK_SoportePorRoles_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes (Id),
	CONSTRAINT UQ_IdAnioLectivo_Rol_Nivel_Sede UNIQUE (IdAnioLectivo, IdRolInstitucional, IdNivelEducativo, IdSede)
)

GO







