namespace Libellus.Web.Areas.Administracion.Models.GruposPorGrado
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// View model para el manejo de grupos por grado.
    /// </summary>
    public class GruposPorGradoViewModel
    {
        /// <summary>
        /// Inicializa una instancia de la clase GruposPorGradoViewModel.
        /// </summary>
        public GruposPorGradoViewModel()
        {
            this.Grados = new List<SelectListItem>();
            this.Grupos = new List<SelectListItem>();
            this.GruposPorGrado = new List<SelectListItem>();
        }

        /// <summary>
        /// Identificador del grado.
        /// </summary>
        [Display(Name = "Grado")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdGrado { get; set; }

        /// <summary>
        /// Listado de grados. 
        /// </summary>
        public List<SelectListItem> Grados { get; set; }

        /// <summary>
        /// Listado de grupos.
        /// </summary>
        [Display(Name = "Grupos")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int[] IdGrupos { get; set; }

        /// <summary>
        /// Listado de grupos.
        /// </summary>
        public List<SelectListItem> Grupos { get; set; } 

        /// <summary>
        /// Listaodo de grupos por grado.
        /// </summary>
        [Display(Name = "Grupos por grado")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int[] IdGruposPorGrado { get; set; }

        /// <summary>
        /// Listado de grupos por grado. 
        /// </summary>
        public List<SelectListItem> GruposPorGrado { get; set; }
    }
}