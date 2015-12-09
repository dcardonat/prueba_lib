namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using Libellus.Entidades.TiposComplejos;
    using System;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para la funcionalidad de documentacion para soporte por roles.
    /// </summary>
    public class RepositorioDocumentacionSoporteRoles : RepositorioBase<SoportePorRol>, IRepositorioDocumentacionSoporteRoles
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAulas con el DbContext a trabajar.
        /// </summary>
        /// <param name="contexto">DbContext a trabajar.</param>
        public RepositorioDocumentacionSoporteRoles(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor

        /// <summary>
        /// Elimina un documento soporte de la lista.
        /// </summary>
        /// <param name="documento">Documento a eliminar.</param>
        public void EliminarDocumento(SoportePorRolesDocumento documento)
        {
            this.ContextoLibellus.Entry(documento).State = System.Data.Entity.EntityState.Deleted;
        }

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        public IEnumerable<DocumentoSoportePorRolSeleccionado> ConsultarDocumentacionSoportePorRol(int idRolInstitucional, int idSede, int anioEscolar, int? idDocente)
        {
            string sqlQuery = String.Format("EXEC dbo.ConsultarDocumentosSoportePorRolSeleccionados {0}, {1}, {2}, {3}", idRolInstitucional, idSede, anioEscolar, idDocente.HasValue ? idDocente.Value.ToString() : "NULL");
            return this.ContextoLibellus.Database.SqlQuery<DocumentoSoportePorRolSeleccionado>(sqlQuery);
        }

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        public IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int idSede, int anioEscolar)
        {
            return this.ContextoLibellus.SoportePorRoles.Where(x => x.IdRolInstitucional == idRolInstitucional && x.IdSede == idSede && x.IdAnioLectivo == anioEscolar).First().Documentos;
        }

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <param name="idNivel">Nivel educativo.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        public IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int idSede, int anioEscolar, int idNivel)
        {
            var soportePorRol = this.ContextoLibellus.SoportePorRoles.Where(x => x.IdRolInstitucional == idRolInstitucional 
                && x.IdSede == idSede 
                && x.IdAnioLectivo == anioEscolar 
                && x.NivelEducativo.Id == idNivel);

            if (soportePorRol != null && soportePorRol.FirstOrDefault() != null)
            {
                return soportePorRol.First().Documentos;
            }
            else
            {
                return null;
            }
        }
    }
}