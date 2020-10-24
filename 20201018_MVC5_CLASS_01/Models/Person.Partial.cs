namespace _20201018_MVC5_CLASS_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
    }
    
    public partial class PersonMetaData
    {
        [Required]
        public int ID { get; set; }

        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [DisplayName("講師姓名")]
        public string LastName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [DisplayName("講師名字")]
        public string FirstName { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        [Required]
        public string Discriminator { get; set; }
    
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
