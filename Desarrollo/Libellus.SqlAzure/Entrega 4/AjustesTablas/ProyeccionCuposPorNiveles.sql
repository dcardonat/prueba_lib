ALTER TABLE [dbo].[ProyeccionCuposPorNiveles]
add [IdAnioLectivo] int  NULL;

ALTER TABLE [dbo].[ProyeccionCuposPorNiveles]
DROP CONSTRAINT UQ_ProyeccionCuposPorNiveles;

UPDATE ProyeccionCuposPorNiveles
SET ProyeccionCuposPorNiveles.IdAnioLectivo = AnioLectivo.Id
FROM ProyeccionCuposPorNiveles
INNER JOIN AnioLectivo ON ProyeccionCuposPorNiveles.Anio = AnioLectivo.Anio

ALTER TABLE [dbo].[ProyeccionCuposPorNiveles]
DROP COLUMN [Anio];

ALTER TABLE ProyeccionCuposPorNiveles ADD CONSTRAINT FK_ProyeccionCuposPorNiveles_AnioLectivo
FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)

ALTER TABLE [dbo].[ProyeccionCuposPorNiveles]
ADD CONSTRAINT UQ_ProyeccionCuposPorNiveles UNIQUE (IdAnioLectivo,IdNivel,IdSede);
