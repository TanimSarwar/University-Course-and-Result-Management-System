using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandresultManagementSystem.Manager;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //Saving Department Info
        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            if (ModelState.IsValid)
            {
                DepartmentManager aDepartmentManager = new DepartmentManager();
                aDepartment.DeptCode = aDepartment.DeptCode.ToUpper();
                aDepartment.DeptName = aDepartment.DeptName;
                ViewBag.Message = aDepartmentManager.InsertNewDepartment(aDepartment);
                return View();
            }
            return View();
            
        }
        //Saving Department Info Ends



        //Viewing Department Info
        [HttpGet]
        public ActionResult ViewDepartment()
        {
            ViewBag.Departments = new DepartmentManager().GetAllDepartments();
            return View();
        }
        //Viewing Department Info Ends
	}
}