	ALTER TABLE Usuarios
	add IntentosFallidos tinyint  NULL;


	ALTER TABLE Usuarios
	add IdEstado tinyint  NULL;

	ALTER TABLE Usuarios
	add FechaUltimoIntento tinyint  NULL;


	ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_UsuariosEstado
		FOREIGN KEY (IdEstado) REFERENCES UsuariosEstado (Id)
	;

	Update Usuarios
	Set IdEstado = 1

	ALTER TABLE Usuarios
	alter column IdEstado tinyint  not null;

	ALTER TABLE Usuarios
	drop column Estado;

	ALTER TABLE Usuarios
	drop column FechaUltimoIntento;

	ALTER TABLE Usuarios
	DROP CONSTRAINT UQ_Correo;


	ALTER TABLE Usuarios
	alter column CorreoAlterno varchar(50)  NULL;

	ALTER TABLE Usuarios
	alter column Correo varchar(50)  NULL;

	ALTER TABLE Usuarios
	alter column Clave varchar(100)  NOT NULL;

	ALTER TABLE Usuarios
	DROP CONSTRAINT UQ_NombreUsuario;

	ALTER TABLE Usuarios
	alter column NombreUsuario varchar(20)  NULL;

	ALTER TABLE Usuarios
	ADD CONSTRAINT UQ_NombreUsuario UNIQUE(NombreUsuario)

	ALTER TABLE Usuarios
	alter column IdEstado tinyint  NOT NULL;

	alter table Usuarios
	drop column CorreoAlterno

	alter table UsuariosAdministrativos
	alter column FechaNacimiento Datetime not null