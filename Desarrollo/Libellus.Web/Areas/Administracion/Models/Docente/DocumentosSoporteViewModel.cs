namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using Libellus.Entidades;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información de los documentos de soporte asociados al docente.
    /// </summary>
    public class DocumentosSoporteViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del documento de soporte.
        /// </summary>
        [Display(Name = "Documento de soporte")]
        public Maestro Documento { get; set; }

        /// <summary>
        /// Obtiene o establece si el documento fue o no recibido.
        /// </summary>
        [Display(Name = "Recibido")]
        public bool Recibido { get; set; }
    }
}