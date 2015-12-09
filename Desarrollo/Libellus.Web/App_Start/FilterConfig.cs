namespace Libellus.Web.App_Start
{
    using System.Web.Mvc;
    using Libellus.Web.Atributos;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
