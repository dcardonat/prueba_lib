namespace Libellus.Entidades
{
    using System;

    /// <summary>
    /// Define la informacion de los usuarios administrativos.
    /// </summary>
    public partial class UsuarioAdministrativo
    {
        /// <summary>
        /// Obtiene o establece el id del usuario administrativo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario administrativo.
        /// </summary>        
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos del usuario administrativo.
        /// </summary>        
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el id del usuario.
        /// </summary>        
        public int IdUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el télefono del usuario administrativo.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el id del grupo sanguineo del usuario administrativo.
        /// </summary>
        public int IdGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario administrativo.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el id del cargo del usuario administrativo.
        /// </summary>
        public int? IdCargo { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del usuario administrativo.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el número de celular del usuario administrativo.
        /// </summary>
        public string Celular { get; set; }

        /// <summary>
        /// Obtiene o establece el grupo sanguineo asociado al usuario administrativo.
        /// </summary>
        public virtual Maestro GrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece el cargo asociado al usuario administrativo.
        /// </summary>
        public virtual Maestro Cargo { get; set; }

        /// <summary>
        /// Obtiene o establece el usuario asociado al usuario administrativo.
        /// </summary>
        public virtual Usuario Usuario { get; set; }
    }
}
