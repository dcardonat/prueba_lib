namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.DocumentacionSoporteRoles;
    using Libellus.Web.Helpers;
    using PagedList;

    public class DocumentacionSoporteRolesController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public DocumentacionSoporteRolesController()
        {
            this.NegocioDocumentacionSoporteRoles = new NegocioDocumentacionSoporteRoles(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructor

        #region Metodos

        /// <summary>
        /// Consulta la informacion disponible para los filtros ingresados.
        /// </summary>
        /// <param name="pagina">Paginacion de los registros.</param>
        /// <returns>Redirecciona a la vista para enumerar los datos.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina, int? IdAnioLectivo, int? RolInstitucional, int? NivelEducativo)
        {
            IEnumerable<SoporteRolViewModel> soportes = null;

            try
            {
                var roles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.RolesInstitucionales, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);

                var niveles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);

                ViewBag.Roles = roles;
                ViewBag.Niveles = niveles;
                ViewBag.AnioLectivo = IdAnioLectivo;

                var query = this.NegocioDocumentacionSoporteRoles.ConsultarDocumentacionSoportePorSede();
                soportes = query
                    .Where(e => IdAnioLectivo == null || e.IdAnioLectivo == IdAnioLectivo)
                    .Where(e => RolInstitucional == null || e.IdRolInstitucional == RolInstitucional)
                    .Where(e => NivelEducativo == null || e.IdNivelEducativo == NivelEducativo)
                    .Select(c => new SoporteRolViewModel()
                            {
                                Id = c.Id,
                                Estado = c.Estado,
                        IdAnioLectivo = c.IdAnioLectivo,
                        AnioLectivo = c.AnioLectivo,
                                IdNivelEducativo = c.IdNivelEducativo,
                                NivelEducativo = c.IdNivelEducativo.HasValue ? new Maestro(c.NivelEducativo.Descripcion) : new Maestro(string.Empty),
                                IdRolInstitucional = c.IdRolInstitucional,
                                RolInstitucional = new Maestro
                                {
                                    Descripcion = c.RolInstitucional.Descripcion
                                }
                    })
                    .OrderByDescending(e => e.AnioLectivo.Anio)
                    .ThenBy(e => e.RolInstitucional.Descripcion)
                    .ThenBy(e => e.NivelEducativo.Descripcion)
                    .ToPagedList(pagina ?? 1, 10);

                if (soportes.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(soportes);
        }

        /// <summary>
        /// Crea por rol la documentacion necesaria para soporte.
        /// </summary>
        /// <returns>Redirecciona a la vista para crear.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            SoporteRolViewModel soporteRol = null;
            try
            {
                soporteRol = this.EstablecerValoresModelo();
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            ViewBag.NuevoRegistro = true;
            return View(soporteRol);
        }

        /// <summary>
        /// Recibe la informacion y la ingresa en la base de datos.
        /// </summary>
        /// <param name="soporteRol">Entidad con los datos del formulario de creacion.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Crear(SoportePorRol soporteRol)
        {
            bool error = false;
            try
            {
                this.NegocioDocumentacionSoporteRoles.AlmacenarDocumentacionSoporte(soporteRol);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                SoporteRolViewModel viewModel = this.EstablecerValoresModelo(soporteRol);
                return View(viewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Presenta la informacion en pantalla para ser editada.
        /// </summary>
        /// <param name="id">Identificador del registro a editar.</param>
        /// <returns>Retorna a la vista para editar la información.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            SoporteRolViewModel soporteRol = null;

            try
            {
                var documentos = this.NegocioDocumentacionSoporteRoles.ConsultarDocumentacionSoporte(id);
                if (documentos == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    soporteRol = this.EstablecerValoresModelo(documentos);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            ViewBag.NuevoRegistro = false;
            return View(soporteRol);
        }

        /// <summary>
        /// Recolecta la informacion editada y la lleva al negocio para actualizarla.
        /// </summary>
        /// <returns>Redirecciona a la vista de consulta.</returns>
        [HttpPost]
        public ActionResult Editar(SoportePorRol soporteRol)
        {
            bool error = false;
            try
            {
                this.NegocioDocumentacionSoporteRoles.ActualizarDocumentacionSoporte(soporteRol);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                error = true;
                this.CapturarExcepcion(excepcion);
            }

            if (error)
            {
                SoporteRolViewModel viewModel = this.EstablecerValoresModelo(soporteRol);
                return View(viewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Exportar la información de la funcionalidad.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_Documentacion_soporte_roles.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> documentos = (from p in this.NegocioDocumentacionSoporteRoles.ConsultarDocumentacionSoportePorSede()
                                                  select new
                                                  {
                                                      Año = p.AnioLectivo.Anio,
                                                      Rol_Institucional = p.RolInstitucional.Descripcion,
                                                      Nivel_Educativo = p.NivelEducativo == null ? string.Empty : p.NivelEducativo.Descripcion
                                                  }).OrderByDescending(o => o.Año).ThenBy(o => o.Rol_Institucional).ThenBy(o => o.Nivel_Educativo);

                byteArray = ExportarExcel.Exportar(documentos.ToList(), "DocumentosSoporteRoles");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Establece los campos al modelo.
        /// </summary>
        /// <param name="soporte">Entidad con los datos para el modelo.</param>
        /// <returns>Retorna una instancia de SoporteRolViewModel.</returns>
        private SoporteRolViewModel EstablecerValoresModelo(SoportePorRol soporte = null)
        {
            SoporteRolViewModel viewModel = null;

            var roles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.RolesInstitucionales, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var niveles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var tiposDocumento = (from c in this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposDocumentosSoporteRoles, ContextoLibellus.ObtenerSedeActual, true)
                                  select new SelectListItem()
                                  {
                                      Text = c.Descripcion,
                                      Value = c.Id.ToString()
                                  }).OrderBy(e => e.Text);

            viewModel = new SoporteRolViewModel()
            {
                Roles = roles,
                Niveles = niveles,
                Documentos = tiposDocumento.ToList(),
            };

            if (soporte != null)
            {
                viewModel.IdAnioLectivo = soporte.IdAnioLectivo;
                viewModel.IdNivelEducativo = soporte.IdNivelEducativo;
                viewModel.IdRolInstitucional = soporte.IdRolInstitucional;
                viewModel.Id = soporte.Id;
                viewModel.Estado = soporte.Estado;
                viewModel.TiposDocumentosSeleccionados = soporte.Documentos.Select(d => d.IdTipoDocumentoSoporte);
            }

            return viewModel;
        }

        /// <summary>
        /// Elimina un registro de documentacion para soporte por rol.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                this.NegocioDocumentacionSoporteRoles.EliminarDocumentacionSoporteRol(id);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje004));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        #endregion Metodos
    }
}