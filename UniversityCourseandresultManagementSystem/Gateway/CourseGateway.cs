using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class CourseGateway:CommonGateway
    {
        public int InsertNewCourse(Course aCourse)
        {
            Query = "INSERT INTO CourseTable VALUES(@courseCode, @coursename, @courseCredit, @courseDescription, @departmentId, @semesterId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("courseCode", aCourse.CourseCode);
            Command.Parameters.AddWithValue("coursename", aCourse.CourseName);
            Command.Parameters.AddWithValue("courseCredit", aCourse.CourseCredit);
            Command.Parameters.AddWithValue("courseDescription", aCourse.CourseDescription);
            Command.Parameters.AddWithValue("departmentId", aCourse.DepartmentId);
            Command.Parameters.AddWithValue("semesterId", aCourse.SemesterId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public bool IsCourseCodeExist(Course aCourse)
        {
            Query = "SELECT * FROM CourseTable WHERE CourseCode =@courseCode";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("courseCode", aCourse.CourseCode);
            Command.Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public bool IsCourseNameExist(Course aCourse)
        {
            Query = "SELECT * FROM CourseTable WHERE CourseName =@courseName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("courseName", aCourse.CourseName);
            Command.Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM CourseTable ORDER BY CourseCode";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> listOfCourses = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    Id = (int) Reader["id"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCredit = (decimal) Reader["CourseCredit"],
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    DepartmentId = (int) Reader["DepartmentID"],
                    SemesterId = (int) Reader["SemesterID"]
                };
                listOfCourses.Add(aCourse);
            }
            Connection.Close();
            Reader.Close();
            return listOfCourses;
        }

        public List<Course> GetAllUnAssignCoursesByDeptId(int departmentId)
        {
            Query = "SELECT * FROM CourseTable WHERE Id NOT IN(SELECT CourseId FROM AssignTeacherTable WHERE Status='Assigned') AND DepartmentID=@deptId ORDER BY CourseCode";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> listOfUnassignedCoursesByDepartmetnId = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    Id = (int) Reader["id"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCredit = (decimal) Reader["CourseCredit"],
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    DepartmentId = (int) Reader["DepartmentID"],
                    SemesterId = (int) Reader["SemesterID"]
                };
                listOfUnassignedCoursesByDepartmetnId.Add(aCourse);

            }
            Connection.Close();
            Reader.Close();
            return listOfUnassignedCoursesByDepartmetnId;
        }

        public List<Course> GetAllCoursesByDeptId(int departmentId)
        {
            Query = "SELECT * FROM CourseTable WHERE DepartmentID= @deptId ORDER BY CourseCode";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> listOfCoursesByDepartmetnId = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    Id = (int) Reader["id"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCredit = (decimal) Reader["CourseCredit"],
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    DepartmentId = (int) Reader["DepartmentID"],
                    SemesterId = (int) Reader["SemesterID"]
                };
                listOfCoursesByDepartmetnId.Add(aCourse);

            }
            Connection.Close();
            Reader.Close();
            return listOfCoursesByDepartmetnId;
        }

        public Course GetCourseInformationByCourseId(int courseId)
        {
            string query = "SELECT * FROM CourseTable WHERE id=@courseId";
            Command = new SqlCommand(query, Connection); Command.Parameters.Clear();
            Command.Parameters.AddWithValue("courseId", courseId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = new Course();
            while (Reader.Read())
            {

                aCourse.Id = (int)Reader["id"];
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCredit = (decimal)Reader["CourseCredit"];
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.DepartmentId = (int)Reader["DepartmentID"];
                aCourse.SemesterId = (int)Reader["SemesterID"];
                break;

            }
            Connection.Close();
            Reader.Close();
            return aCourse;
        }

        public List<Course> GetCoursesByStudentId(string studentId)
        {
            Query = "SELECT CourseTable.id,CourseTable.CourseCode from CourseTable " +
                            "Inner JOIN DepartmentTable ON CourseTable.DepartmentID=DepartmentTable.Id " +
                            "Right JOIN StudentTable ON CourseTable.DepartmentID=StudentTable.DepartmentID where StudentTable.id='" + studentId + "' and CourseTable.id is not null";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> listOfCourses = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(Reader["id"]);
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                listOfCourses.Add(aCourse);
            }
            Connection.Close();
            return listOfCourses;
        }
    }
}