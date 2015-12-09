namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la informaci�n de los pa�ses.
    /// </summary>
    [Table("dbo.Paises")]
    public partial class Pais
    {
        /// <summary>
        /// Inicializa una instancia de tipo Pais.
        /// </summary>
        public Pais()
        {
            this.Departamentos = new HashSet<Departamento>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del pa�s.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la informaci�n de los departamentos asociados.
        /// </summary>
        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
