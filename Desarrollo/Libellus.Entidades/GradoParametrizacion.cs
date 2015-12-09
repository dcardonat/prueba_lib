namespace Libellus.Entidades
{
    public partial class GradoParametrizacion
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la parametrizacion.
        /// </summary>
        public int IdParametrizacionEscolar { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del grado.
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece el maestro grado asociado.
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// Obtiene o establece la parametrizacion escolar asociada.
        /// </summary>
        public virtual ParametrizacionEscolar ParametrizacionEscolar { get; set; }
    }
}