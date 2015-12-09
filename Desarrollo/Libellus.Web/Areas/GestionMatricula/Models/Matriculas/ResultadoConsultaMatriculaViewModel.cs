namespace Libellus.Web.Areas.GestionMatricula.Models.Matriculas
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model para el resultado de la consulta de matriculas.
    /// </summary>
    public class ResultadoConsultaMatriculaViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del cupo.
        /// </summary>
        public int IdCupo { get; set; }

        /// <summary>
        /// Obtiene o establece el año.
        /// </summary>
        public int IdAnio { get; set; }

        /// <summary>
        /// Obtiene o establece el año.
        /// </summary>
        [Display(Name = "Año")]
        public short Anio { get; set; }

        /// <summary>
        /// obtien o estabblece si el año esta cerrado.
        /// </summary>
        public bool AnioCerrado { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de documento.
        /// </summary>
        public int IdTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de documento.
        /// </summary>
        [Display(Name = "Tipo documento")]
        public string TipoDocumento { get; set; }

        // <summary>
        /// Obtiene o establece el documento de identidad.
        /// </summary>
        [Display(Name = "Documento identidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres y apellidos.
        /// </summary>
        [Display(Name = "Estudiante")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel educativo.
        /// </summary>
        [Display(Name = "Nivel educativo")]
        public string NivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece grado al que aspira.
        /// </summary>
        [Display(Name = "Grado al que aspira")]
        public string Grado { get; set; }

        /// <summary>
        /// Obtiene o establece la salida ocupacional.
        /// </summary>
        [Display(Name = "Salida ocupacional")]
        public string SalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece el estado.
        /// </summary>
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el estado.
        /// </summary>
        public int Consecutivo { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la matricula.
        /// </summary>
        public int IdEstadoMatricula { get; set; }
    }
}