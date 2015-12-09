namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Modelo para recuperar la contraseña.
    /// </summary>
    public class RecuperarContraseniaViewModels
    {
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string nombreUsuario { get; set; }

        /// <summary>
        /// Codigo del colegio. 
        /// </summary>
        [Display(Name = "Código del colegio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string CodigoColegio { get; set; }
    }
}