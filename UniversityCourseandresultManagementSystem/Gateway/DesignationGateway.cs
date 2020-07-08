using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class DesignationGateway : CommonGateway
    {
        public List<TeacherDesignation> GetAllDesignations()
        {
            Query = "SELECT * FROM TeacherDesignationTable ORDER BY DesignationName";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TeacherDesignation> listOfDesignations = new List<TeacherDesignation>();
            while (Reader.Read())
            {
                TeacherDesignation aDesignation = new TeacherDesignation
                {
                    Id = Convert.ToInt32(Reader["id"]),
                    DesignationId = Convert.ToInt32(Reader["DesignationID"]),
                    DesignationName = Reader["DesignationName"].ToString()
                };
                listOfDesignations.Add(aDesignation);
            }
            Connection.Close();
            Reader.Close();
            return listOfDesignations;
        }
    }
}