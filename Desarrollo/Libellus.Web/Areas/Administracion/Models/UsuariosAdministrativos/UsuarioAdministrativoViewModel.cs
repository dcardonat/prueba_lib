namespace Libellus.Web.Areas.Administracion.Models.UsuariosAdministrativos
{
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Define un view model para los usuarios administrativos.
    /// </summary>
    public class UsuarioAdministrativoViewModel
    {
        /// <summary>
        /// Constructor de la clase UsuarioAdministrativoViewModel
        /// </summary>
        public UsuarioAdministrativoViewModel()
        {
            this.ModeloRegistrarUsuario = new UsuarioViewModel();
        }

        /// <summary>
        /// Obtiene o establece el id del usuario administrativo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [StringLength(50, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [StringLength(30, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo para realizar el registro del usuario.
        /// </summary>
        public UsuarioViewModel ModeloRegistrarUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el télefono del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [StringLength(10, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Display(Name = "Teléfono fijo")]
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el id del grupo sanguineo del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Grupo sanguíneo")]
        public int IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del docente.
        /// </summary>
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el id del cargo del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Cargo")]
        public int? IdCargo { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del usuario administrativo.
        /// </summary>
        [StringLength(50, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el número de celular del usuario administrativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [StringLength(15, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Display(Name = "Teléfono celular")]
        public string Celular { get; set; }

        /// <summary>
        /// Obtiene o establece los grupos sanguineos que pueden ser asociados al usuario administrativo.
        /// </summary>
        public IEnumerable<SelectListItem> GruposSanguineos { get; set; }

        /// <summary>
        /// Obtiene o establece los cargos que pueden ser asociados al usuario administrativo.
        /// </summary>
        public IEnumerable<SelectListItem> Cargos { get; set; }
    }
}