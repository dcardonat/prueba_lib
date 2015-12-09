namespace Libellus.Web.Areas.Administracion.Models.ParametrizacionEscolar
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representa el modelo para periodos.
    /// </summary>
    public class PeriodoViewModel
    {
        /// <summary>
        /// Obtiene o establece la fecha final de la apertura.
        /// </summary>
        public string FechaAperturaFinal { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha inicial de la apertura.
        /// </summary>
        public string FechaAperturaInicial { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha fin del periodo.
        /// </summary>
        [Display(Name = "Fecha final")]
        public DateTime FechaFinal { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio del periodo.
        /// </summary>
        [Display(Name = "Fecha inicial")]
        public DateTime FechaInicial { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la parametrizacion escolar asociada.
        /// </summary>
        public int IdParametrizacionEscolar { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo de la apertura.
        /// </summary>
        public string MotivoApertura { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de periodo.
        /// </summary>
        public byte Periodo { get; set; }

        /// <summary>
        /// Obtiene o establece si el periodo tiene una configuracion de apertura extraordinaria.
        /// </summary>
        public bool TieneApertura { get; set; }
    }
}