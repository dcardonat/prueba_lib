namespace Libellus.Negocio.Matriculas.Interfaces
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interfaz que define la firma para las reglas de negocio de las matriculas.
    /// </summary>
    public interface INegocioMatriculas : IDisposable
    {
        /// <summary>
        /// Obtiene el listado de documentos de la matricula del estudiante.
        /// </summary>
        /// <param name="idMatricula"><identificador del matricula.</param>
        /// <returns>Retorna el resultado de la consulta. </returns>
        IEnumerable<MatriculasDocumentos> ConsultarDocumentosMatriculaEstudiante(int idMatricula);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        int CantidadEstudiantesMatriculadosGrado(int idGrado, int idAnioLectivo);

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="estado">Estado matricula.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        IEnumerable<Matricula> Consultar(int? anio, int? estado, int? tipoDocumento, string documento);

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        IEnumerable<Matricula> Consultar(int? anio, int? tipoDocumento, string documento);

        /// <summary>
        /// Consulta la información de la matricula.
        /// </summary>
        /// <param name="id">Identificador de la maatricula.</param>
        /// <returns>Retorna la consulta.</returns>
        Matricula ConsultarMatriculaPorId(int id);

        /// <summary>
        /// Registrar matricula.
        /// </summary>
        /// <param name="documentos">Documentos para el registro.</param>
        /// <param name="matriculado">Identifica si el estudiante queda matriculado.</param>
        Mensaje RegistrarMatricula(List<MatriculasDocumentos> documentos, bool matriculado);

        /// <summary>
        /// Obtiene los estudiantes matriculados por nivel.
        /// </summary>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <param name="idAnioLectivo">Identificador del anio lectivo.</param>
        /// <returns>Retorna el listado.</returns>
        IEnumerable<Matricula> MatriculadosPorNivelAnioLectivo(int idNivel, int idAnioLectivo);

        /// <summary>
        /// Calcela la matricula.
        /// </summary>
        /// <param name="matricula">Parametros para la cancelación de la matricula.</param>
        /// <returns>Retorna el resultado.</returns>
        bool CancelarMatriculaSalidaOcupacional(Matricula matricula);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        Dictionary<int, int> CantidadEstudiantesMatriculadosGradoSalidaOcupacional(int idGrado, int idAnioLectivo);

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        Dictionary<int, int> CantidadEstudiantesMatriculadosGradoProfundizacion(int idGrado, int idAnioLectivo);
    }
}
