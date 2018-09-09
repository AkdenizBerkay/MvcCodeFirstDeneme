using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class JQueryController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        List<Kisiler> KisiListe = null;
        // GET: JQuery
        public ActionResult Index()
        {
            
            if (Session["Kisiler"] != null)
            {
                KisiListe = Session["Kisiler"] as List<Kisiler>;
            }
            return View(KisiListe);
        }

        public PartialViewResult VerileriGetir()
        {
            List<Kisiler> KisiListe = (from x in db.Kisiler select x).ToList();
            System.Threading.Thread.Sleep(2000);
            Session["Kisiler"]=KisiListe;
            return PartialView("_KisilerPartial",KisiListe);
        }

        public JsonResult VerileriGetirJson()
        {
            List<Kisiler> KisiListe = (from x in db.Kisiler select x).ToList();
            System.Threading.Thread.Sleep(2000);
            Session["Kisiler"] = KisiListe;
            return Json(KisiListe, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Kaydet(string name,string age)
        {
            Kisiler kisi = new Kisiler();
            if (name.Contains(' '))
            {
                string[] isim = name.Split(' ');

                kisi.Ad = isim[0];
                kisi.Soyad = isim[1];
            }
            else {
                kisi.Ad = name;
                kisi.Soyad = name;
            }
            kisi.Yas = Convert.ToInt32(age);
            db.Kisiler.Add(kisi);
            db.SaveChanges();
            
            return View(kisi);
        }
    }
}