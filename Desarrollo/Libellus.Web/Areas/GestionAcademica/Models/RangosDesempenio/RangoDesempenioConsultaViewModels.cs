namespace Libellus.Web.Areas.GestionAcademica.Models.RangosDesempenio
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Rango de desempeño consulta view models.
    /// </summary>
    public class RangoDesempenioConsultaViewModels
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public RangoDesempenioConsultaViewModels()
        {
            AnioLectivo = new AnioLectivo();
        }

        /// <summary>
        /// Año para la configuración.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Calificación Máxima.
        /// </summary>
        [Display(Name = "Calificación Máxima")]
        public string CalificacionMaxima { get; set; }

        /// <summary>
        /// Calificación minima.
        /// </summary>
        [Display(Name = "Calificación Mínima")]
        public string CalificacionMinima { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los rango de desempeño.
        /// </summary>
        public List<RangosDesempenioViewModels> RangosDesempenio { get; set; }
    }
}