using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20201018_MVC5_CLASS_01.ViewModel
{
    public class CourseEditViewModel
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string Memo { get; set; }
    }
}