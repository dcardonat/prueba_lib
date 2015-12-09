namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Clase con los parametros de sesión de un usuario.
    /// </summary>
    [Serializable]
    public class ContextoUsuario
    {
        /// <summary>
        /// Obtiene o establece el codigo del colegio
        /// </summary>
        public string CodigoColegio { get; set; }

        /// <summary>
        /// Obtiene o establece el usuario
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Obtiene o establece el id de la sede
        /// </summary>
        public string IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece la cadena de conexión.
        /// </summary>
        public string CadenaConexionColegio { get; set; }

        /// <summary>
        /// Obtiene o establece las url permitidas.
        /// </summary>
        public virtual IEnumerable<string> UrlPermitidas { get; set; }
    }
}
