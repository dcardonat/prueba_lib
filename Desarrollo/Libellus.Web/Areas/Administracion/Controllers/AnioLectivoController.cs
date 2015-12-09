namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Web.Areas.Administracion.Models.AnioLectivo;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciana la interaccion para las operaciones con los años lectivos.
    /// </summary>
    public class AnioLectivoController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public AnioLectivoController()
        {
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructor

        /// <summary>
        /// Redirecciona a la vista consultar.
        /// </summary>
        /// <param name="pagina">Numero de la pagina para la segmentacion de datos.</param>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        public ActionResult Consultar(int pagina = 1)
        {
            IEnumerable<AnioLectivoViewModel> anios = null;

            try
            {
                anios = (from a in this.NegocioAnioLectivo.ConsultarAniosLectivos()
                         select new AnioLectivoViewModel
                         {
                             Id = a.Id,
                             Anio = a.Anio,
                             Cerrado = a.Cerrado,
                             FechaInicio = a.FechaInicio.ToShortDateString(),
                             FechaCierre = a.FechaCierre.HasValue ? a.FechaCierre.Value.ToShortDateString() : string.Empty
                         }).OrderByDescending(a => a.Anio).ToPagedList(pagina, 10);
                if (anios.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(anios);
        }

        /// <summary>
        /// Redirecciona a la vista para crear un registro.
        /// </summary>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.NuevoRegistro = true;
            return View();
        }

        /// <summary>
        /// Llama al negocio para crear un año lectivo.
        /// </summary>
        /// <param name="anioLectivo">Objeto con la informacion.</param>
        /// <returns>Redirecciona a la vista consulta.</returns>
        [HttpPost]
        public ActionResult Crear(AnioLectivo anioLectivo)
        {
            Mensaje mensajeRespuesta = null;
            try
            {
                mensajeRespuesta = this.NegocioAnioLectivo.AlmacenarAnioLectivo(anioLectivo);
                this.MostrarMensaje(mensajeRespuesta);
                if (mensajeRespuesta.Codigo != CodigoMensaje.Mensaje001)
                {
                    AnioLectivoViewModel viewModel = new AnioLectivoViewModel()
                    {
                        Id = anioLectivo.Id,
                        Anio = anioLectivo.Anio,
                        Cerrado = anioLectivo.Cerrado,
                        FechaCierre = anioLectivo.FechaCierre.HasValue ? anioLectivo.FechaCierre.Value.ToShortDateString() : string.Empty,
                        FechaInicio = anioLectivo.FechaInicio.ToShortDateString()
                    };

                    ViewBag.NuevoRegistro = true;
                    return View(viewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Redirecciona a la vista para editar un registro.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Retorna la vista editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AnioLectivoViewModel viewModel = null;
            ViewBag.NuevoRegistro = false;
            try
            {
                var anioLectivo = this.NegocioAnioLectivo.ConsultarAnioLectivo(id);
                if (anioLectivo != null)
                {
                    viewModel = new AnioLectivoViewModel()
                    {
                        Anio = anioLectivo.Anio,
                        Cerrado = anioLectivo.Cerrado,
                        FechaCierre = anioLectivo.FechaCierre.HasValue ? anioLectivo.FechaCierre.Value.ToShortDateString() : string.Empty,
                        FechaInicio = anioLectivo.FechaInicio.ToShortDateString(),
                        Id = anioLectivo.Id,
                        IdSede = anioLectivo.IdSede
                    };
                }
                else
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Actualiza un registro pasando el modelo recibido al negocio.
        /// </summary>
        /// <param name="anioLectivo">Onjeto de con la informacion a actualizar.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Editar(AnioLectivo anioLectivo)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                mensajeRespuesta = this.NegocioAnioLectivo.ActualizarAnioLectivo(anioLectivo);
                this.MostrarMensaje(mensajeRespuesta);
                if (mensajeRespuesta.Codigo != CodigoMensaje.Mensaje002)
                {
                    AnioLectivoViewModel viewModel = new AnioLectivoViewModel()
                    {
                        Anio = anioLectivo.Anio,
                        Cerrado = anioLectivo.Cerrado,
                        FechaCierre = anioLectivo.FechaCierre.HasValue ? anioLectivo.FechaCierre.Value.ToShortDateString() : string.Empty,
                        FechaInicio = anioLectivo.FechaInicio.ToShortDateString(),
                        Id = anioLectivo.Id,
                        IdSede = anioLectivo.IdSede
                    };

                    ViewBag.NuevoRegistro = false;
                    return View(viewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Elimina un registro de año lectivo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Mensaje mensajeRespuesta = null;
            try
            {
                mensajeRespuesta = this.NegocioAnioLectivo.EliminarAnioLectivo(id);
                this.MostrarMensaje(mensajeRespuesta);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return RedirectToAction("Consultar");
        }
    }
}