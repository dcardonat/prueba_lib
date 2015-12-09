namespace Libellus.Entidades
{
    using System.Collections.Generic;

    public partial class SoportePorRol
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public SoportePorRol()
        {
            this.Documentos = new HashSet<SoportePorRolesDocumento>();
            this.TiposDocumentosSeleccionados = new List<int>();
        }

        /// <summary>
        /// Obtiene o establece el Identificador de la clase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el Año escolar.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol institucional.
        /// </summary>
        public int IdRolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel educativo.
        /// </summary>
        public int? IdNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del objeto.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Referencia al año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Referencia el maestro Rol institucional.
        /// </summary>
        public virtual Maestro RolInstitucional { get; set; }

        /// <summary>
        /// Referencia al maestro Nivel educativo.
        /// </summary>
        public virtual Maestro NivelEducativo { get; set; }

        /// <summary>
        /// Referencia a la sede.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Referencia a los documentos asociados.
        /// </summary>
        public virtual ICollection<SoportePorRolesDocumento> Documentos { get; set; }

        /// <summary>
        /// Establece la lista de valores para los tipos de documentos por rol seleccionados.
        /// </summary>
        public List<int> TiposDocumentosSeleccionados { get; set; }
    }
}
