using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class MBAController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: MBA
        public ActionResult MBAGrid()
        {
            List<Kisiler> KisiList = db.Kisiler.ToList();
            return View(KisiList);
        }
        public ActionResult MBAEdit(string id)
        {
            int Kisiid = Convert.ToInt32(id);
            Kisiler kisi = db.Kisiler.Where(k => k.Id == Kisiid).FirstOrDefault();
            return View(kisi);
        }
        public ActionResult MBADelete(string id)
        {
            int Kisiid = Convert.ToInt32(id);
            Kisiler kisi = db.Kisiler.Where(k => k.Id == Kisiid).FirstOrDefault();
            return View(kisi);
        }
    }
}