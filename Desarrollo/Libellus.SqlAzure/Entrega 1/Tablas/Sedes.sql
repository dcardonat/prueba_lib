/*
	<Summary>Almacena la información de las sedes.<Summary>
*/
IF OBJECT_ID('dbo.Sedes', 'U') IS NOT NULL
 DROP TABLE dbo.Sedes
GO

CREATE TABLE Sedes
(
	Id int IDENTITY(1,1) NOT NULL,
	Nombre varchar(50) NOT NULL,
	IdInstitucionEducativa INT NOT NULL,
	Seccion VARCHAR(10) NOT NULL
	
	CONSTRAINT PK_Sedes PRIMARY KEY (Id)
)
GO