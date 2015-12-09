namespace Libellus.Repositorio.Seguridad
{
    using System.Collections;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Data.Entity;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los Roles.
    /// </summary>
    public interface IRepositorioRoles : IRepositorioBase<Rol>
    {
        /// <summary>
        /// Consulta un Rol por su ID.
        /// </summary>
        /// <param name="idRol">ID Rol.</param>
        /// <returns>Rol.</returns>
        Rol ConsultarRolPorID(string idRol);

        /// <summary>
        /// Consulta un Rol por su Nombre.
        /// </summary>
        /// <param name="nombreRol">Nombre Rol.</param>
        /// <returns>Rol.</returns>
        Rol ConsultarRolPorNombre(string nombreRol);

        /// <summary>
        /// Obtiene los roles por sede.
        /// </summary>
        /// <param name="idSede">identificador de la sede.</param>
        /// <returns>Retorna el listado de roles.</returns>
        IEnumerable<Rol> ConsultarRolesPorSede(int idSede);
    }
}
