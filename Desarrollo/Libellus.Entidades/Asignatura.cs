namespace Libellus.Entidades
{
    using System.Collections.Generic;

    public partial class Asignatura
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public Asignatura()
        {
            IntensidadesHorarias = new HashSet<IntensidadHoraria>();
        }

        /// <summary>
        /// Obtiene o establece el identificador de la asignatura.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del aula.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del maestro relacionado (Area).
        /// </summary>
        public int IdMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece la sede a la que pertenece el registro.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del registro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (Area)
        /// </summary>
        public virtual Maestro Maestro { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion todal de la sede.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece las intensidades horarias asociadas.
        /// </summary>
        public virtual ICollection<IntensidadHoraria> IntensidadesHorarias { get; set; }
    }
}