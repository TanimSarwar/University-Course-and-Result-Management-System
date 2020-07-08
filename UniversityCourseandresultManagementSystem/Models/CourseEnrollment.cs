using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class CourseEnrollment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Student's Reg. No")]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Select a Course")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public int GradeId { get; set; }
    }
}