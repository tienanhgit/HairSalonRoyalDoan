using System.Web;
using System.Web.Mvc;

namespace HairSalonRoyalDoan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
