namespace Libellus.Negocio.Administracion.Clases
{
    using Libellus.Entidades;
    using Libellus.Negocio.Administracion.Interfaces;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;

    /// <summary>
    /// Define las reglas de negocio para para los grupos por grado.
    /// </summary>
    public class NegocioGruposPorGrado : NegocioBase, INegocioGruposPorGrado
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioGruposPorGrado.
        /// </summary>
        public NegocioGruposPorGrado(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos públicos

        /// <summary>
        /// Consulta la información de un grupo asociado.
        /// </summary>
        /// <param name="idGrupo">Identificador interno del grupo.</param>
        /// <returns>Información del grupo; de lo contrario null.</returns>
        public GruposPorGrado ConsultarGrado(int idGrupo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGruposPorGrado.ConsultarGrupo(idGrupo);
        }

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado.</returns>
        public IEnumerable<Maestro> ConsultarGruposPorGrado(int idGrado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGruposPorGrado.ConsultarGruposPorGrado(idGrado);
        }

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado (entidad tipo GradosPorNivel).</returns>
        public IEnumerable<GruposPorGrado> ConsultarGruposPorGradoEntidad(int idGrado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGruposPorGrado.ConsultarGruposPorGradoEntidad(idGrado);
        }

        /// <summary>
        /// Elimina la información de un grupo por grado de la base de datos.
        /// <param name="idGrado">Identificador interno del grupo a eliminar.</param>
        public void EliminarGruposPorGrados(int idGrupo)
        {
            this.UnidadDeTrabajoLibellus.RepositorioGruposPorGrado.Delete(this.ConsultarGrado(idGrupo));
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Guarda la información de un grupo por grado en la base de datos.
        /// </summary>
        /// <param name="grupoPorGrado">Información del grupo por grado a almacenar.</param>
        public void GuardarGruposPorGrado(GruposPorGrado grupoPorGrado)
        {
            this.UnidadDeTrabajoLibellus.RepositorioGruposPorGrado.Insert(grupoPorGrado);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        #endregion Métodos públicos

    }
}
