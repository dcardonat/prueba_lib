namespace Libellus.Entidades
{
    using System.Collections.Generic;

    /// <summary>
    /// Define la información de la tabla SoportePorRolesDocumentos.
    /// </summary>
    public partial class SoportePorRolesDocumento
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public SoportePorRolesDocumento()
        {
            this.DocentesDocumentosSoporte = new HashSet<DocenteDocumentoSoporte>();
            this.MatriculaDocumentosSoporte = new HashSet<MatriculasDocumentos>();
        }

        /// <summary>
        /// Obtiene o establece el identificador de la clase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador 
        /// </summary>
        public int IdSoportePorRoles { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del documento asociado.
        /// </summary>
        public int IdTipoDocumentoSoporte { get; set; }

        /// <summary>
        /// Referencia al Maestro del documento asociado.
        /// </summary>
        public virtual Maestro TipoDocumentoSoporte { get; set; }

        /// <summary>
        /// Referencia al soporte por rol asociado.
        /// </summary>
        public virtual SoportePorRol SoportePorRol { get; set; }

        /// <summary>
        /// Referencia a los documentos de soporte por docente.
        /// </summary>
        public virtual ICollection<DocenteDocumentoSoporte> DocentesDocumentosSoporte { get; set; }

        /// <summary>
        /// Referencia a los documentos de soporte matricula.
        /// </summary>
        public virtual ICollection<MatriculasDocumentos> MatriculaDocumentosSoporte { get; set; }
    }
}
