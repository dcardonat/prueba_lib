namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase para la información de los estudiantes por grupo.
    /// </summary>
    public class EstudiantePorGrupo
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del estudiante.
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Identificador del grupo.
        /// </summary>
        public int IdGrupo { get; set; }

        /// <summary>
        /// Estudiante asociado.
        /// </summary>
        public virtual EstudianteDatosPersonales Estudiante { get; set; }

        /// <summary>
        /// Grupo asocuado.
        /// </summary>
        public virtual Grupo Grupo { get; set; }
    }
}
