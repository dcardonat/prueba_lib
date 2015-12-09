namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///Define la informacion de las funcionalidades de la aplicacion.
    /// </summary>
    public class Funcionalidad
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Funcionalidad()
        {
            RolesFuncionalidades = new HashSet<RolesFuncionalidades>();
            Funcionalidades = new HashSet<Funcionalidad>();
        }

        /// <summary>
        /// Obtiene o establece el identificador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la funcionalidad.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obitiene o establece la acción.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Obtiene o establece el idetificado de la funcioalidad padre.
        /// </summary>
        public int? IdPadre { get; set; }

        /// <summary>
        /// Obtiene o establece el orden de visualización.
        /// </summary>
        public int? OrdenMenu { get; set; }

        /// <summary>
        /// Obtiene o establece la categoria.
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la funcionalidad.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de roles y funcionalidades asociadas.
        /// </summary>
        public virtual ICollection<RolesFuncionalidades> RolesFuncionalidades { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de funcionalidades.
        /// </summary>
        public virtual ICollection<Funcionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Obtiene o establece la fucionalidad pabre.
        /// </summary>
        public virtual Funcionalidad FuncionalidadPadre { get; set; }
    }
}