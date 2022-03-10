using System;
using System.Collections.Generic;
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
            List<asptable>all_data = db.asptables.ToList();
            return View(all_data);
        }
    }
}