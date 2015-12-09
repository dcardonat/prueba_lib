namespace Libellus.Web.Areas.GestionAcademica.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.GestionAcademica;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionAcademica.Models.ParametrosPromocion;
    using System;
    using System.Web.Mvc;
    using Libellus.Web.Helpers;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los parametros de promoción.
    /// </summary>
    public class ParametrosPromocionController : GestionAcademicaBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo ParametrosPromocionController.
        /// </summary>
        public ParametrosPromocionController()
        {
            this.NegocioParametrosPromocion = new NegocioParametrosPromocion(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioRangosDesempenio = new NegocioRangosDesempenio(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Acción Get para la administración de los parametros de promoción.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpGet]
        public ActionResult Administrar(int? IdAnioLectivo)
        {
            ParametrosPromocionViewModels parametrosPromocionViewModels = new ParametrosPromocionViewModels();
            
            try
            {
                ObtenerInformacionMaestros(parametrosPromocionViewModels);
                List<AnioLectivo> anios = this.NegocioAnioLectivo.ConsultarAniosLectivos().ToList();
                AnioLectivo anoLectivo = anios.Where(x => x.Anio == DateTime.Now.Year).FirstOrDefault();
                parametrosPromocionViewModels.IdAnioLectivo = anoLectivo.Id;
                parametrosPromocionViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                ViewBag.AnioLectivo = parametrosPromocionViewModels.IdAnioLectivo;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(parametrosPromocionViewModels);
        }

        /// <summary>
        /// Metodo post para administrar los parametros de promoción.
        /// </summary>
        /// <param name="anio">Año seleccionado.</param>
        /// <returns>Retorna el resultado de la accion.</returns>
        [HttpPost]
        public ActionResult Administrar(ParametrosPromocionViewModels parametrosPromocionViewModels)
        {
            try
            {
                ParametroPromocion parametrosPromocion = new ParametroPromocion()
                {
                    Id = parametrosPromocionViewModels.Id,
                    IdAnioLectivo = parametrosPromocionViewModels.IdAnioLectivo,
                    IdCalificacionMaxima = parametrosPromocionViewModels.IdCalificacionMaxima,
                    IdCalificacionMinima = parametrosPromocionViewModels.IdCalificacionMinima,
                    CalificacionMinimaAprobacion = Convert.ToDecimal(parametrosPromocionViewModels.CalificacionMinimaAprobacion),
                    IdEvaluacionAprendizaje = parametrosPromocionViewModels.IdEvaluacionAprendizaje,
                    MaximoAreasMejoramiento = Convert.ToInt32(parametrosPromocionViewModels.MaximoAreasMejoramiento),
                    MinimoAreaReprobacion = Convert.ToInt32(parametrosPromocionViewModels.MinimoAreaReprobacion),
                    MinimoAreasReprobadas = Convert.ToInt32(parametrosPromocionViewModels.MinimoAreasReprobadas),
                    PorcentajeInasistencia = Convert.ToDecimal(parametrosPromocionViewModels.PorcentajeInasistencia),
                    PromedioPonderado = parametrosPromocionViewModels.PromedioPonderado,
                    PromedioPromocion = parametrosPromocionViewModels.IdPromedioPromocion
                };

                Mensaje mensaje = NegocioParametrosPromocion.AdministrarParametrosPromocion(parametrosPromocion);

                if (mensaje != null)
                {
                    this.MostrarMensaje(mensaje);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            parametrosPromocionViewModels = new ParametrosPromocionViewModels();
            ObtenerInformacionMaestros(parametrosPromocionViewModels);
            return RedirectToAction("Administrar", parametrosPromocionViewModels);
        }

        /// <summary>
        /// Consulta la información de los parametros de promocion.
        /// </summary>
        /// <param name="anio">Año seleccionado</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpGet]
        public ActionResult ConsultarInformacionParametroPromocion(int? anio)
        {
            ParametrosPromocionViewModels parametrosPromocionViewModels = new ParametrosPromocionViewModels();

            try
            {
                if (anio.HasValue)
                {
                    parametrosPromocionViewModels = ConsultarParametroPromocion(anio);
                }

                ObtenerInformacionMaestros(parametrosPromocionViewModels);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return PartialView("_Detalle", parametrosPromocionViewModels);
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Consulta los parametros de promocion por año.
        /// </summary>
        /// <param name="anio">Año seleccionado</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public ParametrosPromocionViewModels ConsultarParametroPromocion(int? anio)
        {
            ParametrosPromocionViewModels parametrosPromocionViewModels = new ParametrosPromocionViewModels();

            try
            {
                int cantidadRangoDesempenio = NegocioRangosDesempenio.ConsultarCantidadRegistroPorAnio((int)anio);
                ParametroPromocion parametrosPromocion = NegocioParametrosPromocion.ConsultarParametrosPromocion((int)anio);

                AnioLectivo anoLectivo = this.NegocioAnioLectivo.ConsultarAnioLectivo((int)anio);

                if (anoLectivo != null)
                {
                    parametrosPromocionViewModels.IdAnioLectivo = anoLectivo.Id;
                    parametrosPromocionViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                    ViewBag.AnioLectivo = parametrosPromocionViewModels.IdAnioLectivo;
                }

                if (parametrosPromocion != null && parametrosPromocion.Id > 0)
                {
                    parametrosPromocionViewModels.Id = parametrosPromocion.Id;
                    parametrosPromocionViewModels.IdAnioLectivo = parametrosPromocion.IdAnioLectivo;
                    parametrosPromocionViewModels.AnioLectivo = new AnioLectivo { Id = parametrosPromocion.IdAnioLectivo , Anio = parametrosPromocion.AnioLectivo.Anio, Cerrado = parametrosPromocion.AnioLectivo.Cerrado};
                    parametrosPromocionViewModels.IdCalificacionMaxima = parametrosPromocion.IdCalificacionMaxima;
                    parametrosPromocionViewModels.IdCalificacionMinima = parametrosPromocion.IdCalificacionMinima;
                    parametrosPromocionViewModels.CalificacionMinimaAprobacion = Convert.ToString(parametrosPromocion.CalificacionMinimaAprobacion);
                    parametrosPromocionViewModels.Id = parametrosPromocion.Id;
                    parametrosPromocionViewModels.IdEvaluacionAprendizaje = parametrosPromocion.IdEvaluacionAprendizaje;
                    parametrosPromocionViewModels.MaximoAreasMejoramiento = parametrosPromocion.MaximoAreasMejoramiento.ToString();
                    parametrosPromocionViewModels.MinimoAreaReprobacion = parametrosPromocion.MinimoAreaReprobacion.ToString();
                    parametrosPromocionViewModels.MinimoAreasReprobadas = parametrosPromocion.MinimoAreasReprobadas.ToString();
                    parametrosPromocionViewModels.PorcentajeInasistencia = Convert.ToString(parametrosPromocion.PorcentajeInasistencia);
                    parametrosPromocionViewModels.PromedioPonderado = parametrosPromocion.PromedioPonderado;
                    parametrosPromocionViewModels.IdPromedioPromocion = parametrosPromocion.PromedioPromocion;
                    ViewBag.AnioLectivo = parametrosPromocion.IdAnioLectivo;
                    parametrosPromocionViewModels.ConfiguracionRangos = cantidadRangoDesempenio > 0 ? true: false;
                }
            } 
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return parametrosPromocionViewModels;
        }

        /// <summary>
        /// Obtiene la información de los maestros. 
        /// </summary>
        /// <param name="parametrosPromocionViewModels">Entidad para asignar la información de los maestros.</param>
        private void ObtenerInformacionMaestros(ParametrosPromocionViewModels parametrosPromocionViewModels)
        {
            Maestro promedioPromocion = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.PromedioPromocion, Utilidades.ContextoLibellus.ObtenerSedeActual, true).FirstOrDefault();
            parametrosPromocionViewModels.PromediosPromocion = UtilidadesApp.ObtenerListaMaestro(promedioPromocion.Descripcion);
            parametrosPromocionViewModels.CalificacionesMaximas = NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.CalificacionMaxima, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
            parametrosPromocionViewModels.CalificacionesMinimas = NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.CalificacionMinima, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
            parametrosPromocionViewModels.Evaluaciones = NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EvaluacionAprendizaje, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);    
        }

        #endregion
    }
}