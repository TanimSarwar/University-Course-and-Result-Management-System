using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string InsertNewDepartment(Department aDepartment)
        {
            if (aDepartmentGateway.IsDeptCodeExist(aDepartment))
            {
                return "Department Code Already Exists";
            }
            if (aDepartmentGateway.IsDeptNameExist(aDepartment))
            {
                return "Department Name Already Exists";
            }
            int rowAffected = aDepartmentGateway.InsertNewDepartment(aDepartment);
            if (rowAffected > 0)
            {
                return "Department Information Saved Successfully";
            }
            return "Department Information Not Saved";
            
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }

        public Department GetDepartmentbyId(int departmentId)
        {
            return aDepartmentGateway.GetDepartmentbyId(departmentId);
        }
    }
}