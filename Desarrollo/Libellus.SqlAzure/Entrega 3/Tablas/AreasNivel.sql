IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('AreasNivel') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE AreasNivel
GO

CREATE TABLE AreasNivel ( 
	Id int IDENTITY(1,1) NOT NULL,
	IdArea int NOT NULL,
	IdNivelParametrizacion int NOT NULL,

	CONSTRAINT PK_AreasNivel PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_AreasNivel_Maestros FOREIGN KEY (IdArea) REFERENCES Maestros (Id),
	CONSTRAINT FK_AreasNivel_NivelesParametrizacion FOREIGN KEY (IdNivelParametrizacion) REFERENCES NivelesParametrizacion (Id)
)
GO




