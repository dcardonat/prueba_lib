namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de los tipos de maestro administrables.
    /// </summary>
    [Table("dbo.TipoMaestros")]
    public partial class TipoMaestro
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public TipoMaestro()
        {
            Maestros = new HashSet<Maestro>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        [Key]
        public short Id { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de maestro.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece si el maestro es administrable o no.
        /// </summary>
        public bool Administrable { get; set; }

        /// <summary>
        /// Obtiene o establece la relación de los registros asociados al tipo de maestro.
        /// </summary>
        public virtual ICollection<Maestro> Maestros { get; set; }
    }
}
