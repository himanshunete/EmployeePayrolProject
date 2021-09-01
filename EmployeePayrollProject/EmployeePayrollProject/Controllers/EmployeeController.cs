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
using static EmployeePayrollProject.FilterConfig;

namespace EmployeePayrollProject.Controllers
{
    [CustomAuthenticationFilter]
    public class EmployeeController : Controller
    {

        IEmployeeBL employeeBL;
        IGetItemsBL getItemsBL;
        Employee employeeEdit = new Employee();
        Employee employee = new Employee();
        GetItems getItems = new GetItems();
        //private IConfiguration Configuration { get; }

        public EmployeeController(IEmployeeBL employeeBL, IGetItemsBL getItemsBL)
        {
            this.employeeBL = employeeBL;
            this.getItemsBL = getItemsBL;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize("Admin", "Employee")]
        public ActionResult Form()
        {
            ViewBag.Salary = getItemsBL.GetSalary();
            ViewBag.Month = getItemsBL.GetMonth();
            ViewBag.Day = getItemsBL.GetDay();
            ViewBag.Year = getItemsBL.GetYear();
            
            return View();
        }

        [CustomAuthorize("Admin", "Employee")]
        [HttpPost]
        public ActionResult Form(Employee employee)
        {
            if (ModelState.IsValid)
            {

                employeeBL.EmployeeRegistration(employee);
                ViewBag.JavaScriptFunction = string.Format("myFunction();");
                Session["loginsuccess"] = "";
                Session["register"] = "register";
                return Redirect("GetEmployeeDetails");
            }
            else
            {
                ViewBag.Salary = getItemsBL.GetSalary();
                ViewBag.Month = getItemsBL.GetMonth();
                ViewBag.Day = getItemsBL.GetDay();
                ViewBag.Year = getItemsBL.GetYear();
                return View(employee);
            }
        }

        [CustomAuthorize("Admin", "Employee")]
        public ActionResult GetEmployeeDetails()
        {
            ViewData["employees"] = employeeBL.GetEmployeeDetails();
            ViewData["employees_departments"] = employeeBL.GetEmployeeDepartmentDetails();
            int Id = (int)Session["Id"];
            string EmailAddress = Session["EmailAddress"].ToString();

            if (Id.Equals(null) && EmailAddress.Equals(null))
            {
              
                Session["loginfailed"] = "loginfailed";
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.loginsuccess = Session["loginsuccess"];
                ViewBag.register = Session["register"];
                ViewBag.editregister = Session["editregister"];
                ViewBag.JavaScriptFunction = string.Format("myFunction();");
                return View();
            }
        
        }

        [CustomAuthorize("Admin", "Employee")]
        public ActionResult EditEmployee(int employeeId)
        {
            Session["employeeId"] = employeeId;
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

        [CustomAuthorize("Admin", "Employee")]
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeId = (int)Session["employeeId"];
                employeeBL.UpdateEmployeeDetails(employee);
                employeeBL.UpdateDepartment(employee);
                Session["loginsuccess"] = "";
                Session["editregister"] = "editregister";
                return RedirectToAction("GetEmployeeDetails");
            }
            else
            {
                ViewBag.Salary = getItemsBL.GetSalary();
                ViewBag.Month = getItemsBL.GetMonth();
                ViewBag.Day = getItemsBL.GetDay();
                ViewBag.Year = getItemsBL.GetYear();
                return View(employee);
            }
        }

        [CustomAuthorize("Admin", "Employee")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            employeeBL.DeleteEmployee(employeeId); 
            return RedirectToAction("GetEmployeeDetails");
        }

        [CustomAuthorize("Admin", "Employee")]
        [HttpPost]
        public ActionResult ViewDetails(int employeeId)
        {
            var result1 = employeeBL.DetailsToEdit(employeeId);
            var result2 = employeeBL.DetailsToEditDepartment(employeeId);
            employeeEdit.Name = result1.Name;
            employeeEdit.ProfileImage = result1.ProfileImage;
            employeeEdit.Gender = result1.Gender;
            employeeEdit.Salary = result1.Salary;
            employeeEdit.StartDate = result1.StartDate;
            employeeEdit.Notes = result1.Notes;
            string[] date = employeeEdit.StartDate.Split('-');
            employeeEdit.Year = date[2];
            employeeEdit.Month = date[1];
            employeeEdit.Day = date[0];
            employeeEdit.multipleDepartments = result2.multipleDepartments;
            employeeEdit.isHRChecked = result2.isHRChecked;
            employeeEdit.isSalesChecked = result2.isSalesChecked;
            employeeEdit.isFinanceChecked = result2.isFinanceChecked;
            employeeEdit.isEngineerChecked = result2.isEngineerChecked;
            employeeEdit.isOthersChecked = result2.isOthersChecked;
            employeeEdit.Notes = result1.Notes;
           
            return View(employeeEdit);
        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
        }
    }
}