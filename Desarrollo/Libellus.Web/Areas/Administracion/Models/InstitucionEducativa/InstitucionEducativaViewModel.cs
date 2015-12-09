namespace Libellus.Web.Areas.Administracion.Models.InstitucionEducativa
{
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class InstitucionEducativaViewModel
    {
        public InstitucionEducativaViewModel()
        {
            Sedes = new List<SedeViewModel>();
            RegistrosLegalizacion = new List<RegistroLegalizacionViewModel>();
            Paises = new List<SelectListItem>();
            Departamentos = new List<SelectListItem>();
            Municipios = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [RegularExpression("[a-zA-ZáÁéÉíÍóÓúÚ ]+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        public string Nombre { get; set; }

        [Display(Name = "Resolución de aprobación")]
        [MaxLength(600)]
        public string ResolucionAprobacion { get; set; }

        [Display(Name = "NIT")]
        [MaxLength(15)]
        public string Nit { get; set; }

        [Display(Name = "Código Dane")]
        [MaxLength(15)]
        public string CodigoDane { get; set; }

        [Display(Name = "RUT")]
        [MaxLength(200)]
        public string Rut { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Direccion { get; set; }

        [Display(Name = "Logo")]
        public string UrlLogo { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdPais { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdDepartamento { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdMunicipio { get; set; }

        [Display(Name = "Teléfono fijo")]
        [MaxLength(15)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Telefono { get; set; }

        [Display(Name = "Fax")]
        [MaxLength(15)]
        public string Fax { get; set; }

        [Display(Name = "Página web")]
        [MaxLength(100)]
        public string PaginaWeb { get; set; }

        public IEnumerable<SedeViewModel> Sedes { get; set; }

        public IEnumerable<RegistroLegalizacionViewModel> RegistrosLegalizacion { get; set; }

        public List<SelectListItem> Paises { get; set; }

        public List<SelectListItem> Departamentos { get; set; }

        public List<SelectListItem> Municipios { get; set; }
    }
}