/*
	<Summary>Almacena la información de las funcionalidades del sistema.<Summary>
*/

IF OBJECT_ID('dbo.Funcionalidades', 'U') IS NOT NULL
 DROP TABLE dbo.Funcionalidades
GO

CREATE TABLE Funcionalidades
(
	Id int NOT NULL,
	Nombre varchar(70) NOT NULL,
	Descripcion nchar(150) NOT NULL,
	Url varchar(200) NULL,
	IdPadre int NULL,
	OrdenMenu int NULL,
	Categoria varchar(50) NULL,
	Estado bit not null
	CONSTRAINT PK_Funcionalidades PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.Funcionalidades WITH CHECK ADD CONSTRAINT FK_Funcionalidades_Funcionalidades FOREIGN KEY (IdPadre) REFERENCES dbo.Funcionalidades (Id);

GO
