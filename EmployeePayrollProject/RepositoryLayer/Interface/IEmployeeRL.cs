using Commonlayer.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        void EmployeeRegistration(Employee employee);
        IList<Employee> GetEmployeeDetails();
        IList<Employee> GetEmployeeDepartmentDetails();
        Employee DetailsToEdit(int employeeId);
        Employee DetailsToEditDepartment(int employeeId);

        void UpdateEmployeeDetails(Employee employee);
        void UpdateDepartment(Employee employee);

        void DeleteEmployee(int employeeId);
    }
}
