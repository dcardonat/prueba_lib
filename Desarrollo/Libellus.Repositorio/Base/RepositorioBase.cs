namespace Libellus.Repositorio.Base
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define las operaciones genéricas para la persistencia de la información con la base de datos.
    /// </summary>
    /// <typeparam name="TObject">Entidad a manipular.</typeparam>
    public abstract class RepositorioBase<TObject> : IRepositorioBase<TObject>
        where TObject : class
    {
        #region Propiedades privadas

        /// <summary>
        /// Obtiene una instancia del tipo TObject especificado en el DbContext.
        /// </summary>
        private DbSet<TObject> DbEntidad
        {
            get
            {
                return this.ContextoLibellus.Set<TObject>();
            }
        }

        #endregion

        #region Propiedades públicas

        /// <summary>
        /// Define el contexto de la base de datos Libellus.
        /// </summary>
        public LibellusDbContext ContextoLibellus { get; set; }

        #endregion Propiedades

        #region Métodos públicos

        /// <summary>
        /// Obtiene toda la información de la entidad especificada.
        /// </summary>
        /// <returns>Información consultada.</returns>
        public IEnumerable<TObject> Get()
        {
            return this.DbEntidad;
        }

        /// <summary>
        /// Obtiene la información de la entidad especificada por su llave primaria.
        /// </summary>
        /// <returns>Información del registro consultado.</returns>
        public TObject GetById(params object[] id)
        {
            return this.DbEntidad.Find(id);
        }

        /// <summary>
        /// Almacena una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a almacenar.</param>
        public void Insert(TObject entidad)
        {
            this.DbEntidad.Add(entidad);
        }

        /// <summary>
        /// Actualiza la información de una entidad existente en base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a almacenar.</param>
        public void Update(TObject entidad)
        {
            this.ContextoLibellus.Entry(entidad).State = EntityState.Modified;
        }

        /// <summary>
        /// Elimina un objeto de la base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a eliminar.</param>
        public void Delete(TObject entidad)
        {
            this.ContextoLibellus.Entry(entidad).State = EntityState.Deleted;
        }

        #endregion
    }
}