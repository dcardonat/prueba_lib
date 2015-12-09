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
    using Libellus.Web.Areas.Administracion.Models.IntensidadHoraria;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la intensidad horaria.
    /// </summary>
    public class IntensidadHorariaController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public IntensidadHorariaController()
        {
            this.NegocioIntensidadHoraria = new NegocioIntensidadHoraria(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAsignaturas = new NegocioAsignaturas(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Consulta los registros de intensidad horaria registrados en el sistema.
        /// </summary>
        /// <param name="IdAnioLectivo">Año escolar seleccionado para filtro.</param>
        /// <param name="Grado">Grado seleccionado para filtro.</param>
        /// <param name="Area">Area de la asignatura.</param>
        /// <param name="pagina">Pagina a visualizar.</param>
        /// <returns>Resultado de las intensidades horarias que cumplen con el filtro seleccionado.</returns>
        [HttpGet]
        public ActionResult Consultar(int? IdAnioLectivo, int? Grado, int? Area, int pagina = 1)
        {
            IEnumerable<IntensidadHorariaViewModel> intensidadHorariaViewModel = null;

            try
            {
                intensidadHorariaViewModel = (from e in this.NegocioIntensidadHoraria.ConsultarIntensidadesHorariasPorSede()
                                              where (IdAnioLectivo == null || e.IdAnioLectivo == IdAnioLectivo) &&
                                                    (Grado == null || e.IdGrado == Grado) &&
                                                    (Area == null || e.Asignatura.Maestro.Id == Area)
                                              select new IntensidadHorariaViewModel()
                                              {
                                                  Id = e.Id,
                                                  AnioLectivo = e.AnioLectivo,
                                                  IdGrado = e.IdGrado,
                                                  Grado = new Maestro(e.Grado.Descripcion),
                                                  Asignatura = new Asignatura()
                                                  {
                                                      Maestro = new Maestro(e.Asignatura.Maestro.Descripcion),
                                                      Descripcion = e.Asignatura.Descripcion
                                                  },
                                                  HorasSemana = e.HorasSemana,
                                              }).OrderByDescending(e => e.AnioLectivo.Anio).ThenBy(e => e.Grado.Descripcion).ToPagedList(pagina, 10);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ResultadoConsulta", intensidadHorariaViewModel);
                }
                else
                {
                    var grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, ContextoLibellus.ObtenerSedeActual, true)
                            .OrderBy(e => e.Descripcion)
                            .ToSelectListItem(e => e.Descripcion, e => e.Id);

                    var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true)
                        .OrderBy(e => e.Descripcion)
                        .ToSelectListItem(e => e.Descripcion, e => e.Id);

                    ViewBag.Grados = grados;
                    ViewBag.Areas = areas;
                    ViewBag.AnioLectivo = IdAnioLectivo;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(intensidadHorariaViewModel);
        }

        /// <summary>
        /// Redirecciona a la vista crear intensidad horaria.
        /// </summary>
        /// <returns>Vista de a acción.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            IntensidadHorariaViewModel intensidadHoraria = null;
            try
            {
                intensidadHoraria = this.EstablecerValoresModelo();
                ViewBag.MomentosTotales = 0;
                ViewBag.MomentosGradoArea = 0;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(intensidadHoraria);
        }

        /// <summary>
        /// Almacena la informacion diligenciada.
        /// </summary>
        /// <param name="intensidadHoraria">Objeto con la informacion.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Crear(IntensidadHoraria intensidadHoraria)
        {
            bool error = false;
            try
            {
                this.NegocioIntensidadHoraria.AlmacenarIntensidadHoraria(intensidadHoraria);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                IntensidadHorariaViewModel intensidadHorariaViewModel = this.EstablecerValoresModelo(intensidadHoraria);
                return View(intensidadHorariaViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Muestra la vista para editar la informacion de un registro.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Redirecciona a la vista editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            IntensidadHorariaViewModel intensidadHorariaViewModel = null;
            try
            {
                var intensidadHoraria = this.NegocioIntensidadHoraria.ConsularIntensidadHoraria(id);
                if (intensidadHoraria == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    intensidadHorariaViewModel = this.EstablecerValoresModelo(intensidadHoraria);
                    ViewBag.MomentosTotales = this.ObtenerMomentosTotales(intensidadHoraria.IdAnioLectivo, intensidadHoraria.IdGrado);
                    ViewBag.MomentosGradoArea = this.ObtenerMomentosGradoArea(intensidadHoraria.IdAnioLectivo, intensidadHoraria.IdGrado, intensidadHoraria.Asignatura.IdMaestro);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(intensidadHorariaViewModel);
        }

        /// <summary>
        /// Edita la informacion de un registro.
        /// </summary>
        /// <param name="intensidadHoraria">Informacion actualizada.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Editar(IntensidadHoraria intensidadHoraria)
        {
            bool error = false;
            try
            {
                this.NegocioIntensidadHoraria.ActualizarIntensidadHoraria(intensidadHoraria);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                IntensidadHorariaViewModel intensidadHorariaViewModel = this.EstablecerValoresModelo(intensidadHoraria);
                ViewBag.MomentosTotales = this.ObtenerMomentosTotales(intensidadHoraria.IdAnioLectivo, intensidadHoraria.IdGrado);
                ViewBag.MomentosGradoArea = this.ObtenerMomentosGradoArea(intensidadHoraria.IdAnioLectivo, intensidadHoraria.IdGrado, intensidadHoraria.Asignatura.IdMaestro);
                return View(intensidadHorariaViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Elimina un registro de intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                this.NegocioIntensidadHoraria.EliminarIntensidadHoraria(id);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje004));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
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
            string nombreArchivo = "Libellus_intensidad_horaria.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> documentos = this.NegocioIntensidadHoraria.ConsultarIntensidadesHorariasPorSede()
                    .OrderByDescending(e => e.AnioLectivo.Anio)
                    .ThenBy(e => e.Grado.Descripcion)
                    .ThenBy(e => e.Asignatura.Maestro.Descripcion)
                    .ThenBy(e => e.Asignatura.Descripcion)
                    .Select(c => new
                    {
                        Año = c.AnioLectivo.Anio,
                        Grado = c.Grado.Descripcion,
                        Área = c.Asignatura.Maestro.Descripcion,
                        Asignatura = c.Asignatura.Descripcion,
                        Intensidad_horario = c.HorasSemana
                    });

                byteArray = ExportarExcel.Exportar(documentos.ToList(), "IntensidadHoraria");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion Acciones

        #region MetodosPublicos

        /// <summary>
        /// Obtiene las asignaturas pertenecientes a un area especifica.
        /// </summary>
        /// <param name="IdArea">Area seleccionada.</param>
        /// <returns>Asignaturas del area.</returns>
        public JsonResult ObtenerAsignaturas(string IdArea)
        {
            int idArea = Convert.ToInt32(IdArea);
            var asignaturas = (from c in this.NegocioAsignaturas.ConsultarAsignaturasPorArea(idArea)
                               select new
                               {
                                   Text = c.Descripcion,
                                   Value = c.Id
                               }).OrderBy(e => e.Text);

            return Json(asignaturas);
        }

        /// <summary>
        /// Obtiene el valor calculado para los momentos por año, grado y area.
        /// </summary>
        /// <param name="IdAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="IdGrado">Identificador del grado.</param>
        /// <param name="IdArea">Identificador del area.</param>
        /// <returns>Total de momentos asignados.</returns>
        public int ObtenerMomentosGradoArea(int? IdAnioLectivo, int? IdGrado, int? IdArea)
        {
            var resultado = this.NegocioIntensidadHoraria.ConsultarIntensidadesHorariasPorSede()
                .Where(e => e.IdAnioLectivo == IdAnioLectivo)
                .Where(e => e.IdGrado == IdGrado)
                .Where(e => e.Asignatura.IdMaestro == IdArea)
                .Select(e => (int)e.HorasSemana);

            return Convert.ToInt32(resultado.Sum());
        }

        /// <summary>
        /// Obtiene el valor calculado para los momentos por año y grado.
        /// </summary>
        /// <param name="IdAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="IdGrado">Identificador del grado.</param>
        /// <returns>Total de momentos asignados.</returns>
        public int ObtenerMomentosTotales(int? IdAnioLectivo, int? IdGrado)
        {
            var resultado = this.NegocioIntensidadHoraria.ConsultarIntensidadesHorariasPorSede()
                .Where(e => e.IdAnioLectivo == IdAnioLectivo)
                .Where(e => IdGrado == null || e.IdGrado == IdGrado)
                .Select(e => (int)e.HorasSemana);

            return Convert.ToInt32(resultado.Sum());
        }

        #endregion MetodosPublicos

        #region MetodosPrivados

        /// <summary>
        /// Establece los valores para el mapeo entre el viewmodel y la entidad.
        /// </summary>
        /// <param name="intensidadHoraria">Entidad con los datos.</param>
        /// <returns>ViewModel mapeado.</returns>
        private IntensidadHorariaViewModel EstablecerValoresModelo(IntensidadHoraria intensidadHoraria = null)
        {
            IntensidadHorariaViewModel intensidadHorariaViewModel = null;

            var grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var anios = this.NegocioAnioLectivo.ConsultarAniosLectivosAbiertos()
                .OrderByDescending(e => e.Anio)
                .ToSelectListItem(e => e.Anio, e => e.Id);

            var horasSemana = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                horasSemana.Add(i);
            }

            intensidadHorariaViewModel = new IntensidadHorariaViewModel()
            {
                Grados = grados,
                Areas = areas,
                HorasSemanas = horasSemana.ToSelectListItem(),
                AniosLectivos = anios
            };

            if (intensidadHoraria != null)
            {
                intensidadHorariaViewModel.IdAnioLectivo = intensidadHoraria.IdAnioLectivo;
                intensidadHorariaViewModel.HorasSemana = intensidadHoraria.HorasSemana;
                intensidadHorariaViewModel.Id = intensidadHoraria.Id;
                intensidadHorariaViewModel.IdAsignatura = intensidadHoraria.IdAsignatura;
                intensidadHorariaViewModel.IdGrado = intensidadHoraria.IdGrado;
                intensidadHorariaViewModel.IdSede = intensidadHoraria.IdSede;
                if (intensidadHoraria.Asignatura != null)
                {
                    intensidadHorariaViewModel.IdArea = intensidadHoraria.Asignatura.Maestro.Id;
                }
            }

            return intensidadHorariaViewModel;
        }

        #endregion MetodosPrivados
    }
}