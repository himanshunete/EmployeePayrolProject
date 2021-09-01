using BusinessLayer.Interface;
using Commonlayer.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayrollProject.Controllers
{
    public class AdminController : Controller
    {
        IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
          
        }

        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Register()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Register(Credential credential)
        {
            if (ModelState.IsValid)
            {
                Session["adminsuccess"] = "adminsuccess";
                adminBL.AdminRegistration(credential);
                return RedirectToAction("Login");
            }
            else
            {
                return View(credential);
            }
          
        }

        public ActionResult Login()
        {
            ViewBag.loginfailed = Session["loginfailed"];
            ViewBag.JavaScriptFunction = string.Format("myFunction();");
            return View();
        }

        [HttpPost]
        public ActionResult Login(Credential credential)
        {
            if (ModelState.IsValid)
            {
                Credential result = adminBL.AdminLogin(credential);
                Session["Id"] = result.Id;
                Session["EmailAddress"] = result.EmailAddress;
                Session["Role"] = result.Role;
             
                Session["loginsuccess"] = "loginsuccess";
                ViewBag.adminsuccess = "adminsuccess";
                ViewBag.JavaScriptFunction = string.Format("myFunction();");
                return RedirectToAction("GetEmployeeDetails", "Employee");
            }
            else
            {
                return View(credential);
            }

        }
    }
}