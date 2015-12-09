namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administracion de RolesFuncionalidades.
    /// </summary>
    public interface INegocioRolesFuncionalidades : IDisposable
    {
        /// <summary>
        /// Obtiene las funcionalidades de un rol.
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <returns>Las funcionalidades del rol.</returns>
        IEnumerable<RolesFuncionalidades> ConsultarFuncionalidadesPorRol(int idRol);

        /// <summary>
        /// Asigna las funcionalidades a las que tendrá acceso un rol.
        /// </summary>
        /// <param name="funcionalidadesAEliminar">Funcionalidades a eliminar.</param>
        /// <param name="funcionalidadesAInsertar">Funcionalidades a insertar.</param>
        void AsignarFuncionalidadesPorRol(IEnumerable<RolesFuncionalidades> funcionalidadesAEliminar, IEnumerable<RolesFuncionalidades> funcionalidadesAInsertar);
    }
}
