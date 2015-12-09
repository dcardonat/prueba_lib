namespace Libellus.Negocio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Entidades.TiposComplejos;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para la funcionalidad de documentacion para soporte por roles
    /// </summary>
    public class NegocioDocumentacionSoporteRoles : NegocioBase, INegocioDocumentacionSoporteRoles
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAsignaturas.
        /// </summary>
        public NegocioDocumentacionSoporteRoles(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Actualiza la informacion diligenciada para la documentacion para soporte por roles.
        /// </summary>
        /// <param name="soporte">Entidad de tipo SoportePorRol con la informacion actualizada.</param>
        public void ActualizarDocumentacionSoporte(SoportePorRol soporte)
        {
            soporte.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            soporte.Estado = true;

            SoportePorRol soporteBD = this.ConsultarDocumentacionSoporte(soporte.Id);
            soporteBD.IdAnioLectivo = soporte.IdAnioLectivo;
            soporteBD.Estado = soporte.Estado;
            soporteBD.IdNivelEducativo = soporte.IdNivelEducativo;
            soporteBD.IdRolInstitucional = soporte.IdRolInstitucional;
            soporteBD.IdSede = soporte.IdSede;

            soporte.Documentos = soporteBD.Documentos;

            if (soporte.TiposDocumentosSeleccionados.Count > 0)
            {
                soporteBD.Documentos.ToList().ForEach((documento) =>
                {
                    if (!soporte.TiposDocumentosSeleccionados.Exists(d => d.Equals(documento.IdTipoDocumentoSoporte)))
                    {
                        this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.EliminarDocumento(documento);
                    }
                });

                soporte.TiposDocumentosSeleccionados.ForEach((documento) =>
                {
                    if (!soporteBD.Documentos.ToList().Exists(d => d.IdTipoDocumentoSoporte.Equals(documento)))
                    {
                        soporteBD.Documentos.Add(new SoportePorRolesDocumento() { IdTipoDocumentoSoporte = documento });
                    }
                });
            }
            else
            {
                soporteBD.Documentos.ToList().ForEach((documento) =>
                {
                    this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.EliminarDocumento(documento);
                });
            }

            this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.Update(soporteBD);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena la informacion diligenciada para la documentacion para soporte por roles.
        /// </summary>
        /// <param name="soporte">Entidad de tipo SoportePorRol con la informacion ingresada.</param>
        public void AlmacenarDocumentacionSoporte(SoportePorRol soporte)
        {
            soporte.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            soporte.Estado = true;

            soporte.TiposDocumentosSeleccionados.ForEach((i) =>
            {
                soporte.Documentos.Add(new SoportePorRolesDocumento() { IdTipoDocumentoSoporte = i });
            });

            this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.Insert(soporte);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta la informacion detallada de un soporte.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Entidad con la informacion diligenciada.</returns>
        public SoportePorRol ConsultarDocumentacionSoporte(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.GetById(id);
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
            return this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.ConsultarDocumentacionSoportePorRol(idRolInstitucional, idSede, anioEscolar, idDocente);
        }

        /// <summary>
        /// Consulta la informacion de documentacion para soporte por roles respectivos de la sede.
        /// </summary>
        /// <returns>Coleccion de datos tipo SoportePorRol.</returns>
        public IEnumerable<SoportePorRol> ConsultarDocumentacionSoportePorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.Get().Where(e => e.IdSede == Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Elimina la información de soporte asociada al rol.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        public void EliminarDocumentacionSoporteRol(int id)
        {
            var documentacion = this.ConsultarDocumentacionSoporte(id);

            documentacion.Documentos.ToList().ForEach((doc) =>
            {
                this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.EliminarDocumento(doc);
            });

            this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.Delete(documentacion);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        public IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int anioEscolar)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.ConsultarDocumentacionSoporteRol(idRolInstitucional, Utilidades.ContextoLibellus.ObtenerSedeActual, anioEscolar);
        }

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <param name="idNivel">Nivel educativo.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        public IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int anioEscolar, int idNivel)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioDocumentacionSoporteRoles.ConsultarDocumentacionSoporteRol(idRolInstitucional, Utilidades.ContextoLibellus.ObtenerSedeActual, anioEscolar,idNivel);
        }

        #endregion Metodos
    }
}