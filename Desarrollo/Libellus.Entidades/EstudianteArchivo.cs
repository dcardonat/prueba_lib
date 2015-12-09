namespace Libellus.Entidades
{
    /// <summary>
    /// Representa los archivos adjuntos de información que puede tener un estudiante.
    /// </summary>
    public class EstudianteArchivo
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el logo para la institucion.
        /// </summary>
        public byte[] Foto { get; set; }

        /// <summary>
        /// Representa la relacion con los datos personales.
        /// </summary>
        public virtual EstudianteDatosPersonales DatosPersonales { get; set; }
    }
}