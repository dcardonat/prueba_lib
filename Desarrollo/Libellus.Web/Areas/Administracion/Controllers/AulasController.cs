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
    using Libellus.Web.Areas.Administracion.Models.Aulas;
    using Libellus.Web.Controllers;
    using Libellus.Web.Helpers;
    using PagedList;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración del maestro Aulas.
    /// </summary>
    public class AulasController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public AulasController()
        {
            this.NegocioAulas = new NegocioAulas(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Consulta la informacion existente para el maestro Aulas.
        /// </summary>
        /// <returns>Redirecciona a la vista para listar los registros.</returns>
        [HttpGet]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<AulaViewModel> aulasViewModel = null;

            try
            {
                aulasViewModel = (from c in this.NegocioAulas.ConsultarAulasPorSede()
                                  select new AulaViewModel()
                                  {
                                      Id = c.Id,
                                      Descripcion = c.Descripcion,
                                      Estado = c.Estado,
                                      Maestro = new Maestro()
                                      {
                                          Descripcion = c.Maestro.Descripcion
                                      }
                                  }).OrderByDescending(e => e.Estado).ThenBy(e => e.Descripcion).ToPagedList(pagina ?? 1, 10);

                if (aulasViewModel.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(aulasViewModel);
        }

        /// <summary>
        /// Muestra el formulario de creacion de aulas.
        /// </summary>
        /// <returns>Redirecciona a la vista.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            AulaViewModel aulaViewModel = null;
            try
            {
                var tiposAula = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposAula, Utilidades.ContextoLibellus.ObtenerSedeActual, true)
                .OrderBy(c => c.Descripcion)
                .ToSelectListItem(o => o.Descripcion, o => o.Id);
                aulaViewModel = new AulaViewModel()
                {
                    TiposAula = tiposAula
                };
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(aulaViewModel);
        }

        /// <summary>
        /// Recibe el aula ingresada en el formulario para llevarla a la base de datos.
        /// </summary>
        /// <param name="aula">Objeto con la informacion del aula diligeniada.</param>
        /// <returns>Redirecciona a la vista consultar.</returns>
        [HttpPost]
        public ActionResult Crear(Aula aula)
        {
            bool error = false;
            try
            {
                this.NegocioAulas.AlmacenarAula(aula);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                AulaViewModel aulaViewModel = RetornarModelo(aula);
                return View(aulaViewModel);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Carga el formulario para la edicion del aula.
        /// </summary>
        /// <param name="id">Identificador del aula.</param>
        /// <returns>Redirecciona a la vista Editar.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AulaViewModel aulaViewModel = null;
            try
            {
                var aula = this.NegocioAulas.ConsultarAula(id);
                if (aula == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    var tiposAula = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposAula, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(c => c.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);
                    aulaViewModel = new AulaViewModel()
                    {
                        Descripcion = aula.Descripcion,
                        Estado = aula.Estado,
                        Id = aula.Id,
                        IdMaestro = aula.IdMaestro,
                        TiposAula = tiposAula
                    };
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(aulaViewModel);
        }

        /// <summary>
        /// Recibe la informacion del aula para actualizarla en la BD.
        /// </summary>
        /// <param name="aula">Objeto con la informacion editada.</param>
        /// <returns>Redirecciona a la vista Consultar.</returns>
        [HttpPost]
        public ActionResult Editar(Aula aula)
        {
            bool error = false;
            try
            {
                this.NegocioAulas.ActualizarAula(aula);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                error = true;
            }

            if (error)
            {
                AulaViewModel aulaViewModel = RetornarModelo(aula);
                return View(aulaViewModel);
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
            string nombreArchivo = "Libellus_Aulas.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> aulas = (from p in this.NegocioAulas.ConsultarAulasPorSede()
                                             select new
                                             {
                                                 Aula = p.Descripcion,
                                                 TipoAula = p.Maestro.Descripcion,
                                                 Estado = p.Estado ? "Activo" : "Inactivo",
                                             }).OrderByDescending(o => o.Estado).ThenBy(o => o.Aula);

                byteArray = ExportarExcel.Exportar(aulas.ToList(), "Aulas");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        /// <summary>
        /// Retorna el viewModel de aulas.
        /// </summary>
        /// <param name="aula">Entidad principal.</param>
        /// <returns>Retorna el ViewModel mapeado.</returns>
        private AulaViewModel RetornarModelo(Aula aula)
        {
            AulaViewModel aulaViewModel = null;
            var tiposAula = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposAula, ContextoLibellus.ObtenerSedeActual, true)
                    .OrderBy(c => c.Descripcion)
                    .ToSelectListItem(o => o.Descripcion, o => o.Id);
            aulaViewModel = new AulaViewModel()
            {
                Descripcion = aula.Descripcion,
                Estado = aula.Estado,
                Id = aula.Id,
                IdMaestro = aula.IdMaestro,
                TiposAula = tiposAula
            };

            return aulaViewModel;
        }

        #endregion Acciones
    }
}