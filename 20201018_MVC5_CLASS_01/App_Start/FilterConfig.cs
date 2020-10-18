using System.Web;
using System.Web.Mvc;

namespace _20201018_MVC5_CLASS_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
