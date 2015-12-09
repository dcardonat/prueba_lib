namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.SalidasOcupacionales;
    using Libellus.Web.Controllers;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración del maestro SalidasOcupacionales.
    /// </summary>
    public class SalidasOcupacionalesController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo SalidasOcupacionalesController.
        /// </summary>
        public SalidasOcupacionalesController()
        {
            this.NegocioSalidasOcupacionales = new NegocioSalidasOcupacionales(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Lista los registros existentes para el maestro de salidas ocupacionales.
        /// </summary>
        /// <param name="pagina">Número de la página para mostrar los registros.</param>
        /// <returns>Redirecciona a la vista de consultar.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<SalidaOcupacionalViewModel> coleccionSalidasOcupacionales = null;

            try
            {
                //// TODO: JMG, Definir en dónde se almacenará el número de registros por página.
                coleccionSalidasOcupacionales = (from p in this.NegocioSalidasOcupacionales.ConsultarSalidasOcupacionalesPorSede()
                                                 select new SalidaOcupacionalViewModel
                                                 {
                                                     Id = p.Id,
                                                     IdSede = p.IdSede,
                                                     Descripcion = p.Descripcion,
                                                     IntensidadHoraria = p.IntensidadHoraria.ToString(),
                                                     Estado = p.Estado
                                                 }).OrderByDescending(o => o.Estado).ThenBy(o => o.Descripcion).ToPagedList(pagina ?? 1, 10);

                if (coleccionSalidasOcupacionales.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(coleccionSalidasOcupacionales);
        }

        /// <summary>
        /// Renderiza la vista de creación para una salida ocupacional.
        /// </summary>
        /// <returns>Vista para crear una salida ocupacional.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.NuevoRegistro = true;

            return View();
        }

        /// <summary>
        /// Almacena la información de una nueva salida ocupacional.
        /// </summary>
        /// <param name="salidaOcupacional">Información de la salida ocupacional.</param>
        /// <returns>Vista para consultar todas las salidas ocupacionales existentes.</returns>
        [HttpPost]
        public ActionResult Crear(SalidaOcupacional salidaOcupacional)
        {
            try
            {
                Mensaje mensajeCreacion = this.NegocioSalidasOcupacionales.AlmacenarSalidaOcupacional(salidaOcupacional);

                if (mensajeCreacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    this.MostrarMensaje(mensajeCreacion);

                    SalidaOcupacionalViewModel salidaOcupacionalViewModel = new SalidaOcupacionalViewModel();
                    salidaOcupacionalViewModel.Descripcion = salidaOcupacional.Descripcion;
                    salidaOcupacionalViewModel.IntensidadHoraria = salidaOcupacional.IntensidadHoraria.ToString();
                    ViewBag.NuevoRegistro = true;

                    return View(salidaOcupacionalViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Renderiza la vista de edición para una salida ocupacional.
        /// </summary>
        /// <param name="id">Identificador interno de la salida ocupacional a editar.</param>
        /// <returns>Vista para editar una salida ocupacional.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            SalidaOcupacionalViewModel salidaOcupacionalViewModel = new SalidaOcupacionalViewModel();
            ViewBag.NuevoRegistro = false;

            try
            {
                SalidaOcupacional salidaOcupacional = this.NegocioSalidasOcupacionales.ConsultarSalidaOcupacional(id);

                if (salidaOcupacional == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    salidaOcupacionalViewModel.Id = salidaOcupacional.Id;
                    salidaOcupacionalViewModel.IdSede = salidaOcupacional.IdSede;
                    salidaOcupacionalViewModel.Descripcion = salidaOcupacional.Descripcion;
                    salidaOcupacionalViewModel.IntensidadHoraria = salidaOcupacional.IntensidadHoraria.ToString();
                    salidaOcupacionalViewModel.Estado = salidaOcupacional.Estado;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(salidaOcupacionalViewModel);
        }

        /// <summary>
        /// Edita la información de una salida ocupacional.
        /// </summary>
        /// <param name="maestro">Información de la salida ocupacional a editar.</param>
        /// <returns>Vista para consultar todas las salidas ocupacionales existentes.</returns>
        [HttpPost]
        public ActionResult Editar(SalidaOcupacional salidaOcupacional)
        {
            try
            {
                Mensaje mensajeEdicion = this.NegocioSalidasOcupacionales.ActualizarSalidaOcupacional(salidaOcupacional);

                if (mensajeEdicion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                }
                else
                {
                    this.MostrarMensaje(mensajeEdicion);

                    SalidaOcupacionalViewModel salidaOcupacionalViewModel = new SalidaOcupacionalViewModel();
                    salidaOcupacionalViewModel.Descripcion = salidaOcupacional.Descripcion;
                    salidaOcupacionalViewModel.IntensidadHoraria = salidaOcupacional.IntensidadHoraria.ToString();
                    ViewBag.NuevoRegistro = false;

                    return View(salidaOcupacionalViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
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
            string nombreArchivo = "Libellus_SalidasOcupacionales.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> salidasOcupacionales = (from p in this.NegocioSalidasOcupacionales.ConsultarSalidasOcupacionalesPorSede()
                                                            select new
                                                            {
                                                                Descripcion = p.Descripcion,
                                                                IntensidadHoraria = p.IntensidadHoraria.ToString(),
                                                                Estado = p.Estado ? "Activo" : "Inactivo",
                                                            }).OrderByDescending(o => o.Estado).ThenBy(o => o.Descripcion);

                byteArray = ExportarExcel.Exportar(salidasOcupacionales.ToList(), "SalidasOcupacionales");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion Acciones
    }
}