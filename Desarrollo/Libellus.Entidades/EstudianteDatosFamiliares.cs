namespace Libellus.Entidades
{
    public class EstudianteDatosFamiliares
    {
        /// <summary>
        /// Identificador del estudiante.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del padre.
        /// </summary>
        public int? IdPadre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la madre.
        /// </summary>
        public int? IdMadre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del acudiente.
        /// </summary>
        public int IdAcudiente { get; set; }

        /// <summary>
        /// Obtiene o establece si se ha checkeado la casilla del padre.
        /// </summary>
        public bool TienePadre { get; set; }

        /// <summary>
        /// Obtiene o establece si se ha checkeado la casilla de la madre.
        /// </summary>
        public bool TieneMadre { get; set; }

        /// <summary>
        /// Referencia del estudiante.
        /// </summary>
        public virtual EstudianteDatosPersonales Estudiante { get; set; }

        /// <summary>
        /// Referencia del padre.
        /// </summary>
        public virtual FamiliarEstudiante Padre { get; set; }

        /// <summary>
        /// Referencia de la madre.
        /// </summary>
        public virtual FamiliarEstudiante Madre { get; set; }

        /// <summary>
        /// Referencia del acudiente.
        /// </summary>
        public virtual FamiliarEstudiante Acudiente { get; set; }
    }
}