namespace Libellus.Entidades
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la información del maestro SalidasOcupacionales.
    /// </summary>
    public partial class SalidaOcupacional
    {
        public SalidaOcupacional()
        {
            this.Cupos = new HashSet<Cupo>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descipción de la salida ocupacional.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la intensidad horaria dedicada al maestro.
        /// </summary>
        public short IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede asocada.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la salida ocupacional.
        /// </summary>
        public bool Estado { get; set; }
        
        /// <summary>
        /// Obtiene o establece la información de la sede relacionada.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene los cupos.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }
    }
}
