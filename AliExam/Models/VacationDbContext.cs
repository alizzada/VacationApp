using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExam.Models
{
    public class VacationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=ALI-5-B6\SQLEXPRESS; Database=AliExam; Trusted_Connection=True");

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<EmployeesVacations> EmployeesVacations { get; set; }
    }
}
