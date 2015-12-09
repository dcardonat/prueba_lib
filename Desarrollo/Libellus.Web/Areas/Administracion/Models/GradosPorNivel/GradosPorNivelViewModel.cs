namespace Libellus.Web.Areas.Administracion.Models.GradosPorNivel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    public class GradosPorNivelViewModel
    {
        public GradosPorNivelViewModel()
        {
            this.Niveles = new List<SelectListItem>();
            this.Grados = new List<SelectListItem>();
            this.GradosPorNivel = new List<SelectListItem>();
        }

        [Display(Name = "Nivel")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdNivel { get; set; }

        public List<SelectListItem> Niveles { get; set; }

        [Display(Name = "Grados")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int[] IdGrados { get; set; }

        public List<SelectListItem> Grados { get; set; }

        [Display(Name = "Grados por nivel")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int[] IdGradosPorNivel { get; set; }

        public List<SelectListItem> GradosPorNivel { get; set; }
    }
}