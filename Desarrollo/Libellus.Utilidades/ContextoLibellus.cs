namespace Libellus.Utilidades
{
    using Libellus.Entidades;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public static class ContextoLibellus
    {
        /// <summary>
        /// Obtiene el colegio del usuario donde se inición la sesión.
        /// </summary>
        public static string ObtenerColegioActual
        {
            get 
            {
                return (string)UtilidadesApp.ObtenerInformacionCookie(ConstantesCookie.CodigoColegio.ToString());
            }
        }

        /// <summary>
        /// Obtiene la sede del usuario donde se inición la sesión.
        /// </summary>
        public static int ObtenerSedeActual
        {
            get
            {
                return Convert.ToInt16(UtilidadesApp.ObtenerInformacionCookie(ConstantesCookie.Sede.ToString()));
            }
        }

        /// <summary>
        /// Obtiene la sede principal del colegio donde se inicia la sesión.
        /// </summary>
        public static int ObtenerSedePrincipal
        {
            get
            {
                return Convert.ToInt16(UtilidadesApp.ObtenerInformacionCookie(ConstantesCookie.SedePrincipal.ToString()));
            }
        }

        /// <summary>
        /// Obtiene el usuario que inicia la sesíón.
        /// </summary>
        public static string ObtenerUsuarioActual
        {
            get
            {
                return UtilidadesApp.ObtenerInformacionCookie(ConstantesCookie.NombreUsuario.ToString());
            }
        }
    }
}
