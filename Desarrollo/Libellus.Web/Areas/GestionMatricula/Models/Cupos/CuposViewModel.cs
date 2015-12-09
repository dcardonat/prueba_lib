namespace Libellus.Web.Areas.GestionMatricula.Models
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Entidad modelo para la vista de Cupos.
    /// </summary>
    public class CuposViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public CuposViewModel()
        {
            this.ComboGrado = new List<SelectListItem>();
            this.ComboNivelEducativo = new List<SelectListItem>();
            this.ComboSalidaOcupacional = new List<SelectListItem>();
            this.ComboTipoIdentificacion = new List<SelectListItem>();
            this.ComboSexo = new List<SelectListItem>();
            this.ComboAnios = new List<SelectListItem>();
            this.ComboProfundizacion = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estudiante.
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del año lectivo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año escolar")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel de profundización.
        /// </summary>
        [Display(Name = "Profundización")]
        public int? IdProfundizacion { get; set; }

        /// <summary>
        /// Obtiene o establece la salida ocupacional.
        /// </summary>
        [Display(Name = "Salida ocupacional")]
        public int? IdSalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el Ide
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Tipo documento")]
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la  identificación.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Documento de identidad")]
        [MaxLength(15, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de estudiante.
        /// </summary>
        public int IdTipoEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del grado al que aspira.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Grado aspirante")]
        public int IdGradoPorNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del nivel al que aspira.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Nivel educativo")]
        public int IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del sexo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Sexo")]
        public int IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece si un estudiante es trasladado o no.
        /// </summary>
        [Display(Name = "Traslado")]
        public bool TrasladoEstudiante { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estudiante.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(100, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el primer apellido del estudiante.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(50, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        /// <summary>
        /// Obtiene o establece el segundo apellido del estudiante.
        [MaxLength(50, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono fijo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(15, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [Display(Name = "Teléfono fijo")]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        public string TelefonoFijo { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono movil.
        /// </summary>
        [MaxLength(15, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        [Display(Name = "Teléfono móvil")]
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Correo electronico.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(50, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [EmailAddress(ErrorMessage="Formato incorrecto.")]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [MaxLength(10, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1002")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        [Display(Name = "Fecha nacimiento")]
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los tipos de identificación.
        /// </summary>
        public IEnumerable<SelectListItem> ComboTipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los niveles educativos.
        /// </summary>
        public IEnumerable<SelectListItem> ComboNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los grados disponibles.
        /// </summary>
        public IEnumerable<SelectListItem> ComboGrado { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los grados disponibles.
        /// </summary>
        public IEnumerable<SelectListItem> ComboSexo { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los tipos de identificación.
        /// </summary>
        public IEnumerable<SelectListItem> ComboSalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los años.
        /// </summary>
        public IEnumerable<SelectListItem> ComboAnios { get; set; }

        /// <summary>
        /// Referencia a la salida ocupacional.
        /// </summary>
        public SalidaOcupacional SalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los niveles de profundización.
        /// </summary>
        public IEnumerable<SelectListItem> ComboProfundizacion { get; set; }

    }
}