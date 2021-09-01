using BusinessLayer.Interface;
using Commonlayer.Models.RequestModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer.Service
{
    public class GetItemsBL : IGetItemsBL
    {
        public IGetItemsRL getItemsRL;

        public GetItemsBL(IGetItemsRL getItemsRL)
        {
            this.getItemsRL = getItemsRL;
        }

        public List<SelectListItem> GetSalary()
        {
            return this.getItemsRL.GetSalary();  
        }

        public List<SelectListItem> GetDay()
        {
            return this.getItemsRL.GetDay();
        }

        public List<SelectListItem> GetMonth()
        {
            return this.getItemsRL.GetMonth();
        }

        public List<SelectListItem> GetYear()
        {
            return this.getItemsRL.GetYear();
        }

        //public List<CheckBoxes> GetDept()
        //{
        //    return this.getItemsRL.GetDept();
        //}
    }
}
