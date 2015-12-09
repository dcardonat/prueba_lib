namespace Libellus.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información del estado del docente.
    /// </summary>
    [Table("dbo.DocentesEstados")]
    public partial class DocenteEstado
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del docente.
        /// </summary>
        public int IdDocente { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estado del docente.
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Obtiene o establece las observaciones del por qué se inactiva el docente.
        /// </summary>
        public string ObservacionesEstado { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del horario del docente.
        /// </summary>
        public int IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información del horario establecido para el docente.
        /// </summary>
        public virtual Maestro Horario { get; set; }

        /// <summary>
        /// Obtiene o establece la información del estado del docente.
        /// </summary>
        public virtual Maestro Estado { get; set; }
    }
}
