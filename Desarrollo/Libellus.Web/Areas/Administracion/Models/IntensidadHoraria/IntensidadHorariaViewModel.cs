namespace Libellus.Web.Areas.Administracion.Models.IntensidadHoraria
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class IntensidadHorariaViewModel
    {
        public IntensidadHorariaViewModel()
        {
            Asignaturas = new List<SelectListItem>();
            Grados = new List<SelectListItem>();
            HorasSemanas = new List<SelectListItem>();
            Areas = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el anio escolar del registro.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Establece el combo para las areas.
        /// </summary>
        public List<SelectListItem> Areas { get; set; }

        /// <summary>
        /// Obtiene o establece la asignatura asociada.
        /// </summary>
        public virtual Asignatura Asignatura { get; set; }

        /// <summary>
        /// Establece el combo para las asignaturas.
        /// </summary>
        public List<SelectListItem> Asignaturas { get; set; }

        /// <summary>
        /// Obtiene o establece el grado asociado.
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// Establece el combo para los grados.
        /// </summary>
        public List<SelectListItem> Grados { get; set; }

        /// <summary>
        /// Obtiene o establece las intensidad horaria por semana.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Intensidad horario")]
        public byte HorasSemana { get; set; }

        /// <summary>
        /// Establece el combo para las horas por semana.
        /// </summary>
        public List<SelectListItem> HorasSemanas { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del area seleccionada.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Área")]
        public int IdArea { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la asignatura.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Asignatura")]
        public int IdAsignatura { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del grado.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Grado")]
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede a la cual pertenence el registro.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece la sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Referencia al año lectivo establecido.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el combo para los años lectivos.
        /// </summary>
        public List<SelectListItem> AniosLectivos { get; set; }
    }
}