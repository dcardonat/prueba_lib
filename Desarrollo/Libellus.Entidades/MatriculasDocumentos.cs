namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase para el manejo de la información de los documentos para la matricula.
    /// </summary>
    public class MatriculasDocumentos
    {
        /// <summary>
        /// Identificaodr del registro. 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del  de la matricula. 
        /// </summary>
        public int IdMatricula { get; set; }

        /// <summary>
        /// Identificador del documento asociado. 
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// Verifica si el documento ha sido seleccionado.
        /// </summary>
        [NotMapped]
        public bool Recibido { get; set; }

        /// <summary>
        /// Matricula asociiada.
        /// </summary>
        public virtual Matricula Matricula { get; set; }

        /// <summary>
        /// Documento para el soporte de la matricula.
        /// </summary>
        public virtual SoportePorRolesDocumento SoportePorRolesDocumentos { get; set; }
    }
}
