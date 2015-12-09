namespace Libellus.Web.Areas.GestionMatricula.Models.CancelacionMatricula
{
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public class ConsultaCancelacionMatriculaViewModel
    {
         /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ConsultaCancelacionMatriculaViewModel()
        {
            this.TiposDocumento = new List<SelectListItem>();
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
        public IPagedList<ResultadoConsultaCancelacionMatriculaViewModel> Matriculas { get; set; }
    }
}