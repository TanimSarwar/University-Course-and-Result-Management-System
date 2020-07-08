using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();
        public int GetRowCount(int departmentId, int year)
        {
            return aStudentGateway.GetRowCount(departmentId, year);
        }

        public string Save(Student aStudent)
        {
            if (aStudentGateway.IsExists(aStudent))
            {
                return "Given Email Already Exists";
            }
            int rowAffect = aStudentGateway.Save(aStudent);
            if (rowAffect > 0)
            {
                return "Student Inforrmation Saved Successfully with the following Information:\n Name: " +
                       aStudent.StudentName + "\nEmail: " + aStudent.StudentEmail + "\nContact No: " +
                       aStudent.StudentContactNo + "\nRegistration Date: " + aStudent.StudentAddDate + "\nAddress: " +
                       aStudent.StudentAddress + "\nDepartment: " + aStudent.DepartmentId +
                       " and the Registration Number: " + aStudent.StudentRegNo + ".";
            }
            else
            {
                return "Save Failed";
            }
        }

        public Student GetStudentInfoById(int studentId)
        {
            return aStudentGateway.GetStudentInfoById(studentId);
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGateway.GetAllStudents();
        }

        public string EnrollStudentInACourse(CourseEnrollment aCourseEnrollment)
        {
            if (aStudentGateway.IsCourseTakenAlready(aCourseEnrollment))
            {
                return "This Course already Taken by this Student";
            }
            int rowAffected = aStudentGateway.EnrollNewCourseToStudent(aCourseEnrollment);
            if (rowAffected > 0)
            {
                return "Course Successfully Assigned to the Student";
            }
            return "Course enrollment Failed";

        }

        public List<Grade> GetAllGrades()
        {
            return aStudentGateway.GetAllGrades();
        }

        public string SaveResult(Result aResult)
        {
            int rowAffected = aStudentGateway.SaveResult(aResult);
            if (rowAffected>0)
            {
                return "Result Saved";
            }
            else
            {
                return "Result wasn't saved";
            }
        }

        public List<Course> GetAllTakenCoursesByStudent(int studentId)
        {
            return aStudentGateway.GetAllTakenCoursesByStudent(studentId);
        }

        public List<Result> GetAllResultForView(int studentId)
        {
            return aStudentGateway.GetAllResultForView(studentId);
        }
    }
}