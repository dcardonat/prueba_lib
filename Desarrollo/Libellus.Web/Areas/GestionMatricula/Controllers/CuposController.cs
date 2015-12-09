namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Matriculas;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionMatricula.Models;
    using Libellus.Web.Helpers;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Gestiona las acciones de los cupos.
    /// </summary>
    public class CuposController : GestionMatriculaBaseController
    {
        /// <summary>
        /// Identificador de la sede actual.
        /// </summary>
        private int SedeActual = Utilidades.ContextoLibellus.ObtenerSedeActual;

        /// <summary>
        /// Identificador de la sede principal.
        /// </summary>
        private int SedePrincipal = Utilidades.ContextoLibellus.ObtenerSedePrincipal;

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public CuposController()
        {
            this.NegocioCupos = new NegocioCupos(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioSalidasOcupacionales = new NegocioSalidasOcupacionales(this.UnidadDeTrabajoLibellus);
            this.NegocioGradosPorNivel = new NegocioGradosPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioEstudiantes = new NegocioEstudiantes(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Consulta la informacion de un estudiante existente.
        /// </summary>
        /// <param name="tipoDocumento">Tipo de documento de identidad.</param>
        /// <param name="documento">Numero de documento de identidad.</param>
        /// <returns>Informacion del estudiante en formato JSON.</returns>
        public JsonResult ConsultarEstudiante(int tipoDocumento, string documento)
        {
            var query = this.NegocioEstudiantes.ConsultarEstudiante(tipoDocumento, documento);
            if (query != null)
            {
                var datosEstudiante = new
                {
                    Resultado = true,
                    Nombre = query.Nombre,
                    PrimerApellido = query.PrimerApellido,
                    SegundoApellido = query.SegundoApellido,
                    Correo = query.Usuario.Correo,
                    TelefonoFijo = query.DatosResidenciales.TelefonoFijo,
                    TelefonoMovil = query.DatosResidenciales.TelefonoMovil,
                    IdSexo = query.IdSexo,
                    IdEstudiante = query.Id,
                    FechaNacimiento = query.FechaNacimiento.ToShortDateString()
                };

                return Json(datosEstudiante);
            }
            else
            {
                var datosEstudiante = new
                {
                    Resultado = false
                };

                return Json(datosEstudiante);
            }
        }

        /// <summary>
        /// Obtiene las asignaturas pertenecientes a un area especifica.
        /// </summary>
        /// <param name="IdArea">Area seleccionada.</param>
        /// <returns>Asignaturas del area.</returns>
        public JsonResult GradosPorNivel(string IdNivel)
        {
            int idNivel = Convert.ToInt32(IdNivel);
            var gradosPorNivel = (from c in this.NegocioGradosPorNivel.ConsultarGradosPorNivelEntidad(idNivel)
                                  select new
                                  {
                                      Text = c.Grado.Descripcion,
                                      Value = c.Id
                                  }).OrderBy(e => e.Text);

            return Json(gradosPorNivel);
        }

        /// <summary>
        /// Redirecciona a la vista principal.
        /// </summary>
        /// <returns>Retorna a la vista.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            CuposViewModel viewModel = null;
            try
            {
                viewModel = this.EstablecerValoresModelo();
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Bienvenida", "Home", new { area = string.Empty });
            }

            return View(viewModel);
        }

        /// <summary>
        /// Genera un
        /// </summary>
        /// <param name="cupo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(CuposViewModel viewModel)
        {
            int resultadoEstudiante = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Cupo cupo = new Cupo();
                    cupo.IdAnioLectivo = viewModel.IdAnioLectivo;
                    cupo.IdGradoPorNivel = viewModel.IdGradoPorNivel;
                    cupo.IdSalidaOcupacional = viewModel.IdSalidaOcupacional;
                    cupo.IdTipoEstudiante = viewModel.IdTipoEstudiante;
                    cupo.TrasladoEstudiante = viewModel.TrasladoEstudiante;
                    cupo.IdEstudiante = viewModel.IdEstudiante;
                    cupo.IdSede = SedeActual;
                    cupo.IdProfundizacion = viewModel.IdProfundizacion;
                    cupo.Estudiante = new EstudianteDatosPersonales();
                    cupo.Estudiante.IdSexo = viewModel.IdSexo;
                    cupo.Estudiante.Id = viewModel.IdEstudiante;
                    cupo.Estudiante.Nombre = viewModel.Nombre;
                    cupo.Estudiante.PrimerApellido = viewModel.PrimerApellido;
                    cupo.Estudiante.SegundoApellido = viewModel.SegundoApellido;
                    cupo.Estudiante.FechaNacimiento = DateTime.Parse(viewModel.FechaNacimiento);
                    cupo.Estudiante.DatosResidenciales = new EstudianteDatosResidenciales();
                    cupo.Estudiante.DatosResidenciales.Id = cupo.Estudiante.Id;
                    cupo.Estudiante.DatosResidenciales.TelefonoFijo = viewModel.TelefonoFijo;
                    cupo.Estudiante.DatosResidenciales.TelefonoMovil = viewModel.TelefonoMovil;
                    cupo.Estudiante.Usuario = new Usuario();
                    cupo.Estudiante.Usuario.Id = cupo.Estudiante.Id;
                    cupo.Estudiante.Usuario.Correo = viewModel.Correo;
                    cupo.Estudiante.Usuario.Identificacion = viewModel.Identificacion;
                    cupo.Estudiante.Usuario.IdTipoIdentificacion = viewModel.IdTipoIdentificacion;

                    resultadoEstudiante = this.NegocioCupos.GenerarCupo(cupo);
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1007));
                    viewModel = this.EstablecerValoresModelo(viewModel);
                    return View(viewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                viewModel = this.EstablecerValoresModelo(viewModel);
                return View(viewModel);
            }

            return RedirectToAction("Actualizar", "DatosGeneralesEstudiante", new { id = resultadoEstudiante, soloLectura = false });
        }

        /// <summary>
        /// Establece los valores que lleva el model para presentar la vista.
        /// </summary>
        /// <returns>Retorna una instancia del viewmodel.</returns>
        private CuposViewModel EstablecerValoresModelo(CuposViewModel cupo = null)
        {
            var anios = this.NegocioAnioLectivo.ConsultarAniosLectivosAbiertos()
                .OrderByDescending(e => e.Anio)
                .ToSelectListItem(e => e.Anio, e => e.Id);

            var tiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, SedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            var niveles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, SedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var sexos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Sexo, SedePrincipal, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var salidasOcupacionales = this.NegocioSalidasOcupacionales.ConsultarSalidasOcupacionalesPorSede(true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var profundizacion = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Profundizacion, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(e => e.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            if (cupo != null)
            {
                cupo.ComboTipoIdentificacion = tiposDocumento;
                cupo.ComboNivelEducativo = niveles;
                cupo.ComboSexo = sexos;
                cupo.ComboSalidaOcupacional = salidasOcupacionales;
                cupo.ComboAnios = anios;
                cupo.ComboProfundizacion = profundizacion;

                return cupo;
            }
            else
            {
                CuposViewModel viewModel = new CuposViewModel()
                {
                    ComboTipoIdentificacion = tiposDocumento,
                    ComboNivelEducativo = niveles,
                    ComboSexo = sexos,
                    ComboSalidaOcupacional = salidasOcupacionales,
                    ComboAnios = anios,
                    ComboProfundizacion = profundizacion
                };

                return viewModel;
            }
        }
    }
}