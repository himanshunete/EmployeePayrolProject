using BusinessLayer.Interface;
using Commonlayer.Models.RequestModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        public IEmployeeRL employeeRL;

        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public void EmployeeRegistration(Employee employee)
        {
            try
            {
                this.employeeRL.EmployeeRegistration(employee);
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public IList<Employee> GetEmployeeDetails()
        {
            try
            {
                return this.employeeRL.GetEmployeeDetails();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Employee> GetEmployeeDepartmentDetails()
        {
            try
            {
                return this.employeeRL.GetEmployeeDepartmentDetails();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee DetailsToEdit(int employeeId)
        {
            return this.employeeRL.DetailsToEdit(employeeId);
        }

        public Employee DetailsToEditDepartment(int employeeId)
        {
            return this.employeeRL.DetailsToEditDepartment(employeeId);
        }

        public void UpdateEmployeeDetails(Employee employee)
        {
            this.employeeRL.UpdateEmployeeDetails(employee);
        }

        public void UpdateDepartment(Employee employee)
        {
            this.employeeRL.UpdateDepartment(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            this.employeeRL.DeleteEmployee(employeeId);
        }
    }
}
