using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class WeekDayGateway:CommonGateway
    {
        public List<WeekDays> GetAllDay()
        {
            Query = "SELECT *from SevenDayWeekTable order by id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<WeekDays> listOfDays = new List<WeekDays>();
            while (Reader.Read())
            {
                WeekDays aWeekDays = new WeekDays();
                aWeekDays.Id = Convert.ToInt32(Reader["id"]);
                aWeekDays.Day = Reader["Day"].ToString();
                listOfDays.Add(aWeekDays);

            }
            Connection.Close();
            return listOfDays;
        }
    }
}