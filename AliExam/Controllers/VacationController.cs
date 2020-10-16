using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AliExam.Dtos;
using AliExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AliExam.Controllers
{
    public class VacationController : Controller
    {
        
        [HttpGet]
        public ActionResult GetAllVacation()
        {
            using (var dbContext=new VacationDbContext())
            {
                var model = dbContext.EmployeesVacations.Include(x => x.Employees).OrderByDescending(m=>m.Id).ToList();
                return View(model);
            }
        }

       

        [HttpGet]
        public ActionResult AddVacation()
        {
            using (var dbContext = new VacationDbContext())
            {
                var depList = dbContext.Departments.Where(x=>x.Type==1).ToList();
                return View(depList);
            }                      
        }

        public JsonResult getSections(int id)
        {
            using (var dbContext = new VacationDbContext())
            {
                var section= dbContext.Departments.Where(x => x.RootId == id).ToList();
                return new JsonResult(section);
            }
        }

        public JsonResult GetEmployees(int id)
        {
            using (var dbContext = new VacationDbContext())
            {
                var empSelect = dbContext.Employees.Where(x => x.DepartmentId == id).ToList();
                return new JsonResult(empSelect);
            }
        }

        public JsonResult Calculate (DateTime startDate, int daysCount)
        {
            var dbContext = new VacationDbContext();
            var holidays = dbContext.Holidays.ToList();
            DateTime endDate = startDate.AddDays(daysCount);

            var offDays =0;

            for (DateTime count = startDate; count <= endDate; )
            {
                if (count.DayOfWeek==DayOfWeek.Saturday|| count.DayOfWeek == DayOfWeek.Sunday)
                {
                    offDays++;
                }
                else if (holidays.Where(x=>x.HolidayStartDate<=count && x.HolidayEndDate>=count).Count()>0)
                {
                    offDays++;
                }
                count=count.AddDays(1);
            }

            DateTime workDate = endDate.AddDays(offDays);
            if (workDate.DayOfWeek==DayOfWeek.Saturday)
            {
                workDate = workDate.AddDays(2);
            }
            else if (workDate.DayOfWeek == DayOfWeek.Sunday)
            {
                workDate = workDate.AddDays(1);
            }

            return  Json( new { endDate, offDays, workDate});

        }
        [HttpPost]
        public JsonResult Add(EployeesVacationsDto employeesVacationsDto)
        {
            using (var dbContext = new VacationDbContext())
            {
                var addedVacation = new EmployeesVacations
                {
                    EmployeesId = employeesVacationsDto.EmployeesId,
                    VacationStart = employeesVacationsDto.VacationStart,
                    VacationDayCount = employeesVacationsDto.VacationDayCount,
                    WorkDay = employeesVacationsDto.WorkDay
                };
                
                 dbContext.EmployeesVacations.Add(addedVacation);
                 dbContext.SaveChanges();

                return new JsonResult(200);
            }
        }

        public ActionResult DeleteVacation(int id)
        {
            using (var dbContext=new VacationDbContext())
            {
                var vacation = dbContext.EmployeesVacations.Find(id);
                if (vacation == null)
                {
                    return BadRequest();
                }

                dbContext.EmployeesVacations.Remove(vacation);
                dbContext.SaveChanges();
                return RedirectToAction("GetAllVacation");
            }
        }
    }
}