namespace Libellus.Negocio.Seguridad
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using System.Data.Entity;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administracion de los roles.
    /// </summary>
    public interface INegocioRoles : IDisposable
    {
        /// <summary>
        /// Consulta el rol por id.
        /// </summary>
        /// <param name="id">Id del rol a consultar.</param>
        /// <returns>El rol de acuerdo al id.</returns>
        Rol Consultar(int id);

        /// <summary>
        /// Consulta los roles por sede.
        /// </summary>
        /// <returns>Información de los roles existentes.</returns>
        IEnumerable<Rol> ConsultarRolesPorSede();

        /// <summary>
        /// Marca como agregado un objeto de tipo Role dentro del contexto de base de datos.
        /// </summary>
        /// <param name="rol">Objeto a agregar.</param>
        /// <returns>El estado en el que quedo la entidad en el contexto..</returns>
        void AgregarRol(Rol rol);

        /// <summary>
        /// Edita el rol.
        /// </summary>
        /// <param name="rol">Objeto editado.</param>
        void ActualizarRol(Rol rol);
    }
}
