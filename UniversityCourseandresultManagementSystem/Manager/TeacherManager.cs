using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();
        public string InsertNewTeacher(Teacher aTeacher)
        {
            if (aTeacherGateway.IsEmailExist(aTeacher))
            {
                return "Teacher's Email Already Exists";
            }
            int rowAffected = aTeacherGateway.InsertNewTeacher(aTeacher);
            if (rowAffected > 0)
            {
                return "Teacher's Information Saved Successfully";
            }
            return "Teacher's Information Not Saved";

        }

        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            return aTeacherGateway.GetAllTeachersByDepartment(departmentId);
        }

        public Teacher GetTeacherInformationById(int teacherId)
        {
            return aTeacherGateway.GetTeacherInformationById(teacherId);
        }

        public double GetTotalTakenCourses(int teacherId)
        {
            return aTeacherGateway.GetTotalTakenCourses(teacherId);
        }
    }
}