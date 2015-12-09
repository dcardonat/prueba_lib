namespace Libellus.Web.Areas.Administracion.Models.ParametrizacionEscolar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Representa las areas por nivel del modelo.
    /// </summary>
    public class AreasNivelViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del area.
        /// </summary>
        public int IdArea { get; set; }

        /// <summary>
        /// Obtiene o establece el texto del area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel.
        /// </summary>
        public int IdNivelParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del area por nivel.
        /// </summary>
        public int IdAreaNivel { get; set; }
    }
}