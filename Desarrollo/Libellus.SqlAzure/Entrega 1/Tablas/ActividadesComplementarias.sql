/*
	<Summary>Almacena las actividades complementarias definidas.<Summary>
*/

IF OBJECT_ID('dbo.ActividadesComplementarias', 'U') IS NOT NULL
  DROP TABLE dbo.ActividadesComplementarias
GO

CREATE TABLE ActividadesComplementarias
(
	Id int IDENTITY(1,1) NOT NULL,
	Descripcion varchar(100) NOT NULL,
	IntensidadHoraria smallint NOT NULL,
	IdSede int NOT NULL,
	Estado bit NOT NULL,

    CONSTRAINT PK_ActividadesComplementarias PRIMARY KEY (Id),
    CONSTRAINT FK_ActividadesComplementarias_Sedes FOREIGN KEY (IdSede) REFERENCES Sedes(Id)
)
GO

ALTER TABLE ActividadesComplementarias ADD CONSTRAINT AK_Descripcion UNIQUE (Descripcion)
GO
