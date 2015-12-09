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
    using Libellus.Web.Areas.Administracion.Models.Maestros;
    using Libellus.Web.Controllers;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los maestros.
    /// </summary>
    public class MaestrosController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo MaestrosController.
        /// </summary>
        public MaestrosController()
        {
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Renderiza la vista de consulta de administración de los maestros.
        /// </summary>
        /// <returns>Vista para consultar maestros administrables.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina, short? idTipoMaestro, string nombreTipoMaestro)
        {
            MaestroViewModel maestroViewModel = new MaestroViewModel();

            try
            {
                if (idTipoMaestro.HasValue)
                {
                    maestroViewModel.IdTipoMaestro = idTipoMaestro.Value;
                    maestroViewModel.NombreTipoMaestro = nombreTipoMaestro;
                    //// TODO: JMG, Definir en dónde se almacenará el número de registros por página.
                    maestroViewModel.Maestros = this.NegocioMaestros.ConsultarMaestrosPorTipo((TiposMaestros)idTipoMaestro.Value, Utilidades.ContextoLibellus.ObtenerSedeActual).OrderByDescending(o => o.Estado).ThenBy(o => o.Descripcion).ToPagedList(pagina.Value, 10);
                }
                else
                {
                    maestroViewModel.Maestros = new List<Maestro>().ToPagedList(1, 10);
                }

                maestroViewModel.TiposMaestro = this.NegocioMaestros.ConsultarTipoMaestros().OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(maestroViewModel);
        }

        /// <summary>
        /// Renderiza la vista de creación para un maestro administrable.
        /// </summary>
        /// <param name="idTipoMaestro">Identificador interno del tipo de maestro seleccionado.</param>
        /// <param name="nombreMaestro">Valor del maestro a almacenar.</param>
        /// <returns>Vista para crear un maestro administrable.</returns>
        [HttpGet]
        public ActionResult Crear(short idTipoMaestro, string nombreMaestro)
        {
            MaestroViewModel maestroViewModel = new MaestroViewModel();
            maestroViewModel.NombreTipoMaestro = nombreMaestro;
            maestroViewModel.IdTipoMaestro = idTipoMaestro;

            ViewBag.NuevoRegistro = true;

            return View(maestroViewModel);
        }

        /// <summary>
        /// Almacena la información de un nuevo maestro administrable.
        /// </summary>
        /// <param name="maestro">Información del maestro a crear.</param>
        /// <param name="nombreMaestro">Nombre del tipo de maestro que se está tratando.</param>
        /// <returns>Vista para consultar maestros administrables.</returns>
        [HttpPost]
        public ActionResult Crear(Maestro maestro, string nombreMaestro)
        {
            try
            {
                Mensaje mensajeCreacion = this.NegocioMaestros.AlmacenarMaestro(maestro);

                if (mensajeCreacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    this.MostrarMensaje(mensajeCreacion);

                    MaestroViewModel maestroViewModel = new MaestroViewModel();
                    maestroViewModel.NombreTipoMaestro = nombreMaestro;
                    maestroViewModel.IdTipoMaestro = maestro.IdTipoMaestro;
                    ViewBag.NuevoRegistro = true;

                    return View(maestroViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar", new { pagina = 1, idTipoMaestro = maestro.IdTipoMaestro, nombreTipoMaestro = nombreMaestro });
        }

        /// <summary>
        /// Renderiza la vista de edición para un maestro administrable.
        /// </summary>
        /// <param name="idTipoMaestro">Identificador interno del tipo de maestro seleccionado.</param>
        /// <param name="idMaestro">Identificador interno del maestro a editar.</param>
        /// <param name="nombreMaestro">Nombre del tipo de maestro que se está tratando.</param>
        /// <returns>Vista para crear un maestro administrable.</returns>
        [HttpGet]
        public ActionResult Editar(short idTipoMaestro, int idMaestro, string nombreMaestro)
        {
            MaestroViewModel maestroViewModel = new MaestroViewModel();

            try
            {
                maestroViewModel.Id = idMaestro;
                maestroViewModel.NombreTipoMaestro = nombreMaestro;
                maestroViewModel.IdTipoMaestro = idTipoMaestro;

                Maestro maestro = this.NegocioMaestros.ConsultarMaestroPorId(idMaestro);
                maestroViewModel.IdSede = maestro.IdSede;
                maestroViewModel.Descripcion = maestro.Descripcion;
                maestroViewModel.Estado = maestro.Estado;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            ViewBag.NuevoRegistro = false;

            return View(maestroViewModel);
        }

        /// <summary>
        /// Edita la información de un maestro administrable.
        /// </summary>
        /// <param name="maestro">Información del maestro a editar.</param>
        /// <param name="nombreMaestro">Nombre del tipo de maestro que se está tratando.</param>
        /// <returns>Vista para consultar maestros administrables.</returns>
        [HttpPost]
        public ActionResult Editar(Maestro maestro, string nombreMaestro)
        {
            try
            {
                Mensaje mensajeEdicion = this.NegocioMaestros.EditarMaestro(maestro);

                if (mensajeEdicion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                }
                else
                {
                    this.MostrarMensaje(mensajeEdicion);

                    MaestroViewModel maestroViewModel = new MaestroViewModel();
                    maestroViewModel.NombreTipoMaestro = nombreMaestro;
                    maestroViewModel.IdTipoMaestro = maestro.IdTipoMaestro;
                    ViewBag.NuevoRegistro = false;

                    return View(maestroViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar", new { pagina = 1, idTipoMaestro = maestro.IdTipoMaestro, nombreTipoMaestro = nombreMaestro });
        }

        /// <summary>
        /// Exportar la información de un maestro a Excel.
        /// </summary>
        /// <param name="idTipoMaestro">Identificador interno del maestro a exportar su información a Excel.</param>
        /// <param name="nombreMaestro">Nombre del maestro a exportar.</param>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionMaestro(int idTipoMaestro, string nombreMaestro, string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = String.Format("Libellus_{0}.xlsx", nombreMaestro);
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> listaMaestros = from p in this.NegocioMaestros.ConsultarMaestrosPorTipo((TiposMaestros)idTipoMaestro, Utilidades.ContextoLibellus.ObtenerSedeActual)
                                                    select new
                                                    {
                                                        Nombre = p.Descripcion,
                                                        Estado = UtilidadesApp.ObtenerNombreEstadoRegistro(p.Estado),
                                                        TipoMaestro = p.TipoMaestro.Descripcion
                                                    };


                byteArray = ExportarExcel.Exportar(listaMaestros.ToList(), nombreMaestro);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion

        #region Métodos asíncronos

        /// <summary>
        /// Consulta la información de un maestos específico.
        /// </summary>
        /// <param name="pagina">Página a mostrar.</param>
        /// <param name="idTipoMaestro">Identificador interno del tipo de maestro a visualizar los datos.</param>
        /// <param name="nombreTipoMaestro">Nombre del tipo de maestro seleccionado.</param>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Vista con la información de los maestros asociada.</returns>
        [HttpGet]
        public ActionResult ConsultarInformacionMaestros(int? pagina, short? idTipoMaestro, string nombreTipoMaestro, string token)
        {
            MaestroViewModel maestroViewModel = new MaestroViewModel();

            try
            {
                maestroViewModel.IdTipoMaestro = idTipoMaestro.Value;
                maestroViewModel.NombreTipoMaestro = nombreTipoMaestro;
                maestroViewModel.Token = token;
                maestroViewModel.Maestros = this.NegocioMaestros.ConsultarMaestrosPorTipo((TiposMaestros)idTipoMaestro.Value, Utilidades.ContextoLibellus.ObtenerSedeActual).OrderByDescending(o => o.Estado).ThenBy(o => o.Descripcion).ToPagedList(pagina.Value, 10);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return PartialView("_InformacionMaestros", maestroViewModel);
        }

        #endregion
    }
}