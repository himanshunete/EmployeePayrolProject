using Commonlayer.Models.RequestModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {

        //create new sqlconnection and connection to database by using connection string from web.config file  
        public static readonly string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);

        public void EmployeeRegistration(Employee employee)
        {
            string year = employee.Year;
            string month = employee.Month;
            string day = employee.Day;
            employee.CreatedDate = DateTime.Now;
            string StartDate = day + "-" + month + "-" + year;
            employee.StartDate = StartDate;
            
            SqlCommand com = new SqlCommand("spEmployeeRegistration", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", employee.Name);
            com.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
            com.Parameters.AddWithValue("@Gender", employee.Gender);
            com.Parameters.AddWithValue("@Salary", employee.Salary);
            com.Parameters.AddWithValue("@StartDate", employee.StartDate);
            com.Parameters.AddWithValue("@Notes", employee.Notes);
            com.Parameters.AddWithValue("@CreatedDate", employee.CreatedDate);
            var ReturnParameter = com.Parameters.Add("@Result", SqlDbType.Int);
            ReturnParameter.Direction = ParameterDirection.ReturnValue;

            con.Open();
            com.ExecuteNonQuery();
            int result = (int)ReturnParameter.Value;
            con.Close();


            if (employee.isHRChecked == true)
            {
                employee.Department = "1";
                RegisterDepartment(employee);
            }
            if (employee.isSalesChecked == true)
            {
                employee.Department = "2";
                RegisterDepartment(employee);
            }
            if (employee.isFinanceChecked == true)
            {
                employee.Department = "3";
                RegisterDepartment(employee);
            }
            if (employee.isEngineerChecked == true)
            {
                employee.Department = "4";
                RegisterDepartment(employee);
            }
            if (employee.isOthersChecked == true)
            {
                employee.Department = "5";
                RegisterDepartment(employee);
            }
        }

        public IList<Employee> GetEmployeeDetails()
        {
            SqlCommand com = new SqlCommand("spGetRecords", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            List<Employee> resultList = new List<Employee>();
           
            while (dr.Read())
            {
                Employee entity = new Employee();
                entity.EmployeeId = (int)dr["EmployeeId"];
                entity.ProfileImage = (string)dr["ProfileImage"];
                entity.Name = (string)dr["Name"];
                entity.Gender = Convert.ToChar(dr["Gender"]);
                entity.Salary = (int)dr["Salary"];
                entity.StartDate = (string)dr["StartDate"];
                resultList.Add(entity);
            }
            con.Close();
            return resultList;
        }

        public IList<Employee> GetEmployeeDepartmentDetails()
        {
            SqlCommand com = new SqlCommand("spGetDepartmentRecords", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            List<Employee> resultList = new List<Employee>();
           
            while (dr.Read())
            {
                Employee entity = new Employee();
                entity.EmployeeId = (int)dr["EmployeeId"];
                entity.Department = (string)dr["DepartmentName"];
                string[] departments = entity.Department.Split(',');
                for (int i = 0; i < departments.Length; i++)
                {
                    departments[i] = departments[i].Trim();
                }
                entity.multipleDepartments = departments;
                resultList.Add(entity);
            }
            con.Close();
            return resultList;
        }



        public void RegisterDepartment(Employee department)
        {
            SqlCommand com = new SqlCommand("spRegisterEmployeeDepartment", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProfileImage", department.ProfileImage);
            com.Parameters.AddWithValue("@DepartmentId", int.Parse(department.Department));

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public Employee DetailsToEdit(int employeeId)
        {
            SqlCommand com = new SqlCommand("spDetailsToEdit", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", employeeId);
            SqlDataReader dr = com.ExecuteReader();
            List<Employee> resultList = new List<Employee>();
            Employee entity = new Employee();
            while (dr.Read())
            {
              
                entity.EmployeeId = (int)dr["EmployeeId"];
                entity.ProfileImage = (string)dr["ProfileImage"];
                entity.Name = (string)dr["Name"];
                entity.Gender = (char)dr["Gender"];
                entity.Salary = (int)dr["Salary"];
                entity.StartDate = (string)dr["StartDate"];

            }
            return entity;
        }

        public Employee DetailsToEditDepartment(int employeeId)
        {
            SqlCommand com = new SqlCommand("spDetailsToEditDepartment", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", employeeId);
            SqlDataReader dr = com.ExecuteReader();
            List<Employee> resultList = new List<Employee>();
            Employee entity = new Employee();
            while (dr.Read())
            {
                entity.Department = (string)dr["DepartmentName"];
                string[] departments = entity.Department.Split(',');
                for (int i = 0; i < departments.Length; i++)
                {
                    departments[i] = departments[i].Trim();
                }
                entity.multipleDepartments = departments;
            }

            if (entity.multipleDepartments.Contains("HR"))
            {
                entity.isHRChecked = true;
            }
            if (entity.multipleDepartments.Contains("Finance"))
            {
                entity.isFinanceChecked = true;
            }
            if (entity.multipleDepartments.Contains("Sales"))
            {
                entity.isSalesChecked = true;
            }
            if (entity.multipleDepartments.Contains("Engineer"))
            {
                entity.isEngineerChecked = true;
            }
            if (entity.multipleDepartments.Contains("Others"))
            {
                entity.isOthersChecked = true;
            }

            return entity;
        }
    }
}
