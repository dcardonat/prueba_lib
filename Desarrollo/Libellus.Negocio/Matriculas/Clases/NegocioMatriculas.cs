namespace Libellus.Negocio.Matriculas.Clases
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Matriculas.Interfaces;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Se encarga de las reglas de negocio para las matriculas.
    /// </summary>
    public class NegocioMatriculas : NegocioBase, INegocioMatriculas
    {
        /// <summary>
        /// Inicualiza una nueva instancia de la clase.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo con la que se trabaja.</param>
        public NegocioMatriculas(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        /// <summary>
        /// Obtiene el listado de documentos de la matricula del estudiante.
        /// </summary>
        /// <param name="idMatricula"><identificador del matricula.</param>
        /// <returns>Retorna el resultado de la consulta. </returns>
        public IEnumerable<MatriculasDocumentos> ConsultarDocumentosMatriculaEstudiante(int idMatricula)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.ConsultarDocumentosMatriculaEstudiante(idMatricula);
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public int CantidadEstudiantesMatriculadosGrado(int idGrado, int idAnioLectivo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.CantidadEstudiantesMatriculadosGrado(idGrado, ContextoLibellus.ObtenerSedeActual, idAnioLectivo);
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public Dictionary<int, int> CantidadEstudiantesMatriculadosGradoSalidaOcupacional(int idGrado, int idAnioLectivo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.CantidadEstudiantesMatriculadosGradoSalidaOcupacional(idGrado, ContextoLibellus.ObtenerSedeActual, idAnioLectivo);
        }

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado.
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        public Dictionary<int, int> CantidadEstudiantesMatriculadosGradoProfundizacion(int idGrado, int idAnioLectivo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.CantidadEstudiantesMatriculadosGradoProfundizacion(idGrado, ContextoLibellus.ObtenerSedeActual, idAnioLectivo);
        }

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="estado">Estado cupo.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        public IEnumerable<Matricula> Consultar(int? anio, int? estado, int? tipoDocumento, string documento)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.Consultar(anio, estado, tipoDocumento, documento, ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Realiza la consulta de matriculas.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento estudiante.</param>
        /// <returns>retorna la consulta.</returns>
        public IEnumerable<Matricula> Consultar(int? anio, int? tipoDocumento, string documento)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.Consultar(anio, tipoDocumento, documento, ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta la información de la matricula.
        /// </summary>
        /// <param name="id">Identificador de la maatricula.</param>
        /// <returns>Retorna la consulta.</returns>
        public Matricula ConsultarMatriculaPorId(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.GetById(id);
        }

        /// <summary>
        /// Registrar matricula.
        /// </summary>
        /// <param name="documentos">Documentos para el registro.</param>
        /// <param name="matriculado">Identifica si el estudiante queda matriculado.</param>
        public Mensaje RegistrarMatricula(List<MatriculasDocumentos> documentos, bool matriculado)
        {
            Matricula matricula = this.ConsultarMatriculaPorId((int)documentos.First().IdMatricula);

            foreach (var documento in documentos)
            {
                if(documento.Id == 0 && documento.Recibido == true)
                {
                    matricula.MatriculasDocumentos.Add(documento);
                }
                else if(documento.Id > 0 && documento.Recibido == false)
                {
                    matricula.MatriculasDocumentos.Add(documento);
                }
            }

            return this.ActualizarEstadoMatricula(matricula, matriculado);
        }

        /// <summary>
        /// Obtiene los estudiantes matriculados por nivel.
        /// </summary>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <param name="idAnioLectivo">Identificador del anio lectivo.</param>
        /// <returns>Retorna el listado.</returns>
        public IEnumerable<Matricula> MatriculadosPorNivelAnioLectivo(int idNivel, int idAnioLectivo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMatriculas.MatriculadosPorNivelAnioLectivo(idNivel, Utilidades.ContextoLibellus.ObtenerSedeActual, idAnioLectivo);
        }

        /// <summary>
        /// Calcela la matricula.
        /// </summary>
        /// <param name="matricula">Parametros para la cancelación de la matricula.</param>
        /// <returns>Retorna el resultado.</returns>
        public bool CancelarMatriculaSalidaOcupacional(Matricula matricula)
        {
            Maestro estadoPendienteDocumentacion = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudianteInactivo, ContextoLibellus.ObtenerSedeActual);
            matricula.IdEstado = estadoPendienteDocumentacion.Id;
            this.UnidadDeTrabajoLibellus.RepositorioMatriculas.Update(matricula);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Actualizar el estado de la matricula.
        /// </summary>
        /// <param name="idMatricula">Identificador de la matricula.</param>
        /// <param name="matriculado">Identifica si esta matriculado.</param>
        /// <returns>Retorna el resultado.</returns>
        private Mensaje ActualizarEstadoMatricula(Matricula matricula, bool matriculado)
        {
            Mensaje mensaje = new Mensaje(CodigoMensaje.Mensaje001);

            if (!matriculado)
            {
                Maestro estadoPendienteDocumentacion = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudiantePendienteDocumentación, ContextoLibellus.ObtenerSedeActual);
                matricula.IdEstado = estadoPendienteDocumentacion.Id;
            }
            else
            {
                Maestro estadoMatriculado = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudianteMatriculado, ContextoLibellus.ObtenerSedeActual);
                matricula.IdEstado = estadoMatriculado.Id;
                mensaje = new Mensaje(CodigoMensaje.Mensaje1019);
            }

            this.UnidadDeTrabajoLibellus.RepositorioMatriculas.Update(matricula);
            this.UnidadDeTrabajoLibellus.SaveChanges();
            
            return mensaje;
        }
    }
}
