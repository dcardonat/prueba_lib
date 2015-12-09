namespace Libellus.Negocio.Matriculas
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interfaz que define la firma para las reglas de negocio de los estudiantes.
    /// </summary>
    public interface INegocioEstudiantes : IDisposable
    {
        /// <summary>
        /// Realiza la consulta de un estudiante.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento de identificacion.</param>
        /// <returns>Datos del estudiante.</returns>
        EstudianteDatosPersonales ConsultarEstudiante(int tipoDocumento, string documento);

        /// <summary>
        /// Consulta un estudiante por su identificador.
        /// </summary>
        /// <param name="id">Identificador del estudiante.</param>
        /// <returns>Información del estudiante.</returns>
        EstudianteDatosPersonales ConsultarEstudiante(int id);

        /// <summary>
        /// Actualiza los datos de un estudiante.
        /// </summary>
        /// <param name="estudiante">Entidad estudiante con los datos.</param>
        void ActualizarEstudiante(EstudianteDatosPersonales estudiante);

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
        /// COnsulta los estudiantes matriculados.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificaodr del año.</param>
        /// <returns>Retorna la lista.</returns>
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesMatriculados(int idGrado, int idAnioLectivo);

        /// <summary>
        /// Consulta estudiantes por grupo.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <returns>Retorna el listado de la consulta.</returns>
        IEnumerable<EstudianteDatosPersonales> ConsultarEstudiantesPorGrupo(int idGrupo);

        /// <summary>
        /// Consulta un familiar de estudiante.
        /// </summary>
        /// <param name="identificacion">Documento de identidad del familiar.</param>
        /// <returns>Información del familiar.</returns>
        FamiliarEstudiante ConsultarFamiliarEstudiante(string identificacion);
    }
}