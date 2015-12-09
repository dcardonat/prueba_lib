namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define la informacion de las RolesFuncionalidades de la aplicacion.
    /// </summary>
    public class RolesFuncionalidades
    {
        /// <summary>
        /// Obtiene o establece el dentificador. 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la funcionalidad.
        /// </summary>
        public int IdFuncionalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Obtiene o establece la funcionalidad asociada al rol. 
        /// </summary>
        public virtual Funcionalidad Funcionalidad { get; set; }

        /// <summary>
        /// Obtiene o establece el rol asociado a la funcionalidad. 
        /// </summary>
        public virtual Rol Rol { get; set; }
    }
}
