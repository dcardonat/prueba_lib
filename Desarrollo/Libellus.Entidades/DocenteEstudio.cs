namespace Libellus.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de los estudio del docente.
    /// </summary>
    [Table("dbo.DocentesEstudios")]
    public partial class DocenteEstudio
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
        /// Obtiene o establece el nombre de la institución educativa donde realizó el estudio.
        /// </summary>
        public string InstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece el título otorgado.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la clasificación del estudio.
        /// </summary>
        public int IdClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de terminación del estudio.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? FechaTerminacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del estudio.
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información de la clasificación del estudio.
        /// </summary>
        public virtual Maestro Clasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del estudio.
        /// </summary>
        public virtual Maestro EstadoEstudio { get; set; }
    }
}
