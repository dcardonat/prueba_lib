namespace Libellus.Web.Areas.Administracion.Models.AperturaPeriodos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Exito.Sime.Web.Attributes;
    using Libellus.Mensajes;

    public class AperturaPeriodosViewModel
    {
        /// <summary>
        /// Obtiene o establece la fecha final de la apertura.
        /// </summary>
        [Display(Name = "Fecha final")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string FechaFinal { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha inicial de la apertura.
        /// </summary>
        [Display(Name = "Fecha inicial")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string FechaInicial { get; set; }

        [Display(Name = "Hora final")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [TimeAmPm(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1010")]
        public string HoraFinal { get; set; }

        [Display(Name = "Hora inicial")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [TimeAmPm(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1010")]
        public string HoraInicial { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el Identificador del periodo de la apertura.
        /// </summary>
        [Display(Name = "Periodo")]
        public int IdPeriodo { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo de la apertura del periodo.
        /// </summary>
        [Display(Name = "Motivo de apertura")]
        [MaxLength(50)]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string MotivoApertura { get; set; }

        /// <summary>
        /// Obtiene o establece el numero del periodo.
        /// </summary>
        public int Periodo { get; set; }
    }
}