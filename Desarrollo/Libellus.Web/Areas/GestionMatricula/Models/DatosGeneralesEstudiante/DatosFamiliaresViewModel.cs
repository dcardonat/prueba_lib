using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    public class DatosFamiliaresViewModel
    {
        public DatosFamiliaresViewModel()
        {
            Padre = new FamiliarViewModel();
            Madre = new FamiliarViewModel();
            Acudiente = new FamiliarViewModel();
        }
        /// <summary>
        /// Identificador del estudiante.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del padre.
        /// </summary>
        public int? IdPadre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la madre.
        /// </summary>
        public int? IdMadre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del acudiente.
        /// </summary>
        public int IdAcudiente { get; set; }

        /// <summary>
        /// Obtiene o establece si se ha checkeado la casilla del padre.
        /// </summary>
        public bool TienePadre { get; set; }

        /// <summary>
        /// Obtiene o establece si se ha checkeado la casilla de la madre.
        /// </summary>
        public bool TieneMadre { get; set; }

        public FamiliarViewModel Padre { get; set; }
        public FamiliarViewModel Madre { get; set; }
        public FamiliarViewModel Acudiente { get; set; }
    }
}