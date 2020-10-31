using _20201018_MVC5_CLASS_01.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class PrepareDepartmentListForDropDownListAttribute : ActionFilterAttribute
    {
        DepartmentRepository repo = new DepartmentRepository();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.DepartmentList = repo.All().Select(p => new { p.DepartmentID, p.Name }).ToList();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }

    internal class selectlist
    {
        private IQueryable<Department> queryables;
        private string v1;
        private string v2;

        public selectlist(IQueryable<Department> queryables, string v1, string v2)
        {
            this.queryables = queryables;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}