using Libellus.Mensajes;
using System.ComponentModel.DataAnnotations;
namespace Libellus.Web.Areas.Administracion.Models.InstitucionEducativa
{
    public class SedeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Sede")]
        [MaxLength(50)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Nombre { get; set; }

        public int? IdInstitucionEducativa { get; set; }

        [Display(Name = "Sección")]
        [MaxLength(10)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Seccion { get; set; }
    }
}