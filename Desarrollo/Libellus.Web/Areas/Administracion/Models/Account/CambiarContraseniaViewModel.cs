namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Modelo para el cambio de contraseña.
    /// </summary>
    public class CambiarContraseniaViewModel
    {
        /// <summary>
        /// Obtiene o establece la contraseña actual.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string ClaveAcceso { get; set; }

        /// <summary>
        /// Obtiene o establece la nueva contraseña.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string NuevaContrasenia { get; set; }

        /// <summary>
        /// Obtiene o establece la confirmación de la contraseña. 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string ConfirmarContrasenia { get; set; }
    }
}