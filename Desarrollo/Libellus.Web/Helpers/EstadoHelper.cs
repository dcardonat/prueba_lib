namespace Libellus.Web.Helpers
{
    using System.Web.Mvc;
    using Libellus.Utilidades;

    /// <summary>
    /// Proporciona el mecanismo de visualizar en texto el estado de un registro.
    /// </summary>
    public static class EstadoHelper
    {
        /// <summary>
        /// Genera un texto especificando el estado de un registro.
        /// </summary>
        /// <param name="helper">Representa los controles HTML en una vista.</param>
        /// <param name="estado">Boolean que determina el estado de un registro.</param>
        /// <returns>Valores configurables de acuerdo al estado del registro.</returns>
        public static MvcHtmlString VisualizarEstado(this HtmlHelper helper, bool estado)
        {
            return new MvcHtmlString(UtilidadesApp.ObtenerNombreEstadoRegistro(estado));
        }
    }
}