using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commonlayer.Models.ResponseModel
{
    public class EmployeeEdit
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public char Gender { get; set; }
        public bool isHRChecked { get; set; }
        public bool isSalesChecked { get; set; }
        public bool isFinanceChecked { get; set; }
        public bool isEngineerChecked { get; set; }
        public bool isOthersChecked { get; set; }
        public string Salary { get; set; }
     
        public string StartDate { get; set; }
        public string Notes { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
