namespace Libellus.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using Libellus.Negocio.Administracion;

    /// <summary>
    /// Define la información del control geográfico que permite seleccionar los países, departamento y municipios.
    /// </summary>
    public class GeografiaController : BaseController
    {
        #region Atributos

        /// Define la interfáz de las reglas de negocio para los maestros administrables.
        /// </summary>
        private INegocioMaestros NegocioMaestros { get; set; }

        #endregion

        #region Acciones asíncronas

        /// <summary>
        /// Inicializa una nueva instancia de tipo GeografiaController.
        /// </summary>
        public GeografiaController()
        {
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        /// <summary>
        /// Consulta los países existentes.
        /// </summary>
        /// <returns>Colección de países.</returns>
        public JsonResult ConsultarPaises()
        {
            var coleccionPaises = from p in this.NegocioMaestros.ConsultarPaises()
                                  select new
                                  {
                                      Text = p.Nombre,
                                      Value = p.Id
                                  };

            return Json(coleccionPaises, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentos(short idPais)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(idPais)
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipios(short idDepartamento)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(idDepartamento)
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentosNacimiento(short IdPaisNacimiento)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(IdPaisNacimiento)
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipiosNacimiento(short IdDepartamentoNacimiento)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(IdDepartamentoNacimiento)
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentosMadre(short DatosFamiliaresMadreIdPais)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(DatosFamiliaresMadreIdPais)
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipiosMadre(short DatosFamiliaresMadreIdDepartamento)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(DatosFamiliaresMadreIdDepartamento)
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentosPadre(short DatosFamiliaresPadreIdPais)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(DatosFamiliaresPadreIdPais)
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipiosPadre(short DatosFamiliaresPadreIdDepartamento)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(DatosFamiliaresPadreIdDepartamento)
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno de un país.</param>
        /// <returns>Colección de departamentos.</returns>
        public JsonResult ConsultarDepartamentosResidenciales(short DatosResidencialesIdPais)
        {
            var coleccionDepartamentos = from p in this.NegocioMaestros.ConsultarDepartamentos(DatosResidencialesIdPais)
                                         select new
                                         {
                                             Text = p.Nombre,
                                             Value = p.Id
                                         };

            return Json(coleccionDepartamentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno de un departamento.</param>
        /// <returns>Colección de municipios.</returns>
        public JsonResult ConsultarMunicipiosResidenciales(short DatosResidencialesIdDepartamento)
        {
            var coleccionMunicipios = from p in this.NegocioMaestros.ConsultarMunicipios(DatosResidencialesIdDepartamento)
                                      select new
                                      {
                                          Text = p.Nombre,
                                          Value = p.Id
                                      };

            return Json(coleccionMunicipios, JsonRequestBehavior.AllowGet);
        }

        #endregion Acciones asíncronas
    }
}
