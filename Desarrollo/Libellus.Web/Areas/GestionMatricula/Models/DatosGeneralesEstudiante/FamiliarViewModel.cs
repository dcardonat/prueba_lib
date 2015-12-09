using Libellus.Entidades;
using Libellus.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    public class FamiliarViewModel
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificacion del familiar.
        /// </summary>
        [Display(Name = "Documento de identidad")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Tipo de identificaion del familiar.
        /// </summary>
        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Nombres del familiar.
        /// </summary>
        [Display(Name = "Nombres")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del pais.
        /// </summary>
        [Display(Name = "País")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdPais { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del departamento.
        /// </summary>
        [Display(Name = "Departamento")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdDepartamento { get; set; }

        /// <summary>
        /// Municipio donde vive el familiar.
        /// </summary>
        [Display(Name = "Municipio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public short IdMunicipio { get; set; }

        /// <summary>
        /// Direccion del familiar.
        /// </summary>
        [Display(Name = "Dirección")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Direccion { get; set; }

        /// <summary>
        /// Barrio del familiar.
        /// </summary>
        [Display(Name = "Barrio")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Barrio { get; set; }

        /// <summary>
        /// Estrato del familiar.
        /// </summary>
        [Display(Name = "Estrato")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdEstrato { get; set; }

        /// <summary>
        /// Telefono del familiar.
        /// </summary>
        [Display(Name = "Teléfono fijo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string Telefono { get; set; }

        /// <summary>
        /// Celular del familiar.
        /// </summary>
        [Display(Name = "Teléfono celular")]
        public string Celular { get; set; }

        /// <summary>
        /// Correo del familiar.
        /// </summary>
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Formato incorrecto.")]
        public string Correo { get; set; }

        /// <summary>
        /// Identificador del nivel de escolaridad.
        /// </summary>
        [Display(Name = "Nivel de escolaridad")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdNivelEscolaridad { get; set; }

        /// <summary>
        /// Identificador el estado civil del familiar.
        /// </summary>
        [Display(Name = "Estado civil")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdEstadoCivil { get; set; }

        /// <summary>
        /// Establece si es acudiente.
        /// </summary>
        [Display(Name = "Es acudiente")]
        public bool EsAcudiente { get; set; }

        /// <summary>
        /// Establece si aun vive.
        /// </summary>
        public bool Vive { get; set; }

        /// <summary>
        /// Identificador del parentesco del familiar.
        /// </summary>
        [Display(Name = "Parentesco")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int? IdParentesco { get; set; }

        /// <summary>
        /// Referencia al maestro estado civil.
        /// </summary>
        public virtual Maestro EstadoCivil { get; set; }

        /// <summary>
        /// Referencia al maestro Estrato.
        /// </summary>
        public virtual Maestro Estrato { get; set; }

        /// <summary>
        /// Referencia al municipio.
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// Referencia al maestro NivelEscolaridad.
        /// </summary>
        public virtual Maestro NivelEscolaridad { get; set; }

        /// <summary>
        /// Referencia al maestro Parentesco.
        /// </summary>
        public virtual Maestro Parentesco { get; set; }

        /// <summary>
        /// Referencia al maestro TipoIdentificacion.
        /// </summary>
        public virtual Maestro TipoIdentificacion { get; set; }
    }
}