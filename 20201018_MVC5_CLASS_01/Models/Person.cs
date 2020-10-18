using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _20201018_MVC5_CLASS_01.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "請輸入姓名:")]
        public String Name { get; set; }
        [Required(ErrorMessage ="請輸入年紀:")]
        [Range(5,99, ErrorMessage = "請輸入範圍:5~99")]
        public int Age { get; set; }
    }
}