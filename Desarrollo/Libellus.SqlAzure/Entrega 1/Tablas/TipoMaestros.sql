/*
	<Summary>Almacena los tipos de maestro que se administrarán desde la misma vista. Ejm: Grados, Aspectos evaluativos, etc.<Summary>
*/

CREATE TABLE dbo.TipoMaestros
(
	Id SMALLINT NOT NULL, 
	Descripcion VARCHAR(100) NOT NULL,
	Administrable BIT NOT NULL,
    CONSTRAINT PK_Id_TipoMaestros PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.TipoMaestros ADD CONSTRAINT UK_Descripcion UNIQUE (Descripcion)