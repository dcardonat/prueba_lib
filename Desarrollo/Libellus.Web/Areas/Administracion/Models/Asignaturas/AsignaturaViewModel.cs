namespace Libellus.Web.Areas.Administracion.Models.Asignaturas
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AsignaturaViewModel
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public AsignaturaViewModel()
        {
            Areas = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador de la asignatura.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del aula.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name="Asignatura")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del maestro relacionado (Area).
        /// </summary>
        [Display(Name="Área")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del registro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (Area)
        /// </summary>
        public List<SelectListItem> Areas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (Area)
        /// </summary>
        [Display(Name="Área")]
        public virtual Maestro Maestro { get; set; }
    }
}