namespace Libellus.Web.Areas.Administracion.Models.CuposPorNivel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model Para la administración de la informacion de los cupos por nivel.
    /// </summary>
    public class CuposPorNivelViewModels
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Identificador del nivel.
        /// </summary>
        [Display(Name = "Identificador")]
        public int IdNivelEducativo { get; set; }

        /// <summary>
        /// Nivel asociado a la configuración.
        /// </summary>
        [Display(Name = "Nivel educativo")]
        public string NivelEducativo { get; set; }

        /// <summary>
        /// Numero de estudiantes por grupo.
        /// </summary>
        [Display(Name = "Estudiantes por grupo")]
        public int EstudiantesGrupo { get; set; }

        /// <summary>
        /// Numero de estudiantes esperados por nivel y grupo.
        /// </summary>
        [Display(Name = "Estudiantes esperados")]
        public int EstudiantesEsperados { get; set; }

        /// <summary>
        /// Calculo de cantidade de grupos.
        /// </summary>
        [Display(Name = "Cantidad de grupos")]
        public int CantidadGrupos { get; set; }

        /// <summary>
        /// Calculo de cantidad de docentes.
        /// </summary>
        [Display(Name = "cantidad de docentes")]
        public decimal CantidadDocentes { get; set; }

        /// <summary>
        /// Calculo de cantidad de docentes.
        /// </summary>
        [Display(Name = "Estudiantes matriculados")]
        public int? CantidadEstudiantesMatriculados { get; set; }

        /// <summary>
        /// Calculo del total de docentes.
        /// </summary>
        [Display(Name = "Total docentes")]
        public int? TotalDocentes { get; set; }

        /// <summary>
        /// Año del nivel educativo.
        /// </summary>
        [Display(Name = "Año")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Consecutivo del nivel educativo.
        /// </summary>
        public int? Consecutivo { get; set; }
    }
}