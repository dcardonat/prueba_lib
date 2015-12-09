namespace Libellus.Negocio.Matriculas
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;

    /// <summary>
    /// Se encarga de las reglas de negocio para los estudiantes.
    /// </summary>
    public class NegocioEstudiantes : NegocioBase, INegocioEstudiantes
    {
        /// <summary>
        /// Inicualiza una nueva instancia de la clase.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo con la que se trabaja.</param>
        public NegocioEstudiantes(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        /// <summary>
        /// Actualiza los datos de un estudiante.
        /// </summary>
        /// <param name="estudiante">Entidad estudiante con los datos.</param>
        public void ActualizarEstudiante(EstudianteDatosPersonales estudiante)
        {
            estudiante.Usuario.Clave = Utilidades.EncripcionLibellus.Cifrar(estudiante.Usuario.Clave);
            this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ActualizarEstudiante(estudiante);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta un estudiante por su identificador.
        /// </summary>
        /// <param name="id">Identificador del estudiante.</param>
        /// <returns>Información del estudiante.</returns>
        public EstudianteDatosPersonales ConsultarEstudiante(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.GetById(id);
        }

        /// <summary>
        /// Realiza la consulta de un estudiante.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento de identificacion.</param>
        /// <returns>Datos del estudiante.</returns>
        public EstudianteDatosPersonales ConsultarEstudiante(int tipoDocumento, string documento)
        {
            EstudianteDatosPersonales estudiante = this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiante(tipoDocumento, documento);
            return estudiante;
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
        /// <returns>Estudiantes seleccionados.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantes(int? anio, int? tipoDocumento, string documento, int? estadoMatricula, int? grado, string grupo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiantes(anio, tipoDocumento, documento, estadoMatricula, grado, grupo);
        }

        /// <summary>
        /// COnsulta los estudiantes matriculados.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificaodr del año.</param>
        /// <returns>Retorna la lista.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesMatriculados(int idGrado, int idAnioLectivo)
        {
            Maestro maestro = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado, ContextoLibellus.ObtenerSedeActual);
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiantesMatriculados(idGrado, ContextoLibellus.ObtenerSedeActual, idAnioLectivo, maestro.Id);
        }

        /// <summary>
        /// Consulta estudiantes por grupo.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <returns>Retorna el listado de la consulta.</returns>
        public IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesPorGrupo(int idGrupo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarEstudiantesPorGrupo(idGrupo);
        }

        /// <summary>
        /// Consulta un familiar de estudiante.
        /// </summary>
        /// <param name="identificacion">Documento de identidad del familiar.</param>
        /// <returns>Información del familiar.</returns>
        public FamiliarEstudiante ConsultarFamiliarEstudiante(string identificacion)
        {
            if (!string.IsNullOrEmpty(identificacion))
            {
                return this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ConsultarFamiliarEstudiante(identificacion);
            }
            else
            {
                return null;
            }
        }
    }
}