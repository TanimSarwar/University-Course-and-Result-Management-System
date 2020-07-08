using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using UniversityCourseandresultManagementSystem.Manager;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        TeacherController aTeacherController = new TeacherController();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        [HttpGet]
        public ActionResult SaveStudent()
        {
            ViewBag.Departments = aTeacherController.GetDepartmentForDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(Student aStudent)
        {
            if (ModelState.IsValid)
            {
                aStudent.StudentRegNo = GenerateRegNo(aStudent);
                ViewBag.Message = aStudentManager.Save(aStudent);
                ViewBag.Departments = aTeacherController.GetDepartmentForDropDown();
                return View();
            }
            ViewBag.Departments = aTeacherController.GetDepartmentForDropDown();
            return View();
        }
        private string GenerateRegNo(Student aStudent)
        {
            string year = GetYearFromDate(aStudent.StudentAddDate);
            string department = aDepartmentManager.GetDepartmentbyId(aStudent.DepartmentId).DeptCode;
            string serial = GetSerialFromRowCount(aStudentManager.GetRowCount(aStudent.DepartmentId, Convert.ToInt32(GetYearFromDate(aStudent.StudentAddDate))));

            return department + "-" + year + "-" + serial;
        }
        private string GetSerialFromRowCount(int rowCount)
        {
            rowCount++;
            string serial = rowCount.ToString("D3");
            return serial;
        }

        private string GetYearFromDate(string datefromdatepicker)
        {
            DateTime date = DateTime.ParseExact(datefromdatepicker, "dd-MM-yyyy", null);
            string year = date.Year.ToString();
            return year;
        }

        //Enroll in a course

        [HttpGet]
        public ActionResult StudentEnrollInCourse()
        {
            ViewBag.StudentsRegNo = GetAllStudentForDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult StudentEnrollInCourse(CourseEnrollment aCourseEnrollment)
        {
            if (ModelState.IsValid)
            {
                ViewBag.StudentsRegNo = GetAllStudentForDropDown();
                ViewBag.Message = aStudentManager.EnrollStudentInACourse(aCourseEnrollment);
                return View();
            }
            else
            {
                ViewBag.StudentsRegNo = GetAllStudentForDropDown();
                return View();
            }
        }
        public IEnumerable<SelectListItem> GetAllStudentForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Student's RegNo.---",Value = ""},                
            };
            List<Student> students = aStudentManager.GetAllStudents();
            foreach (Student aStudent in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aStudent.StudentRegNo;
                selectListItem.Value = aStudent.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
        public JsonResult GetStudentByStudentId(int studentId)
        {
            var students = aStudentManager.GetStudentInfoById(studentId);
            return Json(students);
        }

        public JsonResult GetCoursesByStudentId(string studentId)
        {
            var courses = aCourseManager.GetCoursesByStudentId(studentId);
            return Json(courses);
        }
        public JsonResult GetAllTakenCourseByStudentId(int studentId)
        {
            var courses = aStudentManager.GetAllTakenCoursesByStudent(studentId);
            return Json(courses);
        }
        public JsonResult GetAllCoursesByDeptId(int departmentId)
        {
            var courses = aCourseManager.GetAllCoursesByDeptId(departmentId);
            return Json(courses);
        }

        public JsonResult GetAllResultByStudentId(int studentId)
        {
            var courses = aStudentManager.GetAllResultForView(studentId);
            return Json(courses);
        }
        //Save Result
        [HttpGet]
        public ActionResult SaveStudentResult()
        {
            ViewBag.StudentsRegNo = GetAllStudentForDropDown();
            ViewBag.Grades = GetAllGradesForDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudentResult(Result aResult)
        {
            if (ModelState.IsValid)
            {
                ViewBag.StudentsRegNo = GetAllStudentForDropDown();
                ViewBag.Grades = GetAllGradesForDropDown();
                ViewBag.Message = aStudentManager.SaveResult(aResult);
                return View();
            }
            else
            {

                ViewBag.StudentsRegNo = GetAllStudentForDropDown();
                ViewBag.Grades = GetAllGradesForDropDown();
                return View();
            }

        }
        public IEnumerable<SelectListItem> GetAllGradesForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "---Select Grade---",Value = ""},                
            };
            List<Grade> grades = aStudentManager.GetAllGrades();
            foreach (Grade aGrade in grades)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aGrade.GradeLetter;
                selectListItem.Value = aGrade.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        public ActionResult ViewStudentResult()
        {
            ViewBag.StudentsRegNo = GetAllStudentForDropDown();
            return View();
        }

        //[HttpPost]
        //public FileResult JSFUN()
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=SalesSummary.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    pdfPanel.RenderControl(hw);

        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}
    }
}