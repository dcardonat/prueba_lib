namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Define la información de los datos de residencia del docente.
    /// </summary>
    public class DatosResidencialesViewModel
    {
        /// <summary>
        /// Inicializa una instancia de tipo DatosResidencialesViewModel.
        /// </summary>
        public DatosResidencialesViewModel()
        {
            this.Estratos = new List<SelectListItem>();
            this.Paises = new List<SelectListItem>();
            this.Departamentos = new List<SelectListItem>();
            this.Municipios = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece la dirección de residencia del docente.
        /// </summary>
        [Display(Name = "Dirección")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estrato de residencial del docente.
        /// </summary>
        [Display(Name = "Estrato")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdEstrato { get; set; }

        /// <summary>
        /// Obtiene o establece los estratos existentes en la base de datos.
        /// </summary>
        public List<SelectListItem> Estratos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del país de residencia.
        /// </summary>
        [Display(Name = "País")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdPais { get; set; }

        /// <summary>
        /// Obtiene o establece los países existentes en la base de datos.
        /// </summary>
        public List<SelectListItem> Paises { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del departamento de residencia.
        /// </summary>
        [Display(Name = "Departamento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdDepartamento { get; set; }

        /// <summary>
        /// Obtiene o establece los departamentos existentes en el sistema.
        /// </summary>
        public List<SelectListItem> Departamentos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del municipio de residencia.
        /// </summary>
        [Display(Name = "Municipio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece los municipios existentes en la base de datos.
        /// </summary>
        public List<SelectListItem> Municipios { get; set; }

        /// <summary>
        /// Obtiene o establece el teléfono fijo de residencia.
        /// </summary>
        [Display(Name = "Teléfono fijo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el teléfono celular del docente.
        /// </summary>
        [Display(Name = "Teléfono celular")]
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Obtiene o establece barrio de residencia del docente.
        /// </summary>
        [Display(Name = "Barrio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Barrio { get; set; }
    }
}