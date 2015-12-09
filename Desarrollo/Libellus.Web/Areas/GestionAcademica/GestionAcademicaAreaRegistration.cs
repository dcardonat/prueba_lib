namespace Libellus.Web.Areas.GestionAcademica
{
    using System.Web.Mvc;

    public class GestionAcademicaAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GestionAcademica";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GestionAcademica_default",
                "GestionAcademica/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}