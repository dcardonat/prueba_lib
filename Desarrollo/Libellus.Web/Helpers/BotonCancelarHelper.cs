namespace Libellus.Web.Helpers
{
    using System;
    using System.Web.Mvc;
    using Libellus.Mensajes;


    /// <summary>
    /// Define un control HTML de tipo botón para cancelar cualquier acción del sistema.
    /// </summary>
    public static class BotonCancelarHelper
    {
        /// <summary>
        /// Devuelve un elemento input de tipo botón.
        /// </summary>
        /// <param name="helper">Representa la compatibilidad para representar los controles HTML en una vista.</param>
        /// <param name="action">Acción a ejecutar.</param>
        /// <param name="controller">Control a redireccionar.</param>
        /// <returns>Control de tipo botón.</returns>
        public static MvcHtmlString BotonCancelar(this HtmlHelper helper, string action, string controller)
        {
            return BotonCancelar(helper, action, controller, null, null);
        }

        /// <summary>
        /// Devuelve un elemento input de tipo botón.
        /// </summary>
        /// <param name="helper">Representa la compatibilidad para representar los controles HTML en una vista.</param>
        /// <param name="action">Acción a ejecutar.</param>
        /// <param name="controller">Control a redireccionar.</param>
        /// <param name="routeValues">Parámetros adicionales en la cadena de conexión.</param>
        /// <returns>Control de tipo botón.</returns>
        public static MvcHtmlString BotonCancelar(this HtmlHelper helper, string action, string controller, object routeValues)
        {
            return BotonCancelar(helper, action, controller, routeValues, null);
        }

        /// <summary>
        /// Devuelve un elemento input de tipo botón.
        /// </summary>
        /// <param name="helper">Representa la compatibilidad para representar los controles HTML en una vista.</param>
        /// <param name="action">Acción a ejecutar.</param>
        /// <param name="controller">Control a redireccionar.</param>
        /// <param name="routeValues">Parámetros adicionales en la cadena de conexión.</param>
        /// <param name="htmlAttributes">Atributos html adicionales.</param>
        /// <returns>Control de tipo botón.</returns>
        public static MvcHtmlString BotonCancelar(this HtmlHelper helper, string action, string controller, object routeValues, object htmlAttributes)
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            TagBuilder buttonHelper = new TagBuilder("button");
            buttonHelper.MergeAttribute("type", "button");
            buttonHelper.MergeAttribute("class", "btn btn-link");
            buttonHelper.MergeAttribute("onclick", String.Format("CancelarAccion('{0}', '{1}');", Mensaje.Mensaje1003, urlHelper.Action(action, controller, routeValues)));
            buttonHelper.SetInnerText("Cancelar");

            if (!ReferenceEquals(htmlAttributes, null))
            {
                buttonHelper.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            return new MvcHtmlString(buttonHelper.ToString());
        }
    }
}