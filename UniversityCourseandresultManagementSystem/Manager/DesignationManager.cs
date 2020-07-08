using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Gateway;
using UniversityCourseandresultManagementSystem.Models;


namespace UniversityCourseandresultManagementSystem.Manager
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway = new DesignationGateway();
        public List<TeacherDesignation> GetAllDesignations()
        {
            return aDesignationGateway.GetAllDesignations();
        }
    }
}