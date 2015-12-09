namespace Libellus.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de los archivos relacionados al docente.
    /// </summary>
    [Table("dbo.DocentesArchivos")]
    public partial class DocenteArchivo
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
        /// Obtiene o establece la foto del docente.
        /// </summary>
        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }

        /// <summary>
        /// Obtiene o establece la firma del docente.
        /// </summary>
        [Column(TypeName = "image")]
        public byte[] Firma { get; set; }

        /// <summary>
        /// Obtiene o establece los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }
    }
}
