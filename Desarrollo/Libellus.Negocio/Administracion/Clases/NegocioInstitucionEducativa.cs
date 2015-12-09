namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Transactions;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para los datos de institucion educativa.
    /// </summary>
    public class NegocioInstitucionEducativa : NegocioBase, INegocioInstitucionEducativa
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAsignaturas.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo que utiliza.</param>
        public NegocioInstitucionEducativa(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Actualiza los datos de la institucion educativa.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        public void ActualizarDatosInstitucionEducativa(InstitucionEducativa institucionEducativa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    List<int> listaSedesExistentes = new List<int>();
                    InstitucionEducativa institucionEducativaBD = this.ConsultarDatosInstitucionEducativa();

                    institucionEducativaBD.Nombre = institucionEducativa.Nombre;
                    institucionEducativaBD.ResolucionAprobacion = institucionEducativa.ResolucionAprobacion;
                    institucionEducativaBD.Nit = institucionEducativa.Nit;
                    institucionEducativaBD.CodigoDane = institucionEducativa.CodigoDane;
                    institucionEducativaBD.Rut = institucionEducativa.Rut;
                    institucionEducativaBD.Direccion = institucionEducativa.Direccion;
                    institucionEducativaBD.Telefono = institucionEducativa.Telefono;
                    institucionEducativaBD.Fax = institucionEducativa.Fax;
                    institucionEducativaBD.PaginaWeb = institucionEducativa.PaginaWeb;
                    institucionEducativaBD.IdPais = institucionEducativa.IdPais;
                    institucionEducativaBD.IdDepartamento = institucionEducativa.IdDepartamento;
                    institucionEducativaBD.IdMunicipio = institucionEducativa.IdMunicipio;
                    institucionEducativaBD.Logo = institucionEducativa.Logo;

                    foreach (Sede sede in institucionEducativa.Sedes)
                    {
                        if (sede.Id.Equals(0))
                        {
                            institucionEducativaBD.Sedes.Add(sede);
                        }
                        else
                        {
                            Sede sedeBD = institucionEducativaBD.Sedes.FirstOrDefault(s => s.Id.Equals(sede.Id));
                            sedeBD.Nombre = sede.Nombre.Trim();
                            sedeBD.Seccion = sede.Seccion.Trim();
                            listaSedesExistentes.Add(sede.Id);
                        }
                    }

                    foreach (RegistroLegalizacion registro in institucionEducativa.RegistrosLegalizacion)
                    {
                        if (registro.Id.Equals(0))
                        {
                            institucionEducativaBD.RegistrosLegalizacion.Add(registro);
                        }
                        else
                        {
                            var registroBD = institucionEducativaBD.RegistrosLegalizacion.FirstOrDefault(s => s.Id.Equals(registro.Id));
                            registroBD.TipoRegistro = registro.TipoRegistro.Trim();
                            registroBD.FechaExpedicion = registro.FechaExpedicion;
                            registroBD.TextoLegalizacion = registro.TextoLegalizacion.Trim();
                            registroBD.VigenciaDesde = registro.VigenciaDesde;
                            registroBD.VigenciaHasta = registro.VigenciaHasta;
                        }
                    }

                    institucionEducativaBD.RegistrosLegalizacion.ToList().ForEach((registro) =>
                    {
                        if (!institucionEducativa.RegistrosLegalizacion.ToList().Exists(e => e.Id.Equals(registro.Id)))
                        {
                            this.UnidadDeTrabajoLibellus.RepositorioInstitucionEducativa.EliminarRegistroLegalizacion(registro);
                        }
                    });

                    this.UnidadDeTrabajoLibellus.RepositorioInstitucionEducativa.Update(institucionEducativaBD);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    this.InsertarPrecargaSedes(listaSedesExistentes);
                    transaccion.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Administra la informacion diligenciada.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        /// <returns>Mensaje con la informacion de la operación.</returns>
        public Mensaje AdministrarInstitucionEducativa(InstitucionEducativa institucionEducativa)
        {
            Mensaje mensaje = null;
            if (institucionEducativa.Id.Equals(0))
            {
                this.CrearInstitucionEducativa(institucionEducativa);
                mensaje = new Mensaje(CodigoMensaje.Mensaje001);
            }
            else
            {
                this.ActualizarDatosInstitucionEducativa(institucionEducativa);
                mensaje = new Mensaje(CodigoMensaje.Mensaje002);
            }

            return mensaje;
        }

        /// <summary>
        /// Consulta los datos registrados de la institucion educativa.
        /// </summary>
        /// <returns>Entidad con los campos diligenciados.</returns>
        public InstitucionEducativa ConsultarDatosInstitucionEducativa()
        {
            var query = this.UnidadDeTrabajoLibellus.RepositorioInstitucionEducativa.Get();
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Crea el registro de la institucion educativa.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        public void CrearInstitucionEducativa(InstitucionEducativa institucionEducativa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                try
                {
                    this.UnidadDeTrabajoLibellus.RepositorioInstitucionEducativa.Insert(institucionEducativa);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    this.InsertarPrecargaSedes();
                    transaccion.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Inserta la precarga de los maestros para las sedes.
        /// </summary>
        /// <param name="sedesExistentes">Codigos de sedes que ya existen en la base de datos.</param>
        private void InsertarPrecargaSedes(List<int> sedesExistentes = null)
        {
            InstitucionEducativa institucionEducativa = this.ConsultarDatosInstitucionEducativa();
            if (sedesExistentes == null)
            {
                foreach (Sede sede in institucionEducativa.Sedes)
                {
                    this.UnidadDeTrabajoLibellus.RepositorioSedes.InsertarPrecargasSede(sede.Id);
                }
            }
            else
            {
                foreach (Sede sede in institucionEducativa.Sedes)
                {
                    if (!sedesExistentes.Exists(e => e.Equals(sede.Id)))
                    {
                        this.UnidadDeTrabajoLibellus.RepositorioSedes.InsertarPrecargasSede(sede.Id);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna la primera sede creada para una institucion educativa.
        /// </summary>
        /// <returns>Primera sede creada.</returns>
        public Sede ConsultarSedePrincipal()
        {
            Sede sede = this.ConsultarDatosInstitucionEducativa().Sedes.First();
            return sede;
        }

        #endregion Metodos
    }
}