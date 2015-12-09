namespace Libellus.Repositorio.Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Administracion.Interfaces;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para la administración de la información de los docentes.
    /// </summary>
    public class RepositorioDocente : RepositorioBase<DocenteDatosPersonales>, IRepositorioDocente
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioDocente con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioDocente(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

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
        public IEnumerable<DocenteDatosPersonales> ConsultarDocentes(int? idTipoDocumento, string documentoIdentidad, int? idEstado, string nombres, string apellidos, int? idSexo)
        {
            IEnumerable<DocenteDatosPersonales> docentes = from d in this.ContextoLibellus.DocenteDatosPersonales
                                                           from e in d.DocenteEstados
                                                           where (!idTipoDocumento.HasValue || d.IdTipoDocumento == idTipoDocumento.Value) &&
                                                                 (String.IsNullOrEmpty(documentoIdentidad) || d.DocumentoIdentidad.Equals(documentoIdentidad, StringComparison.OrdinalIgnoreCase)) &&
                                                                 (String.IsNullOrEmpty(nombres) || d.Nombres.Contains(nombres)) &&
                                                                 (String.IsNullOrEmpty(apellidos) || d.Apellidos.Contains(apellidos)) &&
                                                                 (!idSexo.HasValue || d.IdSexo == idSexo.Value) &&
                                                                 (!idEstado.HasValue || e.IdEstado == idEstado.Value)
                                                           select d;

            return docentes;
        }

        #endregion Métodos públicos
    }
}
