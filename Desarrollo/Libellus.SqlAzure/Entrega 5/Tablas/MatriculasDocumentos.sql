IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('MatriculasDocumentos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE MatriculasDocumentos
;

CREATE TABLE dbo.MatriculasDocumentos
(
	Id int identity(1,1)  NOT NULL,
    IdMatricula INT NOT NULL, 
    IdDocumento INT NOT NULL,

	CONSTRAINT PK_MatriculasDocumentos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_MatriculasDocumentos UNIQUE (IdMatricula, IdDocumento),
	CONSTRAINT FK_MatriculasDocumentos_Matriculas FOREIGN KEY (IdMatricula) REFERENCES Matriculas (Id),
	CONSTRAINT FK_MatriculasDocumentos_SoportePorRolesDocumentos FOREIGN KEY (IdDocumento) REFERENCES SoportePorRolesDocumentos (Id)
)
GO
