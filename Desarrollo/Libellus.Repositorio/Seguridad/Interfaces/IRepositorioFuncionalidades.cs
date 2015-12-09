namespace Libellus.Repositorio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Interfaz define los metodos y propiedades disponibles para la entidad Funcionalidad.
    /// </summary>
    public interface IRepositorioFuncionalidades : IRepositorioBase<Funcionalidad>
    {
        /// <summary>
        /// Verifica si un usuario esta autorizado para acceder a una URL determinada.
        /// </summary>
        /// <param name="urlRelativa">Url para verificar su acceso.</param>
        /// <param name="usuario">Nombre de usuario de red.</param>
        /// <returns>Diccionario de datos con las claves ["autorizado"]:si|no, y ["funcionalidad"]: nombre funcionalidad.</returns>
        bool ValidarAcceso(string urlRelativa, string usuario, int idSede);

        /// <summary>
        /// Consulta todas las funcionalidades del sistema.
        /// </summary>
        /// <returns>IEnumerable de Funcionalidade.</returns>
        IEnumerable<Funcionalidad> ConsultarFuncionalidades();

        /// <summary>
        /// Retorna una collección de funcionalidades para un nombre de rol determinado
        /// </summary>
        /// <param name="nombreRol">Nombre del rol.</param>
        IEnumerable<Funcionalidad> ConsultarFuncionalidadesPorRol(int id);

        /// <summary>
        /// Retorna la colección de items para el menu de la aplicación asociados a un usuario.
        /// </summary>
        /// <param name="usuario">Nombre  de usuario.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>IEnumerable de tipo Funcionalidade.</returns>
        IEnumerable<Funcionalidad> ConsultarMenuItemsPorUsuario(string usuario, int idSede);
    }
}
