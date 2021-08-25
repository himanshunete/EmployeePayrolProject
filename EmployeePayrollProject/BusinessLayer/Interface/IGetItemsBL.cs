using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer.Interface
{
    public interface IGetItemsBL
    {
        List<SelectListItem> GetSalary();
        List<SelectListItem> GetYear();
        List<SelectListItem> GetMonth();
        List<SelectListItem> GetDay();
    }
}
