using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20201018_MVC5_CLASS_01.Models;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var data = new List<Person>
            {
                new Person{Id=1, Name="Dell", Age=20 },
                new Person{Id=2, Name="Aiyu", Age=21 },
                new Person{Id=3, Name="Bunch", Age=22 },
                new Person{Id=4, Name="Egenda", Age=23 },
                new Person{Id=5, Name="Test", Age=24 }
            };

            return View(data);
        }
    }
}