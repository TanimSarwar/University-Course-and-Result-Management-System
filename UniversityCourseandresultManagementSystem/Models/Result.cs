using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Student's Reg. No")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Select a Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select a Grade")]
        public int GradeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Grade { get; set; }
    }
}