using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _20201018_MVC5_CLASS_01.ViewModel
{
    public class DepartmentEditVewModel
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:0000}")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}