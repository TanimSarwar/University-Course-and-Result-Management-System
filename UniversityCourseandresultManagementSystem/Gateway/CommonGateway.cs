using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class CommonGateway
    {
        private string ConnectionString =
            WebConfigurationManager.ConnectionStrings["URCMSDBConnection"].ConnectionString;
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlConnection Connection { get; set; }
        public string Query { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection(ConnectionString);
        }
    }
}