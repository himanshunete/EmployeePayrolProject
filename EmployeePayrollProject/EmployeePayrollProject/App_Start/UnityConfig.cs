using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace EmployeePayrollProject.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeBL, EmployeeBL>();
            container.RegisterType<IEmployeeRL, EmployeeRL>();
            container.RegisterType<IGetItemsBL, GetItemsBL>();
            container.RegisterType<IGetItemsRL, GetItemsRL>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        
    }
}