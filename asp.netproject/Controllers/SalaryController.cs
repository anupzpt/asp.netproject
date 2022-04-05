using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netproject.Models;

namespace asp.netproject.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        MainEntities db = new MainEntities();
        public ActionResult Salary()
        {
            List<employee_salary_details> all_data = db.employee_salary_details.ToList();
            return View(all_data);
        
        }
       
        public ActionResult adddata()
        {
            var empList =db.records.ToList();
            ViewBag.employeeList = new SelectList(empList,"id","Firstname");
            return View();
        }

        [HttpPost]
        public ActionResult adddata(employee_salary_details add)
        {
            db.employee_salary_details.Add(add);
            db.SaveChanges();
            return RedirectToAction("Salary");
        }
        public ActionResult Editsalary(int id)
        {
            var empList = db.records.ToList();
            ViewBag.employeeList = new SelectList(empList, "id", "Firstname");
            employee_salary_details data = db.employee_salary_details.Find(id);
            return View(data);
        }
        public ActionResult UpdateSalaryData(employee_salary_details update)
        {
            db.Entry(update).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Salary");
        }
    }
}