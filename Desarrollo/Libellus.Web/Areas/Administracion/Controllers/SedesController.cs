namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;

    /// <summary>
    /// Proporciona las acciones de interacción con las sedes.
    /// </summary>
    public class SedesController : AdministracionBaseController
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public  SedesController()
        {
            NegocioSedes = new NegocioSedes(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        ///  Acción para consultat las sedes del usuario.
        /// </summary>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Consultar()
        {
            IEnumerable<Sede> sedes = NegocioSedes.ConsultarSedesPorUsuario(User.Identity.Name);
            IEnumerable<Sede> sedesColegio = NegocioSedes.ConsultarSedes();
            string sede = sedesColegio.OrderBy(x => x.Id).FirstOrDefault().Id.ToString();
            UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.SedePrincipal, sede, DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));
            int cantidadSedes = sedes.Count();

            if (cantidadSedes == 1)
            {
                UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.Sede, sedes.FirstOrDefault().Id.ToString(), DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));
                return RedirectToAction("Bienvenida", "Home", new { area = "" });
            }
            else
            {
                ViewBag.sede = "true";
                ViewBag.Sedes = sedes;
                return View();
            }
        }

        /// <summary>
        /// Acción para consultat las sedes del usuario.
        /// </summary>
        /// <param name="sede">Sede seleccionada</param>
        /// <returns>Retorna la vista</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Consultar(string sede)
        {
            UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.Sede, sede, DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));
            return RedirectToAction("Bienvenida", "Home", new { area = "" });
        }
    }
}