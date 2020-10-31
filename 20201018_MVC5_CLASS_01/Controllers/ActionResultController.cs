using _20201018_MVC5_CLASS_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class ActionResultController : Controller
    {
        private DepartmentRepository repo;
        public ActionResultController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
        }

        // GET: ActionResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest2()
        {
            return View("index");
        }

        public ActionResult ViewTest3()
        {
            return View("TEMP");
        }

        public ActionResult ViewTest4()
        {
            return PartialView("index");
        }

        public ActionResult ContentTest()
        {
            return Content("<root>123</root>", "text/xml", System.Text.Encoding.GetEncoding("big5"));
        }

        public ActionResult FileTest(bool dl = false)
        {
            if(dl)
            {
                return File(Server.MapPath("~/Content/IMG_0151.jpg"), "image/jpeg", "Song.jpg");
            }
            else
            {
                return File(Server.MapPath("~/Content/IMG_0151.jpg"), "image/jpeg");
            }    
        }

        public ActionResult JsonTest()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;

            var data = repo.All();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JsonTest2()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;

            var data = repo.All();
            return Json(data);
        }
    }
}