namespace Libellus.Entidades
{
    using System;
    //TODO: DLR, documentar propiedades RegistroLegalizacion.
    public class RegistroLegalizacion
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TipoRegistro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaExpedicion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextoLegalizacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime VigenciaDesde { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime VigenciaHasta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdInstitucionEducativa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InstitucionEducativa InstitucionEducativa { get; set; }
    }
}