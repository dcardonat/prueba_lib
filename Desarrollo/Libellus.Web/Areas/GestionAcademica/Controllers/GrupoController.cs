namespace Libellus.Web.Areas.GestionAcademica.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Negocio.GestionAcademica.Clases;
    using Libellus.Negocio.Matriculas;
    using Libellus.Negocio.Matriculas.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionAcademica.Models.Grupo;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona las funcionalidades para la administración de grupos. 
    /// </summary>
    public class GrupoController : GestionAcademicaBaseController
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public GrupoController()
        {
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
            this.NegocioAulas = new NegocioAulas(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioGradosPorNivel = new NegocioGradosPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioMatriculas = new NegocioMatriculas(this.UnidadDeTrabajoLibellus);
            this.NegocioCuposPorNivel = new NegocioCuposPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioGruposPorGrado = new NegocioGruposPorGrado(this.UnidadDeTrabajoLibellus);
            this.NegocioGrupos = new NegocioGrupos(this.UnidadDeTrabajoLibellus);
            this.NegocioEstudiantes = new NegocioEstudiantes(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Retorna la vista de estudiantes por grupo.
        /// </summary>
        /// <returns>La vista de estuduantes por grupo.</returns>
        [HttpGet]
        public ActionResult AdministrarEstudiantesPorGrupo(int? idAnioLectivo, int? idNivel, bool consultar = false, bool habilitarCampos = true)
        {
            ViewBag.HabilitarCampos = habilitarCampos;
            EstudianteGrupoViewModel estudiantesGrupo = new EstudianteGrupoViewModel();

            try
            {
                estudiantesGrupo.IdAnioLectivo = this.NegocioAnioLectivo.ConsultarIdAnioActual((short)DateTime.Now.Year);
                estudiantesGrupo.Niveles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, ContextoLibellus.ObtenerSedeActual, true)
                    .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Descripcion });

                if (consultar)
                {
                    IEnumerable<GradosPorNivel> gradosPorNivel = this.NegocioGradosPorNivel.ConsultarGradosPorNivelEntidad((int)idNivel);
                    int cantidadEstudiantesPorGrupo = this.NegocioCuposPorNivel.ConsultarCantidadEstudiantesPorGrupo((int)idAnioLectivo, (int)idNivel);
                    IEnumerable<Grupo> gruposAsignados = this.NegocioGrupos.ConsultarGrupos((int)idAnioLectivo, (int)idNivel);
                    Grupo grupoEstudiante = null;

                    foreach (var gradoPorNivel in gradosPorNivel)
                    {
                        Dictionary<int, int> listEstudiantesMatriculados = this.CantidadEstudiatesMatriculados((int)gradoPorNivel.Nivel.Consecutivo, gradoPorNivel.IdGrado, (int)idAnioLectivo);
                        int estudiantesMatriculados = listEstudiantesMatriculados.Sum(x => x.Value);

                        foreach (var cantidadEstudiantesMatriculado in listEstudiantesMatriculados)
                        {
                            int cantidadGruposPorGrado = CalcularCantidadGruposPorGrado(cantidadEstudiantesMatriculado.Value, cantidadEstudiantesPorGrupo);

                            if (cantidadGruposPorGrado == 0)
                            {
                                estudiantesGrupo.DistribucionEstudiantesGrupo.Add(new DistribucionEstudianteGrupoViewModel
                                {
                                    Id = 0,
                                    IdNivel = (int)idNivel,
                                    Nivel = gradoPorNivel.Nivel.Descripcion,
                                    EstudiantesPorGrupo = cantidadEstudiantesPorGrupo,
                                    EstudiantesMatriculados = estudiantesMatriculados,
                                    IdGrado = gradoPorNivel.IdGrado,
                                    Grado = gradoPorNivel.Grado.Descripcion,
                                    Grupos = this.NegocioGruposPorGrado.ConsultarGruposPorGrado(gradoPorNivel.IdGrado).Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Descripcion }).ToList(),
                                    Horarios = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Horario, ContextoLibellus.ObtenerSedeActual).Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Descripcion }).ToList(),
                                    CantidadGruposPorGrado = cantidadGruposPorGrado,
                                    IdActividadComplementaria = cantidadEstudiantesMatriculado.Key
                                });
                            }
                            else
                            {
                                int idGrupo = 0;
                                string grupo = string.Empty;
                                int idHorario = 0;
                                string horario = string.Empty;

                                for (int i = 0; i < cantidadGruposPorGrado; i++)
                                {
                                    if (i < gruposAsignados.Where(x => x.GruposPorGrado.IdGrado == gradoPorNivel.IdGrado).Count())
                                    {
                                        idGrupo = gruposAsignados.Where(x => x.GruposPorGrado.IdGrado == gradoPorNivel.IdGrado).ToArray()[i].GruposPorGrado.IdGrupo;
                                        grupo = gruposAsignados.Where(x => x.GruposPorGrado.IdGrado == gradoPorNivel.IdGrado).ToArray()[i].GruposPorGrado.Grupo.Descripcion;
                                        idHorario = gruposAsignados.Where(x => x.GruposPorGrado.IdGrado == gradoPorNivel.IdGrado).ToArray()[i].IdHorario;
                                        horario = gruposAsignados.Where(x => x.GruposPorGrado.IdGrado == gradoPorNivel.IdGrado).ToArray()[i].Horario.Descripcion;
                                    }

                                    grupoEstudiante = gruposAsignados.Where(g => g.GruposPorGrado.Grado.Id == gradoPorNivel.Grado.Id && g.GruposPorGrado.Grupo.Id == idGrupo).FirstOrDefault();

                                    estudiantesGrupo.DistribucionEstudiantesGrupo.Add(new DistribucionEstudianteGrupoViewModel
                                    {
                                        Id = grupoEstudiante == null ? 0 : grupoEstudiante.Id,
                                        IdNivel = (int)idNivel,
                                        Nivel = gradoPorNivel.Nivel.Descripcion,
                                        EstudiantesPorGrupo = cantidadEstudiantesPorGrupo,
                                        EstudiantesMatriculados = estudiantesMatriculados,
                                        IdGrado = gradoPorNivel.IdGrado,
                                        Grado = gradoPorNivel.Grado.Descripcion,
                                        IdGrupo = idGrupo,
                                        Grupo = grupo,
                                        Grupos = this.NegocioGruposPorGrado.ConsultarGruposPorGrado(gradoPorNivel.IdGrado).Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Descripcion, Selected = n.Id.Equals(idGrupo) }).ToList(),
                                        IdHorario = idHorario,
                                        Horario = horario,
                                        Horarios = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Horario, ContextoLibellus.ObtenerSedeActual).Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Descripcion, Selected = h.Id.Equals(idHorario) }).ToList(),
                                        CantidadGruposPorGrado = cantidadGruposPorGrado,
                                        IdActividadComplementaria = cantidadEstudiantesMatriculado.Key
                                    });

                                    idGrupo = 0;
                                    grupo = string.Empty;
                                    idHorario = 0;
                                    horario = string.Empty;
                                }
                            }
                        }
                    }

                    ViewBag.Consultar = consultar;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(estudiantesGrupo);
        }

        /// <summary>
        /// Lista los estudiantes de un grupo.
        /// </summary>
        /// <param name="informacionGrupo">Información del grupo.</param>
        /// <returns>la vista con los estudiantes que pertenecen a un grupo.</returns>
        public ActionResult ListarEstudiantesPorGrupo(int id, int idAnioLectivo, int idNivel, string nivel, string grado, string grupo, string horario, int? pagina)
        {
            DistribucionEstudianteGrupoViewModel distribucionEstudianteGrupo = new DistribucionEstudianteGrupoViewModel
            {
                Id = id,
                IdNivel = idNivel,
                Nivel = nivel,
                Grado = grado,
                Grupo = grupo,
                Horario = horario
            };

            try
            {
                distribucionEstudianteGrupo.Estudiantes = this.NegocioEstudiantes.ConsultarEstudiantesPorGrupo(id).Select(e =>
                    new EstudianteViewModel
                    {
                        Id = e.Id,
                        Nombre = e.Nombre,
                        DocumentoIdentidad = e.Usuario.Identificacion
                    }).OrderBy(x => x.Nombre).ToPagedList(pagina ?? 1, 10);

                ViewBag.IdAnioLectivo = idAnioLectivo;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(distribucionEstudianteGrupo);
        }

        /// <summary>
        /// Asocia estudiantes a los grupos.
        /// </summary>
        /// <param name="informacionGrupos">Información de los grupos a los que serán asociados los estudiantes.</param>
        /// <returns>Un Json con el estado de la transacción.</returns>
        [HttpPost]
        public JsonResult AsociarEstudiantesAGrupos(IList<DistribucionEstudianteGrupoViewModel> informacionGrupos, int anio)
        {
            Mensaje mensaje = null;
            List<Grupo> grupos = new List<Grupo>();
            Grupo grupo = null;

            try
            {
                foreach (var informacionGrupo in informacionGrupos)
                {
                    grupo = this.NegocioGrupos.Consultar(informacionGrupo.Id);

                    if (grupo == null)
                    {
                        grupo = new Grupo()
                        {
                            Id = informacionGrupo.Id,
                            IdAnioLectivo = anio,
                            IdGrupoPorGrado = this.NegocioGrupos.ConsultarGrupoPorGrado(informacionGrupo.IdGrupo, informacionGrupo.IdGrado),
                            IdHorario = informacionGrupo.IdHorario,
                            EstudiantesPorGrupo = new List<EstudiantePorGrupo>()
                        };
                    }

                    grupos.Add(grupo);
                }

                mensaje = this.NegocioGrupos.AsociarEstudiantesAGrupos(grupos, informacionGrupos.FirstOrDefault().IdGrado, informacionGrupos.FirstOrDefault().EstudiantesPorGrupo);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { estado = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { estado = true, mensaje = mensaje, idsGrupo = grupos.Select(g => g.Id) }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Guarda un grupo.
        /// </summary>
        /// <param name="informacionGrupo">Información del grupo.</param>
        /// <returns>Un Json con el estado de la transacción.</returns>
        [HttpPost]
        public JsonResult Guardar(DistribucionEstudianteGrupoViewModel informacionGrupo, int anio)
        {
            Mensaje mensaje = null;
            Grupo grupo = null;

            try
            {
                grupo = new Grupo()
                {
                    Id = informacionGrupo.Id,
                    IdAnioLectivo = anio,
                    IdGrupoPorGrado = this.NegocioGrupos.ConsultarGrupoPorGrado(informacionGrupo.IdGrupo, informacionGrupo.IdGrado),
                    IdHorario = informacionGrupo.IdHorario
                };

                mensaje = this.NegocioGrupos.GuardarGrupos(grupo);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { estado = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { estado = true, mensaje = mensaje, idGrupo = grupo.Id }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cantidad de estudiantes  matriculados por nivel y grado.
        /// </summary>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <returns>Retorna el resultado de la lista.</returns>
        private Dictionary<int, int> CantidadEstudiatesMatriculados(int idNivel, int idGrado, int idAnioLectivo)
        {
            Dictionary<int, int> estudiantesMatriculados = new Dictionary<int, int>();

            if (idNivel == (int)ConsecutivoMaestros.NivelMediaTecnica)
            {
                estudiantesMatriculados = this.NegocioMatriculas.CantidadEstudiantesMatriculadosGradoSalidaOcupacional(idGrado, idAnioLectivo);
            }

            if (idNivel == (int)ConsecutivoMaestros.NivelMedia)
            {
                estudiantesMatriculados = this.NegocioMatriculas.CantidadEstudiantesMatriculadosGradoProfundizacion(idGrado, (int)idAnioLectivo);
            }

            int estudiantes = this.NegocioMatriculas.CantidadEstudiantesMatriculadosGrado(idGrado, (int)idAnioLectivo);

            estudiantesMatriculados.Add(0, estudiantes);

            return estudiantesMatriculados;
        }

        /// <summary>
        /// Calcula la cantidad de estudiantes por grupo y grado. 
        /// </summary>
        /// <param name="estudiantesMatriculados">Estudiantes matriculados.</param>
        /// <param name="cantidadEstudiantesPorGrupo">Cantidad de estudiantes por grupo.</param>
        /// <returns>Retorna la cantidad.</returns>
        private int CalcularCantidadGruposPorGrado(int estudiantesMatriculados, int cantidadEstudiantesPorGrupo)
        {
            int cantidadGrupos = estudiantesMatriculados % cantidadEstudiantesPorGrupo == 0 ? estudiantesMatriculados / cantidadEstudiantesPorGrupo : (estudiantesMatriculados / cantidadEstudiantesPorGrupo) + 1;
            return cantidadGrupos;
        }
    }
}