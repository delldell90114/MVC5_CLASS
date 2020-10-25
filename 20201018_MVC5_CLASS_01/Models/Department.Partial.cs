namespace _20201018_MVC5_CLASS_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }

    public partial class Department : IValidatableObject 
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Bunch" && this.Budget > 100)
            {
                yield return new ValidationResult("您的預算不足", new string[] { "Budget" });
            }
        }
    }

    public partial class DepartmentMetaData
    {
        public int DepartmentID { get; set; }
        [Required]
        [DisplayName("姓名")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [MustEven]
        [DisplayName("預算")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal Budget { get; set; }
        [Required]
        [DisplayName("開始日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required]
        [DisplayName("講師名字")]
        public Nullable<int> InstructorID { get; set; }
    }
}
