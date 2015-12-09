namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    using Libellus.Entidades;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representa el modelo para la vista de antecedentes academicos.
    /// </summary>
    public class AntecedentesAcademicosViewModel
    {
        /// <summary>
        /// Identificador del antecedente academico.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del estudiante.
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el Nombre de la institucion educativa.
        /// </summary>
        [Display(Name = "Institución educativa")]
        public string InstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del tipo de institucion.
        /// </summary>
        [Display(Name = "Tipo de institución")]
        public int IdTipoInstitucion { get; set; }

        /// <summary>
        /// Obtiene o establece el Año.
        /// </summary>
        [Display(Name = "Año")]
        public int Anio { get; set; }

        /// <summary>
        /// Obtiene o establece  el identificador del grado.
        /// </summary>
        [Display(Name = "Grado")]
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo de retiro.
        /// </summary>
        [Display(Name = "Motivo de retiro")]
        public int IdMotivoRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece la observación.
        /// </summary>
        [Display(Name = "Observaciones")]
        public string Observacion { get; set; }

        /// <summary>
        /// Referencia al estudiante.
        /// </summary>
        public virtual EstudianteDatosPersonales Estudiante { get; set; }

        /// <summary>
        /// Referencia al maestro tipo institución.
        /// </summary>
        public virtual Maestro TipoInstitucion { get; set; }

        /// <summary>
        /// Referencia al maestro Grados
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// Referencia al maestro Motivos retiro.
        /// </summary>
        public virtual Maestro MotivoRetiro { get; set; }
    }
}