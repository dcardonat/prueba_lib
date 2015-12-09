/*
	<Summary>Almacena los usuarios registrados.<Summary>
*/

IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
 DROP TABLE dbo.Usuarios
GO

CREATE TABLE Usuarios
(
	Id int identity NOT NULL,
	IdEstado tinyint NOT NULL,
	Correo varchar(50) NULL,
	Clave varchar(100) NULL,
	NombreUsuario varchar(20) NOT NULL,
	IdTipoIdentificacion int NOT NULL,
	Identificacion varchar(15) NOT NULL,
	IntentosFallidos tinyint  NULL

	CONSTRAINT PK_Usuarios PRIMARY KEY (Id),
	CONSTRAINT UQ_NombreUsuario UNIQUE(NombreUsuario) ,
	CONSTRAINT UQ_Identificacion UNIQUE(IdTipoIdentificacion , Identificacion) ,
)
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_MaestrosTiposIdentificaciones] FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [dbo].[Maestros] ([Id])
GO

ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_UsuariosEstado
	FOREIGN KEY (IdEstado) REFERENCES UsuariosEstado (Id)
;
