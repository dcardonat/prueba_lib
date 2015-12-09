namespace Libellus.Repositorio.Matriculas.Clases
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using Libellus.Repositorio.Matriculas.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Persistencia de los datos para Matriculas. 
    /// </summary>
    public class RepositorioMatriculas : RepositorioBase<Matricula>, IRepositorioMatriculas
    {
        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="contextoLibellus">Contexto para el repositorio.</param>
        public RepositorioMatriculas(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        /// <summary>
        /// Obtiene el listado de documentos de la matricula del estudiante.
        /// </summary>
        /// <param name="idMatricula"><identificador del cupo.</param>
        /// <returns>Retorna el resultado de la consulta. </returns>
        public IEnumerable<MatriculasDocumentos> ConsultarDocumentosMatriculaEstudiante(int idMatricula)
        {
            return this.ContextoLibellus.MatriculaDocumentosSoporte.Where(x => x.IdMatricula == idMatricula);
        }

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="estado">Estado matricula.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        public IEnumerable<Matricula> Consultar(int? anio, int? estado, int? tipoDocumento, string documento, int sede)
        {
            return this.ContextoLibellus.Matriculas.Where(x => (anio == null || anio == x.Cupo.IdAnioLectivo)
                && (estado == null || estado == x.IdEstado)
                && (tipoDocumento == null || x.Cupo.Estudiante.Usuario.IdTipoIdentificacion == tipoDocumento)
                && (string.IsNullOrEmpty(documento) || x.Cupo.Estudiante.Usuario.Identificacion == documento)
                && x.Cupo.IdSede == sede
                );
        }

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        public IEnumerable<Matricula> Consultar(int? anio, int? tipoDocumento, string documento, int sede)
        {
            return this.ContextoLibellus.Matriculas.Where(x => (anio == null || anio == x.Cupo.IdAnioLectivo)
                && (tipoDocumento == null || x.Cupo.Estudiante.Usuario.IdTipoIdentificacion == tipoDocumento)
                && (string.IsNullOrEmpty(documento) || x.Cupo.Estudiante.Usuario.Identificacion == documento)
                && (x.Estado.Consecutivo == (int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado)
                && x.Cupo.IdSede == sede
                );
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public int CantidadEstudiantesMatriculadosGrado(int idGrado, int idSede, int idAnioLectivo)
        {
            return this.ContextoLibellus.Matriculas.Where(x => x.Estado.Consecutivo == (int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado
                && x.Cupo.GradoPorNivel.IdGrado == idGrado && x.Cupo.IdSede == idSede && x.Cupo.IdAnioLectivo == idAnioLectivo).Count();
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public Dictionary<int, int> CantidadEstudiantesMatriculadosGradoSalidaOcupacional(int idGrado, int idSede, int idAnioLectivo)
        {
            return this.ContextoLibellus.Matriculas.Where(x => x.Estado.Consecutivo == (int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado
                && x.Cupo.GradoPorNivel.IdGrado == idGrado && x.Cupo.IdSede == idSede && x.Cupo.IdAnioLectivo == idAnioLectivo).GroupBy(m => m.Cupo.SalidaOcupacional.Id).Select(x => new { Key = x.Key, Count = x.Count() }).ToDictionary(x => x.Key, x => x.Count);
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public Dictionary<int, int> CantidadEstudiantesMatriculadosGradoProfundizacion(int idGrado, int idSede, int idAnioLectivo)
        {
            return this.ContextoLibellus.Matriculas.Where(x => x.Estado.Consecutivo == (int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado
                && x.Cupo.GradoPorNivel.IdGrado == idGrado && x.Cupo.IdSede == idSede && x.Cupo.IdAnioLectivo == idAnioLectivo).GroupBy(m => m.Cupo.Profundizacion.Id).Select(x => new { Key = x.Key, Count = x.Count() }).ToDictionary(x => x.Key, x => x.Count);
        }

        /// <summary>
        /// Obtiene los estudiantes matriculados por nivel.
        /// </summary>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="idAnioLectivo">Identificador del anio lectivo.</param>
        /// <returns>Retorna el listado.</returns>
        public IEnumerable<Matricula> MatriculadosPorNivelAnioLectivo(int idNivel, int idSede, int idAnioLectivo)
        {
            return this.ContextoLibellus.Matriculas.Where(x => x.Estado.Consecutivo == (int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado
                && x.Cupo.GradoPorNivel.IdNivel == idNivel && x.Cupo.IdSede == idSede && x.Cupo.IdAnioLectivo == idAnioLectivo);
        }
    }
}
