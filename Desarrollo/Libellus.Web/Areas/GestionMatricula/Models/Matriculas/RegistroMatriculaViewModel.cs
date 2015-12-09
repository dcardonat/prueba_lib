namespace Libellus.Web.Areas.GestionMatricula.Models.Matriculas
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase para el registro de matrícula. 
    /// </summary>
    public class RegistroMatriculaViewModel
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public RegistroMatriculaViewModel()
        {
            this.Documentos = new List<DocumentosMatriculaViewModels>();
        }

        /// <summary>
        /// Obtiene o establece el año.
        /// </summary>
        [Display(Name = "Año")]
        public short Anio { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estudiante.
        /// </summary>
        [Display(Name = "Estudiante")]
        public string Estudiante { get; set; }

        /// <summary>
        /// Identificador del estudiante.
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de documento.
        /// </summary>
        [Display(Name = "Tipo de documento")]
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Obtiene establece el documento de identidad.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o estabblece el nivel educativo.
        /// </summary>
        [Display(Name = "Nivel educativo")]
        public string NivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el grado al que aspira.
        /// </summary>
        [Display(Name = "Grado al que aspira")]
        public string GradoAspira { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la matricula.
        /// </summary>
        [Display(Name = "Estado estudiante")]
        public string EstadoMatricula { get; set; }

        /// <summary>
        /// Obtiene o establece el traslado.
        /// </summary>
        [Display(Name = "Traslado")]
        public string Traslado { get; set; }

        /// <summary>
        /// Obtiene o establece Cantidad actual de estudiantes matriculados en el grado
        /// </summary>
        [Display(Name = "Estudiantes matriculados en el grado")]
        public string CantidadActualMatriculadosGrado { get; set; }

        /// <summary>
        /// Obtiene o establece los documentos.
        /// </summary>
        public List<DocumentosMatriculaViewModels> Documentos { get; set; }

    }
}