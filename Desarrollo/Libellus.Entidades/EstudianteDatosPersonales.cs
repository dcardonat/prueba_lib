namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entidad que representa a los datos personales del estudiante.
    /// </summary>
    public class EstudianteDatosPersonales
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public EstudianteDatosPersonales()
        {
            this.Cupos = new HashSet<Cupo>();
            this.EstudiantesPorGrupo = new HashSet<EstudiantePorGrupo>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estudiante.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el primer apellido del estudiante.
        /// </summary>
        public string PrimerApellido { get; set; }

        /// <summary>
        /// Obtiene o establece el segundo apellido del estudiante.
        /// </summary>
        public string SegundoApellido { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha creacion del estudiante.
        /// </summary>
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la última actualizacion de datos del estudiante.
        /// </summary>
        public DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del estudiante.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece Id de relacion del maestro sexo.
        /// </summary>
        public int IdSexo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del maestro de grupo sanguineo.
        /// </summary>
        public int? IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del municipio de nacimiento.
        /// </summary>
        public short? IdMunicipioNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del estado del estudiante.
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Identificador de la EPS.
        /// </summary>
        public int? IdEntidadPromotoraSalud { get; set; }

        /// <summary>
        /// Listado de cupos del estudiante.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }

        /// <summary>
        /// Datos residenciales del estudiante.
        /// </summary>
        public virtual EstudianteDatosResidenciales DatosResidenciales { get; set; }

        /// <summary>
        /// Representa los archivos de información que tiene un estudiante.
        /// </summary>
        public virtual EstudianteArchivo Archivos { get; set; }

        /// <summary>
        /// Referencia al usuario.
        /// </summary>
        public virtual Usuario Usuario { get; set; }

        /// <summary>
        /// Referencia al maestro Sexo.
        /// </summary>
        public virtual Maestro Sexo { get; set; }

        /// <summary>
        /// Referencia al maestro GrupoSanguineo.
        /// </summary>
        public virtual Maestro GrupoSanguineo { get; set; }

        /// <summary>
        /// Referencia a los municipios.
        /// </summary>
        public virtual Municipio MunicipioNacimiento { get; set; }

        /// <summary>
        /// Referencia al maestro Estado.
        /// </summary>
        public virtual Maestro Estado { get; set; }

        /// <summary>
        /// Listado de cupos del estudiante.
        /// </summary>
        public virtual ICollection<EstudianteAntecedenteAcademico> AntecedentesAcademicos { get; set; }

        /// <summary>
        /// Obtiene las información de los estudiantes por grupos.
        /// </summary>
        public virtual ICollection<EstudiantePorGrupo> EstudiantesPorGrupo { get; set; }

        /// <summary>
        /// Obtiene o establece los datos familiares de un estudiante.
        /// </summary>
        public virtual EstudianteDatosFamiliares DatosFamiliares { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad para confirmar si se actualizan los antecedentes academicos.
        /// </summary>
        public bool ActualizarAntecedentes { get; set; }
    }
}