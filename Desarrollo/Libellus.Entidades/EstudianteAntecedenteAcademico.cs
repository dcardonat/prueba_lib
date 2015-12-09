namespace Libellus.Entidades
{
    public class EstudianteAntecedenteAcademico
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
        public string InstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del tipo de institucion.
        /// </summary>
        public int IdTipoInstitucion { get; set; }

        /// <summary>
        /// Obtiene o establece el Año.
        /// </summary>
        public int Anio { get; set; }

        /// <summary>
        /// Obtiene o establece  el identificador del grado.
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo de retiro.
        /// </summary>
        public int IdMotivoRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece la observación.
        /// </summary>
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