namespace Libellus.Web.Areas.GestionAcademica.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.GestionAcademica;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.GestionAcademica.Models.AspectoEvaluativo;
    using Libellus.Web.Helpers;
    using PagedList;
    using System;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los aspectos evaluativos.
    /// </summary>
    public class AspectoEvaluativoController : GestionAcademicaBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo MaestrosController.
        /// </summary>
        public AspectoEvaluativoController()
        {
            this.NegocioAspectosEvaluativos = new NegocioAspectosEvaluativos(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioAnioLectivo = new NegocioAnioLectivo(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Consulta la informacion existente para el maestro Aulas.
        /// </summary>
        /// <returns>Redirecciona a la vista para listar los registros.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<AspectoEvaluativoViewModel> aspectoEvaluativoViewModel = null;

            try
            {
                aspectoEvaluativoViewModel = (from c in this.NegocioAspectosEvaluativos.ConsultarPorSede()
                                              select new AspectoEvaluativoViewModel()
                                              {
                                                  Id = c.Id,
                                                  IdAnioLectivo = c.IdAnioLectivo,
                                                  Evaluativo = new Maestro()
                                                  {
                                                      Descripcion = c.Evaluativo.Descripcion
                                                  },
                                                  AnioLectivo = new AnioLectivo()
                                                  {
                                                      Id = c.AnioLectivo.Id,
                                                      Anio = c.AnioLectivo.Anio,
                                                      Cerrado = c.AnioLectivo.Cerrado
                                                  },
                                                  IdIntensidadHoraria = c.IdIntensidadHoraria,
                                                  Porcentaje = Convert.ToString(c.Porcentaje),
                                                  IntensidadHoraria = new Maestro()
                                                  {
                                                      Id = c.IntensidadHoraria.Id,
                                                      Descripcion = c.IntensidadHoraria.Descripcion
                                                  },
                                                  PruebasMinimas = c.PruebasMinimas
                                              }).OrderByDescending(e => e.AnioLectivo.Anio).ThenByDescending(p => p.Porcentaje).ThenByDescending(i => i.IntensidadHoraria).ToPagedList(pagina ?? 1, 10);

                if (aspectoEvaluativoViewModel.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(aspectoEvaluativoViewModel);
        }

        /// <summary>
        /// Muestra el formulario de creacion de aspecto Evaluativo.
        /// </summary>
        /// <returns>Redirecciona a la vista.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            AspectoEvaluativoViewModel aspectoEvaluativoViewModel = null;

            try
            {
                var aspectoEvaluativo = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.AspectosEvaluativos, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(c => c.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

                Maestro pruebasMinimas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.PruebasMinimas, Utilidades.ContextoLibellus.ObtenerSedeActual, true).FirstOrDefault();

                aspectoEvaluativoViewModel = new AspectoEvaluativoViewModel()
                {
                    AspectosEvaluativos = aspectoEvaluativo,
                    IntensidadHorariaList = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.IntensidaadHoraria, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToSelectListItem(o => o.Descripcion, o => o.Id),
                    PruebasMinimasList = UtilidadesApp.ObtenerListaMaestro(pruebasMinimas.Descripcion)
                };
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(aspectoEvaluativoViewModel);
        }

        /// <summary>
        /// Recibe el aula ingresada en el formulario para llevarla a la base de datos.
        /// </summary>
        /// <param name="aspectoEvaluativo">Objeto con la informacion del aspecto Evaluativo diligeniada.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Crear(AspectoEvaluativoViewModel aspectoEvaluativoViewModel)
        {
            AspectoEvaluativo aspectoEvaluativo = new AspectoEvaluativo();
            bool error = false;

            try
            {
                aspectoEvaluativo = new AspectoEvaluativo()
                {
                    IdAnioLectivo = aspectoEvaluativoViewModel.IdAnioLectivo,
                    IdAspectoEvaluativo = aspectoEvaluativoViewModel.IdAspectoEvaluativo,
                    IdIntensidadHoraria = aspectoEvaluativoViewModel.IdIntensidadHoraria,
                    Porcentaje = Convert.ToDecimal(aspectoEvaluativoViewModel.Porcentaje),
                    PruebasMinimas = aspectoEvaluativoViewModel.PruebasMinimas
                };

                Mensaje mensajeCreacion = this.NegocioAspectosEvaluativos.Crear(aspectoEvaluativo);

                if (mensajeCreacion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                else
                {
                    aspectoEvaluativoViewModel = RetornarModelo(aspectoEvaluativo);
                    ViewBag.NuevoRegistro = true;
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje011));
                    return View(aspectoEvaluativoViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                aspectoEvaluativoViewModel = RetornarModelo(aspectoEvaluativo);
                return View(aspectoEvaluativoViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Carga el formulario para la edicion del aspecto Evaluativo.
        /// </summary>
        /// <param name="id">Identificador del aula.</param>
        /// <returns>Redirecciona a la vista Editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AspectoEvaluativoViewModel aspectoEvaluativoViewModel = null;
            try
            {
                var aspectoEvaluativo = this.NegocioAspectosEvaluativos.Consultar(id);
                if (aspectoEvaluativo == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    var aspectosEvaluativo = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.AspectosEvaluativos, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                        .OrderBy(c => c.Descripcion)
                        .ToSelectListItem(o => o.Descripcion, o => o.Id);

                    Maestro pruebasMinimas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.PruebasMinimas, Utilidades.ContextoLibellus.ObtenerSedeActual, true).FirstOrDefault();

                    aspectoEvaluativoViewModel = new AspectoEvaluativoViewModel()
                    {
                        Id = aspectoEvaluativo.Id,
                        IdAnioLectivo = aspectoEvaluativo.IdAnioLectivo,
                        IdAspectoEvaluativo = aspectoEvaluativo.IdAspectoEvaluativo,
                        IdIntensidadHoraria = aspectoEvaluativo.IdIntensidadHoraria,
                        Porcentaje = Convert.ToString(aspectoEvaluativo.Porcentaje),
                        PruebasMinimas = aspectoEvaluativo.PruebasMinimas,
                        AspectosEvaluativos = aspectosEvaluativo,
                        IntensidadHorariaList = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.IntensidaadHoraria, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToSelectListItem(o => o.Descripcion, o => o.Id),
                        PruebasMinimasList = UtilidadesApp.ObtenerListaMaestro(pruebasMinimas.Descripcion),
                    };
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(aspectoEvaluativoViewModel);
        }

        /// <summary>
        /// Recibe la informacion del aspecto Evaluativo para actualizarla en la BD.
        /// </summary>
        /// <param name="aspectoEvaluativo">Objeto con la informacion editada.</param>
        /// <returns>Redirecciona a la vista Consultar.</returns>
        [HttpPost]
        public ActionResult Editar(AspectoEvaluativoViewModel aspectoEvaluativoViewModel)
        {
            AspectoEvaluativo aspectoEvaluativo = new AspectoEvaluativo();
            bool error = false;

            try
            {
                aspectoEvaluativo = new AspectoEvaluativo()
                {
                    Id = aspectoEvaluativoViewModel.Id,
                    IdAnioLectivo = aspectoEvaluativoViewModel.IdAnioLectivo,
                    IdAspectoEvaluativo = aspectoEvaluativoViewModel.IdAspectoEvaluativo,
                    IdIntensidadHoraria = aspectoEvaluativoViewModel.IdIntensidadHoraria,
                    Porcentaje = Convert.ToDecimal(aspectoEvaluativoViewModel.Porcentaje),
                    PruebasMinimas = aspectoEvaluativoViewModel.PruebasMinimas
                };

                Mensaje mensajeEdicion = this.NegocioAspectosEvaluativos.Editar(aspectoEvaluativo);

                if (mensajeEdicion == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                }
                else
                {
                    aspectoEvaluativoViewModel = RetornarModelo(aspectoEvaluativo);
                    ViewBag.NuevoRegistro = false;
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje011));
                    return View(aspectoEvaluativoViewModel);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                aspectoEvaluativoViewModel = RetornarModelo(aspectoEvaluativo);
                ViewBag.NuevoRegistro = false;
                return View(aspectoEvaluativoViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Exportar la información de las salidas ocupacionales a Excel.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_AspectoEvaluativo.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> aspectosEvaluativos = (from aspectoEvaluativo in this.NegocioAspectosEvaluativos.ConsultarPorSede()
                                                           select new
                                                           {
                                                               Año = aspectoEvaluativo.AnioLectivo.Anio,
                                                               Aspecto_Evaluativo = aspectoEvaluativo.Evaluativo.Descripcion,
                                                               Porcentaje = aspectoEvaluativo.Porcentaje,
                                                               Intensidad_Horaria = aspectoEvaluativo.IntensidadHoraria.Descripcion,
                                                               Pruebas_Mínimas = aspectoEvaluativo.PruebasMinimas,
                                                           }).OrderByDescending(o => o.Año).ThenByDescending(p => p.Porcentaje).ThenByDescending(i => i.Intensidad_Horaria);

                byteArray = ExportarExcel.Exportar(aspectosEvaluativos.ToList(), "Aspecto evaluativo");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Retorna el AspectoEvaluativoViewModel de aspecto evaluativo..
        /// </summary>
        /// <param name="aspectoEvaluativo">Entidad principal.</param>
        /// <returns>Retorna el ViewModel mapeado.</returns>
        private AspectoEvaluativoViewModel RetornarModelo(AspectoEvaluativo aspectoEvaluativo)
        {
            AspectoEvaluativoViewModel aspectoEvaluativoViewModel = null;
            var aspectosEvaluativo = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.AspectosEvaluativos, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(c => c.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);

            Maestro pruebasMinimas = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.PruebasMinimas, Utilidades.ContextoLibellus.ObtenerSedeActual, true).FirstOrDefault();

            aspectoEvaluativoViewModel = new AspectoEvaluativoViewModel()
            {
                Id = aspectoEvaluativo.Id,
                IdAnioLectivo = aspectoEvaluativo.IdAnioLectivo,
                AnioLectivo = new AnioLectivo { Id = aspectoEvaluativo.Id, Anio = aspectoEvaluativo.AnioLectivo.Anio, Cerrado = aspectoEvaluativo.AnioLectivo.Cerrado },
                IdAspectoEvaluativo = aspectoEvaluativo.IdAspectoEvaluativo,
                IntensidadHoraria = new Maestro { Id = aspectoEvaluativo.IntensidadHoraria.Id, Descripcion = aspectoEvaluativo.IntensidadHoraria.Descripcion},
                IdIntensidadHoraria = aspectoEvaluativo.IdIntensidadHoraria,
                Porcentaje = Convert.ToString(aspectoEvaluativo.Porcentaje),
                PruebasMinimas = aspectoEvaluativo.PruebasMinimas,
                AspectosEvaluativos = aspectosEvaluativo,
               // IntensidadHorariaList = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.IntensidaadHoraria, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToSelectListItem(o => o.Descripcion, o => o.Id),
                PruebasMinimasList = UtilidadesApp.ObtenerListaMaestro(pruebasMinimas.Descripcion),
            };

            return aspectoEvaluativoViewModel;
        }

        /// <summary>
        /// Elimina un registro de intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                this.NegocioAspectosEvaluativos.Eliminar(id);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje004));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        #endregion
    }
}