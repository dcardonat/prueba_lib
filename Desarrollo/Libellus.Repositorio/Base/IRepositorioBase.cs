namespace Libellus.Repositorio.Base
{
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;

    /// <summary>
    /// Expone las operaciones genéricas para la persistencia de la información con la base de datos.
    /// </summary>
    /// <typeparam name="TObject">Entidad a manipular.</typeparam>
    public interface IRepositorioBase<TObject>
        where TObject : class
    {
        // <summary>
        /// Define el contexto de la base de datos Libellus.
        /// </summary>
        LibellusDbContext ContextoLibellus { get; set; }

        /// <summary>
        /// Obtiene toda la información de la entidad especificada.
        /// </summary>
        /// <returns>Información consultada.</returns>
        IEnumerable<TObject> Get();

        /// <summary>
        /// Obtiene la información de la entidad especificada por su llave primaria.
        /// </summary>
        /// <returns>Información del registro consultado.</returns>
        TObject GetById(params object[] id);

        /// <summary>
        /// Almacena una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a almacenar.</param>
        void Insert(TObject entidad);

        /// <summary>
        /// Actualiza la información de una entidad existente en base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a almacenar.</param>
        void Update(TObject entidad);

        /// <summary>
        /// Elimina un objeto de la base de datos.
        /// </summary>
        /// <param name="entidad">Información de la entidad a eliminar.</param>
        void Delete(TObject entidad);
    }
}
