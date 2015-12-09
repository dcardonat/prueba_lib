namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información a visualizar de la consulta del docente.
    /// </summary>
    public class ResultadoConsultaDocentesViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de documento.
        /// </summary>
        [Display(Name = "Tipo de documento")]
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad del docente.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres y apellidos del docente.
        /// </summary>
        [Display(Name = "Nombre")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del docente.
        /// </summary>
        public string Estado { get; set; }
    }
}