namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administracion de las funcionaliades.
    /// </summary>
    public interface INegocioFuncionalidades : IDisposable
    {
        /// <summary>
        /// Verifica si un usuario esta autorizado para acceder a una URL determinada.
        /// </summary>
        /// <param name="urlRelativa">Url para verificar su acceso.</param>
        /// <param name="usuarioNT">Nombre de usuario de red.</param>
        /// <returns>Diccionario de datos con las claves ["autorizado"]:si|no, y ["funcionalidad"]: nombre funcionalidad.</returns>
        bool ValidarAcceso(string urlRelativa, string usuarioNT);

        /// <summary>
        /// Consulta todas las funcionalidades del sistema.
        /// </summary>
        /// <returns>IEnumerable de Funcionalidade.</returns>
        IEnumerable<Funcionalidad> ConsultarFuncionalidades();

        /// <summary>
        /// Retorna una collección de funcionalidades para un nombre de rol determinado
        /// </summary>
        /// <param name="idRol">Identificador del rol.</param>
        IEnumerable<Funcionalidad> ConsultarFuncionalidadesPorRol(int idRol);

        /// <summary>
        /// Retorna la colección de items para el menu de la aplicación asociados a un usuario.
        /// </summary>
        /// <param name="usuario">Nombre  de usuario.</param>
        /// <returns>IEnumerable de tipo Funcionalidade.</returns>
        IEnumerable<Funcionalidad> ConsultarMenuItemsPorUsuario(string usuario);
    }
}
