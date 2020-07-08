using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class WeekDayManager
    {
        WeekDayGateway aWeekDayGateway = new WeekDayGateway();
        public List<WeekDays> GetAllDay()
        {
            return aWeekDayGateway.GetAllDay();
        }
    }
}