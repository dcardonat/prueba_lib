namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Expone la persistencia con la DB de Libellus para el registro de intensidad horaria.
    /// </summary>
    public interface IRepositorioParametrizacionEscolar : IRepositorioBase<ParametrizacionEscolar>
    {
        /// <summary>
        /// Actualiza un registro de parametrizacion escolar con sus propiedades.
        /// </summary>
        /// <param name="parametrizacion">Entidad con los datos de la parametrizacion.</param>
        void Actualizar(ParametrizacionEscolar parametrizacion);

        /// <summary>
        /// Elimina un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        void Eliminar(int id);

        /// <summary>
        /// Elimina el grado de la parametrizacion escolar.
        /// </summary>
        /// <param name="grado">Grado que se va a eliminar.</param>
        void EliminarGrado(GradoParametrizacion grado);
    }
}