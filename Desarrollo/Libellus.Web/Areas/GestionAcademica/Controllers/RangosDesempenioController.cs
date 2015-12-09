namespace Libellus.Web.Areas.GestionAcademica.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.GestionAcademica;
    using Libellus.Web.Areas.GestionAcademica.Models.RangosDesempenio;
    using Libellus.Web.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los rangos de desempeño.
    /// </summary>
    public class RangosDesempenioController : GestionAcademicaBaseController
    {
        #region Propiedades

        /// <summary>
        /// Calificación mínima.
        /// </summary>
        private decimal? CalificacionMinima;

        /// <summary>
        /// Calificación máxima.
        /// </summary>
        private decimal? CalificacionMaxima;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo RangosDesempenioController.
        /// </summary>
        public RangosDesempenioController()
        {
            this.NegocioRangosDesempenio = new NegocioRangosDesempenio(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioParametrosPromocion = new NegocioParametrosPromocion(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Metodo para obtener la información de los rangos de desempeño.
        /// </summary>
        /// <param name="pagina">Página para realizar la páginación.</param>
        /// <param name="IdAnioLectivo">Año seleccionado.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpGet]
        public ActionResult Administrar(int? IdAnioLectivo)
        {
            RangoDesempenioConsultaViewModels rangoDesempenioConsultaViewModels = new RangoDesempenioConsultaViewModels();

            try
            {
                if (IdAnioLectivo.HasValue)
                {
                    ObtenerModeloRangoDesempenio(rangoDesempenioConsultaViewModels, IdAnioLectivo);
                }

                List<AnioLectivo> anios = this.NegocioAnioLectivo.ConsultarAniosLectivos().ToList();
                AnioLectivo anoLectivo = anios.Where(x => x.Anio == DateTime.Now.Year).FirstOrDefault();
                rangoDesempenioConsultaViewModels.IdAnioLectivo = anoLectivo.Id;
                rangoDesempenioConsultaViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                ViewBag.AnioLectivo = rangoDesempenioConsultaViewModels.IdAnioLectivo;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(rangoDesempenioConsultaViewModels);
        }

        /// <summary>
        /// Administra la información de los rangos de desempeño.
        /// </summary>
        /// <param name="ListaRangosDesempenio">Listado para almacenar la información.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpPost]
        public JsonResult Administrar(List<RangosDesempenioViewModels> listaRangosDesempenio)
        {
            RangoDesempenioConsultaViewModels rangoDesempenioConsultaViewModels = new RangoDesempenioConsultaViewModels();

            try
            {
                List<RangosDesempenio> rangosDesempenios = new List<RangosDesempenio>();
                RangosDesempenio rangoDesempenio;

                if (listaRangosDesempenio != null)
                {
                    foreach (var item in listaRangosDesempenio)
                    {
                        rangoDesempenio = new RangosDesempenio()
                        {
                            IdAnioLectivo = item.Anio,
                            NotaMaxima = Convert.ToDecimal(item.NotaMaxima),
                            NotaMinima = Convert.ToDecimal(item.NotaMinima),
                            IdDesempenio = item.IdDesempenio,
                            Id = item.Id
                        };

                        rangosDesempenios.Add(rangoDesempenio);
                    }
                }

                if (NegocioRangosDesempenio.Administrar(rangosDesempenios))
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return Json(Url.Action("Administrar"));
        }

        /// <summary>
        /// Consulta la información de los rangos de desempeño.
        /// </summary>
        /// <param name="pagina">Página para la páginación de la tabla.</param>
        /// <param name="anio">Año seleccionado.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        [HttpGet]
        public ActionResult ConsultarRangosDesempenio(int? anio)
        {
            RangoDesempenioConsultaViewModels rangoDesempenioConsultaViewModels = new RangoDesempenioConsultaViewModels();

            try
            {
                AnioLectivo anoLectivo = this.NegocioAnioLectivo.ConsultarAnioLectivo((int)anio);

                if (anoLectivo != null)
                {
                    rangoDesempenioConsultaViewModels.IdAnioLectivo = anoLectivo.Id;
                    rangoDesempenioConsultaViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                    ViewBag.AnioLectivo = rangoDesempenioConsultaViewModels.IdAnioLectivo;
                }

                ObtenerModeloRangoDesempenio(rangoDesempenioConsultaViewModels, anio);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return PartialView("_InformacionRangoDesempenio", rangoDesempenioConsultaViewModels);
        }

        /// <summary>
        /// Elimina los rangos de desempeño del año seleccioando.
        /// </summary>
        /// <param name="anio">El año seleccionado.</param>
        /// <returns>La acción producto de eliminar los rangos de desempeño.</returns>
        [HttpPost]
        public JsonResult Eliminar(int anio)
        {
            try
            {
                if (this.NegocioRangosDesempenio.Eliminar(this.NegocioRangosDesempenio.Consultar(anio, null).ToList()))
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje004));
            }
            catch (Exception exception)
            {
                this.CapturarExcepcion(exception);
            }

            return Json(Url.Action("Administrar"));
        }

        #endregion

        #region Metodos privados

        /// <summary>
        /// Obtiene los parametros de promocion.
        /// </summary>
        /// <param name="rangoDesempenioConsultaViewModels">Modelo para almacenar la información.</param>
        /// <param name="anio">Año seleccionado.</param>
        /// <returns>Retorna el resultado.</returns>
        private bool ConsultarParametrosPromocion(RangoDesempenioConsultaViewModels rangoDesempenioConsultaViewModels, int? anio)
        {
            bool resultado = false;

            if (anio.HasValue)
            {
                ParametroPromocion ParametroPromocion = NegocioParametrosPromocion.ConsultarParametrosPromocion((int)anio.Value);

                if (ParametroPromocion != null && !string.IsNullOrEmpty(ParametroPromocion.CalificacionMaxima.Descripcion) && !string.IsNullOrEmpty(ParametroPromocion.CalificacionMinima.Descripcion))
                {
                    resultado = true;
                    rangoDesempenioConsultaViewModels.CalificacionMaxima = ParametroPromocion.CalificacionMaxima.Descripcion;
                    rangoDesempenioConsultaViewModels.CalificacionMinima = ParametroPromocion.CalificacionMinima.Descripcion;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene el modelo parametros desempeño.
        /// </summary>
        /// <param name="rangoDesempenioConsultaViewModels">Entidad para almacenar.</param>
        /// <param name="anio">Año seleccionado.</param>
        private void ObtenerModeloRangoDesempenio(RangoDesempenioConsultaViewModels rangoDesempenioConsultaViewModels, int? anio)
        {
            if (anio.HasValue)
            {
                if (ConsultarParametrosPromocion(rangoDesempenioConsultaViewModels, anio))
                {
                    ViewBag.SinParametrosPromocion = false;
                    IEnumerable<RangosDesempenio> ListaRangosDesempenio = NegocioRangosDesempenio.Consultar(anio.Value, null);
                    IEnumerable<Maestro> ListaDesempenio = NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.DesempenosEvaluativos, Utilidades.ContextoLibellus.ObtenerSedeActual);

                    rangoDesempenioConsultaViewModels.RangosDesempenio = ListaDesempenio.GroupJoin(
                           ListaRangosDesempenio,
                           p => p.Id,
                           c => c.IdDesempenio,
                           (p, g) => g
                               .Select(c => new RangosDesempenioViewModels
                               {
                                   Id = c.Id,
                                   IdDesempenio = p.Id,
                                   Desempenio = p.Descripcion,
                                   NotaMinima = c.NotaMinima.ToString(),
                                   NotaMaxima = c.NotaMaxima.ToString(),
                                   Consecutivo = (int)p.Consecutivo
                               })
                               .DefaultIfEmpty(new RangosDesempenioViewModels
                               {
                                   IdDesempenio = p.Id,
                                   Desempenio = p.Descripcion,
                                   NotaMinima = null,
                                   NotaMaxima = null,
                                   Consecutivo = (int)p.Consecutivo
                               })
                           ).SelectMany(g => g).ToList();

                }
                else
                {
                    ViewBag.SinParametrosPromocion = true;
                }
            }
        }

        #endregion
    }
}