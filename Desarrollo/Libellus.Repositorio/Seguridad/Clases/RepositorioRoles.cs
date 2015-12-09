namespace Libellus.Repositorio.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la clase para la persistencia con la DB de Libellus central para los parametros de Rol.
    /// </summary>
    public class RepositorioRoles : RepositorioBase<Rol>, IRepositorioRoles
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioRoles con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioRoles(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta un Rol por su ID.
        /// </summary>
        /// <param name="idRol">ID Rol.</param>
        /// <returns>Rol.</returns>
        public Rol ConsultarRolPorID(string idRol)
        {
            return ContextoLibellus.Roles.Find(idRol);
        }

        /// <summary>
        /// Consulta un Rol por su Nombre.
        /// </summary>
        /// <param name="idFuncionalidad">Nombre Rol.</param>
        /// <returns>Rol.</returns>
        public Rol ConsultarRolPorNombre(string nombreRol)
        {
            return ContextoLibellus.Roles.FirstOrDefault(o => o.Nombre == nombreRol);
        }

        /// <summary>
        /// Obtiene los roles por sede.
        /// </summary>
        /// <param name="idSede">identificador de la sede.</param>
        /// <returns>Retorna el listado de roles.</returns>
        public IEnumerable<Rol> ConsultarRolesPorSede(int idSede)
        {
            return ContextoLibellus.Roles.Where(o => o.IdSede == idSede);
        }

        #endregion
    }
}
