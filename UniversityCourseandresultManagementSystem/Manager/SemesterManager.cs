using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Manager
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemesters()
        {
            return aSemesterGateway.GetAllSemesters();
        }
    }
}