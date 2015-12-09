namespace Libellus.Web.Areas.Administracion.Models.ActividadesComplementarias
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la informacion a mostrar para el maestro de Actividades Complementarias.
    /// </summary>
    public class ActividadesComplementariasViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador de la actividad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion de la actividad.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(100)]
        [Display(Name="Nombre actividad")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la intensidad horaria de la actividad.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Range(1, 99, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Display(Name="Intensidad horaria")]
        public short IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la actividad.
        /// </summary>
        [Required]
        public bool Estado { get; set; }
    }
}