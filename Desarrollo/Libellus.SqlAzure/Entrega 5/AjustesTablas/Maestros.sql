update Maestros
Set Consecutivo = 42
where Descripcion = 'Estudiante' AND IdTipoMaestro = 16

update GradosPorNivel
set idNivel = 29
where idNivel in (30, 2082)

update ParametrizacionInstitucional
set idNivelEducativo = 29
where idNivelEducativo in (select id from Maestros where  idTipoMaestro = 6 and Consecutivo in (8, 33))

delete from ProyeccionCuposPorNiveles
where IdNivel in (select id from Maestros where  idTipoMaestro = 6 and Consecutivo in (8, 33))

select * from SoportePorRoles

update SoportePorRoles
set idNivelEducativo = 29
where idNivelEducativo in (select id from Maestros where  idTipoMaestro = 6 and Consecutivo in (8, 33))

delete from Maestros where idTipoMaestro = 6 and Consecutivo = 8
delete from Maestros where idTipoMaestro = 6 and Consecutivo = 33

update Maestros
set Descripcion = 'CLEI'
where idTipoMaestro = 6 and Consecutivo = 7