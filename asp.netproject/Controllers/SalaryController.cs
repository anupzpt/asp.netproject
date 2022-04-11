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
            var employeesalary=db.employee_salary_details.ToList();
            //List<employee_salary_details> all_data = db.employee_salary_details.ToList();
            return View(employeesalary);
        
        }
       
        public ActionResult adddata()
        {
            var empList =db.records.ToList();
            ViewBag.employeeList = new SelectList(empList,"id","Firstname");
            return View();
        }

        [HttpPost]
        public ActionResult Search(DateTime? begindate ,DateTime? enddate, string employeename)
        {
            List<employee_salary_details> search = db.employee_salary_details.ToList();
            if (begindate!=null && enddate!=null)
            {
                search=search.Where(x=>begindate <=x.paid_date && enddate>=x.paid_date).ToList();
            }
            if (employeename != null)
            {
                search = search.Where(x=>x.record.Firstname==employeename).ToList();
            }
            return View("Salary", search);
        }
        //public ActionResult Salary(DateTime dat)
        //{
        //    var results = db.employee_salary_details.Where(x => x.paid_date == dat).ToList();
        //    return View(results);

        //}
        public ActionResult add(employee_salary_details add)
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