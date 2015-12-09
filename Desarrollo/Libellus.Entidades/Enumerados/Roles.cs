namespace Libellus.Entidades.Enumerados
{
    /// <summary>
    /// Enumera los tipos de usuarios del sistema.
    /// </summary>
    public enum Roles : short
    {
        /// <summary>
        /// Identificaca rol docente
        /// </summary>
        Docente = 1,

        /// <summary>
        /// Identificaca el rol estudiante.
        /// </summary>
        Estudiante = 2,

        /// <summary>
        /// Identificaca el rol administrador
        /// </summary>
        Administrador = 3,
    }
}
