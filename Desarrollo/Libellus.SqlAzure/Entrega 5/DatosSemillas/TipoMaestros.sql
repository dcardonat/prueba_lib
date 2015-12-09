-- Adición de nuevos tipos de maestros.
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 36, 'Tipo estudiante', 0 )
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 37, 'Estados matricula', 0 )
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 38, 'Tipos institucion', 0 )
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 39, 'Motivos de retiro', 1 )
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 40, 'Estados estudiante', 0 )

--Grupos
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 41, 'Grupos', 1 )

--Niveles profundización.
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 42, 'Niveles de profundización', 1 )

--Parentesco
INSERT INTO dbo.TipoMaestros ( Id, Descripcion, Administrable ) VALUES ( 43, 'Parentesco', 0 )