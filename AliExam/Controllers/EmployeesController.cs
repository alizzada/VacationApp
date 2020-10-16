using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliExam.Models;
using AliExam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AliExam.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            using (var dbContext=new VacationDbContext())
            {
                var model = dbContext.Employees.Include(x => x.Department).Where(m=>m.State==true).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            using (var dbContext=new VacationDbContext())
            {
                var model = new EmployeesFormViewModel()
                {
                    Departments = dbContext.Departments.ToList(),
                    Employees=new Employees()
                };
                return View("AddEmployee", model);

            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddEmployee(Employees employees)
        {
            using (var dbContext=new VacationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    var model = new EmployeesFormViewModel()
                    {
                        Departments=dbContext.Departments.ToList(),
                        Employees=employees
                    };
                    return View("AddEmployee",model);
                }
                 
                if (employees.Id==0)
                {
                    dbContext.Employees.Add(employees);
                }
                else
                {
                    dbContext.Employees.Update(employees);
                }
                
                dbContext.SaveChanges();
                return RedirectToAction("GetAllEmployees");
            }
            
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            using (var dbContext = new VacationDbContext())
            {
                var model = new EmployeesFormViewModel()
                {
                    Departments = dbContext.Departments.ToList(),
                    Employees = dbContext.Employees.Find(id)
                };
                return View("AddEmployee", model);
            }
        }


        public IActionResult DeleteEmployee(int id)
        {
            using (var dbContext=new VacationDbContext())
            {
                var employee = dbContext.Employees.Find(id);
                employee.State = false;
                dbContext.Employees.Update(employee).Property("State").IsModified = true;
                dbContext.SaveChanges();
                return RedirectToAction("GetAllEmployees");
            }
        }


        
    }
}