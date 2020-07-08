using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        public string InsertNewCourse(Course aCourse)
        {
            if (aCourseGateway.IsCourseCodeExist(aCourse))
            {
                return "Course Code Already Exists";
            }
            if (aCourseGateway.IsCourseNameExist(aCourse))
            {
                return "Course Name Already Exists";
            }
            int rowAffected = aCourseGateway.InsertNewCourse(aCourse);
            if (rowAffected > 0)
            {
                return "Course Information Saved Successfully";
            }
            return "Course Information Not Saved";

        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        public List<Course> GetAllUnAssignCoursesByDeptId(int departmentId)
        {
            return aCourseGateway.GetAllUnAssignCoursesByDeptId(departmentId);
        }

        public List<Course> GetAllCoursesByDeptId(int departmentId)
        {
            return aCourseGateway.GetAllCoursesByDeptId(departmentId);
            
        }

        public Course GetCourseInformationByCourseId(int courseId)
        {
            return aCourseGateway.GetCourseInformationByCourseId(courseId);

        }

        public List<Course> GetCoursesByStudentId(string studentId)
        {
            return aCourseGateway.GetCoursesByStudentId(studentId);
        }
    }
}