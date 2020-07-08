using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Manager;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        //For Saving Teacher Info
        
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = GetDepartmentForDropDown();
            ViewBag.Designation = GetDesignationForDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            if (ModelState.IsValid)
            {
                TeacherManager aTeacherManager = new TeacherManager();
                ViewBag.Message = aTeacherManager.InsertNewTeacher(aTeacher);
                ViewBag.Departments = GetDepartmentForDropDown();
                ViewBag.Designation = GetDesignationForDropDown();
                return View();
            }
                ViewBag.Departments = GetDepartmentForDropDown();
                ViewBag.Designation = GetDesignationForDropDown();
                return View();
        }

        public IEnumerable<SelectListItem> GetDesignationForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Designation---",Value = ""},                
            };
            List<TeacherDesignation> teacherDesignations = new DesignationManager().GetAllDesignations();
            foreach (TeacherDesignation teacherDesignation in teacherDesignations)
            {
                SelectListItem selectListDesignation = new SelectListItem();
                selectListDesignation.Text = teacherDesignation.DesignationName;
                selectListDesignation.Value = teacherDesignation.Id.ToString();
                selectListItems.Add(selectListDesignation);
            }

            return selectListItems;
        }

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

        public IEnumerable<SelectListItem> GetCoursesForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select---",Value = ""},                
            };
            List<Course> courses = new CourseManager().GetAllCourses();
            foreach (Course course in courses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = course.CourseName;
                selectListItem.Value = course.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
        // For Assigning Courses to The Teacher

        [HttpGet]
        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.Departments = GetDepartmentForDropDown();
            ViewBag.Courses = GetCoursesForDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(CourseAssign aCourseAssign)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Departments = GetDepartmentForDropDown();
                ViewBag.Designation = GetDesignationForDropDown();
                ViewBag.Message = new CourseAssignToTeacherManager().AssignCourseToTeacher(aCourseAssign);
                return View();
            }
                ViewBag.Departments = GetDepartmentForDropDown();
                ViewBag.Courses = GetCoursesForDropDown();
                return View();

        }
        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teacher = new TeacherManager().GetAllTeachersByDepartment(departmentId);
            var teacherList = teacher.ToList();
            return Json(teacherList);
        }
        public JsonResult GetTeacherInformationById(int teacherId)
        {
            var teacher = new TeacherManager().GetTeacherInformationById(teacherId);
            teacher.CourseTaken = new TeacherManager().GetTotalTakenCourses(teacherId);
            //teacher.CourseTaken = new TeacherGateway().GetTotalTakenCourses(teacherId);
            return Json(teacher);
        }
        
	}
}