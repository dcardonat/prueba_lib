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
    public class CancelacionMatriculas
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdMatricula { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdMotivoRetiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Maestro MotivoRetiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Matricula Matriculas { get; set; }
    }
}
