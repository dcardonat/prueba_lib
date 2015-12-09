namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.ParametrizacionEscolar;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la parametrizacion anual y semestral.
    /// </summary>
    public class ParametrizacionEscolarController : AdministracionBaseController
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public ParametrizacionEscolarController()
        {
            this.NegocioParametrizacionEscolar = new NegocioParametrizacionEscolar(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Consulta la informacion para presentarla a la vista.
        /// </summary>
        /// <param name="pagina">Consecutivo del paginador para la consulta.</param>
        /// <returns>Retorna a la vista del metodo.</returns>
        [HttpGet]
        public ActionResult Consultar(int? IdAnioLectivo, int? Jornada, int pagina = 1)
        {
            IEnumerable<ParametrizacionEscolarViewModel> parametrizacionEscolarViewModel = null;

            try
            {
                parametrizacionEscolarViewModel = (from c in this.NegocioParametrizacionEscolar.ConsultarParametrizacionesEscolaresPorSede()
                                                   where (IdAnioLectivo == null || c.IdAnioLectivo == IdAnioLectivo) &&
                                                   (Jornada == null || c.IdJornadaAcademica == Jornada)
                                                   select new ParametrizacionEscolarViewModel()
                                                   {
                                                       Id = c.Id,
                                                       TipoParametrizacion = new Maestro(c.TipoParametrizacion.Descripcion),
                                                       AnioLectivo = c.AnioLectivo,
                                                       Semestre = c.Semestre == null ? new Maestro() : new Maestro(c.Semestre.Descripcion),
                                                       JornadaAcademica = new Maestro(c.JornadaAcademica.Descripcion),
                                                       SemanasLectivas = c.SemanasLectivas,
                                                       PorcentajeInasistencia = c.PorcentajeInasistencia,
                                                       PeriodosParametrizacion = c.PeriodosParametrizacion.Select(d => new PeriodoViewModel { Id = d.Id })
                                                   }).OrderByDescending(e => e.AnioLectivo.Anio).ToPagedList(pagina, 10);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ResultadoConsulta", parametrizacionEscolarViewModel);
                }
                else
                {
                    var jornadas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.JornadaAcademica, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

                    ViewBag.Jornadas = jornadas;
                    ViewBag.AnioLectivo = IdAnioLectivo;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(parametrizacionEscolarViewModel);
        }

        /// <summary>
        /// Consulta las areas disponibles en el negocio.
        /// </summary>
        /// <returns>Coleccion serializada en formato Json de tipo SelectListItem.</returns>
        public JsonResult ConsultarAreas()
        {
            var areas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Areas, ContextoLibellus.ObtenerSedeActual, true);
            var resultado = (from c in areas
                             select new SelectListItem
                             {
                                 Text = c.Descripcion,
                                 Value = c.Id.ToString()
                             }).OrderBy(e => e.Text);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Presenta la vista para crear un nuevo registro.
        /// </summary>
        /// <returns>Retorna a la vista del metodo.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            ParametrizacionEscolarViewModel parametrizacionEscolarViewModel = null;
            try
            {
                parametrizacionEscolarViewModel = this.EstablecerValoresModelo();
                ViewBag.Crear = true;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(parametrizacionEscolarViewModel);
        }

        /// <summary>
        /// Redirecciona al negocio para crear una instancia de la parametrizacion anual y semestral.
        /// </summary>
        /// <param name="parametrizacionEscolar"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Crear(ParametrizacionEscolar parametrizacionEscolar, ParametrizacionEscolarViewModel viewModel)
        {
            try
            {
                // Se asignan las areas por nivel pasadas en el viewModel.
                foreach (var item in viewModel.AreasNivel.OrderBy(e => e.IdNivelParametrizacion))
                {
                    if (!parametrizacionEscolar.NivelesParametrizacion.ToList().Exists(e => e.IdNivel.Equals(item.IdNivelParametrizacion)))
                    {
                        parametrizacionEscolar.NivelesParametrizacion.Add(new NivelParametrizacion { IdNivel = item.IdNivelParametrizacion });
                    }

                    parametrizacionEscolar.NivelesParametrizacion.Last().AreasNivel.Add(new AreaNivel { IdArea = item.IdArea });
                }

                Mensaje mensajeRespuesta = this.NegocioParametrizacionEscolar.CrearParametrizacionEscolar(parametrizacionEscolar);

                if (mensajeRespuesta == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    this.MostrarMensaje(mensajeRespuesta);
                    ParametrizacionEscolarViewModel parametrizacionEscolarViewModel = this.EstablecerValoresModelo(parametrizacionEscolar);
                    return View(parametrizacionEscolarViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Redirecciona a la vista para editar un registro.
        /// </summary>
        /// <param name="id">Identificador de la parametrizacion.</param>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ParametrizacionEscolarViewModel viewModel = null;

            try
            {
                ParametrizacionEscolar parametrizacion = this.NegocioParametrizacionEscolar.ConsultarParametrizacionEscolar(id);
                if (parametrizacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    viewModel = this.EstablecerValoresModelo(parametrizacion);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Edita un registro de parametrizacion anual y semestral.
        /// </summary>
        /// <param name="parametrizacion">Entidad con los datos a actualizar.</param>
        /// <returns>Retorna a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Editar(ParametrizacionEscolar parametrizacion, ParametrizacionEscolarViewModel viewModel)
        {
            try
            {
                foreach (var item in viewModel.AreasNivel.OrderBy(e => e.IdNivelParametrizacion))
                {
                    if (!parametrizacion.NivelesParametrizacion.Any(e => e.IdNivel == item.IdNivelParametrizacion))
                    {
                        parametrizacion.NivelesParametrizacion.Add(new NivelParametrizacion()
                        {
                            Id = item.Id,
                            IdNivel = item.IdNivelParametrizacion,
                            IdParametrizacionEscolar = parametrizacion.Id
                        });
                    }

                    parametrizacion.NivelesParametrizacion.Last().AreasNivel.Add(new AreaNivel()
                    {
                        Id = item.IdAreaNivel,
                        IdArea = item.IdArea,
                        IdNivelParametrizacion = item.Id,
                        Area = new Maestro(item.Area)
                    });
                }

                foreach (var periodo in parametrizacion.PeriodosParametrizacion)
                {
                    periodo.IdParametrizacionEscolar = parametrizacion.Id;
                }

                Mensaje mensaje = this.NegocioParametrizacionEscolar.ActualizarParametrizacionEscolar(parametrizacion);
                if (mensaje == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                }
                else
                {
                    this.MostrarMensaje(mensaje);
                    ParametrizacionEscolarViewModel datosViewModel = this.EstablecerValoresModelo(parametrizacion);
                    return View(datosViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Elimina un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="id">Identificador de la parametrizacion.</param>
        /// <returns>Retorna a la vista consultar.</returns>
        public ActionResult Eliminar(int id)
        {
            try
            {
                this.NegocioParametrizacionEscolar.Eliminar(id);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje004));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
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
            string nombreArchivo = "Libellus_parametrizacion_escolar.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> parametrizacion = (from c in this.NegocioParametrizacionEscolar.ConsultarParametrizacionesEscolaresPorSede()
                                                       select new
                                                       {
                                                           Tipo_Parametrización = c.TipoParametrizacion.Descripcion,
                                                           Año = c.AnioLectivo.Anio,
                                                           Semestre = c.Semestre == null ? string.Empty : c.Semestre.Descripcion,
                                                           Jornada_Académica = c.JornadaAcademica.Descripcion,
                                                           Semanas_Lectivas = c.SemanasLectivas,
                                                           Porcentaje_Inasistencia = c.PorcentajeInasistencia,
                                                           Periodos = c.PeriodosParametrizacion.Count
                                                       }).OrderByDescending(e => e.Año);

                byteArray = ExportarExcel.Exportar(parametrizacion.ToList(), "ParametrizacionEscolar");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Establece los valores para el modelo asociado a la vista.
        /// </summary>
        /// <param name="parametrizacionEscolar">Instancia con los valores.</param>
        /// <returns>ViewModel con los respectivos valores.</returns>
        private ParametrizacionEscolarViewModel EstablecerValoresModelo(ParametrizacionEscolar parametrizacionEscolar = null)
        {
            ParametrizacionEscolarViewModel parametrizacionEscolarViewModel = null;

            var jornadas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.JornadaAcademica, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var semestres = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Semestres, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var tiposParametrizacion = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TipoParametrizacion, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var momentosDocente = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.MomentosDocente, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var duracionMomentos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.DuracionMomentos, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(e => e.Descripcion)
                    .ToSelectListItem(e => e.Descripcion, e => e.Id);

            var grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, ContextoLibellus.ObtenerSedeActual, true);

            var anios = this.NegocioAnioLectivo.ConsultarAniosLectivosAbiertos()
                .OrderByDescending(e => e.Anio)
                .ToSelectListItem(e => e.Anio, e => e.Id);

            parametrizacionEscolarViewModel = new ParametrizacionEscolarViewModel()
            {
                ComboTiposParametrizacion = tiposParametrizacion,
                ComboSemestres = semestres,
                ComboJornadasAcademicas = jornadas,
                ComboAnios = anios,
                ComboGrados = (from c in grados
                               select new SelectListItem
                               {
                                   Text = c.Descripcion,
                                   Value = c.Id.ToString()
                               }).OrderBy(e => e.Text).ToList(),
            };

            if (parametrizacionEscolar != null)
            {
                parametrizacionEscolarViewModel.Id = parametrizacionEscolar.Id;
                parametrizacionEscolarViewModel.IdAnioLectivo = parametrizacionEscolar.IdAnioLectivo;
                parametrizacionEscolarViewModel.IdJornadaAcademica = parametrizacionEscolar.IdJornadaAcademica;
                parametrizacionEscolarViewModel.SemanasLectivas = parametrizacionEscolar.SemanasLectivas;
                parametrizacionEscolarViewModel.IdSemestre = parametrizacionEscolar.IdSemestre;
                parametrizacionEscolarViewModel.IdTipoParametrizacion = parametrizacionEscolar.IdTipoParametrizacion;
                parametrizacionEscolarViewModel.PorcentajeInasistencia = parametrizacionEscolar.PorcentajeInasistencia;
                parametrizacionEscolarViewModel.GradosParametrizacionSeleccionados = from g in parametrizacionEscolar.GradosParametrizacion
                                                                                     select g.IdGrado;
                parametrizacionEscolarViewModel.PeriodosParametrizacion = from p in parametrizacionEscolar.PeriodosParametrizacion
                                                                          select new PeriodoViewModel
                                                                          {
                                                                              Id = p.Id,
                                                                              Periodo = p.Periodo,
                                                                              FechaInicial = p.FechaInicial,
                                                                              FechaFinal = p.FechaFinal,
                                                                              TieneApertura = p.AperturaExtemporaneaPeriodos.Any() ? true : false,
                                                                              FechaAperturaInicial = p.AperturaExtemporaneaPeriodos.Any() ? p.AperturaExtemporaneaPeriodos.Last().FechaInicial.ToShortDateString() : string.Empty,
                                                                              FechaAperturaFinal = p.AperturaExtemporaneaPeriodos.Any() ? p.AperturaExtemporaneaPeriodos.Last().FechaFinal.ToShortDateString() : string.Empty,
                                                                              MotivoApertura = p.AperturaExtemporaneaPeriodos.Any() ? p.AperturaExtemporaneaPeriodos.Last().MotivoApertura : string.Empty
                                                                          };
                parametrizacionEscolarViewModel.AreasNivel = from n in parametrizacionEscolar.NivelesParametrizacion
                                                             from a in n.AreasNivel
                                                             select new AreasNivelViewModel
                                                             {
                                                                 IdArea = a.IdArea,
                                                                 Area = a.Area.Descripcion,
                                                                 IdNivelParametrizacion = n.IdNivel,
                                                                 Id = n.Id,
                                                                 IdAreaNivel = a.Id
                                                             };
            }

            return parametrizacionEscolarViewModel;
        }

        /// <summary>
        /// Obtiene el numero de semanas de un año, o de un semestre.
        /// </summary>
        /// <param name="IdTipoParametrizacion">Identificador del maestro TipoParametrización.</param>
        /// <returns>Colección de enteros.</returns>
        public JsonResult ObtenerSemanasLectivas(string IdTipoParametrizacion)
        {
            int idTipoParametrizacion = int.Parse(IdTipoParametrizacion);
            Maestro maestro = this.NegocioMaestros.ConsultarMaestroPorId(idTipoParametrizacion);

            var numeroSemanas = new List<int>();

            if (maestro.Consecutivo == ConsecutivoMaestros.Anual.GetHashCode())
            {
                for (int i = 1; i <= 52; i++)
                {
                    numeroSemanas.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= 26; i++)
                {
                    numeroSemanas.Add(i);
                }
            }

            var semanas = (from c in numeroSemanas
                           select new
                           {
                               Text = c,
                               Value = c
                           });

            return Json(semanas);
        }

        /// <summary>
        /// Obtiene los niveles dependiendo del tipo de parametrización.
        /// </summary>
        /// <param name="IdTipoParametrizacion">Identificador de la parametrizacion.</param>
        /// <returns>Niveles correspondientes a la parametrización.</returns>
        public JsonResult ObtenerNiveles(string IdTipoParametrizacion)
        {
            int idTipoParametrizacion = int.Parse(IdTipoParametrizacion);
            Maestro maestro = this.NegocioMaestros.ConsultarMaestroPorId(idTipoParametrizacion);

            IEnumerable<Maestro> niveles = null;

            if (maestro.Consecutivo == ConsecutivoMaestros.Anual.GetHashCode())
            {
                niveles = from n in this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, ContextoLibellus.ObtenerSedeActual, true)
                          where !n.Descripcion.Contains("CLEI")
                          select n;
            }
            else
            {
                niveles = from n in this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, ContextoLibellus.ObtenerSedeActual, true)
                          where n.Descripcion.Contains("CLEI")
                          select n;
            }

            var json = (from n in niveles
                        select new
                        {
                            Text = n.Descripcion,
                            Value = n.Id
                        }).OrderBy(e => e.Text);

            return Json(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdAnioLectivo"></param>
        /// <returns></returns>
        public JsonResult ConsultarParametrizacionesAnualesAnteriores(string IdAnioLectivo)
        {
            int idAnioParametrizar = Convert.ToInt32(IdAnioLectivo);
            AnioLectivo anioParametrizar = this.NegocioAnioLectivo.ConsultarAnioLectivo(idAnioParametrizar);
            if (anioParametrizar != null)
            {
                int ap = anioParametrizar.Anio - 1;
                AnioLectivo anioAnterior = this.NegocioAnioLectivo.ConsultarAniosLectivos().Where(e => e.Anio == ap).FirstOrDefault();
                if (anioAnterior != null)
                {
                    ParametrizacionEscolar parametrizacionAnterior = this.NegocioParametrizacionEscolar.ConsultarParametrizacionesEscolaresPorSede()
                        .Where(e => e.IdAnioLectivo == anioAnterior.Id).FirstOrDefault();

                    if (parametrizacionAnterior != null)
                    {
                        var query = from n in parametrizacionAnterior.NivelesParametrizacion
                                    from a in n.AreasNivel
                                    select new AreasNivelViewModel
                                    {
                                        IdArea = a.IdArea,
                                        Area = a.Area.Descripcion,
                                        IdNivelParametrizacion = n.IdNivel,
                                        Id = n.Id,
                                        IdAreaNivel = a.Id
                                    };

                        return Json(query);
                    }
                }
            }

            return new JsonResult();
        }

        public JsonResult ConsultarParametrizacionesSemestralesAnteriores(string IdAnioLectivo, string IdSemestre)
        {
            return new JsonResult();
        }
    }
}