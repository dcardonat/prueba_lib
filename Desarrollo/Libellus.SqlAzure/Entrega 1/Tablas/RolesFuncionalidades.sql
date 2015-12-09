/*
	<Summary>Almacena la información de los roles y funcionalidades.<Summary>
*/

IF OBJECT_ID('dbo.RolesFuncionalidades', 'U') IS NOT NULL
 DROP TABLE dbo.RolesFuncionalidades
GO

CREATE TABLE RolesFuncionalidades
(
	Id int identity NOT NULL,
	IdFuncionalidad int NOT NULL,
	IdRol int NOT NULL,
	CONSTRAINT PK_RolesFuncionalidades PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.RolesFuncionalidades WITH CHECK ADD CONSTRAINT FK_RolesFuncionalidades_Funcionalidades FOREIGN KEY (IdFuncionalidad) REFERENCES dbo.Funcionalidades (Id);

GO 

ALTER TABLE dbo.RolesFuncionalidades WITH CHECK ADD CONSTRAINT FK_RolesFuncionalidades_Roles FOREIGN KEY (IdRol) REFERENCES dbo.Roles (Id);
