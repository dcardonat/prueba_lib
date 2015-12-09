namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Exito.Sime.Web.Attributes;
    using Libellus.Mensajes;
    using Libellus.Web.Attributes;

    /// <summary>
    /// Define la información de los datos personales del docente.
    /// </summary>
    public class DatosPersonalesViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de tipo DatosPersonalesViewModel.
        /// </summary>
        public DatosPersonalesViewModel()
        {
            this.TiposDocumento = new List<SelectListItem>();
            this.Sexos = new List<SelectListItem>();
            this.GrupoSanguineo = new List<SelectListItem>();
            this.EstadosCiviles = new List<SelectListItem>();
            this.Paises = new List<SelectListItem>();
            this.Departamentos = new List<SelectListItem>();
            this.Municipios = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno del tipo de documento de identidad.
        /// </summary>
        [Display(Name = "Tipo de documento de identidad")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de documento existentes.
        /// </summary>
        public List<SelectListItem> TiposDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad del docente.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres del docente.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos del docente.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del sexo del docente.
        /// </summary>
        [Display(Name = "Sexo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece los sexos existentes.
        /// </summary>
        public List<SelectListItem> Sexos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del grupo sanguíneo del docente.
        /// </summary>
        [Display(Name = "Grupo sanguíneo")]
        public int? IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece los grupos sanguíneos existentes.
        /// </summary>
        public List<SelectListItem> GrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estado civil del docente.
        /// </summary>
        [Display(Name = "Estado civil")]
        public int? IdEstadoCivil { get; set; }

        /// <summary>
        /// Obtiene o establece los estados civiles existentes.
        /// </summary>
        public List<SelectListItem> EstadosCiviles { get; set; }

        /// <summary>
        /// Obtiene o establece el rol insitucional del docente.
        /// </summary>
        [Display(Name = "Rol institucional")]
        public string RolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del rol insitucional del docente.
        /// </summary>
        public int IdRolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del docente.
        /// </summary>
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MayoriaEdadAttribute(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1014")]
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico personal del docente.
        /// </summary>
        [Display(Name = "Correo electrónico")]
        [EmailAttribute(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del país de nacimiento del docente.
        /// </summary>
        [Display(Name = "País de nacimiento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdPaisNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece los países existentes.
        /// </summary>
        public List<SelectListItem> Paises { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del departamento de nacimiento del docente.
        /// </summary>
        [Display(Name = "Departamento de nacimiento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdDepartamentoNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece los departamentos existentes.
        /// </summary>
        public List<SelectListItem> Departamentos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del municipio de nacimiento del docente.
        /// </summary>
        [Display(Name = "Municipio de nacimiento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdMunicipioNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece los municipio existentes.
        /// </summary>
        public List<SelectListItem> Municipios { get; set; }

        /// <summary>
        /// Obtiene o establece el grado en el escalafón.
        /// </summary>
        [Display(Name = "Grado en el escalafón")]
        public int? IdEscalafon { get; set; }

        /// <summary>
        /// Obtiene o establece los posibles grados en el escalafón.
        /// </summary>
        public List<SelectListItem> Escalafones { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción de la escalafón.
        /// </summary>
        public short Escalafon { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha del último ascenso.
        /// </summary>
        [Display(Name = "Fecha último ascenso")]
        public string FechaUltimoAscenso { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta de la foto del docente.
        /// </summary>
        [Display(Name = "Foto")]
        public string RutaFotoDocente { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta de la firma del docente.
        /// </summary>
        [Display(Name = "Firma")]
        public string RutaFirmaDocente { get; set; }
    }
}