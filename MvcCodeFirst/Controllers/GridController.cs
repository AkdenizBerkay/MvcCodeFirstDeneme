using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class GridController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Grid
        public ActionResult Index()
        {
            List<Kisiler> KisiList = db.Kisiler.ToList();
            return View(KisiList);
        }
        [HttpPost]
        public ActionResult Index(string Ad = null)
        {
            List<Kisiler> KisiList = db.Kisiler.ToList();
            return View(KisiList);
        }

        public ActionResult Edit(int id)
        {
            List<Kisiler> KisiList = db.Kisiler.ToList();
            return View(KisiList);
        }
        public ActionResult Delete(int id)
        {
            List<Kisiler> KisiList = db.Kisiler.ToList();
            return View(KisiList);
        }

        public ActionResult AdresIndex()
        {
            List<Adresler> AdresList = db.Adresler.ToList();
            return View(AdresList);
        }
    }
}