namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Persistencia de los datos para EstudianteDatosPersonales.
    /// </summary>
    public class RepositorioEstudiante : RepositorioBase<EstudianteDatosPersonales>, IRepositorioEstudiante
    {
        public RepositorioEstudiante(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        /// <summary>
        /// Actualiza la informacion del estudiante.
        /// </summary>
        /// <param name="estudiante">Información del estudiante.</param>
        public void ActualizarEstudiante(EstudianteDatosPersonales estudiante)
        {
            var estudianteBD = this.ContextoLibellus.EstudiantesDatosPersonales.Find(estudiante.Id);

            estudianteBD.Nombre = estudiante.Nombre ?? estudianteBD.Nombre;
            estudianteBD.PrimerApellido = estudiante.PrimerApellido ?? estudianteBD.PrimerApellido;
            estudianteBD.SegundoApellido = estudiante.SegundoApellido ?? estudianteBD.SegundoApellido;
            estudianteBD.IdSexo = estudiante.IdSexo > 0 ? estudiante.IdSexo : estudianteBD.IdSexo;
            estudianteBD.FechaNacimiento = estudiante.FechaNacimiento != DateTime.MinValue ? estudiante.FechaNacimiento : estudianteBD.FechaNacimiento;
            estudianteBD.FechaActualizacion = DateTime.Now;
            estudianteBD.IdEntidadPromotoraSalud = estudiante.IdEntidadPromotoraSalud ?? estudianteBD.IdEntidadPromotoraSalud;
            estudianteBD.IdGrupoSanguineo = estudiante.IdGrupoSanguineo ?? estudianteBD.IdGrupoSanguineo;
            estudianteBD.IdMunicipioNacimiento = estudiante.IdMunicipioNacimiento ?? estudianteBD.IdMunicipioNacimiento;

            if (estudiante.Archivos != null)
            {
                if (estudianteBD.Archivos == null)
                {
                    this.ContextoLibellus.EstudiantesArchivos.Add(estudiante.Archivos);
                    estudianteBD.Archivos = estudiante.Archivos;
                }
                else
                {
                    estudianteBD.Archivos.Foto = estudiante.Archivos.Foto;
                }
            }

            if (estudiante.DatosResidenciales != null)
            {
                estudianteBD.DatosResidenciales.Barrio = estudiante.DatosResidenciales.Barrio ?? estudianteBD.DatosResidenciales.Barrio;
                estudianteBD.DatosResidenciales.Direccion = estudiante.DatosResidenciales.Direccion ?? estudianteBD.DatosResidenciales.Direccion;
                estudianteBD.DatosResidenciales.IdEstrato = estudiante.DatosResidenciales.IdEstrato ?? estudianteBD.DatosResidenciales.IdEstrato;
                estudianteBD.DatosResidenciales.IdMunicipio = estudiante.DatosResidenciales.IdMunicipio ?? estudianteBD.DatosResidenciales.IdMunicipio;
                estudianteBD.DatosResidenciales.TelefonoFijo = estudiante.DatosResidenciales.TelefonoFijo ?? estudianteBD.DatosResidenciales.TelefonoFijo;
                estudianteBD.DatosResidenciales.TelefonoMovil = estudiante.DatosResidenciales.TelefonoMovil ?? estudianteBD.DatosResidenciales.TelefonoMovil;
            }

            if (estudiante.Usuario != null)
            {
                estudianteBD.Usuario.Correo = estudiante.Usuario.Correo ?? estudianteBD.Usuario.Correo;
                estudianteBD.Usuario.Clave = estudiante.Usuario.Clave ?? estudianteBD.Usuario.Clave;
                estudianteBD.Usuario.IdTipoIdentificacion = estudiante.Usuario.IdTipoIdentificacion > 0 ? estudiante.Usuario.IdTipoIdentificacion : estudianteBD.Usuario.IdTipoIdentificacion;
                estudianteBD.Usuario.Identificacion = estudiante.Usuario.Identificacion ?? estudianteBD.Usuario.Identificacion;
            }

            if (estudiante.DatosFamiliares != null && estudiante.DatosFamiliares.Id > 0)
            {
                if (estudiante.DatosFamiliares.TieneMadre)
                {
                    if (!estudiante.DatosFamiliares.IdMadre.HasValue)
                    {
                        this.ContextoLibellus.FamiliaresEstudiantes.Add(estudiante.DatosFamiliares.Madre);
                        estudianteBD.DatosFamiliares.Madre = estudiante.DatosFamiliares.Madre;
                    }
                    else
                    {
                        estudiante.DatosFamiliares.Madre.Id = estudiante.DatosFamiliares.IdMadre.Value;
                        var madreDB = this.ContextoLibellus.FamiliaresEstudiantes.Find(estudiante.DatosFamiliares.IdMadre);
                        this.ContextoLibellus.Entry(madreDB).CurrentValues.SetValues(estudiante.DatosFamiliares.Madre);
                        estudianteBD.DatosFamiliares.Madre = madreDB;
                    }
                }
                else
                {
                    estudianteBD.DatosFamiliares.IdMadre = null;
                    estudianteBD.DatosFamiliares.Madre = null;
                }
                
                if (estudiante.DatosFamiliares.TienePadre)
                {
                    if (!estudiante.DatosFamiliares.IdPadre.HasValue)
                    {
                        this.ContextoLibellus.FamiliaresEstudiantes.Add(estudiante.DatosFamiliares.Padre);
                        estudianteBD.DatosFamiliares.Padre = estudiante.DatosFamiliares.Padre;
                    }
                    else
                    {
                        estudiante.DatosFamiliares.Padre.Id = estudiante.DatosFamiliares.IdPadre.Value;
                        var padreDB = this.ContextoLibellus.FamiliaresEstudiantes.Find(estudiante.DatosFamiliares.IdPadre);
                        this.ContextoLibellus.Entry(padreDB).CurrentValues.SetValues(estudiante.DatosFamiliares.Padre);
                        estudianteBD.DatosFamiliares.Padre = padreDB;
                    }
                }
                else
                {
                    estudianteBD.DatosFamiliares.IdPadre = null;
                    estudianteBD.DatosFamiliares.Padre = null;
                }

                if (estudiante.DatosFamiliares.IdAcudiente == 0)
                {
                    this.ContextoLibellus.FamiliaresEstudiantes.Add(estudiante.DatosFamiliares.Acudiente);
                    estudianteBD.DatosFamiliares.Acudiente = estudiante.DatosFamiliares.Acudiente;
                }
                else
                {
                    estudiante.DatosFamiliares.Acudiente.Id = estudiante.DatosFamiliares.IdAcudiente;
                    var acudienteDB = this.ContextoLibellus.FamiliaresEstudiantes.Find(estudiante.DatosFamiliares.IdAcudiente);
                    this.ContextoLibellus.Entry(acudienteDB).CurrentValues.SetValues(estudiante.DatosFamiliares.Acudiente);
                    estudianteBD.DatosFamiliares.Acudiente = acudienteDB;
                }
                
            }
            else
            {
                if (estudianteBD.DatosFamiliares == null)
                {
                    estudianteBD.DatosFamiliares = new EstudianteDatosFamiliares();
                    estudianteBD.DatosFamiliares.Id = estudianteBD.Id;
                }

                if (estudiante.DatosFamiliares != null && estudiante.DatosFamiliares.TienePadre)
                {
                    estudianteBD.DatosFamiliares.Padre = new FamiliarEstudiante();
                    if (estudiante.DatosFamiliares.IdPadre > 0)
                    {
                        estudiante.DatosFamiliares.Padre.Id = estudiante.DatosFamiliares.IdPadre.Value;
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Padre).CurrentValues.SetValues(estudiante.DatosFamiliares.Padre);
                        this.ContextoLibellus.FamiliaresEstudiantes.Attach(estudianteBD.DatosFamiliares.Padre);
                    }
                    else
                    {
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Padre).CurrentValues.SetValues(estudiante.DatosFamiliares.Padre);
                    }
                }

                if (estudiante.DatosFamiliares != null && estudiante.DatosFamiliares.TieneMadre)
                {
                    estudianteBD.DatosFamiliares.Madre = new FamiliarEstudiante();
                    if (estudiante.DatosFamiliares.IdMadre > 0)
                    {
                        estudiante.DatosFamiliares.Madre.Id = estudiante.DatosFamiliares.IdMadre.Value;
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Madre).CurrentValues.SetValues(estudiante.DatosFamiliares.Madre);
                        this.ContextoLibellus.FamiliaresEstudiantes.Attach(estudianteBD.DatosFamiliares.Madre);
                    }
                    else
                    {
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Madre).CurrentValues.SetValues(estudiante.DatosFamiliares.Madre);
                    }
                }

                if (estudianteBD.DatosFamiliares.Acudiente == null)
                {
                    estudianteBD.DatosFamiliares.Acudiente = new FamiliarEstudiante();
                    if (estudiante.DatosFamiliares.IdAcudiente > 0)
                    {
                        estudiante.DatosFamiliares.Acudiente.Id = estudiante.DatosFamiliares.IdAcudiente;
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Acudiente).CurrentValues.SetValues(estudiante.DatosFamiliares.Acudiente);
                        this.ContextoLibellus.FamiliaresEstudiantes.Attach(estudianteBD.DatosFamiliares.Acudiente);
                    }
                    else
                    {
                        this.ContextoLibellus.Entry(estudianteBD.DatosFamiliares.Acudiente).CurrentValues.SetValues(estudiante.DatosFamiliares.Acudiente);
                    }
                    
                    this.ContextoLibellus.EstudiantesDatosFamiliares.Add(estudianteBD.DatosFamiliares);
                }
            }

            // Actualiza los antecedentes academicos.
            if (estudiante.ActualizarAntecedentes)
            {
                if (estudiante.AntecedentesAcademicos != null && estudiante.AntecedentesAcademicos.Any())
                {
                    foreach (var antecedente in estudiante.AntecedentesAcademicos)
                    {
                        if (antecedente.Id == 0)
                        {
                            antecedente.Estudiante = estudianteBD;
                            this.ContextoLibellus.EstudiantesAntecedentesAcademicos.Add(antecedente);
                        }
                        else
                        {
                            this.ContextoLibellus.EstudiantesAntecedentesAcademicos.Attach(antecedente);
                            antecedente.IdEstudiante = estudiante.Id;
                            this.ContextoLibellus.Entry(antecedente).State = System.Data.Entity.EntityState.Modified;
                        }
                    }

                    if (estudianteBD.AntecedentesAcademicos != null)
                    {
                        foreach (var antecedenteEliminar in estudianteBD.AntecedentesAcademicos.Where(x => !estudiante.AntecedentesAcademicos.Any(u => u.Id == x.Id)).ToList())
                        {
                            this.ContextoLibellus.EstudiantesAntecedentesAcademicos.Remove(antecedenteEliminar);
                        }
                    }
                }
                else
                {
                    estudianteBD.AntecedentesAcademicos = null;
                    var antecedentesEliminar = this.ContextoLibellus.EstudiantesAntecedentesAcademicos.Where(x => x.Estudiante.Id == estudiante.Id);
                    foreach (var antecedente in antecedentesEliminar)
                    {
                        this.ContextoLibellus.EstudiantesAntecedentesAcademicos.Remove(antecedente);
                    }
                }
            }

            this.ContextoLibellus.Entry(estudianteBD).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Consulta la informacion de un estudiante.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento de identidad.</param>
        /// <param name="documento">Documento de identidad.</param>
        /// <returns>Informacion del estudiante.</returns>
        public EstudianteDatosPersonales ConsultarEstudiante(int tipoDocumento, string documento)
        {
            return (from e in this.ContextoLibellus.EstudiantesDatosPersonales
                    where e.Usuario.IdTipoIdentificacion == tipoDocumento &&
                    e.Usuario.Identificacion == documento
                    select e).FirstOrDefault();
        }

        /// <summary>
        /// Consulta la informacion del estudiante filtrada por las opciones.
        /// </summary>
        /// <param name="anio">Año lectivo.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento de identidad.</param>
        /// <param name="estadoMatricula">Estado de la matricula del estudiante para el año.</param>
        /// <param name="grado">Grado del estudiante.</param>
        /// <param name="grupo">Grupo del estudiante.</param>
        /// <returns></returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantes(int? anio, int? tipoDocumento, string documento, int? estadoMatricula, int? grado, string grupo)
        {
            return from e in this.ContextoLibellus.Matriculas
                   where (anio == null || e.Cupo.IdAnioLectivo == anio)
                   && (tipoDocumento == null || e.Cupo.Estudiante.Usuario.IdTipoIdentificacion == tipoDocumento)
                   && (string.IsNullOrEmpty(documento) || e.Cupo.Estudiante.Usuario.Identificacion == documento)
                   && (estadoMatricula == null || e.IdEstado == estadoMatricula)
                   && (grado == null || e.Cupo.GradoPorNivel.IdGrado == grado)
                   && string.IsNullOrEmpty(grupo)
                   select e.Cupo.Estudiante;
        }

        /// <summary>
        /// Consulta los estudiantes matriculados.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo</param>
        /// <param name="estadoMatricula">Estado matriculado</param>
        /// <returns>Retorna la lista.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesMatriculados(int idGrado, int idSede, int idAnioLectivo, int estadoMatricula)
        {
            return from x in this.ContextoLibellus.Matriculas
                   where x.Cupo.GradoPorNivel.Grado.Id == idGrado
            && x.Cupo.IdSede == idSede
            && x.Cupo.IdAnioLectivo == idAnioLectivo
            && x.IdEstado == estadoMatricula
                   select x.Cupo.Estudiante;
        }

        /// <summary>
        /// Consulta estudiantes por grupo.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <returns>Retorna el listado de la consulta.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesPorGrupo(int idGrupo)
        {
            return ContextoLibellus.EstudiantesPorGrupo.Where(x => x.IdGrupo == idGrupo).Select(x => x.Estudiante);
        }

        /// <summary>
        /// Estudiantes asignado a un grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Año lectivo.</param>
        /// <param name="idGrado">Identificador  del  grado.<param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesAsignadosGrupo(int idAnioLectivo, int idGrado)
        {
            return this.ContextoLibellus.EstudiantesDatosPersonales.Where(e => e.EstudiantesPorGrupo.Any(x => x.Grupo.GruposPorGrado.Grado.Id == idGrado && x.Grupo.IdAnioLectivo == idAnioLectivo));
        }

        /// <summary>
        /// Consulta un familiar de estudiante.
        /// </summary>
        /// <param name="identificacion">Documento de identidad del familiar.</param>
        /// <returns>Información del familiar.</returns>
        public FamiliarEstudiante ConsultarFamiliarEstudiante(string identificacion)
        {
            return this.ContextoLibellus.FamiliaresEstudiantes.Where(e => e.Identificacion == identificacion).FirstOrDefault();
        }
    }
}