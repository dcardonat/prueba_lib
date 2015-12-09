namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los Estudiantes.
    /// </summary>
    public interface IRepositorioEstudiante : IRepositorioBase<EstudianteDatosPersonales>
    {
        /// <summary>
        /// Actualiza la informacion del estudiante.
        /// </summary>
        /// <param name="estudiante">Información del estudiante.</param>
        void ActualizarEstudiante(EstudianteDatosPersonales estudiante);

        /// <summary>
        /// Consulta la informacion de un estudiante.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento de identidad.</param>
        /// <param name="documento">Documento de identidad.</param>
        /// <returns>Informacion del estudiante.</returns>
        EstudianteDatosPersonales ConsultarEstudiante(int tipoDocumento, string documento);

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
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantes(int? anio, int? tipoDocumento, string documento, int? estadoMatricula, int? grado, string grupo);

        /// <summary>
        /// Consulta los estudiantes matriculados.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo</param>
        /// <param name="estadoMatricula">Estado matriculado</param>
        /// <returns>Retorna la lista.</returns>
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesMatriculados(int idGrado, int idSede, int idAnioLectivo, int estadoMatricula);

        /// <summary>
        /// Consulta estudiantes por grupo.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <returns>Retorna el listado de la consulta.</returns>
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesPorGrupo(int idGrupo);

        /// <summary>
        /// Estudiantes asignado a un grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Año lectivo.</param>
        /// <param name="idGrado">Identificador  del grado.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesAsignadosGrupo(int idAnioLectivo, int idGrado);

        /// <summary>
        /// Consulta un familiar de estudiante.
        /// </summary>
        /// <param name="identificacion">Documento de identidad del familiar.</param>
        /// <returns>Información del familiar.</returns>
        FamiliarEstudiante ConsultarFamiliarEstudiante(string identificacion);
    }
}