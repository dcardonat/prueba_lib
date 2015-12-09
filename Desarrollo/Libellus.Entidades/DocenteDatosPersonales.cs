namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información personal del docente.
    /// </summary>
    [Table("dbo.DocentesDatosPersonales")]
    public partial class DocenteDatosPersonales
    {
        /// <summary>
        /// Inicializa una instancia de tipo DocenteDatosPersonales.
        /// </summary>
        public DocenteDatosPersonales()
        {
            this.DocenteArchivos = new HashSet<DocenteArchivo>();
            this.DocenteDatosResidenciales = new HashSet<DocenteDatosResidenciales>();
            this.DocenteDocumentosSoporte = new HashSet<DocenteDocumentoSoporte>();
            this.DocenteEstados = new HashSet<DocenteEstado>();
            this.DocenteEstudios = new HashSet<DocenteEstudio>();
            this.DocenteExperienciaLaboral = new HashSet<DocenteExperienciaLaboral>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece identificador interno del tipo de documento.
        /// </summary>
        public int IdTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el documento de identidad del docente.
        /// </summary>
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres de pila.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos.
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del sexo.
        /// </summary>
        public int IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del grupo sanguíneo.
        /// </summary>
        public int? IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del estado civil.
        /// </summary>
        public int? IdEstadoCivil { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del rol institucional.
        /// </summary>
        public int IdRolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del municipio de nacimiento.
        /// </summary>
        public short IdMunicipioNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico personal.
        /// </summary>
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del grado en el escalafón al que pertenece.
        /// </summary>
        public int? IdGradoEscalafon { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha del último ascenso otorgado.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? FechaUltimoAscenso { get; set; }

        /// <summary>
        /// Obtiene o establece la información del tipo de documento.
        /// </summary>
        public virtual Maestro TipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece la información del sexo.
        /// </summary>
        public virtual Maestro Sexo { get; set; }

        /// <summary>
        /// Obtiene o establece la información del grupo sanguíneo.
        /// </summary>
        public virtual Maestro GrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece la información del estado civil.
        /// </summary>
        public virtual Maestro EstadoCivil { get; set; }

        /// <summary>
        /// Obtiene o establece la información del rol institucional.
        /// </summary>
        public virtual Maestro RolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los municipios.
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// Obtiene o establece los archivos asociados.
        /// </summary>
        public virtual ICollection<DocenteArchivo> DocenteArchivos { get; set; }

        /// <summary>
        /// Obtiene o establece los datos residenciales.
        /// </summary>
        public virtual ICollection<DocenteDatosResidenciales> DocenteDatosResidenciales { get; set; }

        /// <summary>
        /// Obtiene o establece los documentos de soporte.
        /// </summary>
        public virtual ICollection<DocenteDocumentoSoporte> DocenteDocumentosSoporte { get; set; }

        /// <summary>
        /// Obtiene o establece la información del estado del docente.
        /// </summary>
        public virtual ICollection<DocenteEstado> DocenteEstados { get; set; }

        /// <summary>
        /// Obtiene o establece los estudios realizados.
        /// </summary>
        public virtual ICollection<DocenteEstudio> DocenteEstudios { get; set; }

        /// <summary>
        /// Obtiene o establece la experiencia laboral.
        /// </summary>
        public virtual ICollection<DocenteExperienciaLaboral> DocenteExperienciaLaboral { get; set; }

        /// <summary>
        /// Obtiene o establece la información del grado en el escalafón al que pertenece.
        /// </summary>
        public virtual Maestro GradoEscalafon { get; set; }
    }
}
