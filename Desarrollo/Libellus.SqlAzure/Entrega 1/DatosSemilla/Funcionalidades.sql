INSERT INTO dbo.Funcionalidades (Id,Nombre,Descripcion,Url,IdPadre,OrdenMenu,Categoria,Estado)
VALUES (1,'Administración','Administración del sistema','#',NULL,1,'menu',1)

INSERT INTO dbo.Funcionalidades (Id,Nombre,Descripcion,Url,IdPadre,OrdenMenu,Categoria,Estado)
VALUES (2,'Seguridad','Seguridad','#',1,2,'menu',1)

INSERT INTO dbo.Funcionalidades (Id,Nombre,Descripcion,Url,IdPadre,OrdenMenu,Categoria,Estado)
VALUES (3,'Usuarios administrativos','Usuarios administrativos','/Administracion/UsuariosAdministrativos/Consultar',2,3,'accion',1)
