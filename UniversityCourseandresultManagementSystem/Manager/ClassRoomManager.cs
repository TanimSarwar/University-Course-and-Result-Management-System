using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class ClassRoomManager
    {
        ClassRoomGateway aClassRoomGateway = new ClassRoomGateway();
        public string AllocateNewClassRoom(ClassRoomAllocation aClassRoomAllocation)
        {

            if (!aClassRoomGateway.IsClassRoomAllocatioPossible(aClassRoomAllocation))
            {
                return "ClassRoom is not availabe in this time";
            }
            else
            {
                int rowAffected = aClassRoomGateway.AllocateNewClassRoom(aClassRoomAllocation);
                if (rowAffected>0)
                {
                    return "ClassRoom Allocated Successfully";
                }
                return "ClassRoom Allocation Failed";
            }

        }
        public List<ClassRoom> GetAllClassRooms()
        {
            return aClassRoomGateway.GetAllClassRooms();
        }
        public string UnAllocateClassRooms()
        {
            int rowAffected = aClassRoomGateway.UnAllocateClassRooms();
            if (rowAffected > 0)
            {
                return "ClassRooms are Successfully UnAllocated";
            }
            else
            {
                return "UnAllocation of ClassRoom Failed";
            }
        }

        public List<ClassSchedule> GetAllClassScheduleByDeptId(int departmentId)
        {
            return aClassRoomGateway.GetAllClassScheduleByDeptId(departmentId);
        }
    }
}