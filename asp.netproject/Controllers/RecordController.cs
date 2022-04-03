using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Edit(int id)
        {
            student data = recdb.students.Find(id);
            //column ko anusar select garna
            //record data =db.records.FirstOrDefault(x => x.id == id);
            return View(data);
        }
        public ActionResult UpdateData(student update)
        {
            recdb.Entry(update).State = EntityState.Modified;
            recdb.SaveChanges();
            return RedirectToAction("record");
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
        public ActionResult Delete(int id)
        {
            student data = recdb.students.Find(id);
            return View(data);
        }
        public ActionResult Deletedata(int id)
        {
            student record = recdb.students.Find(id);

            recdb.students.Remove(record);
            recdb.SaveChanges();
            return RedirectToAction("student");
        }
    }
}