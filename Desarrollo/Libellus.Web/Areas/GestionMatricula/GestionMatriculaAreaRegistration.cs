using System.Web.Mvc;

namespace Libellus.Web.Areas.GestionMatricula
{
    public class GestionMatriculaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GestionMatricula";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GestionMatricula_default",
                "GestionMatricula/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}