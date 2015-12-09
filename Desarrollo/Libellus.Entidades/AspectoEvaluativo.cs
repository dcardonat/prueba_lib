namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Entidad para la información de los aspectos evaluativos.
    /// </summary>
    public class AspectoEvaluativo
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Identificador del aspecto evaluativo.
        /// </summary>
        public int IdAspectoEvaluativo { get; set; }

        /// <summary>
        /// Intensidad horaria.
        /// </summary>
        public int IdIntensidadHoraria { get; set; }

        /// <summary>
        /// Porcentaje.
        /// </summary>
        public decimal Porcentaje { get; set; }

        /// <summary>
        /// Identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Pruebas minimas.
        /// </summary>
        public int PruebasMinimas { get; set; }

        /// <summary>
        /// Aspectos evaluativos.
        /// </summary>
        public virtual Maestro Evaluativo { get; set; }

        /// <summary>
        /// Intensidad Horaria.
        /// </summary>
        public virtual Maestro IntensidadHoraria { get; set; }

        /// <summary>
        /// Sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }
    }
}
