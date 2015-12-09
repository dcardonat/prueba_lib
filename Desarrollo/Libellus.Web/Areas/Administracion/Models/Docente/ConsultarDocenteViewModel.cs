namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using PagedList;

    /// <summary>
    /// Define la información a visualizar y manipular de la vista consultar docentes.
    /// </summary>
    public class ConsultarDocenteViewModel
    {
        /// <summary>
        /// Inicializa una instancia de tipo ConsultarDocenteViewModel.
        /// </summary>
        public ConsultarDocenteViewModel()
        {
            this.TiposDocumento = new List<SelectListItem>();
            this.Estados = new List<SelectListItem>();
            this.Sexos = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno del tipo de documento de identidad.
        /// </summary>
        [Display(Name = "Tipo de documento")]
        public int? IdTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de documento existentes.
        /// </summary>
        public List<SelectListItem> TiposDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad del docente.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres del docente.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos del docente.
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del sexo del docente.
        /// </summary>
        [Display(Name = "Sexo")]
        public int? IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece los sexos existentes.
        /// </summary>
        public List<SelectListItem> Sexos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estado en el sistema del docente.
        /// </summary>
        [Display(Name = "Estado")]
        public int? IdEstado { get; set; }

        /// <summary>
        /// Obtiene o establece los estados existentes.
        /// </summary>
        public List<SelectListItem> Estados { get; set; }

        /// <summary>
        /// Obtiene o establece los docentes consultados.
        /// </summary>
        public IPagedList<ResultadoConsultaDocentesViewModel> Docentes { get; set; }
    }
}