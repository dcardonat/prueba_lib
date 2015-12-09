namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Define la información del estado, horario y observaciones adicionales al docente.
    /// </summary>
    public class EstadoHorarioViewModel
    {
        /// <summary>
        /// Inicializa una instancia de tipo EstadoHorarioViewModel.
        /// </summary>
        public EstadoHorarioViewModel()
        {
            this.Estados = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno generado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del docente.
        /// </summary>
        [Display(Name = "Estado")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdEstado { get; set; }

        /// <summary>
        /// Obtiene o establece los estados posibles del docente.
        /// </summary>
        public List<SelectListItem> Estados { get; set; }

        /// <summary>
        /// Obtiene o establece el horario del docente.
        /// </summary>
        [Display(Name = "Horario")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece los horarios posibles del docente.
        /// </summary>
        public List<SelectListItem> Horarios { get; set; }

        /// <summary>
        /// Obtiene o establece las observaciones adicionales que se le pueden asociar al docente.
        /// </summary>
        [StringLength(100, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Observaciones { get; set; }
    }
}