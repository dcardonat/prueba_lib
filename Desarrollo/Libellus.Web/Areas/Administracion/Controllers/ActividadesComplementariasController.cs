namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.ActividadesComplementarias;
    using Libellus.Web.Controllers;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración del maestro Actividades Complementarias.
    /// </summary>
    public class ActividadesComplementariasController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public ActividadesComplementariasController()
        {
            this.NegocioActividadesComplementarias = new NegocioActividadesComplementarias(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructor

        #region Acciones

        /// <summary>
        /// Lista las actividades complementarias.
        /// </summary>
        /// <returns>Redirige a la vista que lista las actividades complementarias.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<ActividadesComplementariasViewModel> actividades = null;
            try
            {
                actividades = (from c in this.NegocioActividadesComplementarias.ConsultarActividadesComplementariasPorSede()
                               select new ActividadesComplementariasViewModel
                               {
                                   Id = c.Id,
                                   Descripcion = c.Descripcion,
                                   IntensidadHoraria = c.IntensidadHoraria,
                                   Estado = c.Estado
                               }).OrderByDescending(i => i.Estado).ThenBy(i => i.Descripcion).ToPagedList(pagina ?? 1, 10);

                if (actividades.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(actividades);
        }

        /// <summary>
        /// Muestra el formulario para la inserccion de campos que permiten crear una actividad complementaria.
        /// </summary>
        /// <returns>Redirecciona a la vista que contiene el formulario.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        /// <summary>
        /// Ingresa un registro de actividades complementarias en la base de datos.
        /// </summary>
        /// <param name="actividad">Objeto con la informacion de actividades complementarias para ingresar.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Crear(ActividadComplementaria actividad)
        {
            bool error = false;
            try
            {
                this.NegocioActividadesComplementarias.AlmacenarActividadComplementaria(actividad);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                ActividadesComplementariasViewModel actividadVM = RetornarViewModel(actividad);
                return View(actividadVM);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Muestra el formulario de edicion de registros de actividades complementarias, cargando los datos de la actividad especificada.
        /// </summary>
        /// <param name="id">Identificador de la actividad.</param>
        /// <returns>Redirecciona a la vista.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ActividadesComplementariasViewModel actividadViewModel = null;
            try
            {
                var actividad = this.NegocioActividadesComplementarias.ConsultarActividadComplementaria(id);
                if (actividad == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    actividadViewModel = new ActividadesComplementariasViewModel()
                    {
                        Descripcion = actividad.Descripcion,
                        Estado = actividad.Estado,
                        Id = actividad.Id,
                        IntensidadHoraria = actividad.IntensidadHoraria
                    };
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(actividadViewModel);
        }

        /// <summary>
        /// Actualiza la actividad complementaria especificada en el formulario.
        /// </summary>
        /// <param name="actividadComplementaria">Actividad complementaria con los datos actualizados.</param>
        /// <returns>Redirecciona a la vista.</returns>
        [HttpPost]
        public ActionResult Editar(ActividadComplementaria actividadComplementaria)
        {
            bool error = true;
            try
            {
                this.NegocioActividadesComplementarias.ActualizarActividadComplementaria(actividadComplementaria);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                ActividadesComplementariasViewModel actividadesViewModel = this.RetornarViewModel(actividadComplementaria);
                return View(actividadesViewModel);
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
            string nombreArchivo = "Libellus_ActividadesComplementarias.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> actividades = (from p in this.NegocioActividadesComplementarias.ConsultarActividadesComplementariasPorSede()
                                                   select new
                                                   {
                                                       NombreActividad = p.Descripcion,
                                                       IntensidadHoraria = p.IntensidadHoraria.ToString(),
                                                       Estado = p.Estado ? "Activo" : "Inactivo",
                                                   }).OrderByDescending(o => o.Estado).ThenBy(o => o.NombreActividad);

                byteArray = ExportarExcel.Exportar(actividades.ToList(), "ActividadesComplementarias");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Retorna el viewModel de la actividad principal.
        /// </summary>
        /// <param name="actividad">Entidad principal.</param>
        /// <returns>Retorna el viewModel mapeado.</returns>
        private ActividadesComplementariasViewModel RetornarViewModel(ActividadComplementaria actividad)
        {
            ActividadesComplementariasViewModel actividadViewModel = null;
            actividadViewModel = new ActividadesComplementariasViewModel()
            {
                Descripcion = actividad.Descripcion,
                Estado = actividad.Estado,
                Id = actividad.Id,
                IntensidadHoraria = actividad.IntensidadHoraria
            };

            return actividadViewModel;
        }

        #endregion Acciones
    }
}