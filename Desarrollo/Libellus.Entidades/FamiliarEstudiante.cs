namespace Libellus.Entidades
{
    /// <summary>
    /// Representa la entidad.
    /// </summary>
    public class FamiliarEstudiante
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificacion del familiar.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Tipo de identificaion del familiar.
        /// </summary>
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Nombres del familiar.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Municipio donde vive el familiar.
        /// </summary>
        public short? IdMunicipio { get; set; }

        /// <summary>
        /// Direccion del familiar.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Barrio del familiar.
        /// </summary>
        public string Barrio { get; set; }

        /// <summary>
        /// Estrato del familiar.
        /// </summary>
        public int? IdEstrato { get; set; }

        /// <summary>
        /// Telefono del familiar.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Celular del familiar.
        /// </summary>
        public string Celular { get; set; }

        /// <summary>
        /// Correo del familiar.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Identificador del nivel de escolaridad.
        /// </summary>
        public int IdNivelEscolaridad { get; set; }

        /// <summary>
        /// Identificador el estado civil del familiar.
        /// </summary>
        public int? IdEstadoCivil { get; set; }

        /// <summary>
        /// Establece si es acudiente.
        /// </summary>
        public bool? EsAcudiente { get; set; }

        /// <summary>
        /// Establece si aun vive.
        /// </summary>
        public bool? Vive { get; set; }

        /// <summary>
        /// Identificador del parentesco del familiar.
        /// </summary>
        public int? IdParentesco { get; set; }

        /// <summary>
        /// Referencia al maestro estado civil.
        /// </summary>
        public virtual Maestro EstadoCivil { get; set; }

        /// <summary>
        /// Referencia al maestro Estrato.
        /// </summary>
        public virtual Maestro Estrato { get; set; }

        /// <summary>
        /// Referencia al municipio.
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// Referencia al maestro NivelEscolaridad.
        /// </summary>
        public virtual Maestro NivelEscolaridad { get; set; }

        /// <summary>
        /// Referencia al maestro Parentesco.
        /// </summary>
        public virtual Maestro Parentesco { get; set; }

        /// <summary>
        /// Referencia al maestro TipoIdentificacion.
        /// </summary>
        public virtual Maestro TipoIdentificacion { get; set; }
    }
}