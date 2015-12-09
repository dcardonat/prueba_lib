namespace Libellus.Repositorio.Matriculas.Interfaces
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para las Matricula.
    /// </summary>
    public interface IRepositorioMatriculas : IRepositorioBase<Matricula>
    {
        /// <summary>
        /// Obtiene el listado de documentos de la matricula del estudiante.
        /// </summary>
        /// <param name="idMatricula"><identificador del matricula.</param>
        /// <returns>Retorna el resultado de la consulta. </returns>
        IEnumerable<MatriculasDocumentos> ConsultarDocumentosMatriculaEstudiante(int idMatricula);

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="estado">Estado matricula.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        IEnumerable<Matricula> Consultar(int? anio, int? estado, int? tipoDocumento, string documento, int sede);

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        IEnumerable<Matricula> Consultar(int? anio, int? tipoDocumento, string documento, int sede);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        int CantidadEstudiantesMatriculadosGrado(int idGrado, int idSede, int idAnioLectivo);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        Dictionary<int, int> CantidadEstudiantesMatriculadosGradoSalidaOcupacional(int idGrado, int idSede, int idAnioLectivo);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        Dictionary<int, int> CantidadEstudiantesMatriculadosGradoProfundizacion(int idGrado, int idSede, int idAnioLectivo);

        /// <summary>
        /// Obtiene los estudiantes matriculados por nivel.
        /// </summary>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del anio lectivo.</param>
        /// <returns>Retorna el listado.</returns>
        IEnumerable<Matricula> MatriculadosPorNivelAnioLectivo(int idNivel, int idSede, int idAnioLectivo);
    }
}
