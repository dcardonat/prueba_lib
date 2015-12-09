namespace Libellus.Repositorio.Administracion
{
    using System.Data.Entity;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para el maestro de actividades complementarias.
    /// </summary>
    public class RepositorioActividadesComplementarias : RepositorioBase<ActividadComplementaria>, IRepositorioActividadesComplementarias
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioActividadesComplementarias con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioActividadesComplementarias(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta la informacion de las actividades complementarias registradas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para consultar los items.</param>
        /// <returns>Coleccion de tipo ActividadComplementaria.</returns>
        public IEnumerable<ActividadComplementaria> ConsultarActividadesComplementariasPorSede(int idSede)
        {
            return this.ContextoLibellus.ActividadesComplementarias.Where(i=>i.IdSede == idSede);
        }

        #endregion Metodos
    }
}