namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Matriculas;
    using Libellus.Negocio.Matriculas.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Clase encargada de la interacción de los datos con la vista.
    /// </summary>
    public class DatosGeneralesEstudianteController : GestionMatriculaBaseController
    {
        /// <summary>
        /// Sede de la sesión.
        /// </summary>
        private int sedePrincipal = Utilidades.ContextoLibellus.ObtenerSedeActual;

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public DatosGeneralesEstudianteController()
        {
            this.NegocioEstudiantes = new NegocioEstudiantes(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAntecedentesAcademicos = new NegocioAntecedentesAcademicos(this.UnidadDeTrabajoLibellus);
            this.NegocioMatriculas = new NegocioMatriculas(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Carga la vista principal de los datos del estudiante.
        /// </summary>
        /// <param name="id">Identificador del estudiante.</param>
        /// <returns>Retorna la vista principal.</returns>
        [HttpGet]
        public ActionResult Actualizar(int id, bool soloLectura)
        {
            EstudianteViewModel viewModel = null;

            try
            {
                EstudianteDatosPersonales estudiante = this.NegocioEstudiantes.ConsultarEstudiante(id);
                viewModel = this.EstablecerValoresModelo(estudiante);
                ViewBag.SoloLectura = soloLectura;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Bienvenida", "Home", new { area = "" });
            }

            return View(viewModel);
        }

        /// <summary>
        /// Actualiza la información del estudiante.
        /// </summary>
        /// <param name="estudiante">Datos del estudiante</param>
        /// <param name="postedFoto">Foto del estudiante.</param>
        /// <returns>Redirecciona a la acción Consultar.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(EstudianteDatosPersonales estudiante, HttpPostedFileBase postedFoto)
        {
            try
            {
                if (postedFoto != null)
                {
                    estudiante.Archivos = new EstudianteArchivo()
                    {
                        Foto = UtilidadesApp.ObtenerBytesArchivo(postedFoto.InputStream, postedFoto.ContentLength)
                    };
                }

                estudiante.ActualizarAntecedentes = true;
                this.NegocioEstudiantes.ActualizarEstudiante(estudiante);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Actualizar", new { id = estudiante.Id, soloLectura = false });
        }

        /// <summary>
        /// Retorna la vista consultar de los estudiantes.
        /// </summary>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        public ActionResult Consultar(int? IdAnioLectivo, int? IdTipoIdentificacion, string Identificacion, int? IdEstado, int? IdGrado, string Grupo, int pagina = 1)
        {
            IEnumerable<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

            try
            {
                if (Request.IsAjaxRequest())
                {
                    var query = this.NegocioEstudiantes.ConsultarEstudiantes(IdAnioLectivo, IdTipoIdentificacion, Identificacion, IdEstado, IdGrado, Grupo);
                    estudiantes = (from c in query
                                   select new EstudianteViewModel()
                                   {
                                       Id = c.Id,
                                       Nombre = c.Nombre,
                                       PrimerApellido = c.PrimerApellido,
                                       SegundoApellido = c.SegundoApellido,
                                       Usuario = new UsuarioViewModel() { Identificacion = c.Usuario.Identificacion },
                                       Estado = new Maestro()
                                       {
                                           Descripcion = c.Cupos
                                           .Where(e => !IdAnioLectivo.HasValue || e.IdAnioLectivo == IdAnioLectivo)
                                           .Select(e => e.Matriculas.FirstOrDefault().Estado.Descripcion).FirstOrDefault()
                                       }
                                   }).ToPagedList(pagina, 10);

                    return PartialView("_ResultadoConsulta", estudiantes);
                }
                else
                {
                    var tiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sedePrincipal, true)
                        .OrderBy(e => e.Descripcion)
                        .ToSelectListItem(o => o.Descripcion, o => o.Id);

                    var estadosEstudiante = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstadosMatricula, sedePrincipal, true)
                        .OrderBy(e => e.Descripcion)
                        .ToSelectListItem(o => o.Descripcion, o => o.Id);

                    var grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                        .OrderBy(e => e.Descripcion)
                        .ToSelectListItem(o => o.Descripcion, o => o.Id);

                    ViewBag.TiposDocumento = tiposDocumento;
                    ViewBag.EstadosEstudiante = estadosEstudiante;
                    ViewBag.Grados = grados;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(estudiantes.ToPagedList(pagina, 10));
        }

        /// <summary>
        /// Realiza la consulta de un familiar de estudiante.
        /// </summary>
        /// <param name="identificacion">Identificacion del familiar.</param>
        /// <returns>Familiar serializado.</returns>
        public JsonResult ConsultarFamiliarEstudiante(string identificacion)
        {
            FamiliarViewModel familiar = new FamiliarViewModel();

            var query = this.NegocioEstudiantes.ConsultarFamiliarEstudiante(identificacion);

            if (query != null)
            {
                familiar = new FamiliarViewModel()
                {
                    Id = query.Id,
                    Barrio = query.Barrio,
                    Celular = query.Celular,
                    Correo = query.Correo,
                    Direccion = query.Direccion,
                    EsAcudiente = query.EsAcudiente ?? false,
                    Identificacion = query.Identificacion,
                    IdEstadoCivil = query.IdEstadoCivil ?? 0,
                    IdEstrato = query.IdEstrato ?? 0,
                    IdNivelEscolaridad = query.IdNivelEscolaridad,
                    IdParentesco = query.IdParentesco ?? 0,
                    IdTipoIdentificacion = query.IdTipoIdentificacion,
                    Nombres = query.Nombres,
                    Vive = query.Vive ?? false,
                    Telefono = query.Telefono
                };

                if (query.IdMunicipio.HasValue)
                {
                    familiar.IdMunicipio = query.IdMunicipio.Value;
                    familiar.IdDepartamento = query.Municipio.IdDepartamento;
                    familiar.IdPais = query.Municipio.Departamentos.IdPais;
                }
            }

            return Json(familiar);
        }

        /// <summary>
        /// Exportar la información de la funcionalidad.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_datos_estudiante.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> documentos = this.NegocioEstudiantes.ConsultarEstudiantes(null, null, null, null, null, null)
                    .Select(e => new
                    {
                        Documento_identidad = e.Usuario.Identificacion,
                        Estudiante = string.Format("{0} {1} {2}", e.Nombre, e.PrimerApellido, e.SegundoApellido),
                        Estado = e.Cupos.Select(f => f.Matriculas.FirstOrDefault().Estado.Descripcion).FirstOrDefault()
                    });

                byteArray = ExportarExcel.Exportar(documentos.ToList(), "DatosEstudiante");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Establece los valores para asociarlos al view model.
        /// </summary>
        /// <param name="estudiante">Entidad con los datos del estudiante.</param>
        /// <returns>Modelo de tipo Estudiante.</returns>
        private EstudianteViewModel EstablecerValoresModelo(EstudianteDatosPersonales estudiante = null)
        {
            var tiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var sexos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Sexo, sedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var grupoSanguineos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.GruposSanguineos, sedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var paises = this.NegocioMaestros.ConsultarPaises()
                .OrderBy(o => o.Nombre)
                .ToSelectListItem(o => o.Nombre, o => o.Id);

            var estratos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstratoSocioEconomico, sedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var tiposInstitucion = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposInstitucion, Utilidades.ContextoLibellus.ObtenerSedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var motivosRetiro = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.MotivosRetiroEstudiante, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var eps = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EntidadesPrestadorasSalud, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var estadosCivil = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.EstadoCivil, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var nivelesEscolaridad = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.ClasificacionesAcademicas, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var parentescos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Parentescos, Utilidades.ContextoLibellus.ObtenerSedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            EstudianteViewModel viewModel = new EstudianteViewModel()
            {
                ComboTiposIdentificacion = tiposDocumento,
                ComboSexos = sexos,
                ComboGruposSanguineos = grupoSanguineos,
                ComboPaises = paises,
                ComboEstratos = estratos,
                ComboTipoInstitucion = tiposInstitucion,
                ComboMotivosRetiro = motivosRetiro,
                ComboGrados = grados,
                ComboEPS = eps,
                ComboEstadosCivil = estadosCivil,
                ComboNivelesEscolaridad = nivelesEscolaridad,
                ComboParentesco = parentescos
            };

            if (estudiante != null)
            {
                viewModel.Id = estudiante.Id;
                viewModel.Nombre = estudiante.Nombre;
                viewModel.PrimerApellido = estudiante.PrimerApellido;
                viewModel.SegundoApellido = estudiante.SegundoApellido;
                viewModel.IdSexo = estudiante.IdSexo;
                viewModel.IdGrupoSanguineo = estudiante.IdGrupoSanguineo;
                viewModel.FechaNacimiento = estudiante.FechaNacimiento.ToShortDateString();
                viewModel.IdEntidadPromotoraSalud = estudiante.IdEntidadPromotoraSalud;
                if (estudiante.IdMunicipioNacimiento.HasValue)
                {
                    viewModel.IdMunicipioNacimiento = estudiante.IdMunicipioNacimiento.Value;
                    viewModel.IdDepartamentoNacimiento = estudiante.MunicipioNacimiento.IdDepartamento;
                    viewModel.IdPaisNacimiento = estudiante.MunicipioNacimiento.Departamentos.IdPais;
                    viewModel.DepartamentoNacimiento = estudiante.MunicipioNacimiento.Departamentos.Nombre;
                    viewModel.MunicipioNacimiento = estudiante.MunicipioNacimiento.Nombre;
                }

                if (estudiante.Archivos != null)
                {
                    viewModel.UrlFoto = UtilidadesApp.ObtenerUrlBase64(estudiante.Archivos.Foto);
                }

                viewModel.DatosResidenciales = new DatosResidencialesViewModel()
                {
                    Direccion = estudiante.DatosResidenciales.Direccion,
                    Barrio = estudiante.DatosResidenciales.Barrio,
                    IdEstrato = estudiante.DatosResidenciales.IdEstrato,
                    TelefonoFijo = estudiante.DatosResidenciales.TelefonoFijo,
                    TelefonoMovil = estudiante.DatosResidenciales.TelefonoMovil,
                    Id = estudiante.DatosResidenciales.Id
                };

                if (estudiante.DatosResidenciales.IdMunicipio.HasValue)
                {
                    viewModel.DatosResidenciales.IdMunicipio = estudiante.DatosResidenciales.IdMunicipio.Value;
                    viewModel.DatosResidenciales.IdDepartamento = estudiante.DatosResidenciales.Municipio.IdDepartamento;
                    viewModel.DatosResidenciales.IdPais = estudiante.DatosResidenciales.Municipio.Departamentos.IdPais;

                    viewModel.IdPais = viewModel.DatosResidenciales.IdPais;
                    viewModel.IdDepartamento = viewModel.DatosResidenciales.IdDepartamento;
                    viewModel.IdMunicipio = viewModel.DatosResidenciales.IdMunicipio;
                    viewModel.Departamento = estudiante.DatosResidenciales.Municipio.Departamentos.Nombre;
                    viewModel.Municipio = estudiante.DatosResidenciales.Municipio.Nombre;
                }

                viewModel.Usuario = new UsuarioViewModel()
                {
                    IdTipoIdentificacion = estudiante.Usuario.IdTipoIdentificacion,
                    Identificacion = estudiante.Usuario.Identificacion,
                    Clave = Utilidades.EncripcionLibellus.Descifrar(estudiante.Usuario.Clave),
                    Correo = estudiante.Usuario.Correo
                };

                if (estudiante.DatosFamiliares != null)
                {
                    viewModel.DatosFamiliares = new DatosFamiliaresViewModel();
                    viewModel.DatosFamiliares.Id = estudiante.DatosFamiliares.Id;
                    viewModel.DatosFamiliares.IdAcudiente = estudiante.DatosFamiliares.IdAcudiente;

                    viewModel.DatosFamiliares.Acudiente = new FamiliarViewModel()
                    {
                        Identificacion = estudiante.DatosFamiliares.Acudiente.Identificacion,
                        IdTipoIdentificacion = estudiante.DatosFamiliares.Acudiente.IdTipoIdentificacion,
                        Nombres = estudiante.DatosFamiliares.Acudiente.Nombres,
                        Telefono = estudiante.DatosFamiliares.Acudiente.Telefono,
                        Celular = estudiante.DatosFamiliares.Acudiente.Celular,
                        Correo = estudiante.DatosFamiliares.Acudiente.Correo,
                        IdNivelEscolaridad = estudiante.DatosFamiliares.Acudiente.IdNivelEscolaridad,
                        IdParentesco = estudiante.DatosFamiliares.Acudiente.IdParentesco
                    };

                    if (estudiante.DatosFamiliares.IdPadre.HasValue)
                    {
                        viewModel.DatosFamiliares.TienePadre = true;
                        viewModel.DatosFamiliares.IdPadre = estudiante.DatosFamiliares.IdPadre;
                        viewModel.IdMunicipioPadre = estudiante.DatosFamiliares.Padre.IdMunicipio.Value;
                        viewModel.IdDepartamentoPadre = estudiante.DatosFamiliares.Padre.Municipio.IdDepartamento;
                        viewModel.IdPaisPadre = estudiante.DatosFamiliares.Padre.Municipio.Departamentos.IdPais;
                        viewModel.DepartamentoPadre = estudiante.DatosFamiliares.Padre.Municipio.Departamentos.Nombre;
                        viewModel.MunicipioPadre = estudiante.DatosFamiliares.Padre.Municipio.Nombre;
                        viewModel.DatosFamiliares.Padre = new FamiliarViewModel()
                        {
                            Barrio = estudiante.DatosFamiliares.Padre.Barrio,
                            Celular = estudiante.DatosFamiliares.Padre.Celular,
                            Correo = estudiante.DatosFamiliares.Padre.Correo,
                            Direccion = estudiante.DatosFamiliares.Padre.Direccion,
                            EsAcudiente = estudiante.DatosFamiliares.Padre.EsAcudiente.Value,
                            Id = estudiante.DatosFamiliares.Padre.Id,
                            IdMunicipio = estudiante.DatosFamiliares.Padre.IdMunicipio.Value,
                            Identificacion = estudiante.DatosFamiliares.Padre.Identificacion,
                            IdEstadoCivil = estudiante.DatosFamiliares.Padre.IdEstadoCivil.Value,
                            IdEstrato = estudiante.DatosFamiliares.Padre.IdEstrato.Value,
                            IdNivelEscolaridad = estudiante.DatosFamiliares.Padre.IdNivelEscolaridad,
                            IdTipoIdentificacion = estudiante.DatosFamiliares.Padre.IdTipoIdentificacion,
                            Nombres = estudiante.DatosFamiliares.Padre.Nombres,
                            Vive = estudiante.DatosFamiliares.Padre.Vive.Value,
                            Telefono = estudiante.DatosFamiliares.Padre.Telefono,
                            IdDepartamento = estudiante.DatosFamiliares.Padre.Municipio.IdDepartamento,
                            IdPais = estudiante.DatosFamiliares.Padre.Municipio.Departamentos.IdPais,
                        };
                    }

                    if (estudiante.DatosFamiliares.IdMadre.HasValue)
                    {
                        viewModel.DatosFamiliares.TieneMadre = true;
                        viewModel.DatosFamiliares.IdMadre = estudiante.DatosFamiliares.IdMadre;
                        viewModel.IdMunicipioMadre = estudiante.DatosFamiliares.Madre.IdMunicipio.Value;
                        viewModel.IdDepartamentoMadre = estudiante.DatosFamiliares.Madre.Municipio.IdDepartamento;
                        viewModel.IdPaisMadre = estudiante.DatosFamiliares.Madre.Municipio.Departamentos.IdPais;
                        viewModel.DepartamentoMadre = estudiante.DatosFamiliares.Madre.Municipio.Departamentos.Nombre;
                        viewModel.MunicipioMadre = estudiante.DatosFamiliares.Madre.Municipio.Nombre;
                        viewModel.DatosFamiliares.Madre = new FamiliarViewModel()
                        {
                            Barrio = estudiante.DatosFamiliares.Madre.Barrio,
                            Celular = estudiante.DatosFamiliares.Madre.Celular,
                            Correo = estudiante.DatosFamiliares.Madre.Correo,
                            Direccion = estudiante.DatosFamiliares.Madre.Direccion,
                            EsAcudiente = estudiante.DatosFamiliares.Madre.EsAcudiente.Value,
                            Id = estudiante.DatosFamiliares.Madre.Id,
                            IdMunicipio = estudiante.DatosFamiliares.Madre.IdMunicipio.Value,
                            Identificacion = estudiante.DatosFamiliares.Madre.Identificacion,
                            IdEstadoCivil = estudiante.DatosFamiliares.Madre.IdEstadoCivil.Value,
                            IdEstrato = estudiante.DatosFamiliares.Madre.IdEstrato.Value,
                            IdNivelEscolaridad = estudiante.DatosFamiliares.Madre.IdNivelEscolaridad,
                            IdTipoIdentificacion = estudiante.DatosFamiliares.Madre.IdTipoIdentificacion,
                            Nombres = estudiante.DatosFamiliares.Madre.Nombres,
                            Vive = estudiante.DatosFamiliares.Madre.Vive.Value,
                            Telefono = estudiante.DatosFamiliares.Madre.Telefono,
                            IdDepartamento = estudiante.DatosFamiliares.Madre.Municipio.IdDepartamento,
                            IdPais = estudiante.DatosFamiliares.Madre.Municipio.Departamentos.IdPais
                        };
                    }
                }

                viewModel.DatosEstado = new DatosEstadoViewModel()
                {
                    Horario = "Horario",
                    EstadoEstudiante = estudiante.Cupos.Last().Matriculas.Last().Estado.Descripcion,
                    FechaCreacion = estudiante.FechaCreacion.Value.ToShortDateString(),
                    FechaActualizacion = estudiante.FechaActualizacion.HasValue ? estudiante.FechaActualizacion.Value.ToShortDateString() : string.Empty
                };

                if (estudiante.Cupos.Last().IdSalidaOcupacional.HasValue)
                {
                    viewModel.DatosEstado.SalidaOcupacional = estudiante.Cupos.Last().SalidaOcupacional.Descripcion;
                    viewModel.DatosEstado.EstadoSalidaOcupacional = estudiante.Cupos.Last().SalidaOcupacional.Estado ? "Activo" : "Inactivo";
                }

                viewModel.AntecedentesAcademicos = from c in estudiante.AntecedentesAcademicos
                                                   select new AntecedentesAcademicosViewModel()
                                                   {
                                                       Id = c.Id,
                                                       Anio = c.Anio,
                                                       Grado = c.Grado,
                                                       IdGrado = c.IdGrado,
                                                       MotivoRetiro = c.MotivoRetiro,
                                                       IdMotivoRetiro = c.IdMotivoRetiro,
                                                       InstitucionEducativa = c.InstitucionEducativa,
                                                       Observacion = c.Observacion,
                                                       TipoInstitucion = c.TipoInstitucion,
                                                       IdTipoInstitucion = c.IdTipoInstitucion
                                                   };
            }

            return viewModel;
        }
    }
}