namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la informacion de los roles.
    /// </summary>
    public class Rol
    {
        /// <summary>
        /// Cotructor de la clase.
        /// </summary>
        public Rol()
        {
            RolesFuncionalidades = new HashSet<RolesFuncionalidades>();
            UsuariosRoles = new HashSet<UsuarioRol>();
        }

        /// <summary>
        /// Obtiene o establece el idetificador del rol.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el ombre del rol.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Ibtiene o establece el estado del rol.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la sede asociada al rol.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece las funcionalidades asociadas al rol.
        /// </summary>
        public virtual ICollection<RolesFuncionalidades> RolesFuncionalidades { get; set; }

        /// <summary>
        /// Obtiene o establece los usuarios y el rol.
        /// </summary>
        public virtual ICollection<UsuarioRol> UsuariosRoles { get; set; }
    }
}
