namespace Libellus.Web.Areas.Administracion.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información a visualizar en la vista de sedes.
    /// </summary>
    public class SedesViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la sede.
        /// </summary>
        [Display(Name = "Sedes")]
        public string Nombre { get; set; }
    }
}