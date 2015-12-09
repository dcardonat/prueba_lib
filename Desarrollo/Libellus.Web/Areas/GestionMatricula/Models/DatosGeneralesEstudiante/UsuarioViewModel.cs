namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representa al modelo usuario.
    /// </summary>
    public class UsuarioViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Correo electronico.
        /// </summary>
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Formato incorrecto.")]
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la Clave.
        /// </summary>
        [Display(Name = "Clave de acceso al sistema")]
        public string Clave { get; set; }

        /// <summary>
        /// Obtiene o establece el NombreUsuario.
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el Ide
        /// </summary>
        [Display(Name = "Tipo de documento")]
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la  identificación.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el número de intentos fallidos realizados por el usuario desde el reproductor músical.
        /// </summary>
        public byte? IntentosFallidos { get; set; }

        /// <summary>
        /// Obtiene o establece el id del estado.
        /// </summary>
        public byte IdEstado { get; set; }
    }
}