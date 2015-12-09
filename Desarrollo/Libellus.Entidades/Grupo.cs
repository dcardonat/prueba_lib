namespace Libellus.Entidades
{
    using System.Collections.Generic;

    /// <summary>
    /// Clase para representar los grupos de un año lectivo especifico.
    /// </summary>
    public class Grupo
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del grupo.
        /// </summary>
        public int IdGrupoPorGrado { get; set; }

        /// <summary>
        /// Identificador del año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Identificador del horario.
        /// </summary>
        public int IdHorario { get; set; }

        /// <summary>
        /// Año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Estudiante por grupo asociado.
        /// </summary>
        public virtual ICollection<EstudiantePorGrupo> EstudiantesPorGrupo { get; set; }

        /// <summary>
        /// Grupos por grado.
        /// </summary>
        public virtual GruposPorGrado GruposPorGrado { get; set; }

        /// <summary>
        /// Horario asociado.
        /// </summary>
        public virtual Maestro Horario { get; set; }
    }
}
