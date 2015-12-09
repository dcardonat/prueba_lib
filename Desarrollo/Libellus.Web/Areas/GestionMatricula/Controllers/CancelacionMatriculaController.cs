namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Matriculas;
    using Libellus.Negocio.Matriculas.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionMatricula.Models.Matriculas;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using Libellus.Mensajes;
    using Libellus.Web.Helpers;
    using Libellus.Web.Areas.GestionMatricula.Models.CancelacionMatricula;

    /// <summary>
    /// Gestiona las acciones de la cancelación de matricula.
    /// </summary>
    public class CancelacionMatriculaController : GestionMatriculaBaseController
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
        public CancelacionMatriculaController()
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
        public ActionResult Consultar(int? pagina, int? IdAnioLectivo, int? IdTipoDocumento, string DocumentoIdentidad, bool consultar = false)
        {
            ConsultaCancelacionMatriculaViewModel consultarMatriculaViewModel = new ConsultaCancelacionMatriculaViewModel();
            consultarMatriculaViewModel.TiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
            consultarMatriculaViewModel.Matriculas = new PagedList<ResultadoConsultaCancelacionMatriculaViewModel>(null, 1, 10);
            ViewBag.AnioLectivo = IdAnioLectivo;

            try
            {
                if (consultar)
                {
                    consultarMatriculaViewModel.Matriculas = (from m in this.NegocioMatriculas.Consultar(IdAnioLectivo, IdTipoDocumento, DocumentoIdentidad)
                                                              select new ResultadoConsultaCancelacionMatriculaViewModel
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
            string nombreArchivo = "Libellus_Cancelacion_Matriculas.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> aspectosEvaluativos = (from m in this.NegocioMatriculas.Consultar(null, null, null)
                                                           select new
                                                           {
                                                               Año = m.Cupo.AnioLectivo.Anio,
                                                               Tipo_Documento = m.Cupo.Estudiante.Usuario.TipoIdentificacion.Descripcion,
                                                               Documento_Identidad = m.Cupo.Estudiante.Usuario.Identificacion,
                                                               Estudiante = (m.Cupo.Estudiante.Nombre + " " + m.Cupo.Estudiante.PrimerApellido),
                                                               Nivel_Educativo = m.Cupo.GradoPorNivel.Nivel.Descripcion,
                                                               Grado = m.Cupo.GradoPorNivel.Grado.Descripcion,
                                                               Salida_Ocupacional = m.Cupo.SalidaOcupacional != null ? m.Cupo.SalidaOcupacional.Descripcion : string.Empty,
                                                               Estado = m.Estado != null ? m.Estado.Descripcion : string.Empty,
                                                           });

                byteArray = ExportarExcel.Exportar(aspectosEvaluativos.ToList(), "Cancelación matrículas");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Metodo get para la cancelación de la matricula.
        /// </summary>
        /// <param name="id">Identificador de la matricula.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpGet]
        public ActionResult CancelarMatricula(int id)
        {
            CancelacionMatriculaViewModel cancelacionMatriculaViewModel = new CancelacionMatriculaViewModel();
            Matricula matricula = this.NegocioMatriculas.ConsultarMatriculaPorId(id);
            cancelacionMatriculaViewModel.MotivosRetiro = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.MotivosRetiroEstudiante, ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
            cancelacionMatriculaViewModel.SalidaOcupacional = matricula.Cupo.SalidaOcupacional == null ? string.Empty : matricula.Cupo.SalidaOcupacional.Descripcion;
            cancelacionMatriculaViewModel.IdMatricula = id;
            return View(cancelacionMatriculaViewModel);
        }

        /// <summary>
        /// Acción pots  para almacenar la cancelación de la matricula.
        /// </summary>
        /// <param name="id">Identificador de la matricula.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpPost]
        public ActionResult CancelarMatricula(CancelacionMatriculaViewModel cancelarMatriculaViewModel)
        {
            Matricula matricula = this.NegocioMatriculas.ConsultarMatriculaPorId(cancelarMatriculaViewModel.IdMatricula);
            matricula.CancelacionMatricula.Add(new CancelacionMatriculas
            {
                IdMatricula = cancelarMatriculaViewModel.IdMatricula,
                IdMotivoRetiro = string.IsNullOrEmpty(cancelarMatriculaViewModel.SalidaOcupacional) == true && cancelarMatriculaViewModel.IdMotivo > 0 ? cancelarMatriculaViewModel.IdMotivo : cancelarMatriculaViewModel.IdMotivoSalidaOcupacional,
                Observacion = cancelarMatriculaViewModel.Observacion
            });

            if (this.NegocioMatriculas.CancelarMatriculaSalidaOcupacional(matricula))
            {
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                return RedirectToAction("Consultar");
            }
            else
            {
                return RedirectToAction("CancelarMatricula", cancelarMatriculaViewModel.IdMatricula);
            }
        }

        #endregion
    }
}