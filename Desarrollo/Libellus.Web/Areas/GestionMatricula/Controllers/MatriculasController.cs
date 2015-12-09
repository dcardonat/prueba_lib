namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Matriculas;
    using Libellus.Negocio.Matriculas.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionMatricula.Models.Matriculas;
    using Libellus.Web.Helpers;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;

    /// <summary>
    /// Gestiona las acciones de las matriculas.
    /// </summary>
    public class MatriculasController : GestionMatriculaBaseController
    {
        #region Propiedades

        /// <summary>
        /// Identificador de la sede actual.
        /// </summary>
        private int SedeActual = Utilidades.ContextoLibellus.ObtenerSedeActual;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MatriculasController()
        {
            this.NegocioCupos = new NegocioCupos(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioEstudiantes = new NegocioEstudiantes(this.UnidadDeTrabajoLibellus);
            this.NegocioDocumentacionSoporteRoles = new NegocioDocumentacionSoporteRoles(this.UnidadDeTrabajoLibellus);
            this.NegocioMatriculas = new NegocioMatriculas(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Realiza la cosulta de matriculas. 
        /// </summary>
        /// <param name="pagina">Paginación.</param>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="estado">Estado del cupo.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documentoIdentidad">Documento de identidad.</param>
        /// <returns>Retorns el resultado de la consulta.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina, int? IdAnioLectivo, int? IdEstado, int? IdTipoDocumento, string DocumentoIdentidad, bool consultar = false)
        {
            ConsultarMatriculaViewModel consultarMatriculaViewModel = new ConsultarMatriculaViewModel();
            consultarMatriculaViewModel.TiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
            consultarMatriculaViewModel.Estados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstadosMatricula, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
            consultarMatriculaViewModel.Matriculas = new PagedList<ResultadoConsultaMatriculaViewModel>(null, 1, 10);

            ViewBag.AnioLectivo = IdAnioLectivo;
            ViewBag.IdEstado = IdEstado;
            ViewBag.IdTipoDocumento = IdTipoDocumento;
            ViewBag.DocumentoIdentidad = DocumentoIdentidad;

            try
            {
                if (consultar)
                {
                    consultarMatriculaViewModel.Matriculas = (from m in this.NegocioMatriculas.Consultar(IdAnioLectivo, IdEstado, IdTipoDocumento, DocumentoIdentidad)
                                                              select new ResultadoConsultaMatriculaViewModel
                                                          {
                                                              Id = m.Id,
                                                              IdAnio = m.Cupo.IdAnioLectivo,
                                                              Anio = m.Cupo.AnioLectivo.Anio,
                                                              AnioCerrado = m.Cupo.AnioLectivo.Cerrado,
                                                              TipoDocumento = m.Cupo.Estudiante.Usuario.TipoIdentificacion.Descripcion,
                                                              IdTipoDocumento = m.Cupo.Estudiante.Usuario.IdTipoIdentificacion,
                                                              DocumentoIdentidad = m.Cupo.Estudiante.Usuario.Identificacion,
                                                              Nombres = (m.Cupo.Estudiante.Nombre + " " + m.Cupo.Estudiante.PrimerApellido),
                                                              NivelEducativo = m.Cupo.GradoPorNivel.Nivel.Descripcion,
                                                              Grado = m.Cupo.GradoPorNivel.Grado.Descripcion,
                                                              SalidaOcupacional = m.Cupo.SalidaOcupacional != null ? m.Cupo.SalidaOcupacional.Descripcion : string.Empty,
                                                              Estado = m.Estado != null ? m.Estado.Descripcion : string.Empty,
                                                              Consecutivo = m.Estado != null ? (int)m.Estado.Consecutivo : 0,
                                                              IdEstadoMatricula = m.IdEstado,
                                                          }).OrderBy(m => m.Anio).ToPagedList(pagina ?? 1, 10);

                    ViewBag.Consultar = consultar;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(consultarMatriculaViewModel);
        }

        /// <summary>
        /// Exportar la información de la matricula a Excel.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_Matriculas.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> aspectosEvaluativos = (from m in this.NegocioMatriculas.Consultar(null, null, null, null)
                                                           select new
                                                           {
                                                               Año = m.Cupo.AnioLectivo.Anio,
                                                               Tipo_Documento = m.Cupo.Estudiante.Usuario.TipoIdentificacion.Descripcion,
                                                               Documento_Identidad = m.Cupo.Estudiante.Usuario.Identificacion,
                                                               Estudiante = (m.Cupo.Estudiante.Nombre + " " + m.Cupo.Estudiante.PrimerApellido),
                                                               Nivel_Educativo = m.Cupo.GradoPorNivel.Nivel.Descripcion,
                                                               Grado_al_que_Aspira = m.Cupo.GradoPorNivel.Grado.Descripcion,
                                                               Salida_Ocupacional = m.Cupo.SalidaOcupacional != null ? m.Cupo.SalidaOcupacional.Descripcion : string.Empty,
                                                               Estado = m.Estado != null ? m.Estado.Descripcion : string.Empty,
                                                           });

                byteArray = ExportarExcel.Exportar(aspectosEvaluativos.ToList(), "Matrículas");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Metodo get para el registro de matricula.
        /// </summary>
        /// <param name="Id">Identificador del cupo.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        [HttpGet]
        public ActionResult Registrar(int id)
        {
            RegistroMatriculaViewModel registroMatricula = new RegistroMatriculaViewModel();

            try
            {
                Matricula matricula = this.NegocioMatriculas.ConsultarMatriculaPorId(id);

                if (matricula != null)
                {
                    registroMatricula = new RegistroMatriculaViewModel()
                    {
                        IdEstudiante = matricula.Cupo.Estudiante.Id,
                        Anio = matricula.Cupo.AnioLectivo.Anio,
                        CantidadActualMatriculadosGrado = this.CantidadActualMatriculadosGrado(matricula.Cupo.GradoPorNivel.Grado.Id, matricula.Cupo.AnioLectivo.Id),
                        DocumentoIdentidad = matricula.Cupo.Estudiante.Usuario.Identificacion,
                        Documentos = this.ObtenerDocumentosSoporteMatricula(id, matricula.Cupo.AnioLectivo.Id, matricula.Cupo.GradoPorNivel.Nivel.Id),
                        EstadoMatricula = matricula.Estado != null ? matricula.Estado.Descripcion : string.Empty,
                        Estudiante = matricula.Cupo.Estudiante.Nombre + " " + matricula.Cupo.Estudiante.PrimerApellido,
                        GradoAspira = matricula.Cupo.GradoPorNivel.Grado.Descripcion,
                        NivelEducativo = matricula.Cupo.GradoPorNivel.Nivel.Descripcion,
                        TipoDocumento = matricula.Cupo.Estudiante.Usuario.TipoIdentificacion.Descripcion,
                        Traslado = matricula.Cupo.TrasladoEstudiante == true ? "Si" : "No"
                    };

                    if(registroMatricula.Documentos != null && registroMatricula.Documentos.Count == 0)
                    {
                        this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje031));
                        return RedirectToAction("Consultar");
                    }
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(registroMatricula);
        }

        /// <summary>
        /// Metodo get para el registro de matricula.
        /// </summary>
        /// <param name="Id">Identificador del cupo.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        [HttpPost]
        public JsonResult Registrar(IList<DocumentosMatriculaViewModels> documentos)
        {
            try
            {
                bool matriculado = false;
                List<MatriculasDocumentos> listaDocumentos = new List<MatriculasDocumentos>();
                MatriculasDocumentos documento = null;

                if (documentos.Count == documentos.Where(x => x.Recibido == true).Count())
                {
                    matriculado = true;
                }

                foreach (var item in documentos)
                {
                    documento = new MatriculasDocumentos()
                    {
                        Id = item.Id.HasValue ? (int)item.Id : 0,
                        IdMatricula = (int)item.IdMatricula,
                        IdDocumento = item.IdDocumento,
                        Recibido = item.Recibido
                    };

                    listaDocumentos.Add(documento);
                }

                this.MostrarMensaje(this.NegocioMatriculas.RegistrarMatricula(listaDocumentos, matriculado));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return Json(Url.Action("Consultar"));
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Obtiene la cantidad de estudiantes matriculados para el grado. 
        /// </summary>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna la cantidad de estudiantes matriculados para el grado.</returns>
        private string CantidadActualMatriculadosGrado(int idGrado, int idAnioLectivo)
        {
            return this.NegocioMatriculas.CantidadEstudiantesMatriculadosGrado(idGrado, idAnioLectivo).ToString();
        }

        /// <summary>
        /// Obtiene el listado de documentos para el soporte de la matricula del estudiante.
        /// </summary>
        /// <param name="idCupo">Identificador del cupo.</param>
        /// <param name="anio">Año seleccionado.</param>
        /// <param name="idMatricula">Identificador de la matricula.</param>
        /// <returns>Retorna el listado de la consulta.</returns>
        private List<DocumentosMatriculaViewModels> ObtenerDocumentosSoporteMatricula(int idMatricula, int anio, int idNivel)
        {
            List<DocumentosMatriculaViewModels> documentos = new List<DocumentosMatriculaViewModels>();

            Maestro rolInstitucional = NegocioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.RolInstitucionalEstudiante, Utilidades.ContextoLibellus.ObtenerSedeActual);
            IEnumerable<SoportePorRolesDocumento> listaDocumentos = this.NegocioDocumentacionSoporteRoles.ConsultarDocumentacionSoporteRol(rolInstitucional.Id, anio, idNivel);
            IEnumerable<MatriculasDocumentos> documentosSoporteMatricula = this.NegocioMatriculas.ConsultarDocumentosMatriculaEstudiante(idMatricula);

            if (listaDocumentos != null)
            {
                documentos = listaDocumentos.GroupJoin(documentosSoporteMatricula,
                       p => p.Id,
                       c => c.IdDocumento,
                       (p, g) => g
                           .Select(c => new DocumentosMatriculaViewModels()
                           {
                               Id = c.Id,
                               Documento = p.TipoDocumentoSoporte.Descripcion,
                               IdDocumento = p.Id,
                               IdMatricula = idMatricula,
                               Recibido = true
                           }).DefaultIfEmpty(new DocumentosMatriculaViewModels
                           {
                               Id = null,
                               Documento = p.TipoDocumentoSoporte.Descripcion,
                               IdDocumento = p.Id,
                               IdMatricula = idMatricula,
                               Recibido = false
                           })
                       ).SelectMany(g => g).ToList();
            }

            return documentos;
        }

        #endregion
    }
}