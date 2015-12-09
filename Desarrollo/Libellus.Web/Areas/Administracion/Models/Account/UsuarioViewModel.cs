namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Entidad con las porpiedades para el registro de usuarios.
    /// </summary>
    public class UsuarioViewModel
    {
        /// <summary>
        /// Ontiene o establece el identificador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el correo.
        /// </summary>
        [EmailAddress(ErrorMessage = "Formato correo electrónico incorrecto.")]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece el id del tipo de identificación del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Tipo documento")]
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o Establece el tipo de identificación de un usuario.
        /// </summary>
        public string TipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la identificación del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Documento de identidad")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del usuario.
        /// </summary>
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el id del rol del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de identificación que pueden ser asociados al usuario administrativo.
        /// </summary>
        public IEnumerable<SelectListItem> TiposIdentificaciones { get; set; }

        /// <summary>
        /// Obtiene o establece los roles que pueden ser asociados al usuario administrativo.
        /// </summary>
        public IEnumerable<SelectListItem> Roles { get; set; }

        /// <summary>
        /// Obtiene o establece los estados.
        /// </summary>
        public IEnumerable<SelectListItem> Estados { get; set; }
    }
}