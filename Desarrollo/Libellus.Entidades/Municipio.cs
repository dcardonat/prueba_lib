namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de los municipios.
    /// </summary>
    [Table("dbo.Municipios")]
    public partial class Municipio
    {
        /// <summary>
        /// Inicializa una nueva instancia de tipo Municipio.
        /// </summary>
        public Municipio()
        {
            this.DocenteDatosPersonales = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosResidenciales = new HashSet<DocenteDatosResidenciales>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del departamento asociado.
        /// </summary>
        public short IdDepartamento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del municipio.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la información del departamento asociado.
        /// </summary>
        public virtual Departamento Departamentos { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales de los docentes relacionados.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos residenciales de los docentes asociados.
        /// </summary>
        public virtual ICollection<DocenteDatosResidenciales> DocenteDatosResidenciales { get; set; }
    }
}
