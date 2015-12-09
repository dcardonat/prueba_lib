namespace Libellus.Entidades
{
    using Libellus.Mensajes;

    /// <summary>
    /// 
    /// </summary>
    public class RespuestaAutenticacionUsuario
    {
        /// <summary>
        /// Mensaje con la respuesta de la autenticación,.
        /// </summary>
        public Mensaje Mensaje {get; set;}

        /// <summary>
        /// Usuario autenticado.
        /// </summary>
        public Usuario usuario { get; set; }

        /// <summary>
        /// Usuario autenticado.
        /// </summary>
        public bool ResultadoValidacion { get; set; }
    }
}
