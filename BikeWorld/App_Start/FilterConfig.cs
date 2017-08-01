using System.Web;
using System.Web.Mvc;

namespace BikeWorld
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //for handling authorization based on users
            filters.Add(new AuthorizeAttribute());
            //for allowing on https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
