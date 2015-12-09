namespace Libellus.Entidades
{
    /// <summary>
    /// Define la informacion de los usuarios y roles.
    /// </summary>
    public class UsuarioRol
    {
        /// <summary>
        /// Obtiene o establece el identificador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Obtiene o establece el idetificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// </summary>
        public virtual Rol Rol { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public virtual Usuario Usuario { get; set; }
    }
}
