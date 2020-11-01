using _20201018_MVC5_CLASS_01.Models;
using Omu.ValueInjecter;
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
        CourseRepository repoCourse;

        public ModelBindingController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
            repoCourse = RepositoryHelper.GetCourseRepository(repo.UnitOfWork);
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

        [PrepareDepartmentListForDropDownList]
        public ActionResult BatchUpdate(bool IsEditMode = false)
        {
            ViewData.Model = repoCourse.All();
            ViewBag.IsEditMode = IsEditMode;
            //ViewBag.DepartmentList = repo.All().Select(p => new { p.DepartmentID, p.Name }).ToList();
            return View();
        }

        [PrepareDepartmentListForDropDownList]
        [HttpPost]
        public ActionResult BatchUpdate(List<CourseViewModel> data, bool IsEditMode = false)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var rec = repoCourse.All().FirstOrDefault(p => p.CourseID == item.CourseID);
                    rec.InjectFrom(item);
                }
                repoCourse.UnitOfWork.Commit();
                TempData["EditResult"] = "批次更新成功";

                return RedirectToAction("BatchUpdate");
            }
            TempData["EditResult"] = "ModelState State 驗證失敗!";
            //ViewBag.DepartmentList = repo.All().Select(p => new { p.DepartmentID, p.Name }).ToList();
            return View(repoCourse.All());
        }

        public ActionResult ModelBindingTest1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModelBindingTest1(ModelBinding modelBinding)
        {
            ViewBag.Name = modelBinding.Name;
            ViewBag.Age = modelBinding.Age;
            return View();
        }

#if !DEBUG
        [NonAction]
#endif
        public ActionResult Debug()
        {
            return Content("DEBUG");
        }
    }
}