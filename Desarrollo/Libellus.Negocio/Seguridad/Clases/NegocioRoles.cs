namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// Define las reglas de negocio para los roles.
    /// </summary>
    public class NegocioRoles : NegocioBase, INegocioRoles
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioRoles.
        /// </summary>
        public NegocioRoles(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion

        #region Métodos publicos

        /// <summary>
        /// Consulta el rol por id.
        /// </summary>
        /// <param name="id">Id del rol a consultar.</param>
        /// <returns>El rol de acuerdo al id.</returns>
        public Rol Consultar(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRoles.GetById(id);
        }

        /// <summary>
        /// Consulta los roles por sede.
        /// </summary>
        /// <returns>Información de los roles existentes.</returns>
        public IEnumerable<Rol> ConsultarRolesPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRoles.ConsultarRolesPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Marca como agregado un objeto de tipo Role dentro del contexto de base de datos.
        /// </summary>
        /// <param name="rol">Objeto a agregar.</param>
        /// <returns>El estado en el que quedo la entidad en el contexto..</returns>
        public void AgregarRol(Rol rol)
        {
            rol.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioRoles.Insert(rol);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Edita el rol.
        /// </summary>
        /// <param name="rol">Objeto editado.</param>
        public void ActualizarRol(Rol rol)
        {
            rol.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioRoles.Update(rol);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        #endregion
    }
}
