-- Precarga maestro Intensidad horaria.
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '1,11,1', 20 , 1, 1 )

-- Precarga maestro Pruebas minimas
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '1,11,1', 21, 1, 1 )


-- Evaluación aprendizaje
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Cualitativa',22,1,1,14)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Cuantitativa',22,1,1,15)

-- Mayoría de edad
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '18', 23, 1, 1 )

-- Semestre
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Semestre 1',24,1,1,18)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Semestre 2',24,1,1,19)

-- Tipo parametrizacion
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Anual',25,1,1,16)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'Semestral',25,1,1,17)

--Semanas lectivas
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '18', 26, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '36', 26, 1, 1 )

--Duracion momentos
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '40', 27, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '45', 27, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '50', 27, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '55', 27, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '60', 27, 1, 1 )

--Momentos docente
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '10', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '11', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '12', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '13', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '14', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '15', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '16', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '17', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '18', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '19', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '20', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '21', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '22', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '23', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '24', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '25', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '26', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '27', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '28', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '29', 28, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '30', 28, 1, 1 )

--Estados estudios académicos
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( 'Finalizado', 29, 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( 'Candidato', 29, 1, 1 )

--Estados
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Activo', 30, 1, 1, 20 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Inactivo', 30, 1, 1, 21 )

-- Precarga promedio promocion.
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '1,12,1', 31 , 1, 1 )

-- Precarga calificación maxima
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '5', 32 , 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '10', 32 , 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '50', 32 , 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '100', 32 , 1, 1 )

-- Precarga calificación minima
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '0', 33 , 1, 1 )
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado ) VALUES ( '1', 33 , 1, 1 )

--Desempeño evaluativo
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Bajo', 1, 1, 1,  30)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Básico', 1, 1, 1,  29)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Alto', 1, 1, 1,  28)
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo  ) VALUES ( 'Superior', 1, 1, 1,  27)

-- Adición tipo de maestro no administrable Momoentos docente
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( '22', 34, 1, 1, 32 )

-- Adición del CLEI Dominical
INSERT INTO dbo.Maestros ( Descripcion, IdTipoMaestro, IdSede, Estado, Consecutivo ) VALUES ( 'CLEI Dominical', 6, 1, 1, 33 )