namespace Libellus.Web.Areas.Administracion.Models.SalidasOcupacionales
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información a visualizar en la vista de la administración de las salidas ocupacionales.
    /// </summary>
    public class SalidaOcupacionalViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece la descipción de la salida ocupacional.
        /// </summary>
        [Display(Name = "Salida ocupacional")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la intensidad horaria dedicada al maestro.
        /// </summary>
        [Display(Name = "Intensidad horaria")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Range(1, 99, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        public string IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la salida ocupacional.
        /// </summary>
        public bool Estado { get; set; }
    }
}