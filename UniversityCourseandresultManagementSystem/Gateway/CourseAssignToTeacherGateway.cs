using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class CourseAssignToTeacherGateway:CommonGateway
    {
        public int AssignCoursetoTeacher(CourseAssign aCourseAssign)
        {
            Query = "INSERT INTO AssignTeacherTable Values('Assigned',@teacherId, @courseId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("teacherId", aCourseAssign.TeacherId);
            Command.Parameters.AddWithValue("courseId", aCourseAssign.CourseId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int UnAssignCourses()
        {
            Query = "UPDATE AssignTeacherTable SET Status = 'UnAssigned' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}