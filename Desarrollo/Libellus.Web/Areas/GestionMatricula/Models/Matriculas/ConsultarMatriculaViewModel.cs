namespace Libellus.Web.Areas.GestionMatricula.Models.Matriculas
{
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// View model para la consulta de matriculas.
    /// </summary>
    public class ConsultarMatriculaViewModel
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ConsultarMatriculaViewModel()
        {
            this.TiposDocumento = new List<SelectListItem>();
            this.Estados = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno del tipo de documento de identidad.
        /// </summary>
        [Display(Name = "Tipo documento")]
        public int? IdTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad del docente.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estado dl cupo.
        /// </summary>
        [Display(Name = "Estado")]
        public int? IdEstado { get; set; }

        /// <summary>
        /// Año para la configuración.
        /// </summary>
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de documento existentes.
        /// </summary>
        public List<SelectListItem> TiposDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece los estados existentes.
        /// </summary>
        public List<SelectListItem> Estados { get; set; }

        /// <summary>
        /// Obtiene o establece las matriculas consultadas.
        /// </summary>
        public IPagedList<ResultadoConsultaMatriculaViewModel> Matriculas { get; set; }
    }
}