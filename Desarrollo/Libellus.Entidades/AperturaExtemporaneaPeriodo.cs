namespace Libellus.Entidades
{
    using System;

    public partial class AperturaExtemporaneaPeriodo
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del periodo de la apertura.
        /// </summary>
        public int IdPeriodo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha inicial de la apertura.
        /// </summary>
        public DateTime FechaInicial { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha final de la apertura.
        /// </summary>
        public DateTime FechaFinal { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo de la apertura del periodo.
        /// </summary>
        public string MotivoApertura { get; set; }

        /// <summary>
        /// Obtiene o establece el periodo de la apertura.
        /// </summary>
        public virtual PeriodoParametrizacion PeriodoParametrizacion { get; set; }
    }
}