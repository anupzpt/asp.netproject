using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netproject.Models;

namespace asp.netproject.Controllers
{
    public class teacherController : Controller
    {
        // GET: teacher
        MainEntities db = new MainEntities();

        public ActionResult teacher()
        {
            List<teacher> all_data = db.teachers.ToList();
            return View(all_data);
        }
        public ActionResult add()
        {
            var techerlist = db.teachers.ToList();
            ViewBag.teacher = new SelectList(techerlist, "tid");
            return View();
        }
        [HttpPost]
        public ActionResult adddata(teacher adddata)
        {
            db.teachers.Add(adddata);
            db.SaveChanges();
            return RedirectToAction("teacher");
        }
        public ActionResult editteacher(int tid)
        {
            var techerlist = db.teachers.ToList();
            ViewBag.teacher = new SelectList(techerlist, "tid");
            teacher data = db.teachers.Find(tid);
            return View(data);
        }
        public ActionResult updateteacher(teacher update)
        {
            db.Entry(update).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("teacher");
        }
    }
}