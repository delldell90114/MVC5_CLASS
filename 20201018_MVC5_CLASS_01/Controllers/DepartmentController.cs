using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGrease;
using Omu.ValueInjecter;
using _20201018_MVC5_CLASS_01.Models;
using _20201018_MVC5_CLASS_01.ViewModel;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class DepartmentController : BaseController
    {
        //private ContosoUniversityEntities db = new ContosoUniversityEntities();

        private DepartmentRepository repo;
        private PersonRepository repoPerson;

        public DepartmentController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
            repoPerson = RepositoryHelper.GetPersonRepository(repo.UnitOfWork);
        }

        // GET: Department
        public ActionResult Index()
        {
            return View(repo.All());
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department data)
        {
            if(ModelState.IsValid)
            {
                //var item = db.Department.Create();
                //item.InjectFrom(data);

                repo.Add(data);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName");
            return View(data);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = repo.GetDepartment(id.Value);
            if(dept == null)
            {
                return this.HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName", dept.InstructorID);
            return View(repo.GetDepartment(id.Value));
        }

        // ** Use ViewModel can prevent the <Over post> attack **
        [HttpPost]
        //public ActionResult Edit(int id, Department data)
        public ActionResult Edit(int id, DepartmentEditVewModel data)
        {
            if (ModelState.IsValid)
            {
                var item = repo.GetDepartment(id);
                // -> ** Use <ValueInjecter> for binding each field, the name of property must be same will be binded **
                item.InjectFrom(data);

                // -> ** Following binded can be marked after usiung <ValueInjecter>
                //item.Name = data.Name;
                //item.Budget = data.Budget;
                //item.StartDate = data.StartDate;
                //item.InstructorID = data.InstructorID;

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var dept = repo.GetDepartment(id);
            if (dept == null)
            {
                return this.HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName", dept.InstructorID);
            return View(repo.GetDepartment(id));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(repo.GetDepartment(id.Value));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName");
            return View(repo.GetDepartment(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var item = repo.GetDepartment(id);

                repo.Delete(item);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.ID), "ID", "FirstName");
            return View();
        }
    }
}