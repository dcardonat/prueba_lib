/*
	<Summary>Almacena la información del maestro salidas ocupacionales.<Summary>
*/

CREATE TABLE dbo.SalidasOcupacionales
(
	Id int NOT NULL IDENTITY(1, 1),
	Descripcion VARCHAR(30) NOT NULL,
	IntensidadHoraria SMALLINT NOT NULL,
	IdSede INT NOT NULL,
	Estado BIT NOT NULL,
    CONSTRAINT PK_Id_SalidasOcupacionales PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.SalidasOcupacionales ADD CONSTRAINT UQ_SalidasOcupacionales_Descripcion UNIQUE (Descripcion);

ALTER TABLE dbo.SalidasOcupacionales WITH CHECK ADD CONSTRAINT FK_IdSede_Sedes FOREIGN KEY (IdSede) REFERENCES dbo.Sedes (Id);