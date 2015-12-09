/*
	<Summary>Almacena la información de cada uno de los roles creados por sede.<Summary>
*/

IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL
 DROP TABLE dbo.Roles
GO

CREATE TABLE Roles
(
	Id INT identity NOT NULL,
	IdSede INT NOT NULL,
	Nombre varchar(30) NOT NULL,
	Estado bit NOT NULL,
	CONSTRAINT PK_Roles PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.Roles WITH CHECK ADD CONSTRAINT FK_Roles_Sedes FOREIGN KEY (IdSede) REFERENCES dbo.Sedes (Id);