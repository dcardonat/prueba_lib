namespace Libellus.Entidades
{
    /// <summary>
    /// Representa los datos residenciales del estudiante.
    /// </summary>
    public class EstudianteDatosResidenciales
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del estudiante.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de relacion con el municipio.
        /// </summary>
        public short? IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el barrio donde reside.
        /// </summary>
        public string Barrio { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estrato de la vivienda.
        /// </summary>
        public int? IdEstrato { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono fijo.
        /// </summary>
        public string TelefonoFijo { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono movil.
        /// </summary>
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Representa la relacion con los datos personales.
        /// </summary>
        public virtual EstudianteDatosPersonales DatosPersonales { get; set; }

        /// <summary>
        /// Representa la relacion con el municipio.
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// Representa la relacion con el estrato.
        /// </summary>
        public virtual Maestro Estrato { get; set; }
    }
}