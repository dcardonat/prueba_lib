namespace Libellus.Entidades
{
    using System;

    /// <summary>
    /// Define la informaci�n de la tabla ParametrizacionInstitucional.
    /// </summary>
    public partial class ParametrizacionInstitucional
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede asociada.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece identificador del a�o lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del horario.
        /// </summary>
        public int IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del nivel educativo.
        /// </summary>
        public int IdNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el horario inicial establecido.
        /// </summary>
        public TimeSpan HoraInicial { get; set; }

        /// <summary>
        /// Obtiene o establece el horario final establecido.
        /// </summary>
        public TimeSpan HoraFinal { get; set; }

        /// <summary>
        /// Obtiene o establece los momentos semanales.
        /// </summary>
        public byte MomentosSemana { get; set; }

        /// <summary>
        /// Obtiene o establece los tiempos (minutos) de descansos.
        /// </summary>
        public int TiempoDescansos { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la parametrizaci�n.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la duraci�n de los momentos en minutos.
        /// </summary>
        public short DuracionMomentos { get; set; }

        /// <summary>
        /// Obtiene o establece los momentos del docente en minutos.
        /// </summary>
        public short MomentosDocente { get; set; }
            
        /// <summary>
        /// Obtiene o establece la informaci�n de la sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece la informaci�n del nivel educativo asociado.
        /// </summary>
        public virtual Maestro NivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece la informaci�n del horario asociado.
        /// </summary>
        public virtual Maestro Horario { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del a�o lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }
    }
}
