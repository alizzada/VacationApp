using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Models
{
    public class EmployeesVacations
    {
        public int Id { get; set; }
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public DateTime VacationStart { get; set; }
        public int VacationDayCount { get; set; }
        public DateTime WorkDay { get; set; }
       
    }
}
