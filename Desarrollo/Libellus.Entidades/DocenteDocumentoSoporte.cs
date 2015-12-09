namespace Libellus.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de los documentos de soporte del docente.
    /// </summary>
    public partial class DocenteDocumentoSoporte
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
        /// Obtiene o establece el identificador interno del documento de soporte.
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente.
        /// </summary>
        public virtual DocenteDatosPersonales DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los documentos de soporte.
        /// </summary>
        public virtual SoportePorRolesDocumento SoportePorRolesDocumentos { get; set; }
    }
}
