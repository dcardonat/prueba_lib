/*
	<Summary>Almacena la información de cada uno de los maestros administrados desde la misma vista y referenciados por su tipo (IdTipoMaestro).<Summary>
*/

CREATE TABLE dbo.Maestros
(
	Id INT IDENTITY(1,1) NOT NULL, 
	Descripcion VARCHAR(300) NOT NULL, 
	IdTipoMaestro SMALLINT NOT NULL,
	IdSede INT NOT NULL,
	Estado BIT NOT NULL,
	Consecutivo INT NULL
    CONSTRAINT PK_Id_Maestros PRIMARY KEY (Id)
)
GO

ALTER TABLE Maestros ADD CONSTRAINT UQ_Maestros_Descripcion UNIQUE (IdTipoMaestro, Descripcion, IdSede);

ALTER TABLE dbo.Maestros WITH CHECK ADD CONSTRAINT FK_Maestros_TipoMaestros FOREIGN KEY (IdTipoMaestro) REFERENCES dbo.TipoMaestros (Id);