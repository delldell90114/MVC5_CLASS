using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20201018_MVC5_CLASS_01.Models
{
    public class CourseReport
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int StudentCount { get; set; }
        public int TeacherCount { get; set; }
        public double? AvgGrade { get; set; }
    }
}