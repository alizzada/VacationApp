using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string DepartName { get; set; }
        public int Type { get; set; }
        public int? RootId { get; set; }
        public bool State { get; set; }
    }
}
