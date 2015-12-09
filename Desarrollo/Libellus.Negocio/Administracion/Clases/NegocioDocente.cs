namespace Libellus.Negocio.Administracion.Clases
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Negocio.Administracion.Interfaces;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para la administración de la información de los docentes.
    /// </summary>
    public class NegocioDocente : NegocioBase, INegocioDocente
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioParametrizacionInstitucional.
        /// </summary>
        public NegocioDocente(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Almacena la información de un docente en base de datos.
        /// </summary>
        /// <param name="informacionDocente">Información del docente.</param>
        public void AlmacenarDocente(DocenteDatosPersonales informacionDocente)
        {
            this.UnidadDeTrabajoLibellus.RepositorioDocente.Insert(informacionDocente);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Actualiza la información de un docente en base de datos.
        /// </summary>
        /// <param name="informacionDocente">Información del docente.</param>
        public void ActualizarDocente(DocenteDatosPersonales informacionDocente)
        {
            this.UnidadDeTrabajoLibellus.RepositorioDocente.Update(informacionDocente);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta la información de un docente por su identificador interno.
        /// </summary>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Información del docente consultado, si no existe, null.</returns>
        public DocenteDatosPersonales ConsultarDocente(int idDocente)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioDocente.GetById(idDocente);
        }

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
            return this.UnidadDeTrabajoLibellus.RepositorioDocente.ConsultarDocentes(idTipoDocumento, documentoIdentidad, idEstado, nombres, apellidos, idSexo);
        }

        #endregion Métodos
    }
}
