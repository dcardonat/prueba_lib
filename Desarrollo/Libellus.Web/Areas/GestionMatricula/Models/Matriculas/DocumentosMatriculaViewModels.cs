namespace Libellus.Web.Areas.GestionMatricula.Models.Matriculas
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Enntidad para el manejo del documento para soporte de matrícula.  
    /// </summary>
    public class DocumentosMatriculaViewModels
    {
        /// <summary>
        /// Obtiene o establece el id del registro. 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Obtiene o establece el id del  matricula.
        /// </summary>
        public int? IdMatricula { get; set; }

        /// <summary>
        /// Obtiene o establece el id del documento.
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del documento.
        /// </summary>
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        /// <summary>
        /// Obtiene o establece si el documento ha sido recibido.
        /// </summary>
        [Display(Name = "Recibido")]
        public bool Recibido { get; set; }
    }
}