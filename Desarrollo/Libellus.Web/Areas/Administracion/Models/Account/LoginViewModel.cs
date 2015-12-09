namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información a visualizar en la vista del login.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Obtiene o establece el login del usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece la contrasenia del usuario.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Clave { get; set; }

        /// <summary>
        /// Obtiene o establece codigo del colegio.
        /// </summary>
        [Display(Name = "Código del colegio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string CodigoColegio { get; set; }
    }
}