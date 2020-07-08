﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandresultManagementSystem.Models
{
    public class ClassSchedule
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string DayShortName { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string RoomName { get; set; }
        public string ScheduleInfo { get; set; }
    }
}