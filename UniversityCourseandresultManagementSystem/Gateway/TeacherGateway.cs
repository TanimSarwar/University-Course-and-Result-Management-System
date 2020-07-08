using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class TeacherGateway:CommonGateway
    {
        public int InsertNewTeacher(Teacher aTeacher)
        {
            Query = "INSERT INTO TeacherTable Values(@teacherName, @teacherAddress, @teacherEmail, @techerContactNo, @teacherCredit, @teacherDesignation, @teacherDepartment)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("teacherName", aTeacher.TeacherName);
            Command.Parameters.AddWithValue("teacherAddress", aTeacher.TeacherAddress);
            Command.Parameters.AddWithValue("teacherEmail", aTeacher.TeacherEmail);
            Command.Parameters.AddWithValue("techerContactNo", aTeacher.TeacherContactNo);
            Command.Parameters.AddWithValue("teacherCredit", aTeacher.TeacherCredit);
            Command.Parameters.AddWithValue("teacherDesignation", aTeacher.TeacherDesignationId);
            Command.Parameters.AddWithValue("teacherDepartment", aTeacher.TeacherDepartmentId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsEmailExist(Teacher aTeacher)
        {
            Query = "SELECT * FROM TeacherTable WHERE TeacherEmail = @teacherEmail";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("teacherEmail", aTeacher.TeacherEmail);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            Query = "SELECT *from TeacherTable where TeacherDepartmentID=@deptId order by TeacherName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> listOfTeachersbyDepartmentId = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher
                {
                    Id = Convert.ToInt32(Reader["id"]),
                    TeacherName = Reader["TeacherName"].ToString(),
                    TeacherCredit = Convert.ToDouble(Reader["TeacherCredit"])
                };
                listOfTeachersbyDepartmentId.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return listOfTeachersbyDepartmentId;
        }

        public Teacher GetTeacherInformationById(int teacherId)
        {
            Query = "SELECT * FROM TeacherTable WHERE id=@teacherId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("teacherId", teacherId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher aTeacher = new Teacher();
            while (Reader.Read())
            {
                aTeacher.Id = Convert.ToInt32(Reader["id"]);
                aTeacher.TeacherName = Reader["TeacherName"].ToString();
                aTeacher.TeacherCredit = Convert.ToDouble(Reader["TeacherCredit"]);
                break;
            }
            Reader.Read();
            Connection.Close();
            return aTeacher;
        }

        public double GetTotalTakenCourses(int teacherId)
        {
            Query = "SELECT CourseCredit FROM AssignTeacherTable INNER JOIN CourseTable ON AssignTeacherTable.CourseID=CourseTable.id WHERE TeacherID=@teacherId and Status='Assigned'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("teacherId", teacherId);
            double totalCredit = 0.0;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                totalCredit += Convert.ToDouble(Reader["CourseCredit"]);
            }
            Reader.Read();
            Connection.Close();
            return totalCredit;
        }
    }
}