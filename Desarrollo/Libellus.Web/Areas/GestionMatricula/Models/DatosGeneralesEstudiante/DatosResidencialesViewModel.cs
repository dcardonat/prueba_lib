namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    using Libellus.Mensajes;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Representa al modelo de los datos residenciales.
    /// </summary>
    public class DatosResidencialesViewModel
    {
        /// <summary>
        /// Obtiene o establece el barrio donde reside.
        /// </summary>
        [Display(Name = "Barrio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Barrio { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del estudiante.
        /// </summary>
        [Display(Name = "Dirección")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del departamento.
        /// </summary>
        [Display(Name = "Departamento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdDepartamento { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estrato de la vivienda.
        /// </summary>
        [Display(Name = "Estrato")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int? IdEstrato { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del municipio.
        /// </summary>
        [Display(Name = "Municipio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del pais.
        /// </summary>
        [Display(Name = "País")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdPais { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono fijo.
        /// </summary>
        [Display(Name = "Teléfono fijo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string TelefonoFijo { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de telefono movil.
        /// </summary>
        [Display(Name = "Teléfono celular")]
        public string TelefonoMovil { get; set; }
    }
}