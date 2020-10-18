using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using _20201018_MVC5_CLASS_01.Models;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class TestController : Controller
    {
        static List<Person>data = new List<Person>
        {
            new Person(){Id=1, Name="Dell", Age=20 },
            new Person(){Id=2, Name="Aiyu", Age=21 },
            new Person(){Id=3, Name="Bunch", Age=22 },
            new Person(){Id=4, Name="Egenda", Age=23 },
            new Person(){Id=5, Name="Test", Age=24 }
        };

        // GET: Test
        public ActionResult Index()
        {   
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                data.Add(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                /*
                data.FirstOrDefault(p => p.Id == id).Name = person.Name;
                data.FirstOrDefault(p => p.Id == id).Age = person.Age;
                */

                var newData = data.FirstOrDefault(p => p.Id == id);
                newData.Name= person.Name;
                newData.Age = person.Age;

                return RedirectToAction("Index");
            }

            return View(id);
        }

        public ActionResult Details(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            data.Remove(data.First(p => p.Id == id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, int a)
        {
            data.Remove(data.First(p => p.Id == id));
            return RedirectToAction("Index");
        }
    }
}