namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// ViewModel de funcionalidades y roles. 
    /// </summary>
    public class FuncionalidadesRolViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador de la funcionalidad.
        /// </summary>
        public string IdsFuncionalidades { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// </summary>
        [Display(Name = "Roles del sistema")]
        [Required]
        public int IdRol { get; set; }

        /// <summary>
        /// Obtiene o establece los roles del sistema 
        /// </summary>
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}