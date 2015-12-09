IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('Grupos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Grupos
;

CREATE TABLE dbo.Grupos
(
	Id int identity(1,1)  NOT NULL,
    IdGrupoPorGrado INT NOT NULL, 
	IdAnioLectivo INT NOT NULL,
	IdHorario INT NOT NULL,

	CONSTRAINT PK_Grupos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK_Grupos_GruposPorGrado FOREIGN KEY (IdGrupoPorGrado) REFERENCES GruposPorGrado (Id),
	CONSTRAINT FK_Grupos_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id),
	CONSTRAINT FK_Grupos_MaestroHorarios FOREIGN KEY (IdHorario) REFERENCES Maestros (Id),
	CONSTRAINT UQ_Grupos_Unique UNIQUE (IdGruposPorGrado, IdAnioLectivo, IdHorario)
)
GO