namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la informacion de los usuarios.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Usuario()
        {
            UsuariosAdministrativos = new HashSet<UsuarioAdministrativo>();
            UsuariosRoles = new HashSet<UsuarioRol>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Correo electronico.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la Clave.
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Obtiene o establece el NombreUsuario.
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el Ide
        /// </summary>
        public int IdTipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la  identificación.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el número de intentos fallidos realizados por el usuario desde el reproductor músical.
        /// </summary>
        public byte? IntentosFallidos { get; set; }

        /// <summary>
        /// Obtiene o establece el id del estado. 
        /// </summary>
        public byte IdEstado { get; set; }

        /// <summary>
        /// Ontiene o establece el estado del usuario.
        /// </summary>
        public virtual UsuariosEstado UsuariosEstado { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de identificación.
        /// </summary>
        public virtual Maestro TipoIdentificacion { get; set; }

        /// <summary>
        /// Obtiene o establece los usuarios administrativos asociados. 
        /// </summary>
        public virtual ICollection<UsuarioAdministrativo> UsuariosAdministrativos { get; set; }

        /// <summary>
        /// Obtiene o establece los roles.
        /// </summary>
        public virtual ICollection<UsuarioRol> UsuariosRoles { get; set; }

        /// <summary>
        /// Obtiene o establece el estudiante asociado.
        /// </summary>
        public virtual EstudianteDatosPersonales Estudiante { get; set; }
    }
}