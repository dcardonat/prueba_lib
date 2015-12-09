namespace Libellus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;

    /// <summary>
    /// Define la información transversal a funcionalidades generales.
    /// </summary>
    public class GeneralController : BaseController
    {
        #region Atributos

        /// Define la interfáz de las reglas de negocio para los maestros administrables.
        /// </summary>
        private INegocioMaestros NegocioMaestros { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para los años lectivos.
        /// </summary>
        private INegocioAnioLectivo NegocioAnioLectivo { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo GeografiaController.
        /// </summary>
        public GeneralController()
        {
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones asíncronas

        [AllowAnonymous]
        public ActionResult AccesoInvalido(string id)
        {
            return View("AccesoInvalido");
        }

        /// <summary>
        /// Obtiene los registros de los años lectivos.
        /// </summary>
        /// <returns>Colección de tipo ListItem con los años registrados.</returns>
        public JsonResult ObtenerAniosLectivos()
        {
            var coleccionAniosLectivos = this.NegocioAnioLectivo.ConsultarAniosLectivos()
                .OrderByDescending(e => e.Anio)
                .Select(e => new { 
                    Value = e.Id,
                    Text = e.Anio,
                    Estado = !e.Cerrado
                });

            return Json(coleccionAniosLectivos, JsonRequestBehavior.AllowGet);
        }

        #endregion Acciones asíncronas
    }
}
