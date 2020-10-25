using _20201018_MVC5_CLASS_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _20201018_MVC5_CLASS_01.ViewModel
{
    public class DepartmentEditVewModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Bunch" && this.Budget > 100)
            {
                yield return new ValidationResult("您的預算不足", new string[] { "Budget" });
            }
        }

        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MustEven]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required]
        public Nullable<int> InstructorID { get; set; }
    }
}