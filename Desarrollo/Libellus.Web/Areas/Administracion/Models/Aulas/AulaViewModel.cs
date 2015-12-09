namespace Libellus.Web.Areas.Administracion.Models.Aulas
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AulaViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador del aula.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del aula.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name="Aula")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro relacionado (Tipo Aula).
        /// </summary>
        [Display(Name="Tipo aula")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del registro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro relacionado (Tipo aula).
        /// </summary>
        [Display(Name = "Tipo aula")]
        public virtual Maestro Maestro { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro Tipo aula para asociar a la entidad.
        /// </summary>
        public List<SelectListItem> TiposAula { get; set; }
        
    }
}