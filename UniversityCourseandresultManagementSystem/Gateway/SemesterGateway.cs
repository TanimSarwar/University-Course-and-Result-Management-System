using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class SemesterGateway:CommonGateway
    {
        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM SemesterTable ORDER BY SemesterCode";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> listOfSemester = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester
                {
                    Id = Convert.ToInt32(Reader["id"]),
                    SemesterCode = Convert.ToInt32(Reader["SemesterCode"]),
                    SemesterName = Reader["SemesterName"].ToString()
                };
                listOfSemester.Add(aSemester);

            }
            Reader.Close();
            Connection.Close();
            return listOfSemester;
        }
    }
}