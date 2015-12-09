IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('UsuariosEstado') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE UsuariosEstado
;

Create Table UsuariosEstado
(
	Id tinyint not null,
	Descripcion varchar(50) not null
)

ALTER TABLE UsuariosEstado ADD CONSTRAINT PK_UsuariosEstado
	PRIMARY KEY CLUSTERED (Id)
;
