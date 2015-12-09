namespace Libellus.Web.Helpers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.WebPages;

    /// <summary>
    /// Define el mecanismo de inyección de código Javascript y/o estilos CSS dentro de las vistas parciales.
    /// </summary>
    public static class ScriptHelper
    {
        /// <summary>
        /// Permite la inyección de código JavaScript y/o estilos CSS dentro de las vistas parciales.
        /// </summary>
        /// <param name="htmlHelper">Contexto de las vistas parciales.</param>
        /// <param name="template">Script o estilo CSS a inyectar.</param>
        /// <returns>Null, porque se inyecta los script o estilos mediante el HttpContext.</returns>
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Renderiza los script y/o estilos CSS en tiempo de ejecución.
        /// </summary>
        /// <param name="htmlHelper">Contexto de las vistas parciales.</param>
        /// <returns>Scripts o estilos CSS en el contexto de las vistas.</returns>
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }

            return MvcHtmlString.Empty;
        }
    }
}