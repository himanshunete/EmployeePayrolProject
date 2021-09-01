using Commonlayer.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RepositoryLayer.Interface
{
    public interface IGetItemsRL
    {
        List<SelectListItem> GetSalary();
        List<SelectListItem> GetYear();
        List<SelectListItem> GetMonth();
        List<SelectListItem> GetDay();
        //List<CheckBoxes> GetDept();
    }
}
