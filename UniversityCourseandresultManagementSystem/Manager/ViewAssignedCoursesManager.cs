using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class ViewAssignedCoursesManager
    {
        ViewAssignedCoursesGateway aViewAssignedCoursesGateway = new ViewAssignedCoursesGateway();
        public List<ViewAssignedCourse> GetAllAssignedCourses(int deptId)
        {
            return aViewAssignedCoursesGateway.GetAllAssignedCourses(deptId);
        }
    }
}