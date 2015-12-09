namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    public partial class PeriodoParametrizacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public PeriodoParametrizacion()
        {
            this.AperturaExtemporaneaPeriodos = new HashSet<AperturaExtemporaneaPeriodo>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de periodo.
        /// </summary>
        public byte Periodo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio del periodo.
        /// </summary>
        public DateTime FechaInicial { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha fin del periodo.
        /// </summary>
        public DateTime FechaFinal { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la parametrizacion escolar asociada.
        /// </summary>
        public int IdParametrizacionEscolar { get; set; }

        /// <summary>
        /// Obtiene o establece las aperturas que pueda tener el periodo.
        /// </summary>
        public virtual ICollection<AperturaExtemporaneaPeriodo> AperturaExtemporaneaPeriodos { get; set; }

        /// <summary>
        /// Obtiene o establece la parametrizacion escolar asociada.
        /// </summary>
        public virtual ParametrizacionEscolar ParametrizacionEscolar { get; set; }
    }
}