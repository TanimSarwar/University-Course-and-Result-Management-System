using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Provide the Department's Codename")]
        [Display(Name = "Code")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Length must be between 2 to 7")]
        public string DeptCode { get; set; }



        [Required(ErrorMessage = "Please Provide the Department's Fullname")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Department Name Must Be a String Without Any Special Character and Number")]
        [Display(Name = "Name")]
        public string DeptName { get; set; }
    }
}