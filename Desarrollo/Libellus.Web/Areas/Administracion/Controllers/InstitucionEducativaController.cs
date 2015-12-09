namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.InstitucionEducativa;
    using Libellus.Web.Helpers;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de la institucion educativa.
    /// </summary>
    public class InstitucionEducativaController : AdministracionBaseController
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public InstitucionEducativaController()
        {
            this.NegocioInstitucionEducativa = new NegocioInstitucionEducativa(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Almacena los datos de la institucion educativa.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los datos diligenciados.</param>
        /// <returns>Retorna a la vista inicial.</returns>
        [HttpPost]
        public ActionResult Administrar(InstitucionEducativa institucionEducativa, HttpPostedFileBase postedLogo)
        {
            try
            {
                if (postedLogo != null)
                {
                    institucionEducativa.Logo = UtilidadesApp.ObtenerBytesArchivo(postedLogo.InputStream, postedLogo.ContentLength);
                }

                Mensaje mensaje = this.NegocioInstitucionEducativa.AdministrarInstitucionEducativa(institucionEducativa);
                this.MostrarMensaje(mensaje);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Presenta los datos de la institucion educativa.
        /// </summary>
        /// <returns>Retorna a la vista con los datos encontrados.</returns>
        public ActionResult Index()
        {
            InstitucionEducativaViewModel institucionEducativa = new InstitucionEducativaViewModel();

            try
            {
                var datos = this.NegocioInstitucionEducativa.ConsultarDatosInstitucionEducativa();

                var paises = this.NegocioMaestros.ConsultarPaises()
                    .OrderBy(o => o.Nombre)
                    .ToSelectListItem(o => o.Nombre, o => o.Id);

                if (datos != null)
                {
                    ViewBag.TituloBoton = "Editar institución educativa";

                    institucionEducativa = new InstitucionEducativaViewModel()
                    {
                        Id = datos.Id,
                        CodigoDane = datos.CodigoDane,
                        Direccion = datos.Direccion,
                        Fax = datos.Fax,
                        Nit = datos.Nit,
                        Nombre = datos.Nombre,
                        PaginaWeb = datos.PaginaWeb,
                        ResolucionAprobacion = datos.ResolucionAprobacion,
                        Rut = datos.Rut,
                        Telefono = datos.Telefono,
                        IdPais = datos.IdPais,
                        IdDepartamento = datos.IdDepartamento,
                        IdMunicipio = datos.IdMunicipio,
                        UrlLogo = UtilidadesApp.ObtenerUrlBase64(datos.Logo),
                        Paises = paises,
                        Sedes = from s in datos.Sedes
                                select new SedeViewModel()
                                {
                                    Id = s.Id,
                                    IdInstitucionEducativa = s.IdInstitucionEducativa,
                                    Nombre = s.Nombre,
                                    Seccion = s.Seccion
                                },
                        RegistrosLegalizacion = from r in datos.RegistrosLegalizacion
                                                select new RegistroLegalizacionViewModel()
                                                {
                                                    Id = r.Id,
                                                    FechaExpedicion = r.FechaExpedicion,
                                                    IdInstitucionEducativa = r.IdInstitucionEducativa,
                                                    TextoLegalizacion = r.TextoLegalizacion,
                                                    TipoRegistro = r.TipoRegistro,
                                                    VigenciaDesde = r.VigenciaDesde,
                                                    VigenciaHasta = r.VigenciaHasta
                                                }
                    };
                }
                else
                {
                    ViewBag.TituloBoton = "Crear institución educativa";
                    institucionEducativa.Paises = paises;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(institucionEducativa);
        }
    }
}