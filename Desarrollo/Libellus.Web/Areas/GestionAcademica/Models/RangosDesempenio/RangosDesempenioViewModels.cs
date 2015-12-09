namespace Libellus.Web.Areas.GestionAcademica.Models.RangosDesempenio
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// View model Para la administración de la informacion de rangos de desempeño.
    /// </summary>
    public class RangosDesempenioViewModels
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public RangosDesempenioViewModels()
        {
        }

        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Consecutivo del maestro.
        /// </summary>
        public int Consecutivo { get; set; }

        /// <summary>
        /// Año del nivel educativo.
        /// </summary>
        [Display(Name = "Año")]
        public int Anio { get; set; }

        /// <summary>
        /// Identificador de desempeño evaluativo.
        /// </summary>
        public int IdDesempenio { get; set; }

        /// <summary>
        /// Calificación Máxima.
        /// </summary>
        [Display(Name = "Nota máxima")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string NotaMaxima { get; set; }

        /// <summary>
        /// Calificación minima.
        /// </summary>
        [Display(Name = "Nota mínima")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string NotaMinima { get; set; }

        /// <summary>
        /// Maestro desempeño evaluativo.
        /// </summary>
        [Display(Name = "Desempeño")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Desempenio { get; set; }
    }
}