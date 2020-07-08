using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide the Course's Code Name")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Course Code Must be 5 to 15 Characters Long.")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Please Provide the Course's Name")]
        [Display(Name = "Course Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Course Name Must Be a String Without Any Special Character and Number")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Provide the Credit of the Course")]
        [Range(0.5, 5, ErrorMessage = "Course Credit Must Lie Between 0.5 to 5.0")]
        [Display(Name = "Course Credit")]
        public decimal CourseCredit { get; set; }
        [Display(Name = "Course Description")]
        [Required(ErrorMessage = "Please Provide the Course's Description")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "Please Select the Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select the Semester")]
        [Display(Name="Semester")]
        public int SemesterId { get; set; }

    }
}