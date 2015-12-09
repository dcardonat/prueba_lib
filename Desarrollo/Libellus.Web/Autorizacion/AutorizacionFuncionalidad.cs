namespace Libellus.Web.Autorizacion
{
    using Libellus.Entidades;
    using Libellus.Negocio.Seguridad;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Clase para realizar la autenticación del usuario.
    /// </summary>
    public class AutorizacionFuncionalidad : AuthorizeAttribute
    {
        /// <summary>
        /// Encapsula la información acerca de la ruta a la que se está accediendo. 
        /// </summary>
        private RouteData routeData;

        #region Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AutorizacionFuncionalidad()
        {
        }

        #endregion

        #region  Metodos

        /// <summary>
        /// Inicializar la autorización.
        /// </summary>
        /// <param name="filterContext">Información requerida para la autorización.</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            routeData = filterContext.RouteData;
            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// Se sobre escribe el método AuthorizeAttribute.AuthorizeCore() para validar si el 
        /// usuario logueado actualmente tiene permisos para ingresar a la URL requerida.
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);

            if (!isAuthorized)
            {
                return false;
            }

            bool validarAcceso = false;
            string usuario = Utilidades.ContextoLibellus.ObtenerUsuarioActual;
            string area = "/" + HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
            string urlRequerida = "/" + routeData.Values["controller"] + "/" + routeData.Values["action"];

            if (!string.IsNullOrEmpty(area))
            {
                urlRequerida = area + urlRequerida;
            }

            using (NegocioFuncionalidades NegocioFuncionalidades = new NegocioFuncionalidades(new UnidadDeTrabajoLibellus()))
            {
                validarAcceso = NegocioFuncionalidades.ValidarAcceso(urlRequerida, usuario);
            }

            return validarAcceso;
        }

        /// <summary>
        /// Este método permite redireccionar hacia una pagina personalizada a los usuarios 
        /// cuya validación de permisos fue negativa. 
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                area = "",
                                controller = "General",
                                action = "AccesoInvalido"
                            })
                        );
        }

        #endregion
    }
}