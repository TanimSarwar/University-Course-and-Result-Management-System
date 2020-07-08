using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class ClassRoomAllocation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Selet the Class Starting Time")]
        [Display(Name = "Time From")]
        public string TimeFrom { get; set; }
        [Required(ErrorMessage = "Please Select the Class Ending Time")]
        [Display(Name = "Time To")]
        public string TimeTo { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Please Select the Deaprtment")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select a Course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select a Room")]
        [Display(Name = "Room No.")]
        public int RoomNoId { get; set; }
        [Required(ErrorMessage = "Please Select the WeekDay")]
        [Display(Name = "Day")]
        public int SevenDayWeekId { get; set; }
    }
}