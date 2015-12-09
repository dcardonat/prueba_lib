namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.Docente;
    using Libellus.Web.Helpers;
    using Libellus.Mensajes;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de la información de un docente.
    /// </summary>
    public class DocenteController : AdministracionBaseController
    {
        #region Constantes

        /// <summary>
        /// Determina si el registro de experiencia docente, estudios realizados es nuevo.
        /// </summary>
        private const string RegistroNuevo = "1";

        #endregion Constantes

        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo DocenteController.
        /// </summary>
        public DocenteController()
        {
            this.NegocioDocente = new NegocioDocente(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioDocumentacionSoporteRoles = new NegocioDocumentacionSoporteRoles(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Renderiza la vista de consulta de docentes con los docentes asociados a los filtros especificados.
        /// </summary>
        /// <param name="pagina">Indice de la página a consultar. Opcional.</param>
        /// <param name="idTipoDocumento">Identificador interno del tipo de documento. Opcional.</param>
        /// <param name="documentoIdentidad">Documento de identidad. Opcional.</param>
        /// <param name="idEstado">Identificador interno del estado. Opcional.</param>
        /// <param name="nombres">Nombres del docente. Opcional.</param>
        /// <param name="apellidos">Apellidos del docente. Opcional.</param>
        /// <param name="idSexo">Identificador interno del sexo. Opcional.</param>
        /// <returns>Vista con filtros de consulta y la información de los docentes existentes.</returns>
        [HttpGet]
        public ActionResult Index(int? pagina, int? idTipoDocumento, string documentoIdentidad, int? idEstado, string nombres, string apellidos, int? idSexo)
        {
            ConsultarDocenteViewModel consultarDocenteViewModel = new ConsultarDocenteViewModel();

            try
            {
                if (Request.IsAjaxRequest())
                {
                    consultarDocenteViewModel.Docentes = (from d in this.NegocioDocente.ConsultarDocentes(idTipoDocumento, documentoIdentidad, idEstado, nombres, apellidos, idSexo)
                                                          select new ResultadoConsultaDocentesViewModel
                                                          {
                                                              Id = d.Id,
                                                              TipoDocumento = d.TipoDocumento.Descripcion,
                                                              DocumentoIdentidad = d.DocumentoIdentidad,
                                                              Nombres = String.Format("{0} {1}", d.Nombres, d.Apellidos),
                                                              Estado = d.DocenteEstados.First().Estado.Descripcion
                                                          }).OrderBy(o => o.Nombres).ToPagedList(pagina ?? 1, 10);

                    return PartialView("_ResultadoConsulta", consultarDocenteViewModel.Docentes);
                }
                else
                {
                    consultarDocenteViewModel.TiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, Utilidades.ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
                    consultarDocenteViewModel.Sexos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Sexo, 1).ToSelectListItem(o => o.Descripcion, o => o.Id, false);
                    consultarDocenteViewModel.Estados = this.ConsultarEstados();
                    consultarDocenteViewModel.Docentes = new PagedList<ResultadoConsultaDocentesViewModel>(null, 1, 10);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(consultarDocenteViewModel);
        }

        /// <summary>
        /// Renderiza la vista para la creación de docentes.
        /// </summary>
        /// <returns>Vista con los campos de creación de un docente.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            DocenteViewModel docenteViewModel = new DocenteViewModel();

            try
            {
                this.InicializarListasDatosPersonales(docenteViewModel);
                this.InicializarListasDatosResidenciales(docenteViewModel);
                this.InicializarListasEstudiosRealizados(docenteViewModel);
                this.InicializarListasEstadoHorario(docenteViewModel);
                this.InicializarListasSoporteDocumentos(docenteViewModel);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(docenteViewModel);
        }

        /// <summary>
        /// Crea un nuevo docente con la información diligenciada en la vista.
        /// </summary>
        /// <param name="datosPersonales">Establece la información de la pestaña datos personales.</param>
        /// <param name="datosResidenciales">Establece la información de la pestaña datos residenciales.</param>
        /// <param name="estadoHorario">Establece la información de la pestaña estados y horario.</param>
        /// <param name="experienciasDocente">Establece la información de la pestaña experiencia docente.</param>
        /// <param name="estudiosRealizados">Establece la información de la pestaña estudios realizados.</param>
        /// <param name="fotoDocente">Bytes con la foto del docente.</param>
        /// <param name="firmaDocente">Bytes con la firma del docente.</param>
        /// <returns>Vista con los campos de creación de un docente.</returns>
        [HttpPost]
        public ActionResult Crear(DatosPersonalesViewModel datosPersonales, DatosResidencialesViewModel datosResidenciales, EstadoHorarioViewModel estadoHorario, List<ExperienciaDocenteViewModel> experienciasDocente, List<EstudiosRealizadosViewModel> estudiosRealizados, HttpPostedFileBase fotoDocente, HttpPostedFileBase firmaDocente)
        {
            DocenteViewModel docenteViewModel = new DocenteViewModel();
            docenteViewModel.DatosPersonales = datosPersonales;
            docenteViewModel.DatosResidenciales = datosResidenciales;
            docenteViewModel.EstadoHorario = estadoHorario;
            docenteViewModel.EstudiosRealizados = estudiosRealizados;
            docenteViewModel.ExperienciaDocente = experienciasDocente;

            try
            {
                if (ModelState.IsValid)
                {
                    DocenteDatosPersonales datosDocente = new DocenteDatosPersonales();
                    this.EstablecerDatosPersonales(datosPersonales, datosDocente, fotoDocente, firmaDocente, false);
                    this.EstablecerDatosResidenciales(datosResidenciales, datosDocente, false);
                    this.EstablecerDatosEstudiosRealizados(estudiosRealizados, datosDocente, false);
                    this.EstablecerDatosExperienciaLaboral(experienciasDocente, datosDocente, false);
                    this.EstablecerDatosEstado(estadoHorario, datosDocente);

                    this.NegocioDocente.AlmacenarDocente(datosDocente);
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));

                    return RedirectToAction("Index");
                }
                else
                {
                    this.InicializarListasDatosPersonales(docenteViewModel);
                    this.InicializarListasDatosResidenciales(docenteViewModel);
                    this.InicializarListasEstudiosRealizados(docenteViewModel);
                    this.InicializarListasEstadoHorario(docenteViewModel);
                    this.InicializarListasSoporteDocumentos(docenteViewModel);

                    if (fotoDocente != null)
                    {
                        docenteViewModel.DatosPersonales.RutaFotoDocente = UtilidadesApp.ObtenerUrlBase64(fotoDocente.InputStream);
                    }

                    if (firmaDocente != null)
                    {
                        docenteViewModel.DatosPersonales.RutaFirmaDocente = UtilidadesApp.ObtenerUrlBase64(firmaDocente.InputStream);
                    }

                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje019));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(docenteViewModel);
        }

        /// <summary>
        /// Renderiza la vista para la edición de la información de un docente.
        /// </summary>
        /// <param name="id">Identificador interno del docente a editar.</param>
        /// <returns>Vista con la información del docente a editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                DocenteDatosPersonales docente = this.NegocioDocente.ConsultarDocente(id);

                if (docente == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                }
                else
                {
                    DocenteViewModel docenteViewModel = new DocenteViewModel();
                    docenteViewModel.IdDocente = id;

                    this.EstablecerDatosPersonalesViewModel(docente, docenteViewModel.DatosPersonales);
                    this.EstablecerDatosResidencialesViewModel(docente.DocenteDatosResidenciales.FirstOrDefault(), docenteViewModel.DatosResidenciales);
                    this.EstablecerDatosEstudiosRealizadosViewModel(docente.DocenteEstudios, docenteViewModel.EstudiosRealizados);
                    this.EstablecerDatosExperienciaLaboralViewModel(docente.DocenteExperienciaLaboral, docenteViewModel.ExperienciaDocente);
                    this.EstablecerDatosEstadoViewModel(docente.DocenteEstados.FirstOrDefault(), docenteViewModel.EstadoHorario);

                    this.InicializarListasDatosPersonales(docenteViewModel);
                    this.InicializarListasDatosResidenciales(docenteViewModel);
                    this.InicializarListasEstudiosRealizados(docenteViewModel);
                    this.InicializarListasEstadoHorario(docenteViewModel);
                    this.InicializarListasSoporteDocumentos(docenteViewModel);

                    return View(docenteViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edita la información de un docente existente en el sistema.
        /// </summary>
        /// <param name="idDocente"></param>
        /// <param name="datosPersonales">Establece la información de la pestaña datos personales.</param>
        /// <param name="datosResidenciales">Establece la información de la pestaña datos residenciales.</param>
        /// <param name="estadoHorario">Establece la información de la pestaña estados y horario.</param>
        /// <param name="experienciasDocente">Establece la información de la pestaña experiencia docente.</param>
        /// <param name="estudiosRealizados">Establece la información de la pestaña estudios realizados.</param>
        /// <param name="fotoDocente">Bytes con la foto del docente.</param>
        /// <param name="firmaDocente">Bytes con la firma del docente.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(FormCollection coleccion, int idDocente, DatosPersonalesViewModel datosPersonales, DatosResidencialesViewModel datosResidenciales, EstadoHorarioViewModel estadoHorario, List<ExperienciaDocenteViewModel> experienciasDocente, List<EstudiosRealizadosViewModel> estudiosRealizados, HttpPostedFileBase fotoDocente, HttpPostedFileBase firmaDocente)
        {
            DocenteViewModel docenteViewModel = new DocenteViewModel();
            docenteViewModel.IdDocente = idDocente;
            docenteViewModel.DatosPersonales = datosPersonales;
            docenteViewModel.DatosResidenciales = datosResidenciales;
            docenteViewModel.EstadoHorario = estadoHorario;
            docenteViewModel.EstudiosRealizados = estudiosRealizados;
            docenteViewModel.ExperienciaDocente = experienciasDocente;

            try
            {
                if (ModelState.IsValid)
                {
                    DocenteDatosPersonales datosDocente = this.NegocioDocente.ConsultarDocente(idDocente);

                    this.EstablecerDatosPersonales(datosPersonales, datosDocente, fotoDocente, firmaDocente, true);
                    this.EstablecerDatosResidenciales(datosResidenciales, datosDocente, true);
                    this.EstablecerDatosEstudiosRealizados(estudiosRealizados, datosDocente, true);
                    this.EstablecerDatosExperienciaLaboral(experienciasDocente, datosDocente, true);
                    //this.EstablecerDatosEstado(estadoHorario, datosDocente);

                    this.NegocioDocente.ActualizarDocente(datosDocente);
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));

                    return RedirectToAction("Index");
                }
                else
                {
                    this.InicializarListasDatosPersonales(docenteViewModel);
                    this.InicializarListasDatosResidenciales(docenteViewModel);
                    this.InicializarListasEstudiosRealizados(docenteViewModel);
                    this.InicializarListasEstadoHorario(docenteViewModel);
                    this.InicializarListasSoporteDocumentos(docenteViewModel);

                    if (fotoDocente != null)
                    {
                        docenteViewModel.DatosPersonales.RutaFotoDocente = UtilidadesApp.ObtenerUrlBase64(fotoDocente.InputStream);
                    }

                    if (firmaDocente != null)
                    {
                        docenteViewModel.DatosPersonales.RutaFirmaDocente = UtilidadesApp.ObtenerUrlBase64(firmaDocente.InputStream);
                    }

                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje019));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(docenteViewModel);
        }

        #endregion Acciones

        #region Acciones asíncronas

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="parametros">Contiene el identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentos(FormCollection parametros)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(short.Parse(parametros[0]))
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="parametros">Contiene el identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipios(FormCollection parametros)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(short.Parse(parametros[0]))
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios);
        }

        #endregion Acciones asíncronas

        #region Métodos privados

        /// <summary>
        /// Consulta los estados de un docente.
        /// </summary>
        /// <returns>Lista con los posibles estados de un docente.</returns>
        private List<SelectListItem> ConsultarEstados()
        {
            List<SelectListItem> listaEstados = new List<SelectListItem>();

            listaEstados.Add(new SelectListItem() { Text = "Todos", Value = String.Empty });
            listaEstados.Add(new SelectListItem() { Text = "Activo", Value = "True" });
            listaEstados.Add(new SelectListItem() { Text = "Inactivo", Value = "False" });

            return listaEstados;
        }

        /// <summary>
        /// Inicializa los valores de las listas de la sección datos personales.
        /// </summary>
        /// <param name="docenteViewModel">Información del docente a visualizar.</param>
        private void InicializarListasDatosPersonales(DocenteViewModel docenteViewModel)
        {
            int sedeActual = ContextoLibellus.ObtenerSedeActual;

            docenteViewModel.DatosPersonales.TiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sedeActual).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.DatosPersonales.Sexos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Sexo, sedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.DatosPersonales.GrupoSanguineo = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.GruposSanguineos, sedeActual).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.DatosPersonales.EstadosCiviles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstadoCivil, sedeActual).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.DatosPersonales.Paises = this.NegocioMaestros.ConsultarPaises().OrderBy(o => o.Nombre).ToSelectListItem(o => o.Nombre, o => o.Id);
            docenteViewModel.DatosPersonales.Escalafones = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.GradoEscalafon, ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);

            Maestro rolInstitucional = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.RolesInstitucionales, sedeActual).FirstOrDefault(r => r.Descripcion.Equals(MaestrosNoAdministrables.RolInstitucionalDocente, StringComparison.OrdinalIgnoreCase));
            docenteViewModel.DatosPersonales.IdRolInstitucional = rolInstitucional.Id;
            docenteViewModel.DatosPersonales.RolInstitucional = rolInstitucional.Descripcion;
        }

        /// <summary>
        /// Inicializa los valores de las listas de la sección datos residenciales.
        /// </summary>
        /// <param name="docenteViewModel">Información del docente a visualizar.</param>
        private void InicializarListasDatosResidenciales(DocenteViewModel docenteViewModel)
        {
            docenteViewModel.DatosResidenciales.Estratos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstratoSocioEconomico, ContextoLibellus.ObtenerSedeActual).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.DatosResidenciales.Paises = docenteViewModel.DatosPersonales.Paises;
        }

        /// <summary>
        /// Inicializa los valores de las listas de la sección estudios realizados.
        /// </summary>
        /// <param name="docenteViewModel">Información del docente a visualizar.</param>
        private void InicializarListasEstudiosRealizados(DocenteViewModel docenteViewModel)
        {
            int sedeActual = ContextoLibellus.ObtenerSedeActual;

            ViewBag.ClasificacionesAcademicas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.ClasificacionesAcademicas, sedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
            ViewBag.EstadosEstudio = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstadosEstudiosAcademicos, sedeActual).OrderBy(o => o.Descripcion).ToSelectListItem(o => o.Descripcion, o => o.Id);
        }

        /// <summary>
        /// Inicializa los valores de las listas de la sección estado y horario.
        /// </summary>
        /// <param name="docenteViewModel">Información del docente a visualizar.</param>
        private void InicializarListasEstadoHorario(DocenteViewModel docenteViewModel)
        {
            docenteViewModel.EstadoHorario.Estados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Estados, ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
            docenteViewModel.EstadoHorario.Horarios = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Horario, ContextoLibellus.ObtenerSedeActual).ToSelectListItem(o => o.Descripcion, o => o.Id);
        }

        /// <summary>
        /// Inicializa los valores de las listas de la sección estado y horario.
        /// </summary>
        /// <param name="docenteViewModel">Información del docente a visualizar.</param>
        private void InicializarListasSoporteDocumentos(DocenteViewModel docenteViewModel)
        {
            //Maestro rolDocente = this.NegocioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.RolInstitucionalDocente, ContextoLibellus.ObtenerSedeActual);

            //docenteViewModel.DocumentosSoporte = (from p in this.NegocioDocumentacionSoporteRoles.ConsultarDocumentacionSoportePorRol(rolDocente.Id, ContextoLibellus.ObtenerSedeActual, DateTime.Now.Year, null)
            //                                      select new DocumentosSoporteViewModel
            //                                      {
            //                                          Id = p.IdDocenteDocumentoSoporte ?? 0,
            //                                          Documento = new Maestro()
            //                                          {
            //                                              Id = p.IdSoportePorRolDocumento,
            //                                              Descripcion = p.Documento
            //                                          },
            //                                          Recibido = p.Recibido
            //                                      }).ToList();
        }

        /// <summary>
        /// Lee el contenido en binario de un archivo específico.
        /// </summary>
        /// <param name="archivo">Información del archivo adjunto.</param>
        /// <returns>Contenido en binario del archivo.</returns>
        private byte[] ObtenerContenidoBinarioArchivo(HttpPostedFileBase archivo)
        {
            byte[] contenidoArchivo = null;

            using (BinaryReader reader = new BinaryReader(archivo.InputStream))
            {
                contenidoArchivo = reader.ReadBytes(archivo.ContentLength);
            }

            return contenidoArchivo;
        }

        /// <summary>
        /// Establece la información personal del docente para almacenar en la base de datos.
        /// </summary>
        /// <param name="datosPersonalesViewModel">Información de los datos del docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Objeto en el que se establecerán los datos del docente.</param>
        /// <param name="fotoDocente">Binario con la foto del docente.</param>
        /// <param name="firmaDocente">Binario con la firma del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosPersonales(DatosPersonalesViewModel datosPersonalesViewModel, DocenteDatosPersonales datosPersonalesDocente, HttpPostedFileBase fotoDocente, HttpPostedFileBase firmaDocente, bool modoEdicion)
        {
            datosPersonalesDocente.Nombres = datosPersonalesViewModel.Nombres;
            datosPersonalesDocente.Apellidos = datosPersonalesViewModel.Apellidos;
            datosPersonalesDocente.IdTipoDocumento = datosPersonalesViewModel.IdTipoDocumento;
            datosPersonalesDocente.DocumentoIdentidad = datosPersonalesViewModel.DocumentoIdentidad;
            datosPersonalesDocente.IdSexo = datosPersonalesViewModel.IdSexo;
            datosPersonalesDocente.IdGrupoSanguineo = datosPersonalesViewModel.IdGrupoSanguineo;
            datosPersonalesDocente.IdEstadoCivil = datosPersonalesViewModel.IdEstadoCivil;
            datosPersonalesDocente.FechaNacimiento = Convert.ToDateTime(datosPersonalesViewModel.FechaNacimiento);
            datosPersonalesDocente.CorreoElectronico = datosPersonalesViewModel.CorreoElectronico;
            datosPersonalesDocente.IdRolInstitucional = datosPersonalesViewModel.IdRolInstitucional;
            datosPersonalesDocente.IdMunicipioNacimiento = datosPersonalesViewModel.IdMunicipioNacimiento;
            datosPersonalesDocente.IdGradoEscalafon = datosPersonalesViewModel.IdEscalafon;
            datosPersonalesDocente.FechaUltimoAscenso = String.IsNullOrEmpty(datosPersonalesViewModel.FechaUltimoAscenso) ? (DateTime?)null : Convert.ToDateTime(datosPersonalesViewModel.FechaUltimoAscenso);

            if (fotoDocente != null || firmaDocente != null)
            {
                DocenteArchivo archivosDocente;

                if (modoEdicion)
                {
                    archivosDocente = datosPersonalesDocente.DocenteArchivos.FirstOrDefault();

                    archivosDocente.Foto = this.ObtenerContenidoBinarioArchivo(fotoDocente);
                    archivosDocente.Firma = this.ObtenerContenidoBinarioArchivo(firmaDocente);
                }
                else
                {
                    archivosDocente = new DocenteArchivo();

                    archivosDocente.Foto = this.ObtenerContenidoBinarioArchivo(fotoDocente);
                    archivosDocente.Firma = this.ObtenerContenidoBinarioArchivo(firmaDocente);

                    datosPersonalesDocente.DocenteArchivos.Add(archivosDocente);
                }
            }
        }

        /// <summary>
        /// Establece los datos personales del docente para visualizar en la vista.
        /// </summary>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente almacenados en la base de datos.</param>
        /// <param name="datosPersonalesViewModel">Objeto en el que se establecerán los datos del docente.</param>
        private void EstablecerDatosPersonalesViewModel(DocenteDatosPersonales datosPersonalesDocente, DatosPersonalesViewModel datosPersonalesViewModel)
        {
            datosPersonalesViewModel.Nombres = datosPersonalesDocente.Nombres;
            datosPersonalesViewModel.Apellidos = datosPersonalesDocente.Apellidos;
            datosPersonalesViewModel.IdTipoDocumento = datosPersonalesDocente.IdTipoDocumento;
            datosPersonalesViewModel.DocumentoIdentidad = datosPersonalesDocente.DocumentoIdentidad;
            datosPersonalesViewModel.IdSexo = datosPersonalesDocente.IdSexo;
            datosPersonalesViewModel.IdGrupoSanguineo = datosPersonalesDocente.IdGrupoSanguineo;
            datosPersonalesViewModel.IdEstadoCivil = datosPersonalesDocente.IdEstadoCivil;
            datosPersonalesViewModel.FechaNacimiento = datosPersonalesDocente.FechaNacimiento.ToString();
            datosPersonalesViewModel.CorreoElectronico = datosPersonalesDocente.CorreoElectronico;
            datosPersonalesViewModel.IdRolInstitucional = datosPersonalesDocente.IdRolInstitucional;
            datosPersonalesViewModel.IdPaisNacimiento = datosPersonalesDocente.Municipio.Departamentos.IdPais;
            datosPersonalesViewModel.IdDepartamentoNacimiento = datosPersonalesDocente.Municipio.Departamentos.Id;
            datosPersonalesViewModel.IdMunicipioNacimiento = datosPersonalesDocente.IdMunicipioNacimiento;
            datosPersonalesViewModel.IdEscalafon = datosPersonalesDocente.IdGradoEscalafon;
            datosPersonalesViewModel.FechaUltimoAscenso = datosPersonalesDocente.FechaUltimoAscenso.HasValue ? datosPersonalesDocente.FechaUltimoAscenso.Value.ToShortDateString() : null;

            if (datosPersonalesDocente.DocenteArchivos.Count() > 0)
            {
                DocenteArchivo imagenesDocente = datosPersonalesDocente.DocenteArchivos.FirstOrDefault();
                datosPersonalesViewModel.RutaFotoDocente = UtilidadesApp.ObtenerUrlBase64(imagenesDocente.Foto);
                datosPersonalesViewModel.RutaFirmaDocente = UtilidadesApp.ObtenerUrlBase64(imagenesDocente.Firma);
            }
        }

        /// <summary>
        /// Establece los datos residenciales del docente.
        /// </summary>
        /// <param name="datosResidencialesViewModel">Información de los datos residenciales del docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosResidenciales(DatosResidencialesViewModel datosResidencialesViewModel, DocenteDatosPersonales datosPersonalesDocente, bool modoEdicion)
        {
            DocenteDatosResidenciales datosResidencialesDocente = modoEdicion ? datosPersonalesDocente.DocenteDatosResidenciales.FirstOrDefault() : new DocenteDatosResidenciales();

            datosResidencialesDocente.Direccion = datosResidencialesViewModel.Direccion;
            datosResidencialesDocente.Barrio = datosResidencialesViewModel.Barrio;
            datosResidencialesDocente.IdEstrato = datosResidencialesViewModel.IdEstrato;
            datosResidencialesDocente.IdMunicipio = datosResidencialesViewModel.IdMunicipio;
            datosResidencialesDocente.Telefono = datosResidencialesViewModel.Telefono;
            datosResidencialesDocente.TelefonoMovil = datosResidencialesViewModel.TelefonoMovil;

            if (!modoEdicion)
            {
                datosPersonalesDocente.DocenteDatosResidenciales.Add(datosResidencialesDocente);
            }
        }

        /// <summary>
        /// Establece los datos residenciales del docente para visualizar en la vista.
        /// </summary>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente almacenados en la base de datos.</param>
        /// <param name="datosPersonalesViewModel">Objeto en el que se establecerán los datos del docente.</param>
        private void EstablecerDatosResidencialesViewModel(DocenteDatosResidenciales datosResidencialesDocente, DatosResidencialesViewModel datosResidencialesViewModel)
        {
            datosResidencialesViewModel.Direccion = datosResidencialesDocente.Direccion;
            datosResidencialesViewModel.Barrio = datosResidencialesDocente.Barrio;
            datosResidencialesViewModel.IdEstrato = datosResidencialesDocente.IdEstrato;
            datosResidencialesViewModel.IdPais = datosResidencialesDocente.Municipio.Departamentos.IdPais;
            datosResidencialesViewModel.IdDepartamento = datosResidencialesDocente.Municipio.Departamentos.Id;
            datosResidencialesViewModel.IdMunicipio = datosResidencialesDocente.IdMunicipio;
            datosResidencialesViewModel.Telefono = datosResidencialesDocente.Telefono;
            datosResidencialesViewModel.TelefonoMovil = datosResidencialesDocente.TelefonoMovil;
        }

        /// <summary>
        /// Establece los estudios realizados por el docente.
        /// </summary>
        /// <param name="estudiosRealizadosViewModel">Información de los estudios realizados por el docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosEstudiosRealizados(List<EstudiosRealizadosViewModel> estudiosRealizadosViewModel, DocenteDatosPersonales datosPersonalesDocente, bool modoEdicion)
        {
            if (estudiosRealizadosViewModel != null)
            {
                if (modoEdicion)
                {
                    this.EstablecerDatosEstudiosRealizadosModoEdicion(estudiosRealizadosViewModel, datosPersonalesDocente);
                }
                else
                {
                    this.EstablecerDatosEstudiosRealizadosModoCreacion(estudiosRealizadosViewModel, datosPersonalesDocente);
                }
            }
        }

        /// <summary>
        /// Establece los estudios realizados por el docente en modo creación de docente.
        /// </summary>
        /// <param name="estudiosRealizadosViewModel">Información de los estudios realizados por el docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        private void EstablecerDatosEstudiosRealizadosModoCreacion(List<EstudiosRealizadosViewModel> estudiosRealizadosViewModel, DocenteDatosPersonales datosPersonalesDocente)
        {
            DocenteEstudio docenteEstudiosRealizados;

            foreach (EstudiosRealizadosViewModel estudioRealizado in estudiosRealizadosViewModel)
            {
                if (!String.IsNullOrEmpty(estudioRealizado.InstitucionEducativa))
                {
                    docenteEstudiosRealizados = new DocenteEstudio();

                    docenteEstudiosRealizados.InstitucionEducativa = estudioRealizado.InstitucionEducativa;
                    docenteEstudiosRealizados.Titulo = estudioRealizado.TituloEstudio;
                    docenteEstudiosRealizados.IdClasificacion = estudioRealizado.IdClasificacion;
                    docenteEstudiosRealizados.FechaTerminacion = String.IsNullOrEmpty(estudioRealizado.FechaTerminacion) ? (DateTime?)null : Convert.ToDateTime(estudioRealizado.FechaTerminacion);
                    docenteEstudiosRealizados.IdEstado = estudioRealizado.IdEstadoEstudio;

                    datosPersonalesDocente.DocenteEstudios.Add(docenteEstudiosRealizados);
                }
            }
        }

        /// <summary>
        /// Establece los estudios realizados por el docente en modo edición de docente.
        /// </summary>
        /// <param name="estudiosRealizadosViewModel">Información de los estudios realizados por el docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        private void EstablecerDatosEstudiosRealizadosModoEdicion(List<EstudiosRealizadosViewModel> estudiosRealizadosViewModel, DocenteDatosPersonales datosPersonalesDocente)
        {
            List<DocenteEstudio> estudiosDocentes = datosPersonalesDocente.DocenteEstudios.ToList();

            foreach (EstudiosRealizadosViewModel estudioRealizado in estudiosRealizadosViewModel)
            {
                if (estudioRealizado.RegistroNuevo == RegistroNuevo)
                {
                    datosPersonalesDocente.DocenteEstudios.Add(new DocenteEstudio()
                    {
                        InstitucionEducativa = estudioRealizado.InstitucionEducativa,
                        Titulo = estudioRealizado.TituloEstudio,
                        IdClasificacion = estudioRealizado.IdClasificacion,
                        FechaTerminacion = String.IsNullOrEmpty(estudioRealizado.FechaTerminacion) ? (DateTime?)null : Convert.ToDateTime(estudioRealizado.FechaTerminacion),
                        IdEstado = estudioRealizado.IdEstadoEstudio
                    });
                }
                else
                {
                    int indiceEstudio = estudiosDocentes.FindIndex(o => o.Id == estudioRealizado.IdEstudioRealizado);
                    estudiosDocentes[indiceEstudio].InstitucionEducativa = estudioRealizado.InstitucionEducativa;
                    estudiosDocentes[indiceEstudio].Titulo = estudioRealizado.TituloEstudio;
                    estudiosDocentes[indiceEstudio].IdClasificacion = estudioRealizado.IdClasificacion;
                    estudiosDocentes[indiceEstudio].FechaTerminacion = String.IsNullOrEmpty(estudioRealizado.FechaTerminacion) ? (DateTime?)null : Convert.ToDateTime(estudioRealizado.FechaTerminacion);
                    estudiosDocentes[indiceEstudio].IdEstado = estudioRealizado.IdEstadoEstudio;
                }
            }
        }

        /// <summary>
        /// Establece los estudios realizados por el docente para visualizar en la vista.
        /// </summary>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente almacenados en la base de datos.</param>
        /// <param name="datosPersonalesViewModel">Objeto en el que se establecerán los datos del docente.</param>
        private void EstablecerDatosEstudiosRealizadosViewModel(IEnumerable<DocenteEstudio> estudiosRealizadosDocente, List<EstudiosRealizadosViewModel> estudiosRealizadosViewModel)
        {
            EstudiosRealizadosViewModel estudioRealizadoViewModel;

            foreach (DocenteEstudio estudio in estudiosRealizadosDocente)
            {
                estudioRealizadoViewModel = new EstudiosRealizadosViewModel();

                estudioRealizadoViewModel.IdEstudioRealizado = estudio.Id;
                estudioRealizadoViewModel.InstitucionEducativa = estudio.InstitucionEducativa;
                estudioRealizadoViewModel.TituloEstudio = estudio.Titulo;
                estudioRealizadoViewModel.NombreClasificacion = estudio.Clasificacion.Descripcion;
                estudioRealizadoViewModel.IdClasificacion = estudio.IdClasificacion;
                estudioRealizadoViewModel.FechaTerminacion = estudio.FechaTerminacion.HasValue ? estudio.FechaTerminacion.Value.ToShortDateString() : null;
                estudioRealizadoViewModel.NombreEstadoEstudio = estudio.EstadoEstudio.Descripcion;
                estudioRealizadoViewModel.IdEstadoEstudio = estudio.IdEstado;
                estudioRealizadoViewModel.RegistroNuevo = "0";

                estudiosRealizadosViewModel.Add(estudioRealizadoViewModel);
            }
        }

        /// <summary>
        /// Establece la experiencia laboral del docente.
        /// </summary>
        /// <param name="experienciaLaboralDocenteViewModel">Información de la experiencia laboral del docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosExperienciaLaboral(List<ExperienciaDocenteViewModel> experienciaLaboralDocenteViewModel, DocenteDatosPersonales datosPersonalesDocente, bool modoEdicion)
        {
            if (experienciaLaboralDocenteViewModel != null)
            {
                if (modoEdicion)
                {
                    this.EstablecerDatosExperienciaLaboralModoEdicion(experienciaLaboralDocenteViewModel, datosPersonalesDocente);
                }
                else
                {
                    this.EstablecerDatosExperienciaLaboralModoCreacion(experienciaLaboralDocenteViewModel, datosPersonalesDocente);
                }
            }
        }

        /// <summary>
        /// Establece la experiencia laboral del docente en modo creación de docente.
        /// </summary>
        /// <param name="experienciaLaboralDocenteViewModel">Información de la experiencia laboral del docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosExperienciaLaboralModoCreacion(List<ExperienciaDocenteViewModel> experienciaLaboralDocenteViewModel, DocenteDatosPersonales datosPersonalesDocente)
        {
            DocenteExperienciaLaboral docenteExperienciaLaboral;

            foreach (ExperienciaDocenteViewModel experienciaLaboral in experienciaLaboralDocenteViewModel)
            {
                if (!String.IsNullOrEmpty(experienciaLaboral.Institucion))
                {
                    docenteExperienciaLaboral = new DocenteExperienciaLaboral();

                    docenteExperienciaLaboral.NombreInstitucion = experienciaLaboral.Institucion;
                    docenteExperienciaLaboral.FechaIngreso = Convert.ToDateTime(experienciaLaboral.FechaIngreso);
                    docenteExperienciaLaboral.FechaRetiro = String.IsNullOrEmpty(experienciaLaboral.FechaRetiro) ? (DateTime?)null : Convert.ToDateTime(experienciaLaboral.FechaRetiro);
                    docenteExperienciaLaboral.MotivoRetiro = experienciaLaboral.MotivoRetiro;
                    docenteExperienciaLaboral.AreasCompetencia = experienciaLaboral.AreasCompetencia;

                    datosPersonalesDocente.DocenteExperienciaLaboral.Add(docenteExperienciaLaboral);
                }
            }
        }

        /// <summary>
        /// Establece la experiencia laboral del docente en modo edición de docente.
        /// </summary>
        /// <param name="experienciaLaboralDocenteViewModel">Información de la experiencia laboral del docente establecidos en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        /// <param name="modoEdicion">True, si se está editando la información de un docente; de lo contrario false.</param>
        private void EstablecerDatosExperienciaLaboralModoEdicion(List<ExperienciaDocenteViewModel> experienciaLaboralDocenteViewModel, DocenteDatosPersonales datosPersonalesDocente)
        {
            List<DocenteExperienciaLaboral> experienciasLaborales = datosPersonalesDocente.DocenteExperienciaLaboral.ToList();

            foreach (ExperienciaDocenteViewModel experienciaDocente in experienciaLaboralDocenteViewModel)
            {
                if (experienciaDocente.RegistroNuevo == RegistroNuevo)
                {
                    datosPersonalesDocente.DocenteExperienciaLaboral.Add(new DocenteExperienciaLaboral()
                    {
                        NombreInstitucion = experienciaDocente.Institucion,
                        FechaIngreso = Convert.ToDateTime(experienciaDocente.FechaIngreso),
                        FechaRetiro = String.IsNullOrEmpty(experienciaDocente.FechaRetiro) ? (DateTime?)null : Convert.ToDateTime(experienciaDocente.FechaRetiro),
                        MotivoRetiro = experienciaDocente.MotivoRetiro,
                        AreasCompetencia = experienciaDocente.AreasCompetencia
                    });
                }
                else
                {
                    int indiceExperiencia = experienciasLaborales.FindIndex(o => o.Id == experienciaDocente.IdExperienciaDocente);
                    experienciasLaborales[indiceExperiencia].NombreInstitucion = experienciaDocente.Institucion;
                    experienciasLaborales[indiceExperiencia].FechaIngreso = Convert.ToDateTime(experienciaDocente.FechaIngreso);
                    experienciasLaborales[indiceExperiencia].FechaRetiro = String.IsNullOrEmpty(experienciaDocente.FechaRetiro) ? (DateTime?)null : Convert.ToDateTime(experienciaDocente.FechaRetiro);
                    experienciasLaborales[indiceExperiencia].MotivoRetiro = experienciaDocente.MotivoRetiro;
                    experienciasLaborales[indiceExperiencia].AreasCompetencia = experienciaDocente.AreasCompetencia;
                }
            }
        }

        /// <summary>
        /// Establece experiencia docente del docente para visualizar en la vista.
        /// </summary>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente almacenados en la base de datos.</param>
        /// <param name="datosPersonalesViewModel">Objeto en el que se establecerán los datos del docente.</param>
        private void EstablecerDatosExperienciaLaboralViewModel(IEnumerable<DocenteExperienciaLaboral> experienciasDocente, List<ExperienciaDocenteViewModel> experienciasViewModel)
        {
            ExperienciaDocenteViewModel experienciaLaboralViewModel;

            foreach (DocenteExperienciaLaboral experiencia in experienciasDocente)
            {
                experienciaLaboralViewModel = new ExperienciaDocenteViewModel();

                experienciaLaboralViewModel.IdExperienciaDocente = experiencia.Id;
                experienciaLaboralViewModel.Institucion = experiencia.NombreInstitucion;
                experienciaLaboralViewModel.FechaIngreso = experiencia.FechaIngreso.ToShortDateString();
                experienciaLaboralViewModel.FechaRetiro = experiencia.FechaRetiro.HasValue ? experiencia.FechaRetiro.Value.ToShortDateString() : null;
                experienciaLaboralViewModel.MotivoRetiro = experiencia.MotivoRetiro;
                experienciaLaboralViewModel.AreasCompetencia = experiencia.AreasCompetencia;
                experienciaLaboralViewModel.RegistroNuevo = "0";

                experienciasViewModel.Add(experienciaLaboralViewModel);
            }
        }

        /// <summary>
        /// Establece el estado del docente.
        /// </summary>
        /// <param name="estadoHorario">Información del estado del docente en la vista.</param>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente.</param>
        private void EstablecerDatosEstado(EstadoHorarioViewModel estadoHorario, DocenteDatosPersonales datosPersonalesDocente)
        {
            DocenteEstado docenteEstado = new DocenteEstado();

            docenteEstado.IdEstado = estadoHorario.IdEstado;
            docenteEstado.ObservacionesEstado = estadoHorario.Observaciones;
            docenteEstado.IdHorario = estadoHorario.IdHorario;

            datosPersonalesDocente.DocenteEstados.Add(docenteEstado);
        }

        /// <summary>
        /// Establece el estado del docente para visualizar en la vista.
        /// </summary>
        /// <param name="datosPersonalesDocente">Información de los datos personales del docente almacenados en la base de datos.</param>
        /// <param name="datosPersonalesViewModel">Objeto en el que se establecerán los datos del docente.</param>
        private void EstablecerDatosEstadoViewModel(DocenteEstado estadoDocente, EstadoHorarioViewModel estadoViewModel)
        {
            estadoViewModel.IdEstado = estadoDocente.IdEstado;
            estadoViewModel.Observaciones = estadoDocente.ObservacionesEstado;
            estadoViewModel.IdHorario = estadoDocente.IdHorario;
        }

        #endregion Métodos privados
    }
}