namespace Libellus.Web.Areas.Administracion.Models.DocumentacionSoporteRoles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    public class SoporteRolViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public SoporteRolViewModel()
        {
            this.Roles = new List<SelectListItem>();
            this.Niveles = new List<SelectListItem>();
            this.TiposDocumentosSeleccionados = new List<int>();
        }

        /// <summary>
        /// Obtiene o establece el Año escolar.
        /// </summary>
        [Display(Name = "Año")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del objeto.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador de la clase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel educativo.
        /// </summary>
        [Display(Name = "Nivel educativo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int? IdNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol institucional.
        /// </summary>
        [Display(Name = "Rol institucional")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdRolInstitucional { get; set; }

        /// <summary>
        /// Referencia al año lectivo.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Referencia al maestro Nivel educativo.
        /// </summary>
        public virtual Maestro NivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion para el combo de niveles educativos.
        /// </summary>
        public List<SelectListItem> Niveles { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion para el combo de roles institucionales.
        /// </summary>
        public List<SelectListItem> Roles { get; set; }

        /// <summary>
        /// Referencia el maestro Rol institucional.
        /// </summary>
        public virtual Maestro RolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion para el combo de los tipos de documentos.
        /// </summary>
        public List<SelectListItem> Documentos { get; set; }

        /// <summary>
        /// Establece la lista de valores para los tipos de documentos por rol seleccionados.
        /// </summary>
        [Display(Name = "Tipos de documentos")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public IEnumerable<int> TiposDocumentosSeleccionados { get; set; }

        /// <summary>
        /// Obtiene la cadena de valores de los grados que estan seleccionados.
        /// </summary>
        public string ValoresDocumentos
        {
            get
            {
                return string.Join(",", this.TiposDocumentosSeleccionados);
            }
        }
    }
}