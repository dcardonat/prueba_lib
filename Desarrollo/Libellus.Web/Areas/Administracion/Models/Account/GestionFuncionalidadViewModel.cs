namespace Libellus.Web.Areas.Administracion.Models
{
    using Libellus.Entidades;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// ViewModel para la gestión de las funcionalidades y elementos del menu. 
    /// </summary>
    /// <author>Jorge Eliecer Guerrero.</author>
    /// <email>jguerrero@intergrupo.com</email>
    /// <date>08/01/2015</date>
    public class GestionFuncionalidadViewModel
    {
        /// <summary>
        /// Id de la funcionalidad.
        /// </summary>
        public decimal? Id { get; set; }

        /// <summary>
        /// Nombre funcionalidad.
        /// </summary>
        [Required]
        [StringLength(70, ErrorMessage = "Supera el máximo de caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// OrdenMenu.
        /// </summary>
        [Display(Name = "Orden del menú")]
        public int? OrdenMenu { get; set; }

        /// <summary>
        /// Estado.
        /// </summary>
        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        /// <summary>
        /// IdPadre.
        /// </summary>
        [Display(Name = "Elemento padre")]
        public int? IdPadre { get; set; }

        /// <summary>
        /// Objeto tipo 'Funcionalidad' que represente el elemento padre del item.
        /// </summary>
        [Display(Name = "Elemento padre")]
        public Funcionalidad ElementoPadre { get; set; }

        /// <summary>
        /// FuncionalidadesDelSistema.
        /// </summary>
        public IEnumerable<Funcionalidad> FuncionalidadesDelSistema { get; set; }
    }
}