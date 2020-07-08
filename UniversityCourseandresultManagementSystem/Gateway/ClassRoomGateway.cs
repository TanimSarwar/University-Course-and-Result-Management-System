using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class ClassRoomGateway:CommonGateway
    {
        public int AllocateNewClassRoom(ClassRoomAllocation aClassRoomAllocation)
        {
            Query = "INSERT INTO ClassRoomAllocationTable Values('" + aClassRoomAllocation.TimeFrom + "','" + aClassRoomAllocation.TimeTo + "','0','" + aClassRoomAllocation.DepartmentId + "','" + aClassRoomAllocation.CourseId + "','" + aClassRoomAllocation.RoomNoId + "','" + aClassRoomAllocation.SevenDayWeekId + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsClassRoomAllocatioPossible(ClassRoomAllocation aClassRoomAllocation)
        {
            Query = "SELECT *from ClassRoomAllocationTable where SevenDayWeekID ='" + aClassRoomAllocation.SevenDayWeekId + "' and RoomNoID ='" + aClassRoomAllocation.RoomNoId + "'  and Status='0' order by TimeFrom";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassRoomAllocation> listOfItems = new List<ClassRoomAllocation>();
            while (Reader.Read())
            {
                ClassRoomAllocation item = new ClassRoomAllocation();
                item.Id = Convert.ToInt32(Reader["id"]);
                item.TimeFrom = Reader["TimeFrom"].ToString();
                item.TimeTo = Reader["TimeTo"].ToString();
                listOfItems.Add(item);
            }
            Connection.Close();
            int[] timeArray = new int[3000];
            foreach (ClassRoomAllocation c in listOfItems)
            {
                for (int i = Convert.ToInt32(c.TimeFrom); i <= Convert.ToInt32(c.TimeTo); i++)
                {
                    timeArray[i] = 1;
                }
                timeArray[Convert.ToInt32(c.TimeTo)] = 0;
            }
            for (int i = Convert.ToInt32(aClassRoomAllocation.TimeFrom); i <= Convert.ToInt32(aClassRoomAllocation.TimeTo); i++)
            {
                if (timeArray[i] == 1)
                {
                    return false;
                }
            }
            return true;
        }
        public List<ClassRoom> GetAllClassRooms()
        {
            Query = "SELECT * from ClassRoomTable order by RoomNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassRoom> listOfClassRoom = new List<ClassRoom>();
            while (Reader.Read())
            {
                ClassRoom item = new ClassRoom
                {
                    Id = Convert.ToInt32(Reader["id"]),
                    RoomNo = Reader["RoomNo"].ToString()
                };
                listOfClassRoom.Add(item);

            }
            Connection.Close();
            Reader.Close();
            return listOfClassRoom;
        }
        public int UnAllocateClassRooms()
        {
            Query = "UPDATE ClassRoomAllocationTable SET Status = '1' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ClassSchedule> GetAllClassScheduleByDeptId(int departmenttId)
        {
            string query =
                "SELECT CourseTable.CourseCode, CourseTable.CourseName,SevenDayWeekTable.DayShortName,ClassRoomAllocationTable.TimeFrom," +
                " ClassRoomAllocationTable.TimeTo,ClassRoomAllocationTable.Status,ClassRoomTable.RoomName" +
                " FROM  ClassRoomAllocationTable" +
                " Left join SevenDayWeekTable ON SevenDayWeekTable.id=ClassRoomAllocationTable.SevenDayWeekID" +
                " Inner join ClassRoomTable ON ClassRoomTable.id=ClassRoomAllocationTable.RoomNoID" +
                " Right JOIN CourseTable ON CourseTable.id=ClassRoomAllocationTable.CourseID" +
                " where CourseTable.DepartmentID='" + departmenttId + "' order by CourseCode";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassSchedule> listOfItems = new List<ClassSchedule>();
            while (Reader.Read())
            {
                if (Reader["Status"].ToString() == "1")
                {
                    continue;
                }
                ClassSchedule item = new ClassSchedule();
                item.CourseCode = Reader["CourseCode"].ToString();
                item.CourseName = Reader["CourseName"].ToString();
                item.DayShortName = Reader["DayShortName"].ToString();
                item.TimeFrom = Reader["TimeFrom"].ToString();
                if (item.TimeFrom != "" && Convert.ToInt32(item.TimeFrom) >= 1200)
                {
                    int temp1 = Convert.ToInt32(item.TimeFrom) - 1200;
                    string timeFrom = "";
                    if (temp1.ToString().Length == 1)
                    {
                        timeFrom = "12:00" + " PM";
                    }
                    else if (temp1.ToString().Length == 2)
                    {
                        timeFrom = "12:" + temp1 + " PM";
                    }
                    else if (temp1.ToString().Length == 3)
                    {
                        string temp = temp1.ToString();
                        char[] array = temp.ToCharArray();
                        timeFrom = "0" + array[0] + ":" + array[1] + array[2] + " PM";
                    }
                    else
                    {
                        string temp = temp1.ToString();
                        char[] array = temp.ToCharArray();
                        timeFrom = "" + array[0] + array[1] + ":" + array[2] + array[3] + " PM";
                    }
                    item.TimeFrom = timeFrom;
                }
                else if (item.TimeFrom != "" && Convert.ToInt32(item.TimeFrom) < 1200)
                {
                    string temp = item.TimeFrom.ToString();
                    char[] array = temp.ToCharArray();
                    item.TimeFrom = "" + array[0] + array[1] + ":" + array[2] + array[3] + " AM";
                }
                item.TimeTo = Reader["TimeTo"].ToString();
                if (item.TimeTo != "" && Convert.ToInt32(item.TimeTo) >= 1200)
                {
                    int temp1 = Convert.ToInt32(item.TimeTo) - 1200;
                    string timeTo = "";
                    if (temp1.ToString().Length == 1)
                    {
                        timeTo = "12:00" + " PM";
                    }
                    else if (temp1.ToString().Length == 2)
                    {
                        timeTo = "12:" + temp1 + " PM";
                    }
                    else if (temp1.ToString().Length == 3)
                    {
                        string temp = temp1.ToString();
                        char[] array = temp.ToCharArray();
                        timeTo = "0" + array[0] + ":" + array[1] + array[2] + " PM";
                    }
                    else
                    {
                        string temp = temp1.ToString();
                        char[] array = temp.ToCharArray();
                        timeTo = "" + array[0] + array[1] + ":" + array[2] + array[3] + " PM";
                    }
                    item.TimeTo = timeTo;
                }
                else if (item.TimeTo != "" && Convert.ToInt32(item.TimeTo) < 1200)
                {
                    string temp = item.TimeTo.ToString();
                    char[] array = temp.ToCharArray();
                    item.TimeTo = "" + array[0] + array[1] + ":" + array[2] + array[3] + " AM";
                }
                item.RoomName = Reader["RoomName"].ToString();
                listOfItems.Add(item);

            }
            Connection.Close();
            return listOfItems;
        }
    }
}