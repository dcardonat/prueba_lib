namespace Libellus.Web.Areas.Administracion.Models.Maestros
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using PagedList;

    /// <summary>
    /// Define la información a visualizar en la vista de un maestro.
    /// </summary>
    public class MaestroViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de tipo MaestroViewModel.
        /// </summary>
        public MaestroViewModel()
        {
            this.TiposMaestro = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno del maestro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede asociada.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de maestro existentes.
        /// </summary>
        [Display(Name = "Maestro")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdTipoMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de maestro existentes.
        /// </summary>
        public List<SelectListItem> TiposMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de maestro.
        /// </summary>
        [Display(Name = "Maestro")]
        public string NombreTipoMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece la información del maestro seleccionado.
        /// </summary>
        public IPagedList<Maestro> Maestros { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del maestro.
        /// </summary>
        [Display(Name = "Nombre")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [StringLength(100, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del maestro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el token generado para determinar el estado de exportación a Excel.
        /// </summary>
        public string Token { get; set; }
    }
}