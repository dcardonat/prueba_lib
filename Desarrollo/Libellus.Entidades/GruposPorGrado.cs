namespace Libellus.Entidades
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class GruposPorGrado
    {
        /// <summary>
        /// 
        /// </summary>
        public GruposPorGrado()
        {
            Grupos = new HashSet<Grupo>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdGrupo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Maestro Grado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Grupo> Grupos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Maestro Grupo { get; set; }
    }
}
