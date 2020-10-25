using _20201018_MVC5_CLASS_01.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace _20201018_MVC5_CLASS_01.Controllers
{
    public class CourseReportController : BaseController
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        StringBuilder sb = new StringBuilder();

        public CourseReportController()
        {
            db.Database.Log = (msg) =>
            {
                sb.AppendLine(msg);
                sb.AppendLine("-----------------------------------------");
            };
        }

        // GET: CourseReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseReportMethod1()
        {
            var data = (from d in db.Course
                       select new CourseReport()
                       {
                           CourseID = d.CourseID,
                           CourseName = d.Title,
                           StudentCount = d.Enrollment.Count(),
                           TeacherCount = d.Person.Count(),
                           AvgGrade = d.Enrollment.Where(c => c.Grade.HasValue).Average(c => c.Grade.Value)
                       }).ToList();
            ViewBag.SQL = sb.ToString();
            return View(data);
        }

        public ActionResult CourseReportMethod2()
        {
            var data = db.Database.SqlQuery<CourseReport>(@"
SELECT
    Course.CourseID, 
    Course.Title AS CourseName,
	(SELECT COUNT(CourseID) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	(SELECT COUNT(CourseID) FROM CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	(SELECT AVG(Cast(Grade as Float)) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
FROM   Course").ToList();

            ViewBag.SQL = sb.ToString();

            return View("CourseReportMethod1", data);
        }

        public ActionResult CourseReportMethod3(int id)
        {
            var data = db.Database.SqlQuery<CourseReport>(@"
SELECT
    Course.CourseID, 
    Course.Title AS CourseName,
	(SELECT COUNT(CourseID) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	(SELECT COUNT(CourseID) FROM CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	(SELECT AVG(Cast(Grade as Float)) FROM Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
FROM   Course
WHERE  Course.CourseID = @p0", id).ToList();

            ViewBag.SQL = sb.ToString();

            return View("CourseReportMethod1", data);
        }

        public ActionResult CourseReportMethod4(int id)
        {
            var data = db.GetCourseReport(id).First();

            ViewBag.SQL = sb.ToString();

            return View(data);
        }

        public ActionResult CourseReportMethod5(int id)
        {
            var data = db.Database.SqlQuery<CourseReport>("EXEC GetCourseReport @p0", id).ToList();

            ViewBag.SQL = sb.ToString();

            return View("CourseReportMethod1", data);
        }
    }
}