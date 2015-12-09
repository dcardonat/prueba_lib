namespace Libellus.Entidades
{
    public partial class AreaNivel
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del maestro Areas.
        /// </summary>
        public int IdArea { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel de parametrizacion.
        /// </summary>
        public int IdNivelParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el maestro Area.
        /// </summary>
        public virtual Maestro Area { get; set; }

        /// <summary>
        /// Obtiene o establece el Nivel de parametrizacion.
        /// </summary>
        public virtual NivelParametrizacion NivelParametrizacion { get; set; }
    }
}