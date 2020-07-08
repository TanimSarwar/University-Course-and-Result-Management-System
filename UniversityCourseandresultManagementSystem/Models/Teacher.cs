using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Teacher's Name")]
        [RegularExpression(@"^[a-zA-Z\s]+[.]*[a-zA-Z\s]*$", ErrorMessage = "Teacher's Name Must Be a String Without Any Special Character and Number")]
        [Display(Name = "Name")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Please Provide Teacher's Address")]
        [Display(Name = "Address")]
        public string TeacherAddress { get; set; }
        [EmailAddress(ErrorMessage = "Enter a Valid Mail")]
        [Required(ErrorMessage = "Please Provide Teacher's Mail")]
        [Display(Name = "Email")]
        public string TeacherEmail { get; set; }
        [Required(ErrorMessage = "Please Provide Teacher's Contact No")]
        [RegularExpression(@"^\(?[+. ]?([0-9]{2})\)?[-. ]?([0-9]{11})$", ErrorMessage = "Invalid Phone number(e.+8801XXXXXXXXX)")]  
        [Display(Name = "Contact No")]
        public string TeacherContactNo { get; set; }
        [Required(ErrorMessage = "Please Provide Teacher's Credit")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Credit must be a Postive Number")]
        [Display(Name = "Credit to be taken")]
        public double TeacherCredit { get; set; }
        [Required(ErrorMessage = "Please Select the Designation")]
        [Display(Name = "Designation")]
        public int TeacherDesignationId { get; set; }
        [Required(ErrorMessage = "Please Select the Department")]
        [Display(Name = "Department")]
        public int TeacherDepartmentId { get; set; }

        public double CourseTaken { get; set; }

        //for courseassign story only
        //[Required (ErrorMessage = "Please Select the Teacher")]
        public string TeacherId { get; set; }

    }
}