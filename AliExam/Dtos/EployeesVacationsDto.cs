using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Dtos
{
    public class EployeesVacationsDto
    {
        public int EmployeesId { get; set; }
        public DateTime VacationStart { get; set; }
        public int VacationDayCount { get; set; }
        public DateTime WorkDay { get; set; }
    }
}
