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
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.ParametrosInstitucionales;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la parametrización institucional.
    /// </summary>
    public class ParametrizacionInstitucionalController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo ParametrizacionInstitucionalController.
        /// </summary>
        public ParametrizacionInstitucionalController()
        {
            this.NegocioParametrizacionInstitucional = new NegocioParametrizacionInstitucional(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Lista la información existente de las parametrizaciones institucionales.
        /// </summary>
        /// <param name="pagina">Número de la página para mostrar los registros.</param>
        /// <returns>Redirecciona a la vista de consultar.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<ParametrizacionInstitucionalViewModel> coleccionParametrizacionInstitucional = null;

            try
            {
                coleccionParametrizacionInstitucional = (from p in this.NegocioParametrizacionInstitucional.Consultar()
                                                         select new ParametrizacionInstitucionalViewModel
                                                         {
                                                             Id = p.Id,
                                                             AnioLectivo = p.AnioLectivo.Anio.ToString(),
                                                             NombreNivelEducativo = p.NivelEducativo.Descripcion,
                                                             NombreHorario = p.Horario.Descripcion,
                                                             Estado = p.Estado
                                                         }).OrderByDescending(o => o.Estado).ThenByDescending(o => o.AnioLectivo).ThenBy(o => o.NombreNivelEducativo).ToPagedList(pagina ?? 1, 10);

                if (coleccionParametrizacionInstitucional.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(coleccionParametrizacionInstitucional);
        }

        /// <summary>
        /// Renderiza la vista de creación de un parámetro institucional.
        /// </summary>
        /// <returns>Vista para crear un parámetro institucional.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            ParametrizacionInstitucionalViewModel parametroViewModel = new ParametrizacionInstitucionalViewModel();

            try
            {
                parametroViewModel.AniosLectivos = this.NegocioAnioLectivo.ConsultarAniosLectivosAbiertos().OrderByDescending(o => o.Anio).ToSelectListItem(o => o.Anio, o => o.Id);
                parametroViewModel.NivelesEducativos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, 1, true).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
                parametroViewModel.Horarios = new List<SelectListItem>();
                parametroViewModel.MomentosDocente = this.NegocioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.ParametrizacionInstitucionalMomentosDocente, ContextoLibellus.ObtenerSedeActual).Descripcion;
                ViewBag.NuevoRegistro = true;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(parametroViewModel);
        }

        /// <summary>
        /// Almacena una parametrización institucional en la base de datos.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización diligenciada por el usuario.</param>
        /// <param name="parametrizacionViewModel">Información de la parametrización diligenciada por el usuario en formato ParametrizacionInstitucionalViewModel.</param>
        /// <returns>Vista con todas las parametrizaciones almacenadas.</returns>
        [HttpPost]
        public ActionResult Crear(ParametrizacionInstitucional parametrizacion, ParametrizacionInstitucionalViewModel parametrizacionViewModel)
        {
            try
            {
                parametrizacion.HoraInicial = UtilidadesApp.ObtenerHoraMilitar(parametrizacionViewModel.HoraInicial);
                parametrizacion.HoraFinal = UtilidadesApp.ObtenerHoraMilitar(parametrizacionViewModel.HoraFinal);

                Mensaje mensajeCreacion = this.NegocioParametrizacionInstitucional.AlmacenarParametrizacionInstitucional(parametrizacion);

                if (mensajeCreacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    this.EstablecerValoresExisteParametrizacion(parametrizacionViewModel);
                    this.ModelState.Clear();

                    return View(parametrizacionViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Renderiza la vista para la edición de un parámetro institucional.
        /// </summary>
        /// <param name="id">Identificador interno del parámetro institucional.</param>
        /// <returns>Vista con la información a editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ParametrizacionInstitucionalViewModel parametroViewModel = new ParametrizacionInstitucionalViewModel();

            try
            {
                ParametrizacionInstitucional parametrizacion = this.NegocioParametrizacionInstitucional.Consultar(id);

                if (parametrizacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    parametroViewModel.IdSede = parametrizacion.IdSede;

                    parametroViewModel.AniosLectivos = this.NegocioAnioLectivo.ConsultarAniosLectivosAbiertos().OrderByDescending(o => o.Anio).ToSelectListItem(o => o.Anio, o => o.Id);
                    parametroViewModel.IdAnioLectivo = parametrizacion.IdAnioLectivo;

                    parametroViewModel.NivelesEducativos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, 1, true).ToSelectListItem(o => o.Descripcion, o => o.Id);
                    parametroViewModel.IdNivelEducativo = parametrizacion.IdNivelEducativo;

                    parametroViewModel.Horarios = this.NegocioParametrizacionInstitucional.ConsultarHorarios(parametrizacion.NivelEducativo.Id).ToSelectListItem(o => o.Descripcion, o => o.Id);
                    parametroViewModel.IdHorario = parametrizacion.IdHorario;

                    parametroViewModel.MomentosSemana = parametrizacion.MomentosSemana.ToString();
                    parametroViewModel.TiempoDescansos = parametrizacion.TiempoDescansos.ToString();
                    parametroViewModel.Estado = parametrizacion.Estado;

                    parametroViewModel.HoraInicial = parametrizacion.HoraInicial.ToString();
                    parametroViewModel.HoraFinal = parametrizacion.HoraFinal.ToString();

                    parametroViewModel.DuracionMomentos = parametrizacion.DuracionMomentos.ToString();
                    parametroViewModel.MomentosDocente = parametrizacion.MomentosDocente.ToString();

                    ViewBag.NuevoRegistro = false;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(parametroViewModel);
        }

        /// <summary>
        /// Edita la información de una parametrización institucional en la base de datos.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización diligenciada por el usuario.</param>
        /// <param name="parametrizacionViewModel">Información de la parametrización diligenciada por el usuario en formato ParametrizacionInstitucionalViewModel.</param>
        /// <returns>Vista con todas las parametrizaciones almacenadas.</returns>
        [HttpPost]
        public ActionResult Editar(ParametrizacionInstitucional parametrizacion, ParametrizacionInstitucionalViewModel parametrizacionViewModel)
        {
            try
            {
                parametrizacion.HoraInicial = UtilidadesApp.ObtenerHoraMilitar(parametrizacionViewModel.HoraInicial);
                parametrizacion.HoraFinal = UtilidadesApp.ObtenerHoraMilitar(parametrizacionViewModel.HoraFinal);

                Mensaje mensajeCreacion = this.NegocioParametrizacionInstitucional.EditarParametrizacionInstitucional(parametrizacion);

                if (mensajeCreacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                }
                else
                {
                    this.EstablecerValoresExisteParametrizacion(parametrizacionViewModel);
                    return View(parametrizacionViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Exportar la información de los parámetros institucionales a Excel.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_ParametrizacionesInstitucional.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<ParametrizacionInstitucional> parametrizaciones = this.NegocioParametrizacionInstitucional.Consultar().OrderByDescending(o => o.Estado).ThenByDescending(o => o.AnioLectivo).ThenBy(o => o.NivelEducativo.Descripcion);

                IEnumerable<object> salidasOcupacionales = (from p in parametrizaciones
                                                            select new
                                                            {
                                                                Año_Lectivo = p.AnioLectivo.Anio,
                                                                Nivel_Educativo = p.NivelEducativo.Descripcion,
                                                                Horario = p.Horario.Descripcion,
                                                                Estado = p.Estado ? "Activo" : "Inactivo",
                                                                Sede = p.Sede.Nombre,
                                                                Hora_Inicial = this.ObtenerHoraAmPm(p.HoraInicial),
                                                                Hora_Final = this.ObtenerHoraAmPm(p.HoraFinal),
                                                                Momentos_Semana_Horas = p.MomentosSemana,
                                                                Tiempo_Descansos_Minutos = p.TiempoDescansos,
                                                            });

                byteArray = ExportarExcel.Exportar(salidasOcupacionales.ToList(), "ParametrizacionesInstitucional");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion Acciones

        #region Acciones asíncronas

        /// <summary>
        /// Consulta los horarios dependiendo del nivel educativo seleccionado.
        /// </summary>
        /// <param name="idNivelEducativo">Id del nivel educativo seleccionado.</param>
        /// <returns>Si el nivel educativo es CLEI, los horarios serán Nocturna, Sabatina, Dominical; de lo contrario serán, Mañana y tarde.</returns>
        [HttpPost]
        public JsonResult ConsultarHorarios(int idNivelEducativo)
        {
            List<SelectListItem> horarios = this.NegocioParametrizacionInstitucional.ConsultarHorarios(idNivelEducativo).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);

            return Json(horarios);
        }

        #endregion Acciones asíncronas

        #region Métodos privados

        /// <summary>
        /// Establece los valores diligenciados por el usuario cuando existe una parametrización en base de datos.
        /// </summary>
        /// <param name="parametrizacionViewModel">Información del ViewModel a visualizar.</param>
        public void EstablecerValoresExisteParametrizacion(ParametrizacionInstitucionalViewModel parametrizacionViewModel)
        {
            this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje010, parametrizacionViewModel.NombreNivelEducativo, parametrizacionViewModel.NombreHorario, parametrizacionViewModel.AnioLectivo));

            parametrizacionViewModel.NivelesEducativos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, 1, true).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            parametrizacionViewModel.Horarios = this.NegocioParametrizacionInstitucional.ConsultarHorarios(parametrizacionViewModel.IdNivelEducativo).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            ViewBag.NuevoRegistro = true;
        }

        /// <summary>
        /// Obtiene la hora en formato AM/PM de 12 horas.
        /// </summary>
        /// <param name="horaMilitar">Hora militar a convertir.</param>
        /// <returns>Hora en formato de 12 horas AM/PM.</returns>
        private string ObtenerHoraAmPm(TimeSpan horaMilitar)
        {
            int hora = horaMilitar.Hours;
            string tipoHora = " AM";

            if (hora > 12)
            {
                hora -= 12;
                tipoHora = " PM";
            }

            return String.Format("{0}:{1} {2}", hora.ToString().PadLeft(2, '0'), horaMilitar.Minutes.ToString().PadLeft(2, '0'), tipoHora);
        }

        #endregion Métodos privados
    }
}