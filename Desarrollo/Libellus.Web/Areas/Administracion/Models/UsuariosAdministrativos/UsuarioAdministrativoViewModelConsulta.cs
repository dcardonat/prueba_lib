namespace Libellus.Web.Areas.Administracion.Models.UsuariosAdministrativos
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Define un view model para los usuarios administrativos.
    /// </summary>
    public class UsuarioAdministrativoViewModelConsulta
    {
        /// <summary>
        /// Obtiene o establece el id del usuario administrativo.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtiene o establece el id del tipo de identificación del usuario administrativo.
        /// </summary>
        [Display(Name = "Tipo de documento")]
        public string TipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la identificación del usuario administrativo.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el id del usuario.
        /// </summary>       
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece el id del usuario.
        /// </summary>       
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre rol del usuario administrativo.
        /// </summary>        
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del cargo del usuario administrativo.
        /// </summary>
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del usuario administrativo.
        /// </summary>
        [Display(Name = "Estado")]
        public string Activo { get; set; }
    }
}