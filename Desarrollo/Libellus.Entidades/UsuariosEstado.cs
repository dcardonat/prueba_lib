namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class UsuariosEstado
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public UsuariosEstado()
        {
            Usuarios = new HashSet<Usuario>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
