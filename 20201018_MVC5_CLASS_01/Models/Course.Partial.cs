namespace _20201018_MVC5_CLASS_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
    }
    
    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        [Required]
        [Range(1, 20)]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Memo { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }

    public class CourseViewModel
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        [Required]
        [Range(1,20)]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}
