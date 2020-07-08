using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandresultManagementSystem.Manager;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Controllers
{
    public class ClassRoomController : Controller
    {
        ClassRoomManager aClassRoomManager = new ClassRoomManager();
        TeacherController aTeacherController = new TeacherController();
        WeekDayManager aWeekDayManager = new WeekDayManager();
        //
        // GET: /ClassRoom/
        [HttpGet]
        public ActionResult AllocateRoom()
        {
            ViewBag.Departments = aTeacherController.GetDepartmentForDropDown();
            ViewBag.ClassRooms = GetClassRoomForDropDown();
            ViewBag.Days = GetDayForDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateRoom(ClassRoomAllocation aClassRoomAllocation)
        {
            ViewBag.Departments = aTeacherController.GetDepartmentForDropDown();
            ViewBag.ClassRooms = GetClassRoomForDropDown();
            ViewBag.Days = GetDayForDropDown();
            aClassRoomAllocation.TimeFrom = aClassRoomAllocation.TimeFrom.Remove(2, 1);
            aClassRoomAllocation.TimeTo = aClassRoomAllocation.TimeTo.Remove(2, 1);
            ViewBag.Message = aClassRoomManager.AllocateNewClassRoom(aClassRoomAllocation);
            return View();
        }
        public IEnumerable<SelectListItem> GetClassRoomForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Room---",Value = ""},                
            };
            List<ClassRoom> classRooms = aClassRoomManager.GetAllClassRooms();
            foreach (ClassRoom classRoom in classRooms)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = classRoom.RoomNo;
                selectListItem.Value = classRoom.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
        public IEnumerable<SelectListItem> GetDayForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Day---",Value = ""},                
            };
            List<WeekDays> sevenDays = aWeekDayManager.GetAllDay();
            foreach (WeekDays aWeekDays in sevenDays)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aWeekDays.Day;
                selectListItem.Value = aWeekDays.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
        [HttpGet]
        public ActionResult UnallocateClassRooms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnallocateClassRooms(string unallocatedClassRoom)
        {
            ViewBag.Message = aClassRoomManager.UnAllocateClassRooms();
            return View();
        }


        [HttpGet]
        public ActionResult ViewClassRoutine()
        {
            ViewBag.Departments = new TeacherController().GetDepartmentForDropDown();
            return View();
        }
        public JsonResult GetAllClassSchedule(int departmentId)
        {
            var getAllClassScheduleViews = GetAllClassScheduleViews(departmentId);
            return Json(getAllClassScheduleViews);
        }

        public List<ClassSchedule> GetAllClassScheduleViews(int departmentId)
        {
            List<ClassSchedule> list = aClassRoomManager.GetAllClassScheduleByDeptId(departmentId);
            List<ClassSchedule> myList = new List<ClassSchedule>();

            for (var i = 0; i < list.Count; )
            {
                ClassSchedule classView = list[i];
                ClassSchedule temp = new ClassSchedule();
                temp.CourseCode = classView.CourseCode;
                temp.CourseName = classView.CourseName;
                temp.ScheduleInfo = ("R. No : " + classView.RoomName + ", " + classView.DayShortName + ", " + classView.TimeFrom + " - " + classView.TimeTo) + "</br>";
                int ck = 0;
                i++;

                for (var j = i; j < list.Count; j++)
                {
                    ck = 1;
                    ClassSchedule classView2 = list[j - 1];
                    ClassSchedule classView3 = list[j];

                    if (classView2.CourseCode == classView3.CourseCode)
                    {
                        i++;
                        temp.ScheduleInfo += ("R. No : " + classView3.RoomName + ", " + classView3.DayShortName + ", " +
                                                         classView3.TimeFrom + " - " + classView3.TimeTo + "</br>");

                        //myList.Add(temp);
                    }
                    else
                    {
                        if (classView.RoomName == "")
                        {
                            temp.ScheduleInfo = "Not Assigned Yet";
                        }
                        myList.Add(temp);
                        break;
                    }
                }
                if (ck == 0)
                {
                    if (classView.RoomName == "")
                    {
                        temp.ScheduleInfo = "Not Assigned Yet";
                    }
                    myList.Add(temp);
                }

            }
            return myList;
        }
	}
}