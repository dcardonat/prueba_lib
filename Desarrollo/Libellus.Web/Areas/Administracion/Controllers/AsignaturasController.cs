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
    using Libellus.Web.Areas.Administracion.Models.Asignaturas;
    using Libellus.Web.Controllers;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración del maestro Asignaturas.
    /// </summary>
    public class AsignaturasController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public AsignaturasController()
        {
            this.NegocioAsignaturas = new NegocioAsignaturas(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructor

        #region Acciones

        /// <summary>
        /// Lista los registros existentes para el maestro de asignaturas.
        /// </summary>
        /// <returns>Redirecciona a la vista de consultar.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<AsignaturaViewModel> asignaturas = null;
            try
            {
                asignaturas = (from c in this.NegocioAsignaturas.ConsultarAsignaturasPorSede()
                               select new AsignaturaViewModel()
                               {
                                   Descripcion = c.Descripcion,
                                   Estado = c.Estado,
                                   Id = c.Id,
                                   Maestro = new Maestro()
                                   {
                                       Descripcion = c.Maestro.Descripcion
                                   }
                               }).OrderByDescending(e => e.Estado).ThenBy(e => e.Descripcion).ToPagedList(pagina ?? 1, 10);

                if (asignaturas.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(asignaturas);
        }

        /// <summary>
        /// Muestra el formulario para el ingreso de datos de una asignatura.
        /// </summary>
        /// <returns>Redirecciona a la vista Crear</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            AsignaturaViewModel asignatura = null;
            try
            {
                var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(o => o.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

                asignatura = new AsignaturaViewModel()
                {
                    Areas = areas
                };
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(asignatura);
        }

        /// <summary>
        /// Recibe la informacion enviada por el formulario Crear para almacenar la informacion.
        /// </summary>
        /// <param name="asignatura">Objeto con la informacion diligenciada.</param>
        /// <returns>Redirecciona a la vista Consultar.</returns>
        [HttpPost]
        public ActionResult Crear(Asignatura asignatura)
        {
            bool error = false;
            try
            {
                this.NegocioAsignaturas.AlmacenarAsignatura(asignatura);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                AsignaturaViewModel asignaturaViewModel = ObtenerViewModel(asignatura);
                return View(asignaturaViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Edita la informacion de la asignatura.
        /// </summary>
        /// <param name="id">Identificador de la asignatura.</param>
        /// <returns>Retorna a la vista que contiene el formulario para edicion del registro.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AsignaturaViewModel asignaturaViewModel = null;
            try
            {
                var asignatura = this.NegocioAsignaturas.ConsultarAsignatura(id);
                if (asignatura == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(o => o.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);

                    asignaturaViewModel = new AsignaturaViewModel()
                    {
                        Id = asignatura.Id,
                        Descripcion = asignatura.Descripcion,
                        Estado = asignatura.Estado,
                        IdMaestro = asignatura.IdMaestro,
                        Areas = areas
                    };
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(asignaturaViewModel);
        }

        /// <summary>
        /// Recibe la informacion enviada por el formulario para actualizar los datos.
        /// </summary>
        /// <param name="asignatura">Objeto con la informacion requerida.</param>
        /// <returns>Redirecciona a la vista Consultar.</returns>
        [HttpPost]
        public ActionResult Editar(Asignatura asignatura)
        {
            bool error = false;
            try
            {
                this.NegocioAsignaturas.ActualizarAsignatura(asignatura);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                AsignaturaViewModel asignaturaViewModel = ObtenerViewModel(asignatura);
                return View(asignaturaViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Exportar la información de las salidas ocupacionales a Excel.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_Asignaturas.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> asignaturas = (from p in this.NegocioAsignaturas.ConsultarAsignaturasPorSede()
                                                   select new
                                                   {
                                                       Area = p.Maestro.Descripcion.ToString(),
                                                       Asignatura = p.Descripcion,
                                                       Estado = p.Estado ? "Activo" : "Inactivo",
                                                   }).OrderByDescending(o => o.Estado).ThenBy(o => o.Asignatura);

                byteArray = ExportarExcel.Exportar(asignaturas.ToList(), "Asignaturas");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Obtiene el viewmodel a partir de la entidad principal.
        /// </summary>
        /// <param name="asignatura">Entidad principal.</param>
        /// <returns>Retorna el ViewModel referente.</returns>
        private AsignaturaViewModel ObtenerViewModel(Asignatura asignatura)
        {
            AsignaturaViewModel asignaturaViewModel = null;

            var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(o => o.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            asignaturaViewModel = new AsignaturaViewModel()
            {
                Descripcion = asignatura.Descripcion,
                Estado = asignatura.Estado,
                Id = asignatura.Id,
                IdMaestro = asignatura.IdMaestro,
                Areas = areas
            };

            return asignaturaViewModel;
        }

        #endregion Acciones
    }
}