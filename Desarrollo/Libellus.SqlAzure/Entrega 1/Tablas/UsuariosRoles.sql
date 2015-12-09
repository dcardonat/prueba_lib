/*
	<Summary>Almacena los usuarios por roles.<Summary>
*/

IF OBJECT_ID('dbo.UsuariosRoles', 'U') IS NOT NULL
 DROP TABLE dbo.UsuariosRoles
GO

CREATE TABLE UsuariosRoles
(
	Id int identity NOT NULL,
	IdUsuario int NOT NULL,
	IdRol int  NOT NULL,
	IdSede int NOT NULL


	CONSTRAINT PK_UsuariosRoles PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.UsuariosRoles WITH CHECK ADD CONSTRAINT FK_UsuariosRoles_Usuarios FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuarios (Id);

GO

ALTER TABLE dbo.UsuariosRoles WITH CHECK ADD CONSTRAINT FK_UsuariosRoles_Roles FOREIGN KEY (IdRol) REFERENCES dbo.Roles (Id);

GO

ALTER TABLE dbo.UsuariosRoles WITH CHECK ADD CONSTRAINT FK_Sedes_Roles FOREIGN KEY (IdSede) REFERENCES dbo.Sedes (Id);
