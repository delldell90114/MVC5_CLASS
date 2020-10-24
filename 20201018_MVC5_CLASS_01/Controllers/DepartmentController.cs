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
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department data)
        {
            if(ModelState.IsValid)
            {
                //var item = db.Department.Create();
                //item.InjectFrom(data);

                db.Department.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName");
            return View(data);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = db.Department.Find(id);
            if(dept == null)
            {
                return this.HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName", dept.InstructorID);
            return View(db.Department.Find(id));
        }

        // ** Use ViewModel can prevent the <Over post> attack **
        [HttpPost]
        //public ActionResult Edit(int id, Department data)
        public ActionResult Edit(int id, DepartmentEditVewModel data)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);
                // -> ** Use <ValueInjecter> for binding each field, the name of property must be same will be binded **
                item.InjectFrom(data);
                
                // -> ** Following binded can be marked after usiung <ValueInjecter>
                //item.Name = data.Name;
                //item.Budget = data.Budget;
                //item.StartDate = data.StartDate;
                //item.InstructorID = data.InstructorID;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var dept = db.Department.Find(id);
            if (dept == null)
            {
                return this.HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName", dept.InstructorID);
            return View(db.Department.Find(id));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Department.Find(id));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName");
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

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.ID), "ID", "FirstName");
            return View();
        }
    }
}