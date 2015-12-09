namespace Libellus.Entidades.TiposComplejos
{
    /// <summary>
    /// Define la información que retorna el procedimiento almacenado ConsultarDocumentosSoportePorRolSeleccionados.
    /// </summary>
    public class DocumentoSoportePorRolSeleccionado
    {
        /// <summary>
        /// Obtiene o establece el identificador interno del documento de soporte asociado al docente.
        /// </summary>
        public int? IdDocenteDocumentoSoporte { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del documento de soporte.
        /// </summary>
        public int IdSoportePorRolDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del documento de soporte.
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Obtiene o establece si fue recibido el documento por parte del docente.
        /// </summary>
        public bool Recibido { get; set; }
    }
}
