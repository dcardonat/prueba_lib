namespace Libellus.Web.Controllers
{
    using Libellus.Web.Areas.Administracion.Controllers;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona las acciones de interacción con la vista de bienvenida.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Vista de bienvenida.
        /// </summary>
        /// <returns>Vista HTML.</returns>
        public ActionResult Bienvenida()
        {
            //string clave = Libellus.Utilidades.UtilidadesApp.Encriptar("Libellus123_");
            //string servidor = Libellus.Utilidades.UtilidadesApp.Encriptar("nf4ghlo3wv.database.windows.net");
            //string NombreUsuario = Libellus.Utilidades.UtilidadesApp.Encriptar("AdminLibellusTest");
            //string Contrasena = Libellus.Utilidades.UtilidadesApp.Encriptar("PruebasLibellus123");
            //string baseDatos = Libellus.Utilidades.UtilidadesApp.Encriptar("LibellusTest");
            //string HostRedisCache = Libellus.Utilidades.UtilidadesApp.Encriptar("libelluscache.redis.cache.windows.net");
            //string ContrasenaRedisCache = Libellus.Utilidades.UtilidadesApp.Encriptar("123");

            return View();
        }
    }
}