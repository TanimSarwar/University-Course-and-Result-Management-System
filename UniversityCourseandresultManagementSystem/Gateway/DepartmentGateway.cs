using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandresultManagementSystem.Models;

namespace UniversityCourseandresultManagementSystem.Gateway
{
    public class DepartmentGateway : CommonGateway
    {
        public bool IsDeptCodeExist(Department aDepartment)
        {
            Query = "SELECT * FROM DepartmentTable WHERE DeptCode = @deptCode";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptCode", aDepartment.DeptCode);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public bool IsDeptNameExist(Department aDepartment)
        {
            Query = "SELECT * FROM DepartmentTable WHERE DeptName = @deptName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptName", aDepartment.DeptName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int InsertNewDepartment(Department aDepartment)
        {
            Query = "INSERT INTO DepartmentTable Values(@deptCode, @deptName)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptCode", aDepartment.DeptCode);
            Command.Parameters.AddWithValue("deptName", aDepartment.DeptName);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM DepartmentTable";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> listOfDepartments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department
                {
                    Id = Convert.ToInt32(Reader["Id"].ToString()),
                    DeptCode = Reader["DeptCode"].ToString(),
                    DeptName = Reader["DeptName"].ToString()
                };
                listOfDepartments.Add(aDepartment);
            }
            Connection.Close();
            Reader.Close();
            return listOfDepartments;
        }

        public Department GetDepartmentbyId(int departmentId)
        {
            Query = "SELECT * FROM DepartmentTable WHERE Id = @deptId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@deptId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = new Department();
            if (Reader.Read())
            {
                aDepartment.DeptCode = Reader["DeptCode"].ToString();
                aDepartment.DeptName = Reader["DeptName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }
    }
}