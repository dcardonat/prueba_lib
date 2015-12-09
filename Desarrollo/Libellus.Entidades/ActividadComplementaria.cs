namespace Libellus.Entidades
{
    public partial class ActividadComplementaria
    {
        /// <summary>
        /// Obtiene o establece el Identificador del objeto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la actividad.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la intensidad horaria de la actividad.
        /// </summary>
        public short IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del registro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el objeto sede relacionado.
        /// </summary>
        public virtual Sede Sede { get; set; }
    }
}