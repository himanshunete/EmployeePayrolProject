using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Commonlayer.Models.ResponseModel
{
    public class GetItems
    {
        public IEnumerable<SelectListItem> salary { get; set; }
    }
}
