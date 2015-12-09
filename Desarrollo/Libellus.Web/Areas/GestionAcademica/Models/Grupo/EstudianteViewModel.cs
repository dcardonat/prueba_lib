namespace Libellus.Web.Areas.GestionAcademica.Models.Grupo
{
    /// <summary>
    /// View model para la administración de estudiantes.
    /// </summary>
    public class EstudianteViewModel
    {
        /// <summary>
        /// Obtiene o establece el id del estudiante.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad de un estudiante.
        /// </summary>        
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel educativo.
        /// </summary>        
        public string Nombre { get; set; }
    }
}