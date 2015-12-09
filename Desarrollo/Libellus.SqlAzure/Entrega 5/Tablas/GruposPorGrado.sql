IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GruposPorGrado') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GruposPorGrado
;

CREATE TABLE dbo.GruposPorGrado
(
	Id INT NOT NULL IDENTITY(1, 1),
	IdGrado INT NOT NULL,
	IdGrupo INT NOT NULL,
    CONSTRAINT PK_GruposPorGrado PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.GruposPorGrado ADD CONSTRAINT FK_GruposPorGrado_Grupos FOREIGN KEY (IdGrupo) REFERENCES dbo.Maestros(Id);
ALTER TABLE dbo.GruposPorGrado ADD CONSTRAINT FK_GruposPorGrado_Grados FOREIGN KEY (IdGrado) REFERENCES dbo.Maestros(Id);