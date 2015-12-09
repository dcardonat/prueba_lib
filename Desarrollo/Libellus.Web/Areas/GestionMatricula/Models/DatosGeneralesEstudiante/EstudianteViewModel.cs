namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Representa al modelo Estudiante.
    /// </summary>
    public class EstudianteViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public EstudianteViewModel()
        {
            this.AntecedentesAcademicos = new List<AntecedentesAcademicosViewModel>();
            this.DatosFamiliares = new DatosFamiliaresViewModel();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estudiante.
        /// </summary>
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene el nombre completo del estudiante.
        /// </summary>
        [Display(Name = "Estudiante")]
        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Nombre, this.PrimerApellido, this.SegundoApellido);
            }
        }

        /// <summary>
        /// Obtiene o establece el primer apellido del estudiante.
        /// </summary>
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        /// <summary>
        /// Obtiene o establece el segundo apellido del estudiante.
        /// </summary>
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del estudiante.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece Id de relacion del maestro sexo.
        /// </summary>
        [Display(Name = "Sexo")]
        public int IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del maestro de grupo sanguineo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Grupo sanguíneo")]
        public int? IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estado del estudiante.
        /// </summary>
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        /// <summary>
        /// Identificador de la eps.
        /// </summary>
        [Display(Name = "Entidad prestadora de salud")]
        public int? IdEntidadPromotoraSalud { get; set; }

        /// <summary>
        /// Identificador del pais de nacimiento.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "País de nacimiento")]
        public int IdPaisNacimiento { get; set; }

        /// <summary>
        /// Identificador del pais de nacimiento.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Departamento de nacimiento")]
        public int IdDepartamentoNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del municipio de nacimiento.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Municipio de nacimiento")]
        public short IdMunicipioNacimiento { get; set; }

        public string MunicipioNacimiento { get; set; }
        public string DepartamentoNacimiento { get; set; }


        /// <summary>
        /// Identificador del pais.
        /// </summary>
        public int IdPais { get; set; }

        /// <summary>
        /// Identificador del departamento.
        /// </summary>
        public int IdDepartamento { get; set; }

        /// <summary>
        /// Identificador del municipio.
        /// </summary>
        public int IdMunicipio { get; set; }

        public string Departamento { get; set; }
        public string Municipio { get; set; }

        /// <summary>
        /// Identificador del pais del padre.
        /// </summary>
        public int IdPaisPadre { get; set; }

        /// <summary>
        /// Departamento del padre.
        /// </summary>
        public int IdDepartamentoPadre { get; set; }

        /// <summary>
        /// Municipio del padre.
        /// </summary>
        public int IdMunicipioPadre { get; set; }

        public string DepartamentoPadre { get; set; }
        public string MunicipioPadre { get; set; }

        /// <summary>
        /// Pais de la madre.
        /// </summary>
        public int IdPaisMadre { get; set; }

        /// <summary>
        /// Departamento de la madre.
        /// </summary>
        public int IdDepartamentoMadre { get; set; }

        /// <summary>
        /// Municipio de la madre.
        /// </summary>
        public int IdMunicipioMadre { get; set; }

        public string DepartamentoMadre { get; set; }
        public string MunicipioMadre { get; set; }

        /// <summary>
        /// Estado del estudiante.
        /// </summary>
        public virtual Maestro Estado { get; set; }

        /// <summary>
        /// Foto del estudiante.
        /// </summary>
        [Display(Name = "Foto")]
        public string UrlFoto { get; set; }

        /// <summary>
        /// Referencia al usuario.
        /// </summary>
        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual DatosResidencialesViewModel DatosResidenciales { get; set; }

        public virtual DatosEstadoViewModel DatosEstado { get; set; }

        public virtual DatosFamiliaresViewModel DatosFamiliares { get; set; }

        public virtual IEnumerable<AntecedentesAcademicosViewModel> AntecedentesAcademicos { get; set; }

        public IEnumerable<SelectListItem> ComboTiposIdentificacion { get; set; }

        public IEnumerable<SelectListItem> ComboSexos { get; set; }

        public IEnumerable<SelectListItem> ComboGruposSanguineos { get; set; }

        public IEnumerable<SelectListItem> ComboPaises { get; set; }

        public IEnumerable<SelectListItem> ComboPaisesNacimiento { get; set; }

        public IEnumerable<SelectListItem> ComboEstratos { get; set; }

        public IEnumerable<SelectListItem> ComboTipoInstitucion { get; set; }

        public IEnumerable<SelectListItem> ComboGrados { get; set; }

        public IEnumerable<SelectListItem> ComboMotivosRetiro { get; set; }

        public IEnumerable<SelectListItem> ComboEPS { get; set; }

        public IEnumerable<SelectListItem> ComboEstadosCivil { get; set; }

        public IEnumerable<SelectListItem> ComboNivelesEscolaridad { get; set; }

        public IEnumerable<SelectListItem> ComboParentesco { get; set; }
    }
}