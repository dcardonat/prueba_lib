namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.AperturaPeriodos;
    using Libellus.Web.Helpers;

    /// <summary>
    /// Proporciona la interaccion para las operaciones de la apertura extemporanea de periodos.
    /// </summary>
    public class AperturaPeriodosController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public AperturaPeriodosController()
        {
            this.NegocioAperturaPeriodos = new NegocioAperturaPeriodos(this.UnidadDeTrabajoLibellus);
            this.NegocioParametrizacionEscolar = new NegocioParametrizacionEscolar(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructor

        /// <summary>
        /// Presenta los datos para la vista.
        /// </summary>
        /// <param name="id">Identificador del periodo.</param>
        /// <returns>Retorna a la vista para mostrar los datos.</returns>
        [HttpGet]
        public ActionResult Administrar(int idPeriodo)
        {
            AperturaPeriodosViewModel viewModel = new AperturaPeriodosViewModel();

            try
            {
                AperturaExtemporaneaPeriodo aperturaPeriodo = this.NegocioAperturaPeriodos.ConsultarAperturaPeriodo(idPeriodo);
                if (aperturaPeriodo != null)
                {
                    viewModel = new AperturaPeriodosViewModel()
                    {
                        Id = aperturaPeriodo.Id,
                        IdPeriodo = aperturaPeriodo.IdPeriodo,
                        FechaInicial = aperturaPeriodo.FechaInicial.ToShortDateString(),
                        FechaFinal = aperturaPeriodo.FechaFinal.ToShortDateString(),
                        MotivoApertura = aperturaPeriodo.MotivoApertura,
                        HoraInicial = aperturaPeriodo.FechaInicial.TimeOfDay.ToString(),
                        HoraFinal = aperturaPeriodo.FechaFinal.TimeOfDay.ToString(),
                        Periodo = aperturaPeriodo.PeriodoParametrizacion.Periodo
                    };

                    ViewBag.Accion = "Editar";
                }
                else
                {
                    PeriodoParametrizacion periodo = this.NegocioParametrizacionEscolar.ConsultarPeriodo(idPeriodo);
                    if (periodo != null)
                    {
                        viewModel.IdPeriodo = periodo.Id;
                        viewModel.Periodo = periodo.Periodo;
                    }

                    ViewBag.Accion = "Crear";
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(viewModel);
        }

        /// <summary>
        /// Recibe la informacion para gestionarla desde el negocio.
        /// </summary>
        /// <param name="aperturaPeriodo">Objeto con la informacion.</param>
        /// <returns>Retorna la vista editar de parametrizacion escolar.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Administrar(AperturaExtemporaneaPeriodo aperturaPeriodo, AperturaPeriodosViewModel viewModel)
        {
            Mensaje mensajeRespuesta = null;
            object[] objetoRespuesta = null;

            try
            {
                TimeSpan horaInicial = UtilidadesApp.ObtenerHoraMilitar(viewModel.HoraInicial);
                TimeSpan horaFinal = UtilidadesApp.ObtenerHoraMilitar(viewModel.HoraFinal);
                aperturaPeriodo.FechaInicial = aperturaPeriodo.FechaInicial.Add(horaInicial);
                aperturaPeriodo.FechaFinal = aperturaPeriodo.FechaFinal.Add(horaFinal);

                objetoRespuesta = this.NegocioAperturaPeriodos.AdministrarAperturaPeriodo(aperturaPeriodo);
                mensajeRespuesta = objetoRespuesta[0] as Mensaje;
                this.MostrarMensaje(mensajeRespuesta);

                if (!mensajeRespuesta.Codigo.Equals(CodigoMensaje.Mensaje001, StringComparison.OrdinalIgnoreCase) &&
                    !mensajeRespuesta.Codigo.Equals(CodigoMensaje.Mensaje002, StringComparison.OrdinalIgnoreCase))
                {
                    ViewBag.Accion = viewModel.Id.Equals(0) ? "Crear" : "Editar";
                    viewModel.HoraInicial = aperturaPeriodo.FechaInicial.TimeOfDay.ToString();
                    viewModel.HoraFinal = aperturaPeriodo.FechaFinal.TimeOfDay.ToString();
                    return View(viewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Editar", "ParametrizacionEscolar", new { id = objetoRespuesta[1] });
        }
    }
}