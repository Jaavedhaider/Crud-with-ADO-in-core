using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_with_ADO_in_core.Models
{
    public class Employee
    {
   
        public int id { get; set; }
        [Required]
        public string Ename { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Mobile { get; set; }
        [Required]
        public int Deptid { get; set; }
        public string DepartmentName { get; set; }
    }
}
