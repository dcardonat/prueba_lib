 
ALTER TABLE ProyeccionCuposPorNiveles
ADD CantidadGrupos int

ALTER TABLE ProyeccionCuposPorNiveles
ADD CantidadDocentes decimal(5,2) 

update  ProyeccionCuposPorNiveles
set EstudiantesEsperados = 0
where EstudiantesEsperados is null

update  ProyeccionCuposPorNiveles
set EstudiantesEsperados = 0,
 EstudiantesGrupo = 0
where EstudiantesGrupo is null and EstudiantesEsperados is null

update  ProyeccionCuposPorNiveles
set CantidadGrupos = 0,
 CantidadDocentes = 0

ALTER TABLE ProyeccionCuposPorNiveles
ALTER COLUMN  EstudiantesGrupo int NOT NULL

ALTER TABLE ProyeccionCuposPorNiveles
ALTER COLUMN  EstudiantesEsperados int NOT NULL

ALTER TABLE ProyeccionCuposPorNiveles
ALTER COLUMN  CantidadGrupos int NOT NULL

ALTER TABLE ProyeccionCuposPorNiveles
ALTER COLUMN  CantidadDocentes decimal(5,2)  NOT NULL

