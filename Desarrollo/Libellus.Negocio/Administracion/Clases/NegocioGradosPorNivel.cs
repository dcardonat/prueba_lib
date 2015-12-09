namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;

    /// <summary>
    /// Define las reglas de negocio para la administración de los grados por nivel.
    /// </summary>
    public class NegocioGradosPorNivel : NegocioBase, INegocioGradosPorNivel
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioGradosPorNivel.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Contexto de la Db Libellus a trabajar.</param>
        public NegocioGradosPorNivel(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos públicos

        /// <summary>
        /// Consulta la información de un grado asociado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información del grado; de lo contrario null.</returns>
        public GradosPorNivel ConsultarGrado(int idGrado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGradosPorNivel.ConsultarGrado(idGrado);
        }

        /// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel.</returns>
        public IEnumerable<Maestro> ConsultarGradosPorNivel(int idNivel)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGradosPorNivel.ConsultarGradosPorNivel(idNivel);
        }

        /// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel (entidad tipo GradosPorNivel).</returns>
        public IEnumerable<GradosPorNivel> ConsultarGradosPorNivelEntidad(int idNivel)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioGradosPorNivel.ConsultarGradosPorNivelEntidad(idNivel);
        }

        /// <summary>
        /// Elimina la información de un grado por nivel de la base de datos.
        /// <param name="idGrado">Identificador interno del grado a eliminar.</param>
        public void EliminarGradosPorNivel(int idGrado)
        {
            this.UnidadDeTrabajoLibellus.RepositorioGradosPorNivel.Delete(this.ConsultarGrado(idGrado));
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Guarda la información de un grado por nivel en la base de datos.
        /// </summary>
        /// <param name="gradoPorNivel">Información del grado por nivel a almacenar.</param>
        public void GuardarGradosPorNivel(GradosPorNivel gradoPorNivel)
        {
            this.UnidadDeTrabajoLibellus.RepositorioGradosPorNivel.Insert(gradoPorNivel);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        #endregion Métodos públicos
    }
}