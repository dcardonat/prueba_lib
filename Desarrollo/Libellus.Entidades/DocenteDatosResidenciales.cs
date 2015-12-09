namespace Libellus.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define los datos residenciales del docente.
    /// </summary>
    [Table("dbo.DocentesDatosResidenciales")]
    public partial class DocenteDatosResidenciales
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
        /// Obtiene o establece la dirección de residencia.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el barrio de residencia.
        /// </summary>
        public string Barrio { get; set; }

        /// <summary>
        /// Obtiene o establece el estrato de vivienda.
        /// </summary>
        public int IdEstrato { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio de residencia.
        /// </summary>
        public short IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el teléfono de residencia.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el teléfono móvil.
        /// </summary>
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Obtiene o establece los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información del estrato de residencia del docente.
        /// </summary>
        public virtual Maestro Estrato { get; set; }

        /// <summary>
        /// Obtiene o establece la información del municipio de residencia.
        /// </summary>
        public virtual Municipio Municipio { get; set; }
    }
}
