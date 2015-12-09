namespace Libellus.Entidades.Enumerados
{
    /// <summary>
    /// Enumera los estados del usuario en el sistema.
    /// </summary>
    public enum EstadoUsuario : short
    {
        /// <summary>
        /// Identifica el estado activo.
        /// </summary>
        Activo = 1,

        /// <summary>
        /// Identifica el estado inactivo.
        /// </summary>
        Inactivo = 2,

        /// <summary>
        /// Identifica el estado bloqueado.
        /// </summary>
        Bloqueado = 3
    }
}
