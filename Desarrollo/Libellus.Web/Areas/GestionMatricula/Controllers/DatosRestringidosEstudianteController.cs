namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Matriculas;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante;

    /// <summary>
    /// Clase que se encarga de la administracion de los datos restringidos del estudiante.
    /// </summary>
    public class DatosRestringidosEstudianteController : GestionMatriculaBaseController
    {
        /// <summary>
        /// Parametro para la sede actual.
        /// </summary>
        private int sedePrincipal = Utilidades.ContextoLibellus.ObtenerSedeActual;

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public DatosRestringidosEstudianteController()
        {
            this.NegocioEstudiantes = new NegocioEstudiantes(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Actualiza la información restringida de un estudiante.
        /// </summary>
        /// <param name="id">Id del estudiante.</param>
        /// <param name="tipoDocumento">Tipo de documento.</param>
        /// <param name="documento">Documento del estudiante.</param>
        /// <param name="clave">Clave de acceso al sistema.</param>
        /// <param name="nombre">Nombre del estudiante.</param>
        /// <param name="primerApellido">Primer apellido del estudiante.</param>
        /// <param name="segundoApellido">Segundo apellido del estudiante.</param>
        /// <returns>Retorna falso o verdadero para confirmar el resultado de la operación.</returns>
        public bool ActualizarEstudiante(int id, int tipoDocumento, string documento, string clave, string nombre, string primerApellido, string segundoApellido)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }

                EstudianteDatosPersonales estudiante = new EstudianteDatosPersonales()
                {
                    Usuario = new Usuario()
                    {
                        IdTipoIdentificacion = tipoDocumento,
                        Identificacion = documento,
                        Clave = clave
                    },
                    Id = id,
                    Nombre = nombre,
                    PrimerApellido = primerApellido,
                    SegundoApellido = segundoApellido
                };

                this.NegocioEstudiantes.ActualizarEstudiante(estudiante);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                throw;
            }

            return true;
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
                    IdEstudiante = query.Id,
                    Nombre = query.Nombre,
                    PrimerApellido = query.PrimerApellido,
                    SegundoApellido = query.SegundoApellido,
                    TipoDocumento = query.Usuario.IdTipoIdentificacion,
                    Documento = query.Usuario.Identificacion,
                    Clave = Utilidades.EncripcionLibellus.Descifrar(query.Usuario.Clave)
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
        /// Retorna la vista de la acción.
        /// </summary>
        /// <returns>Retorna la vista inicio.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            var tiposDocumento = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sedePrincipal, true)
                        .OrderBy(e => e.Descripcion)
                        .ToSelectListItem(o => o.Descripcion, o => o.Id);

            EstudianteViewModel viewModel = new EstudianteViewModel()
            {
                ComboTiposIdentificacion = tiposDocumento
            };

            ViewBag.TiposDocumento = tiposDocumento;

            return View(viewModel);
        }
    }
}