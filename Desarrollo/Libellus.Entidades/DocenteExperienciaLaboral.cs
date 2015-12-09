namespace Libellus.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de la experiencia laboral del docente.
    /// </summary>
    [Table("dbo.DocentesExperienciaLaboral")]
    public partial class DocenteExperienciaLaboral
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del docente.
        /// </summary>
        public int IdDocente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la institucion o empresa en la que labora o laboró.
        /// </summary>
        public string NombreInstitucion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de ingreso de la institucion o empresa en la que labora o laboró.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// Obtiene o establece fecha de retiro de la institucion o empresa en la que labora o laboró.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? FechaRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo del retiro de la institucion o empresa en la que labora o laboró.
        /// </summary>
        public string MotivoRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece las áreas de competencia del docente.
        /// </summary>
        public string AreasCompetencia { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }
    }
}
