namespace Libellus.Mensajes
{
    /// <summary>
    /// Define los tipos de mensaje que se pueden generar en el sistema.
    /// </summary>
    public enum TipoMensaje : int
    {
        /// <summary>
        /// Define los mensajes satisfactorios del sistema.
        /// </summary>
        Informativo = 1,

        /// <summary>
        /// Define los mensajes que violan alguna regla de negocio o impedimento de realizar una acción.
        /// </summary>
        Advertencia = 2,

        /// <summary>
        /// Define los mensajes de error en el sistema.
        /// </summary>
        Error = 3
    }
}
