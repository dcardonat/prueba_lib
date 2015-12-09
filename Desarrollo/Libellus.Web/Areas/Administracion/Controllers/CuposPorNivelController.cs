namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Negocio.Matriculas.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.CuposPorNivel;
    using Libellus.Web.Helpers;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los cupos por nivel.
    /// </summary>
    public class CuposPorNivelController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo CuposPorNivelController.
        /// </summary>
        public CuposPorNivelController()
        {
            this.NegocioCuposPorNivel = new NegocioCuposPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
            this.NegocioMatriculas = new NegocioMatriculas(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Metodo gest para la administración de cupos por nivel.
        /// </summary>
        /// <param name="pagina">Página para la aginación de la tabla.</param>
        /// <param name="IdAnioLectivo">Año seleccionado.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        [HttpGet]
        public ActionResult Administrar(int? pagina, int? IdAnioLectivo)
        {
            CuposPorNivelConsultaViewModels cuposPorNivelConsultaViewModels = new CuposPorNivelConsultaViewModels();

            try
            {
                List<AnioLectivo> anios = this.NegocioAnioLectivo.ConsultarAniosLectivos().ToList();
                AnioLectivo anoLectivo = anios.Where(x => x.Anio == DateTime.Now.Year).FirstOrDefault();
                cuposPorNivelConsultaViewModels.IdAnioLectivo = anoLectivo.Id;
                cuposPorNivelConsultaViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                ViewBag.AnioLectivo = cuposPorNivelConsultaViewModels.IdAnioLectivo;

                if (IdAnioLectivo.HasValue)
                {
                    this.ObtenerInformacionCuposPorNivel(cuposPorNivelConsultaViewModels, IdAnioLectivo);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(cuposPorNivelConsultaViewModels);
        }

        /// <summary>
        /// Metodo post para almacenar la iformación.
        /// </summary>
        /// <param name="cuposPorNivel">Modelo para el almacenamiento.</param>
        /// <returns>Retorna el resultado de la acción</returns>
        [HttpPost]
        public JsonResult Administrar(List<CuposPorNivelViewModels> cuposPorNivel)
        {
            List<ProyeccionCuposPorNivel> ListaCuposPorNivel = new List<ProyeccionCuposPorNivel>();
            ProyeccionCuposPorNivel cupoPorNivel = new ProyeccionCuposPorNivel();
            try
            {
                foreach (var item in cuposPorNivel)
                {
                    cupoPorNivel = new ProyeccionCuposPorNivel()
                    {
                        Id = item.Id == null ? 0 : (int)item.Id,
                        IdNivel = item.IdNivelEducativo,
                        IdAnioLectivo = item.IdAnio,
                        EstudiantesEsperados = item.EstudiantesEsperados,
                        EstudiantesGrupo = item.EstudiantesGrupo,
                        CantidadGrupos = item.CantidadGrupos,
                        CantidadDocentes = item.CantidadDocentes
                    };

                    ListaCuposPorNivel.Add(cupoPorNivel);
                }

                if (NegocioCuposPorNivel.Administrar(ListaCuposPorNivel))
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return Json(Url.Action("Administrar"));
        }

        /// <summary>
        /// Consulta la información de cupos por nivel.
        /// </summary>
        /// <param name="pagina">Pagina para realizar la páginación.</param>
        /// <param name="IdAnioLectivo">Año seleccionado.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarInformacionCuposPorNivel(int? anio)
        {
            CuposPorNivelConsultaViewModels cuposPorNivelConsultaViewModels = new CuposPorNivelConsultaViewModels();

            try
            {
                AnioLectivo anoLectivo = this.NegocioAnioLectivo.ConsultarAnioLectivo((int)anio);

                if (anoLectivo != null)
                {
                    cuposPorNivelConsultaViewModels.IdAnioLectivo = anoLectivo.Id;
                    cuposPorNivelConsultaViewModels.AnioLectivo.Cerrado = anoLectivo.Cerrado;
                    ViewBag.AnioLectivo = cuposPorNivelConsultaViewModels.IdAnioLectivo;
                }

                if (anio.HasValue)
                {
                    this.ObtenerInformacionCuposPorNivel(cuposPorNivelConsultaViewModels, anio);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return PartialView("_InformacionCuposPorNivel", cuposPorNivelConsultaViewModels);
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Obtiene la información de cupos por nivel.
        /// </summary>
        /// <param name="cuposPorNivelConsultaViewModels">Parametro para almacenar la información.</param>
        /// <param name="IdAnioLectivo">Año seleccionado.</param>
        private void ObtenerInformacionCuposPorNivel(CuposPorNivelConsultaViewModels cuposPorNivelConsultaViewModels, int? IdAnioLectivo)
        {
            cuposPorNivelConsultaViewModels.IdAnioLectivo = (int)IdAnioLectivo.Value;
            IEnumerable<ProyeccionCuposPorNivel> ListProyeccionCuposPorNivel = NegocioCuposPorNivel.ConsultarProyeccionCuposNivel((int)IdAnioLectivo.Value);
            IEnumerable<Maestro> ListaNiveles = NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, Utilidades.ContextoLibellus.ObtenerSedeActual);

            cuposPorNivelConsultaViewModels.CuposPorNivel = ListaNiveles.GroupJoin(
                ListProyeccionCuposPorNivel,
                p => p.Id,
                c => c.IdNivel,
                (p, g) => g
                    .Select(c => new CuposPorNivelViewModels
                    {
                        Id = c.Id,
                        IdNivelEducativo = p.Id,
                        NivelEducativo = p.Descripcion,
                        Consecutivo = p.Consecutivo,
                        EstudiantesGrupo = c.EstudiantesGrupo,
                        EstudiantesEsperados = c.EstudiantesEsperados,
                        CantidadGrupos = c.CantidadGrupos,
                        CantidadDocentes = c.CantidadDocentes,
                        CantidadEstudiantesMatriculados = this.ConsultarCantidadEstudiantesMatriculadosPorNivel(p.Id, (int)IdAnioLectivo)
                    })
                    .DefaultIfEmpty(new CuposPorNivelViewModels
                    {
                        Id = null,
                        IdNivelEducativo = p.Id,
                        NivelEducativo = p.Descripcion,
                        Consecutivo = p.Consecutivo,
                        EstudiantesGrupo = 0,
                        EstudiantesEsperados = 0,
                        CantidadGrupos = 0,
                        CantidadDocentes = 0,
                        CantidadEstudiantesMatriculados = this.ConsultarCantidadEstudiantesMatriculadosPorNivel(p.Id, (int)IdAnioLectivo)
                    })
                ).SelectMany(g => g).ToList();
        }

        /// <summary>
        /// Consulta la cantidad de estudiantes matriculados por año y nivel.
        /// </summary>
        /// <param name="idNivel">Identficador del nivel.</param>
        /// <param name="idAnio">Identificador del año.</param>
        /// <returns>Retorna el resultadod de la consulta.</returns>
        private int ConsultarCantidadEstudiantesMatriculadosPorNivel(int idNivel, int idAnio)
        {
            return this.NegocioMatriculas.MatriculadosPorNivelAnioLectivo(idNivel, idAnio).Count();
        }

        #endregion
    }
}