namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Entidad para la información de los parametros de promoción.
    /// </summary>
    public class ParametroPromocion
    {
        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador de la sede. 
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Calificación minima.
        /// </summary>
        public int IdCalificacionMinima { get; set; }

        /// <summary>
        /// Calificación maxima.
        /// </summary>
        public int IdCalificacionMaxima { get; set; }

        /// <summary>
        /// Minimo areas reprobadas.
        /// </summary>
        public int MinimoAreasReprobadas { get; set; }

        /// <summary>
        /// Maximo de areas mejoramiento.
        /// </summary>
        public int MaximoAreasMejoramiento { get; set; }

        /// <summary>
        /// Minimo areas reprobación.
        /// </summary>
        public int MinimoAreaReprobacion { get; set; }

        /// <summary>
        /// Promedio de la promoción.
        /// </summary>
        public int PromedioPromocion { get; set; }

        /// <summary>
        /// Porcentaje de inasistencia.
        /// </summary>
        public decimal PorcentajeInasistencia { get; set; }

        /// <summary>
        /// Identificador de la evaluacion aprendizaje.
        /// </summary>
        public int IdEvaluacionAprendizaje { get; set; }

        /// <summary>
        /// Promedio ponderado.
        /// </summary>
        public bool PromedioPonderado { get; set; }

        /// <summary>
        /// Calificación minima para la aprobación.
        /// </summary>
        public decimal CalificacionMinimaAprobacion { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro EvaluacionAprendizaje { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro CalificacionMinima { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro CalificacionMaxima { get; set; }

        /// <summary>
        /// Sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }
    }
}
