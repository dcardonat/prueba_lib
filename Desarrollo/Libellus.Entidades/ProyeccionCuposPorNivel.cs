namespace Libellus.Entidades
{
    /// <summary>
    /// Define la información de los grupos por nivel.
    /// </summary>
    public class ProyeccionCuposPorNivel
    {
        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Identificador del nivel.
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        /// Numero de estudiantes por grupo.
        /// </summary>
        public int EstudiantesGrupo { get; set; }

        /// <summary>
        /// Numero de estudiantes esperados por nivel y grupo.
        /// </summary>
        public int EstudiantesEsperados { get; set; }

        /// <summary>
        /// cantidad de grupo.
        /// </summary>
        public int CantidadGrupos { get; set; }

        /// <summary>
        /// Cantidad de docentes.
        /// </summary>
        public decimal CantidadDocentes { get; set; }

        /// <summary>
        /// Identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Nivel asociado a la configuración.
        /// </summary>
        public virtual Maestro NivelEducativo { get; set; }

        /// <summary>
        /// Sede de la configuración.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }
    }
}
