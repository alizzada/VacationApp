using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Models
{
    public class Holidays
    {
        public int Id { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
    }
}
