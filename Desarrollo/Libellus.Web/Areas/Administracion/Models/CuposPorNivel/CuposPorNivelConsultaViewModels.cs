namespace Libellus.Web.Areas.Administracion.Models.CuposPorNivel
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model Para la administración de la informacion de los cupos por nivel.
    /// </summary>
    public class CuposPorNivelConsultaViewModels
    {
        /// <summary>
        /// Contructor de la clase. 
        /// </summary>
        public CuposPorNivelConsultaViewModels()
        {
            AnioLectivo = new AnioLectivo();
            CuposPorNivel = new List<CuposPorNivelViewModels>();
        }

        /// <summary>
        /// Año del nivel educativo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de la configuración de cupos por nivel.
        /// </summary>
        public List<CuposPorNivelViewModels> CuposPorNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el token generado para determinar el estado de exportación a Excel.
        /// </summary>
        public string Token { get; set; }
    }
}