namespace Libellus.Entidades
{
    using System.Collections.Generic;

    /// <summary>
    /// Clase que representa las aulas.
    /// </summary>
    public partial class Aula
    {
        /// <summary>
        /// Obtiene o establece el identificador del aula.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del aula.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro relacionado (Tipo Aula).
        /// </summary>
        public int IdMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede a la que pertenece el registro.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del registro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro relacionado (Tipo aula).
        /// </summary>
        public virtual Maestro Maestro { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la sede.
        /// </summary>
        public virtual Sede Sede { get; set; }
    }
}