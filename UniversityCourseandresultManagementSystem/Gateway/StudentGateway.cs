using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class StudentGateway:CommonGateway
    {
        public int GetRowCount(int departmentId, int year)
        {
            int rowCount = 0;
            Query = "SELECT COUNT(*) FROM StudentTable WHERE DepartmentID = @deptId AND YEAR(StudentAddDate) = @year";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@deptId", departmentId);
            Command.Parameters.AddWithValue("@year", year);
            Connection.Open();
            rowCount = (int)Command.ExecuteScalar();
            Connection.Close();
            return rowCount;
        }

        public bool IsExists(Student aStudent)
        {
            Query = "SELECT * FROM StudentTable WHERE StudentEmail = @email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@email", aStudent.StudentEmail);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int Save(Student aStudent)
        {
            Query = "INSERT INTO StudentTable VALUES(@name, @email, @contact, @date, @address, @regno, @deptid)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@name", aStudent.StudentName);
            Command.Parameters.AddWithValue("@email", aStudent.StudentEmail);
            Command.Parameters.AddWithValue("@contact", aStudent.StudentContactNo);
            Command.Parameters.AddWithValue("@date", DateTime.ParseExact(aStudent.StudentAddDate, "dd-MM-yyyy", null));
            Command.Parameters.AddWithValue("@address", aStudent.StudentAddress);
            Command.Parameters.AddWithValue("@regno", aStudent.StudentRegNo);
            Command.Parameters.AddWithValue("@deptid", aStudent.DepartmentId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public Student GetStudentInfoById(int studentId)
        {
            Query = "select StudentTable.id,StudentTable.StudentRegNo, StudentTable.StudentName , StudentTable.StudentEmail,DepartmentTable.DeptCode " +
                            "from StudentTable Join DepartmentTable on StudentTable.DepartmentID=DepartmentTable.id where StudentTable.id='" + studentId + "' order by StudentRegNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = new Student();
            while (Reader.Read())
            {

                aStudent.Id = Convert.ToInt32(Reader["id"]);
                aStudent.StudentRegNo = Reader["StudentRegno"].ToString();
                aStudent.StudentEmail = Reader["StudentEmail"].ToString();
                aStudent.DepartmentName = Reader["DeptCode"].ToString();
                aStudent.StudentName = Reader["StudentName"].ToString();
                break;
            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public List<Student> GetAllStudents()
        {
            Query = "select StudentTable.id,StudentTable.StudentRegNo, StudentTable.StudentName , StudentTable.StudentEmail,DepartmentTable.DeptCode " +
                            "from StudentTable Join DepartmentTable on StudentTable.DepartmentID=DepartmentTable.id  order by StudentRegNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> listOfAllStudents = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = Convert.ToInt32(Reader["id"]);
                aStudent.StudentRegNo = Reader["StudentRegno"].ToString();
                aStudent.StudentEmail = Reader["StudentEmail"].ToString();
                aStudent.DepartmentName = Reader["DeptCode"].ToString();
                aStudent.StudentName = Reader["StudentName"].ToString();
                listOfAllStudents.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return listOfAllStudents;
        }

        public bool IsCourseTakenAlready(CourseEnrollment aCourseEnrollment)
        {
            Query = "SELECT * FROM AssignStudentTable WHERE CourseID = '" + aCourseEnrollment.CourseId + "' And StudentID='" + aCourseEnrollment.StudentId + "' AND Status='0'";

            Command = new SqlCommand(Query, Connection);
            Command.Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            Connection.Close();
            return isExist;
        }

        public int EnrollNewCourseToStudent(CourseEnrollment aCourseEnrollment)
        {
            Query = "INSERT INTO AssignStudentTable Values('0','" + aCourseEnrollment.Date + "','" + aCourseEnrollment.StudentId + "','" + aCourseEnrollment.CourseId + "','14')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Grade> GetAllGrades()
        {
            Query = "SELECT * FROM GradeTable WHERE id!=10 ORDER BY id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> listOfGrades = new List<Grade>();
            while (Reader.Read())
            {
                Grade aGrade = new Grade();
                aGrade.Id = Convert.ToInt32(Reader["id"]);
                aGrade.GradeLetter = Reader["Grade"].ToString();
                listOfGrades.Add(aGrade);

            }
            Reader.Close();
            Connection.Close();
            return listOfGrades;
        }

        public int SaveResult(Result aResult)
        {
            Query = "UPDATE AssignStudentTable SET GradeId = '" + aResult.GradeId + "' WHERE StudentID ='" + aResult.StudentId + "' AND CourseID='" + aResult.CourseId + "' AND Status ='0'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Course> GetAllTakenCoursesByStudent(int studentId)
        {
            Query = "SELECT CourseTable.CourseCode,CourseTable.id from AssignStudentTable " +
                            "Inner JOIN CourseTable ON CourseTable.id=AssignStudentTable.CourseID " +
                            "where AssignStudentTable.StudentID='" + studentId + "' and AssignStudentTable.Status=0";
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

        public List<Result> GetAllResultForView(int studentId)
        {
            Query = "SELECT CourseTable.CourseCode,CourseTable.CourseName,GradeTable.Grade from AssignStudentTable " +
                            "Inner JOIN CourseTable ON CourseTable.id=AssignStudentTable.CourseID " +
                            "Inner JOIN GradeTable On AssignStudentTable.GradeID=GradeTable.id " +
                            "where AssignStudentTable.StudentID='" + studentId + "' and AssignStudentTable.Status=0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Result> listOfResults = new List<Result>();
            while (Reader.Read())
            {
                Result aResult = new Result();
                aResult.CourseCode = Reader["CourseCode"].ToString();
                aResult.CourseName = Reader["CourseName"].ToString();
                aResult.Grade = Reader["Grade"].ToString();
                listOfResults.Add(aResult);

            }
            Connection.Close();
            return listOfResults;
        }
    }
}