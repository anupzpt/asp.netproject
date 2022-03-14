using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netproject.Models;

namespace asp.netproject.Controllers
{
    public class employeeController : Controller
    {
        MainEntities db;
        public employeeController()
        {
            db = new MainEntities();
        }
        // GET: employee
        public ActionResult Employee()
        {
            List<record>all_data = db.records.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            record data = db.records.Find(id);
            //column ko anusar select garna
            //record data =db.records.FirstOrDefault(x => x.id == id);
            return View(data);
        }
  
        public ActionResult UpdateData(record update)
        {
            db.Entry(update).State= EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Employee");
        }


        public ActionResult Deletedata(int id)
        {
            record record = db.records.Find(id); 

            db.records.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Employee");
        }
    }
}