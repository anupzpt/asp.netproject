using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netproject.Models;

namespace asp.netproject.Controllers
{
    public class RecordController : Controller
    {
        MainEntities recdb;
        public RecordController()
        {
            recdb = new MainEntities();
        }
        // GET: Record
        public ActionResult record()
        {
            List<record> all_data = recdb.records.ToList();
            return View(all_data);
        }
       
        public ActionResult Savedata(record recordsave)
        {
            recdb.records.Add(recordsave);
            recdb.SaveChanges();
            return RedirectToAction("record");
        }
        public ActionResult student()
        {
            List<student> all_data = recdb.students.ToList();
            return View(all_data);
        }
        public ActionResult studenttable()
        {
            List<student> all_data = recdb.students.ToList();
            return View(all_data);
        }

        public ActionResult adddata(student studentsave)
        {
            recdb.students.Add(studentsave);
            recdb.SaveChanges();
            return RedirectToAction("student");
        }
    }
}