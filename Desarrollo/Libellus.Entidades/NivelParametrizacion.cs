namespace Libellus.Entidades
{
    using System.Collections.Generic;

    public partial class NivelParametrizacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public NivelParametrizacion()
        {
            this.AreasNivel = new HashSet<AreaNivel>();
        }

        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel asociado.
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la parametrizacion escolar.
        /// </summary>
        public int IdParametrizacionEscolar { get; set; }

        /// <summary>
        /// Obtiene o establece las areas por nivel.
        /// </summary>
        public virtual ICollection<AreaNivel> AreasNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el maestro nivel asociado.
        /// </summary>
        public virtual Maestro Nivel { get; set; }

        /// <summary>
        /// Obtiene o establece la parametrizacion escolar asociada.
        /// </summary>
        public virtual ParametrizacionEscolar ParametrizacionEscolar { get; set; }
    }
}