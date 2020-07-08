using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class CourseAssignToTeacherManager
    {
        CourseAssignToTeacherGateway aAssignToTeacherGateway = new CourseAssignToTeacherGateway();
        public string AssignCourseToTeacher(CourseAssign aCourseAssign)
        {
            int rowAffected = aAssignToTeacherGateway.AssignCoursetoTeacher(aCourseAssign);
            if (rowAffected>0)
            {
                return "Course Assigned to Teacher Successfully";
            }
            return "Course Wasn't Assigned Successfulyl";
        }

        public string UnAssignAllCourses()
        {
            int rowAffected = aAssignToTeacherGateway.UnAssignCourses();
            if (rowAffected > 0)
            {
                return "Courses are Unassigned Successfully";
            }
            else
            {
                return "Courses Wasn't Unassigned";
            }
        }
    }
}