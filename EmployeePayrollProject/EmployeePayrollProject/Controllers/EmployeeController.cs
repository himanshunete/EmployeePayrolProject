using BusinessLayer.Interface;
using Commonlayer.Models.RequestModel;
using Commonlayer.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayrollProject.Controllers
{
    public class EmployeeController : Controller
    {

        IEmployeeBL employeeBL;
        IGetItemsBL getItemsBL;
        Employee employeeEdit = new Employee();
        Employee employee = new Employee();
        //private IConfiguration Configuration { get; }

        public EmployeeController(IEmployeeBL employeeBL, IGetItemsBL getItemsBL)
        {
            this.employeeBL = employeeBL;
            this.getItemsBL = getItemsBL;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {

            ViewData["Salary"] = getItemsBL.GetSalary();
            ViewData["Day"] = getItemsBL.GetDay();
            ViewData["Month"] = getItemsBL.GetMonth();
            ViewData["Year"] = getItemsBL.GetYear();

            return View();
        }


        [HttpPost]
        public ActionResult Form(Employee employee)
        {
            if (ModelState.IsValid)
            {

                employeeBL.EmployeeRegistration(employee);
                return RedirectToAction("GetEmployeeDetails");
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetEmployeeDetails()
        {
            ViewData["employees"] = employeeBL.GetEmployeeDetails();
            ViewData["employees_departments"] = employeeBL.GetEmployeeDepartmentDetails();
            return View();
        }

        public ActionResult EditEmployee(int employeeId)
        {
            var result1 = employeeBL.DetailsToEdit(employeeId);
            var result2 = employeeBL.DetailsToEditDepartment(employeeId);
            employeeEdit.Name = result1.Name;
            employeeEdit.ProfileImage = result1.ProfileImage;
            employeeEdit.Gender = result1.Gender;
            employeeEdit.Salary = result1.Salary;
            employeeEdit.StartDate = result1.StartDate;
            string[] date = employeeEdit.StartDate.Split('-');
            employeeEdit.Year = date[2];
            employeeEdit.Month = date[1];
            employeeEdit.Day = date[0];
            employeeEdit.isHRChecked = result2.isHRChecked;
            employeeEdit.isSalesChecked = result2.isSalesChecked;
            employeeEdit.isFinanceChecked = result2.isFinanceChecked;
            employeeEdit.isEngineerChecked = result2.isEngineerChecked;
            employeeEdit.isOthersChecked = result2.isOthersChecked;
            employeeEdit.Notes = result1.Notes;
            ViewData["Salary"] = getItemsBL.GetSalary();
            ViewData["Day"] = getItemsBL.GetDay();
            ViewData["Month"] = getItemsBL.GetMonth();
            ViewData["Year"] = getItemsBL.GetYear();

            //ViewBag.salary = employeeEdit.Salary;
            //ViewBag.year = employeeEdit.Year;
            //ViewBag.day = employeeEdit.Day;
            //ViewBag.month = employeeEdit.Month;
            return View(employeeEdit);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployeeDetails(employee);
                employeeBL.UpdateDepartment(employee);
                return RedirectToAction("GetEmployeeDetails");
            }
            else
            {
                return View(employee);
            }
        }

        public ActionResult DeleteEmployee(int employeeId)
        {
            employeeBL.DeleteEmployee(employeeId); 
            return RedirectToAction("GetEmployeeDetails");
        }


    }
}