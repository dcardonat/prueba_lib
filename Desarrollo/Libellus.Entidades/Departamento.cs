namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la informaci�n de los departamentos.
    /// </summary>
    [Table("dbo.Departamentos")]
    public partial class Departamento
    {
        /// <summary>
        /// Inicializa una nueva instancia de tipo Departamento.
        /// </summary>
        public Departamento()
        {
            Municipios = new HashSet<Municipio>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del pa�s asociado.
        /// </summary>
        public short IdPais { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del departamento.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la informaci�n del pa�s asociado.
        /// </summary>
        public virtual Pais Paises { get; set; }

        /// <summary>
        /// Obtiene o establece los municipios relacionados.
        /// </summary>
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
