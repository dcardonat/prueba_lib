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
    public class Matricula
    {
        /// <summary>
        /// 
        /// </summary>
        public Matricula()
        {
            CancelacionMatricula = new HashSet<CancelacionMatriculas>();
            MatriculasDocumentos = new HashSet<MatriculasDocumentos>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdCupo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CancelacionMatriculas> CancelacionMatricula { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Cupo Cupo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Maestro Estado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<MatriculasDocumentos> MatriculasDocumentos { get; set; }
    }
}
