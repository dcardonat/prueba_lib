namespace Libellus.Entidades
{
    /// <summary>
    /// Define la informacion para los rango de desempeño.
    /// </summary>
    public class RangosDesempenio
    {
        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador de desempeño evaluativo.
        /// </summary>
        public int IdDesempenio { get; set; }

        /// <summary>
        /// Calificación Máxima.
        /// </summary>
        public decimal NotaMaxima { get; set; }

        /// <summary>
        /// Calificación minima.
        /// </summary>
        public decimal NotaMinima { get; set; }

        /// <summary>
        /// Identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Identificador del año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Maestro desempeño evaluativo.
        /// </summary>
        public virtual Maestro DesempenioEvaluativo { get; set; }

        /// <summary>
        /// Sede asociadad al registro.
        /// </summary>
        public virtual Sede Sede { get; set; }
    }
}
