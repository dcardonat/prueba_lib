namespace Libellus.Repositorio.Administracion.Interfaces
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para la administración de la información de los docentes.
    /// </summary>
    public interface IRepositorioDocente : IRepositorioBase<DocenteDatosPersonales>
    {
        #region Métodos públicos

        /// <summary>
        /// Consulta los docentes que se encuentran asociados a los filtros especificados.
        /// </summary>
        /// <param name="idTipoDocumento">Identificador interno del tipo de documento. Opcional.</param>
        /// <param name="documentoIdentidad">Número del documento de identidad. Opcional.</param>
        /// <param name="idEstado">Identificador interno del estado del docente. Opcional.</param>
        /// <param name="nombres">Valor que coincida con los nombres de un docente. Opcional.</param>
        /// <param name="apellidos">Valor que coincida con los apellidos de un docente. Opcional.</param>
        /// <param name="idSexo">Identificador interno del sexo. Opcional.</param>
        /// <returns>Colección de docentes asociados al filtro especificado.</returns>
        IEnumerable<DocenteDatosPersonales> ConsultarDocentes(int? idTipoDocumento, string documentoIdentidad, int? idEstado, string nombres, string apellidos, int? idSexo);

        #endregion Métodos públicos
    }
}
