using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad xanasi mutleq doldurulmalidir...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad xanasi mutleq doldurulmalidir...")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Departament secmek lazimdir...")]
        [Display(Name ="Department")]
        public int? DepartmentId { get; set; }
        
        public Departments Department { get; set; }
        public bool State { get; set; } = true;
    }
}
