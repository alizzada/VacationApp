using AliExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.ViewModels
{
    public class EmployeesFormViewModel
    {
        public IEnumerable<Departments> Departments { get; set; }
        public Employees Employees { get; set; }
    }
}
