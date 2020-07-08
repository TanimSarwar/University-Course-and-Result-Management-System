using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class ViewAssignedCoursesGateway : CommonGateway
    {
        public List<ViewAssignedCourse> GetAllAssignedCourses(int deptId)
        {
            Query = "SELECT CourseTable.CourseCode, CourseTable.CourseName,SemesterTable.SemesterName,TeacherTable.TeacherName"
                            + " FROM AssignTeacherTable"
                            + " INNER JOIN CourseTable ON CourseTable.id=AssignTeacherTable.CourseID"
                            + " INNER JOIN TeacherTable ON TeacherTable.Id=AssignTeacherTable.TeacherID"
                            + " INNER JOIN SemesterTable ON CourseTable.SemesterID=SemesterTable.Id"
                            + " WHERE CourseTable.DepartmentID=@deptId and AssignTeacherTable.Status='Assigned' ORDER BY CourseCode";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptId", deptId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewAssignedCourse> listOfAssignedCourse = new List<ViewAssignedCourse>();
            while (Reader.Read())
            {
                ViewAssignedCourse aViewAssignedCourse = new ViewAssignedCourse
                {
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseSemester = Reader["SemesterName"].ToString(),
                    AssignTeacherName = Reader["TeacherName"].ToString()
                };

                if (aViewAssignedCourse.AssignTeacherName == "")
                {
                    aViewAssignedCourse.AssignTeacherName = "Not Assigned Yet";
                }
                listOfAssignedCourse.Add(aViewAssignedCourse);

            }
            Reader.Close();
            Connection.Close();
            return listOfAssignedCourse;
        }
    }
}