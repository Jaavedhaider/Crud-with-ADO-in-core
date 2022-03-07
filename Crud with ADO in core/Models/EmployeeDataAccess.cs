using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crud_with_ADO_in_core.Models
{

    public class EmployeeDataAccess
    {
        DbConnection Dbconnection;
        public EmployeeDataAccess()
        {
            Dbconnection = new DbConnection();
        }
        public List<Employee> GetEmployees()
        {

            SqlCommand sql = new SqlCommand("SP_Employees", Dbconnection.connection);
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            sql.CommandType = CommandType.StoredProcedure;
            if(Dbconnection.connection.State==ConnectionState.Closed)
            {
                Dbconnection.connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while(dr.Read())
            {
                Employee emp = new Employee();
                emp.id =(int) dr["id"];
                emp.Ename = dr["ename"].ToString();
                emp.Salary = (int)dr["salary"];
                emp.Mobile = (int)dr["mobile"];
                
                emp.DepartmentName = dr["Dname"].ToString();
                employees.Add(emp);
            }
            Dbconnection.connection.Close();
            return employees;
        }
        public bool AddEmployee(Employee employee)
        {
            SqlCommand sql = new SqlCommand("SP_Employees", Dbconnection.connection);
            sql.Parameters.AddWithValue("@action", "CREATE");
            sql.Parameters.AddWithValue("@ename", employee.Ename);
            sql.Parameters.AddWithValue("@salary", employee.Salary);
            sql.Parameters.AddWithValue("@mobile", employee.Mobile);
            sql.Parameters.AddWithValue("@deptid", employee.Deptid);
        
            sql.CommandType = CommandType.StoredProcedure;
            if (Dbconnection.connection.State == ConnectionState.Closed)
            {
                Dbconnection.connection.Open();
            }
            int i = sql.ExecuteNonQuery();
            Dbconnection.connection.Close();
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
