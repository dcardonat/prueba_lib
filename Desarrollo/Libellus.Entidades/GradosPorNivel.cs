namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la información de los grados por nivel.
    /// </summary>
    public partial class GradosPorNivel
    {
        public GradosPorNivel()
        {
            this.Cupos = new HashSet<Cupo>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del nivel.
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del grado.
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece la información del nivel.
        /// </summary>
        public virtual Maestro Nivel { get; set; }

        /// <summary>
        /// Obtiene o establece la información del grado.
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// Obtiene los cupos.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }

    }
}
