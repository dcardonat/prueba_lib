/*
	<Summary>Almacena la información de los usuarios administrativos del sistema.<Summary>
*/

IF OBJECT_ID('UsuariosAdministrativos', 'U') IS NOT NULL
 DROP TABLE UsuariosAdministrativos
GO

CREATE TABLE UsuariosAdministrativos
(
	Id int identity(1,1) NOT NULL,
	Nombres varchar(50) NOT NULL,
	Apellidos varchar(50) NOT NULL,
	IdUsuario int NOT NULL,
	Telefono varchar(10) NOT NULL,
	IdGrupoSanguineo int NOT NULL,
	FechaNacimiento date NULL,
	IdCargo int NULL,
	Direccion varchar(50) NULL,
	Celular varchar(15) NOT NULL
	
	CONSTRAINT PK_UsuariosAdministrativos PRIMARY KEY (Id)
)


ALTER TABLE UsuariosAdministrativos WITH CHECK ADD CONSTRAINT FK_UsuariosAdministrativos_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id)

ALTER TABLE UsuariosAdministrativos WITH CHECK ADD CONSTRAINT FK_UsuariosAdministrativos_MaestrosGruposSanguineos FOREIGN KEY (IdGrupoSanguineo) REFERENCES Maestros (Id)

ALTER TABLE UsuariosAdministrativos WITH CHECK ADD CONSTRAINT FK_UsuariosAdministrativos_MaestrosCargos FOREIGN KEY (IdCargo) REFERENCES Maestros (Id)