namespace Libellus.Negocio.GestionAcademica.Clases
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define las reglas de negocio para grupos.
    /// </summary>
    public class NegocioGrupos : NegocioBase, INegocioGrupos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioGrupos.
        /// </summary>
        public NegocioGrupos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consuta un grupo por id.
        /// </summary>
        /// <param name="id">Id del grupo.</param>
        /// <returns>El grupo consultado.</returns>
        public Grupo Consultar(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGrupo.GetById(id);
        }

        /// <summary>
        /// obtiene el listado de grupos. 
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<Grupo> ConsultarGrupos(int idAnioLectivo, int idNivel)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGrupo.ConsultarGrupos(idAnioLectivo, idNivel);
        }

        /// <summary>
        /// Asocia los estudiantes matriculados al grupo.
        /// </summary>
        /// <param name="grupos">Listado de grupos.</param>
        /// <param name="idGrado">Identificador del grado.</param>        
        /// <param name="cantidadEstudiantes">Identificador del grado.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        public Mensaje AsociarEstudiantesAGrupos(IList<Grupo> grupos, int idGrado, int cantidadEstudiantes)
        {
            Mensaje mensaje = null;
            Grupo grupo = null;

            IList<int> idsEstudiantesAsignadosGrado = this.ConsultarEstudiantesAsignadosGrado(idGrado, grupos.FirstOrDefault().IdAnioLectivo).Select(ea => ea.Id).ToList();

            IList<EstudianteDatosPersonales> estudiantesMatriculados = this.ConsultarEstudiantesMatriculados(idGrado, grupos.FirstOrDefault().IdAnioLectivo)
                .Where(em => (idsEstudiantesAsignadosGrado.Count == 0 || !idsEstudiantesAsignadosGrado.Contains(em.Id))).ToList();

            foreach (var estudiante in estudiantesMatriculados)
            {
                grupo = grupos.Where(g => g.EstudiantesPorGrupo.Count == grupos.Select(gr => gr.EstudiantesPorGrupo.Count).Min() && g.EstudiantesPorGrupo.Count < cantidadEstudiantes).FirstOrDefault();

                if (grupo != null)
                {
                    grupo.EstudiantesPorGrupo.Add(new EstudiantePorGrupo
                    {
                        IdEstudiante = estudiante.Id,
                        IdGrupo = grupo.Id
                    });
                }

                this.GuardarGrupos(grupo);
            }

            mensaje = new Mensaje(CodigoMensaje.Mensaje001);
            return mensaje;
        }

        /// <summary>
        /// Almacena la información del grupo.
        /// </summary>
        /// <param name="grupo">Grupo.</param>
        /// <returns></returns>
        public Mensaje GuardarGrupos(Grupo grupo)
        {
            Mensaje mensaje = null;

            try
            {
                if (grupo.Id > 0)
                {
                    this.UnidadDeTrabajoLibellus.RepositorioGrupo.Update(grupo);
                    mensaje = new Mensaje(CodigoMensaje.Mensaje002);
                }
                else
                {
                    this.UnidadDeTrabajoLibellus.RepositorioGrupo.Insert(grupo);
                    mensaje = new Mensaje(CodigoMensaje.Mensaje001);
                }

                this.UnidadDeTrabajoLibellus.SaveChanges();
            }
            catch (Exception excepcion)
            {
                mensaje = UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);

                if (mensaje == null)
                {
                    throw excepcion;
                }
            }

            return mensaje;
        }

        /// <summary>
        /// Consulta el id del grupo por grado.
        /// </summary>
        /// <param name="idGrupo">grupo seleccionado.</param>
        /// <param name="idGrado">Grado seleccionado.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public int ConsultarGrupoPorGrado(int idGrupo, int idGrado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGrupo.ConsultarGrupoPorGrado(idGrupo, idGrado);
        }

        /// <summary>
        /// Consula los estudiantes matriculados.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador de año.</param>
        private IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesMatriculados(int idGrado, int idAnioLectivo)
        {
            Maestro maestro = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado, ContextoLibellus.ObtenerSedeActual);
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiantesMatriculados(idGrado, ContextoLibellus.ObtenerSedeActual, idAnioLectivo, maestro.Id);
        }

        /// <summary>
        /// Consula los estudiantes matriculados.
        /// </summary>
        /// <param name="idAnioLectivo">Identificador de año.</param>
        /// <param name="idGrupoGrado">Identificador del grupo por grado.</param>
        /// <returns>Retorna la consulta.</returns>
        private IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesAsignadosGrado(int idGrado, int idAnioLectivo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiantesAsignadosGrupo(idAnioLectivo, idGrado);
        }

        #endregion
    }
}
