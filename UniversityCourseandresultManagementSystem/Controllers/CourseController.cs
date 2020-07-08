using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandresultManagementSystem.Manager;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        ViewAssignedCoursesManager aViewAssignedCoursesManager = new ViewAssignedCoursesManager();
        CourseAssignToTeacherManager aCourseAssignToTeacherManager = new CourseAssignToTeacherManager();

        //Saving Course Info
        [HttpGet]
        public ActionResult SaveCourse()
        {
            ViewBag.Departments = GetDepartmentForDropDown();
            ViewBag.Semesters = GetSemesterForDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            if (ModelState.IsValid)
            {
                aCourse.CourseCode = aCourse.CourseCode.ToUpper();
                ViewBag.Message = aCourseManager.InsertNewCourse(aCourse);
                ViewBag.Departments = GetDepartmentForDropDown();
                ViewBag.Semesters = GetSemesterForDropDown();
                return View();
            }
            ViewBag.Departments = GetDepartmentForDropDown();
            ViewBag.Semesters = GetSemesterForDropDown();
            return View();

        }
        //Saving Course Info Ends
        public IEnumerable<SelectListItem> GetDepartmentForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Department---",Value = ""},                
            };
            List<Department> departments = new DepartmentManager().GetAllDepartments();
            foreach (Department department in departments)
            {
                SelectListItem selectListDepartment = new SelectListItem();
                selectListDepartment.Text = department.DeptName;
                selectListDepartment.Value = department.Id.ToString();
                selectListItems.Add(selectListDepartment);
            }

            return selectListItems;
        }
        public IEnumerable<SelectListItem> GetSemesterForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Semester---",Value = ""},                
            };
            List<Semester> semesters = new SemesterManager().GetAllSemesters();
            foreach (Semester semester in semesters)
            {
                SelectListItem selectListSemester = new SelectListItem();
                selectListSemester.Text = semester.SemesterName;
                selectListSemester.Value = semester.Id.ToString();
                selectListItems.Add(selectListSemester);
            }
            return selectListItems;
        }
        public JsonResult GetAllUnAssignCoursesByDeptId(int departmentId)
        {
            var courses = aCourseManager.GetAllUnAssignCoursesByDeptId(departmentId);

            return Json(courses);
        }
        public JsonResult GetAllCoursesByDeptId(int departmentId)
        {
            var courses = aCourseManager.GetAllCoursesByDeptId(departmentId);

            return Json(courses);
        }

        public ActionResult GetCourseInformationByCourseId(int courseId)
        {
            var course = aCourseManager.GetCourseInformationByCourseId(courseId);
            return Json(course);
        }

        [HttpGet]
        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = GetDepartmentForDropDown();
            return View();
        }
        public JsonResult GetAllAssignedCourses(int departmentId)
        {
            var courses = aViewAssignedCoursesManager.GetAllAssignedCourses(departmentId);
            return Json(courses);
        }
        [HttpGet]
        public ActionResult UnassignCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnassignCourse(string unAssignCourse)
        {
            ViewBag.Message = aCourseAssignToTeacherManager.UnAssignAllCourses();
            return View();
        }
    }


}