namespace Libellus.Web.Areas.Administracion.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Libellus.Entidades;
    using System.ComponentModel.DataAnnotations;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la información a visualizar en la vista de los roles.
    /// </summary>
    public class RolViewModel
    {
        /// <summary>
        /// Obtiene o establece el idetificador del rol.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el ombre del rol.
        /// </summary>
        [Display(Name = "Nombre")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public string NombreSede { get; set; }

        /// <summary>
        /// Ibtiene o establece el estado del rol.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece las funcionalidades asociadas al rol.
        /// </summary>
        public virtual ICollection<Funcionalidad> Funcionalidades { get; set; }
    }
}