using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Commonlayer.Models.RequestModel
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Profile Image")]
        public string ProfileImage { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public char Gender { get; set; }
        public bool isHRChecked { get; set; }
        public bool isSalesChecked { get; set; }
        public bool isFinanceChecked { get; set; }
        public bool isEngineerChecked { get; set; }
        public bool isOthersChecked { get; set; }
        public string Department { get; set; }
        public string[] multipleDepartments { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public string Day { get; set; }
        public string StartDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
