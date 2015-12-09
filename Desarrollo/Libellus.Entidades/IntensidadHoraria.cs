namespace Libellus.Entidades
{
    public partial class IntensidadHoraria
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el anio escolar del registro.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la asignatura.
        /// </summary>
        public int IdAsignatura { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del grado.
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece las intensidad horaria por semana.
        /// </summary>
        public byte HorasSemana { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede a la cual pertenence el registro.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Referencia al año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la asignatura asociada.
        /// </summary>
        public virtual Asignatura Asignatura { get; set; }

        /// <summary>
        /// Obtiene o establece el grado asociado.
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// Obtiene o establece la sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }
    }
}