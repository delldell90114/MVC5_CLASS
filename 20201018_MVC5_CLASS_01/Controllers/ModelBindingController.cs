using _20201018_MVC5_CLASS_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class ModelBindingController : Controller
    {
        DepartmentRepository repo;

        public ModelBindingController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
        }

        // GET: ModelBinding
        public ActionResult Index()
        {
            var data = repo.GetDepartment(1);
            ViewData["Key1"] = "This is Key1";
            ViewBag.Key2 = "This is Key2";
            TempData["tempdata"] = "Temporary Data transfer";
            return View(data);
        }

        public ActionResult ReadTempData()
        {
            return View();
        }
    }
}