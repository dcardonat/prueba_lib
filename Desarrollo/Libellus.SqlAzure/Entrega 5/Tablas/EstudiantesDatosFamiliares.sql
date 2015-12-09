IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('EstudiantesDatosFamiliares') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE EstudiantesDatosFamiliares
GO

CREATE TABLE EstudiantesDatosFamiliares ( 
	Id int NOT NULL,
	IdPadre int,
	IdMadre int,
	IdAcudiente int NOT NULL,

	CONSTRAINT PK_EstudiantesDatosFamiliares PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_EstudiantesDatosFamiliares_EstudiantesDatosPersonales FOREIGN KEY (Id) REFERENCES EstudiantesDatosPersonales (Id),
	CONSTRAINT FK_EstudiantesDatosFamiliares_FamiliaresEstudiente FOREIGN KEY (IdAcudiente) REFERENCES FamiliaresEstudiente (Id),
	CONSTRAINT FK_EstudiantesDatosFamiliares_Padre FOREIGN KEY (IdPadre) REFERENCES FamiliaresEstudiente (Id),
	CONSTRAINT FK_EstudiantesDatosFamiliares_Madre FOREIGN KEY (IdMadre) REFERENCES FamiliaresEstudiente (Id)
)
GO