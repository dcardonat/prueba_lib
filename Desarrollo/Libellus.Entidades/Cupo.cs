using System.Collections.Generic;
namespace Libellus.Entidades
{
    /// <summary>
    /// Representa el cupo generado para un estudiante.
    /// </summary>
    public class Cupo
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Cupo()
        {
            this.Matriculas = new HashSet<Matricula>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estudiante.
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el grado por nivel.
        /// </summary>
        public int IdGradoPorNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel de profundización.
        /// </summary>
        public int? IdProfundizacion { get; set; }

        /// <summary>
        /// Obtiene o establece la salida ocupacional.
        /// </summary>
        public int? IdSalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de estudiante.
        /// </summary>
        public int IdTipoEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece si un estudiante es trasladado o no.
        /// </summary>
        public bool TrasladoEstudiante { get; set; }

        /// <summary>
        /// Referencia a los datos personales del estudiante.
        /// </summary>
        public virtual EstudianteDatosPersonales Estudiante { get; set; }

        /// <summary>
        /// Referencia al año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Referencia al grado por nivel.
        /// </summary>
        public virtual GradosPorNivel GradoPorNivel { get; set; }

        /// <summary>
        /// Referencia a la sede del registro.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Referencia al tipo de estudiante (Nuevo, Antiguo).
        /// </summary>
        public virtual Maestro TipoEstudiante { get; set; }

        /// <summary>
        /// Referencia a la salida ocupacional.
        /// </summary>
        public virtual SalidaOcupacional SalidaOcupacional { get; set; }

        /// <summary>
        /// Listado de matriculas,
        /// </summary>
        public virtual ICollection<Matricula> Matriculas { get; set; }

        /// <summary>
        /// Referencia al nivel de profundizacion.
        /// </summary>
        public virtual Maestro Profundizacion { get; set; }
    }
}