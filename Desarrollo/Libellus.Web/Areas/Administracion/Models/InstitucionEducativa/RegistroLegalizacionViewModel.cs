using Libellus.Mensajes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Libellus.Web.Areas.Administracion.Models.InstitucionEducativa
{
    public class RegistroLegalizacionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de registro")]
        [MaxLength(50)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string TipoRegistro { get; set; }

        [Display(Name = "Fecha expedición")]
        [MaxLength(10)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public DateTime FechaExpedicion { get; set; }

        [Display(Name = "Texto legalización")]
        [MaxLength(600)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string TextoLegalizacion { get; set; }

        [Display(Name = "Vigente desde")]
        [MaxLength(10)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public DateTime VigenciaDesde { get; set; }

        [Display(Name = "Vigente hasta")]
        [MaxLength(10)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public DateTime VigenciaHasta { get; set; }

        public int IdInstitucionEducativa { get; set; }
    }
}