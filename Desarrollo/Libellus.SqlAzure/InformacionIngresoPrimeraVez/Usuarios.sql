INSERT INTO dbo.Usuarios ( Estado, Correo, Clave, NombreUsuario, IdTipoIdentificacion, Identificacion )
VALUES ( 1, 'usuario@correo.com', '7XxguvdZmDOJEJ6nD62qvQkxYTBf+CF5a5FkMM6PHW4=', 'usuario', 33, 1020 )

DECLARE @IdUsuario AS INT = SCOPE_IDENTITY()

INSERT INTO dbo.UsuariosAdministrativos ( Nombres, Apellidos, IdUsuario, Telefono, IdGrupoSanguineo, FechaNacimiento, IdCargo, Direccion, Celular )
VALUES ( 'Usuario despliegues', ' ', @IdUsuario, '2670000', 34, '01/01/1980', 35, 'CRA 50 # 70 - 10', '3002490016' )

INSERT INTO dbo.UsuariosRoles ( IdUsuario, IdRol, IdSede ) VALUES ( @IdUsuario, 3, 1 )