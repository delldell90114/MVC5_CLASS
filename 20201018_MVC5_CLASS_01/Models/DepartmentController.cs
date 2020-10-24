using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace _20201018_MVC5_CLASS_01.Models
{
    public class DepartmentController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department);
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department data)
        {
            if(ModelState.IsValid)
            {
                db.Department.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View(data);
        }
        public ActionResult Edit(int? id)
        {
            if(!id.HasValue)
            {
                return this.HttpNotFound();
            }

            var dept = db.Department.Find(id);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            return View(db.Department.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Department data)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);
                item.Name = data.Name;
                item.Budget = data.Budget;
                item.StartDate = data.StartDate;
                item.InstructorID = data.InstructorID;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View(db.Department.Find(id));
        }

        public ActionResult Details(int? id)
        {
            if(!id.HasValue)
            {
                return this.HttpNotFound();
            }

            return View(db.Department.Find(id));
        }

        public ActionResult Delete(int? id)
        {
            if(!id.HasValue)
            {
                return this.HttpNotFound();
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View(db.Department.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);
                db.Department.Remove(item);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View();
        }
    }
}