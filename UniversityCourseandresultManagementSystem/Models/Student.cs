using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Students's Name")]
        [RegularExpression(@"^[a-zA-Z\s]+[.]*[a-zA-Z\s]*$", ErrorMessage = "Student's Name Must Be a String Without Any Special Character and Number")]
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please Provide Student's Mail")]
        [EmailAddress(ErrorMessage = "Enter a Valid Mail")]
        [Display(Name = "Email")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Please Provide Student's Contact No")]
        [RegularExpression(@"^\(?[+. ]?([0-9]{2})\)?[-. ]?([0-9]{11})$", ErrorMessage = "Invalid Phone number(e.+8801XXXXXXXXX)")]
        [Display(Name = "Contact No")]
        public string StudentContactNo { get; set; }
        [Required(ErrorMessage = "Select a Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy}")]
        public string StudentAddDate { get; set; }
        [Required(ErrorMessage = "Please Provide Student's Address")]
        [Display(Name = "Address")]
        public string StudentAddress { get; set; }

        public string StudentRegNo { get; set; }
        [Required(ErrorMessage = "Please Select the Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public String DepartmentName { get; set; }
    }
}