namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class NegocioFuncionalidades : NegocioBase, INegocioFuncionalidades
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioFuncionalidades.
        /// </summary>
        public NegocioFuncionalidades(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Verifica si un usuario esta autorizado para acceder a una URL determinada.
        /// </summary>
        /// <param name="urlRelativa">Url para verificar su acceso.</param>
        /// <param name="usuario">Nombre de usuario de red.</param>
        /// <returns>Diccionario de datos con las claves ["autorizado"]:si|no, y ["funcionalidad"]: nombre funcionalidad.</returns>
        public bool ValidarAcceso(string urlRelativa, string usuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioFuncionalidades.ValidarAcceso(urlRelativa, usuario, Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta todas las funcionalidades del sistema.
        /// </summary>
        /// <returns>IEnumerable de Funcionalidades.</returns>
        public IEnumerable<Funcionalidad> ConsultarFuncionalidades()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioFuncionalidades.ConsultarFuncionalidades();
        }

        /// <summary>
        /// Retorna una collección de funcionalidades para un nombre de rol determinado
        /// </summary>
        /// <param name="idRol">Identificador del rol.</param>
        public IEnumerable<Funcionalidad> ConsultarFuncionalidadesPorRol(int idRol)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioFuncionalidades.ConsultarFuncionalidadesPorRol(idRol);
        }

        /// <summary>
        /// Retorna la colección de items para el menu de la aplicación asociados a un usuario.
        /// </summary>
        /// <param name="usuario">Nombre  de usuario.</param>
        /// <returns>IEnumerable de tipo Funcionalidade.</returns>
        public IEnumerable<Funcionalidad> ConsultarMenuItemsPorUsuario(string usuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioFuncionalidades.ConsultarMenuItemsPorUsuario(usuario, Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        #endregion
    }
}
