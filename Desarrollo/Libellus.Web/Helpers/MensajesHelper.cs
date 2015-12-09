namespace Libellus.Web.Helpers
{
    using Libellus.Mensajes;
    using System;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Define un control de mensajes Html personalizado.
    /// </summary>
    public static class MensajesHelper
    {
        #region Constantes

        /// <summary>
        /// Define la constante para el valor info.
        /// </summary>
        private const string INFORMACION = "success";

        /// <summary>
        /// Define la constante para el valor advertencia.
        /// </summary>
        private const string ADVERTENCIA = "warning";

        /// <summary>
        /// Define la constante para el valor error.
        /// </summary>
        private const string ERROR = "danger";

        #endregion

        #region Métodos

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar.</param>
        /// <param name="tipoMensaje">Tipo de mensaje a visualizar.</param>
        public static void MostrarMensaje(this Controller controlador, string mensaje, TipoMensaje tipoMensaje)
        {
            GenerarMensaje(controlador, mensaje, tipoMensaje);
        }

        /// <summary>
        /// Visualiza un mensaje de advertencia.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar.</param>
        public static void MostrarMensaje(this Controller controlador, Mensaje mensaje)
        {
            GenerarMensaje(controlador, mensaje.Texto, mensaje.Tipo);
        }

        /// <summary>
        /// Devuelve un mensaje especificado en el TempData del control actual.
        /// </summary>
        /// <param name="helper">Representa la compatibilidad para representar los controles HTML en una vista.</param>
        /// <returns>Mensaje especificado.</returns>
        public static MvcHtmlString MensajeExtender(this HtmlHelper helper)
        {
            string mensaje = String.Empty;
            var claseCss = String.Empty;

            if (!ReferenceEquals(helper.ViewContext.TempData[INFORMACION], null))
            {
                mensaje = helper.ViewContext.TempData[INFORMACION].ToString();
                claseCss = INFORMACION;
            }
            else if (!ReferenceEquals(helper.ViewContext.TempData[ERROR], null))
            {
                mensaje = helper.ViewContext.TempData[ERROR].ToString();
                claseCss = ERROR;
            }
            else if (!ReferenceEquals(helper.ViewContext.TempData[ADVERTENCIA], null))
            {
                mensaje = helper.ViewContext.TempData[ADVERTENCIA].ToString();
                claseCss = ADVERTENCIA;
            }

            TagBuilder mensajeUsuario = new TagBuilder("div");
            mensajeUsuario.MergeAttribute("id", "mensajeNegocio");

            if (!String.IsNullOrEmpty(mensaje))
            {
                mensajeUsuario.MergeAttribute("style", "text-align: center !important");
                mensajeUsuario.AddCssClass(String.Format("alert alert-{0} alert-dismissible", claseCss));
                mensajeUsuario.MergeAttribute("role", "alert");

                TagBuilder botonCerrarMensaje = new TagBuilder("button");
                botonCerrarMensaje.MergeAttribute("type", "button");
                botonCerrarMensaje.MergeAttribute("class", "close");
                botonCerrarMensaje.MergeAttribute("data-dismiss", "alert");
                botonCerrarMensaje.MergeAttribute("aria-label", "Close");
                
                TagBuilder spanCerrarMensaje = new TagBuilder("span");
                spanCerrarMensaje.MergeAttribute("aria-hidden", "true");
                spanCerrarMensaje.SetInnerText("&times;");

                botonCerrarMensaje.InnerHtml = spanCerrarMensaje.ToString();

                mensajeUsuario.InnerHtml = botonCerrarMensaje.ToString();
                mensajeUsuario.SetInnerText(mensaje);
            }

            return new MvcHtmlString(mensajeUsuario.ToString());
        }

        /// <summary>
        /// Determina el tipo de mensaje a generar.
        /// </summary>
        /// <param name="controlador">Controlador que almacena el mensaje.</param>
        /// <param name="mensaje">Mensaje a visualizar.</param>
        /// <param name="tipoMensaje">Tipo de mensaje a visualizar.</param>
        private static void GenerarMensaje(Controller controlador, string mensaje, TipoMensaje tipoMensaje)
        {
            switch (tipoMensaje)
            {
                case TipoMensaje.Informativo:
                    controlador.TempData[INFORMACION] = mensaje;
                    break;
                case TipoMensaje.Advertencia:
                    controlador.TempData[ADVERTENCIA] = mensaje;
                    break;
                case TipoMensaje.Error:
                    controlador.TempData[ERROR] = mensaje;
                    break;
            }
        }

        #endregion
    }
}