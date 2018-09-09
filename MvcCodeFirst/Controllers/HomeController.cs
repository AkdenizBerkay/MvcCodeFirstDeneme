using MvcCodeFirst.Filter;
using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        [AuthFilter, ActFilter,ExcFilter]
        public ActionResult Index()
        {
            //DatabaseContext db = new DatabaseContext();
            List<Kisiler> KisiListe = db.Kisiler.ToList();
            return View(KisiListe);
        }
        
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(string ad,string soyad,string yas)
        {
            Kisiler ben = new Kisiler();
            ben.Ad = ad;
            ben.Soyad = soyad;
            ben.Yas = Convert.ToInt32(yas);
            db.Kisiler.Add(ben);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Duzenle(int Kisiid)
        {
            Kisiler kisi = db.Kisiler.Where(k => k.Id == Kisiid).FirstOrDefault();
            return View(kisi);
        }
        [HttpPost]
        public ActionResult Duzenle(Kisiler kisim,int kisiId)
        {
            Kisiler eski = db.Kisiler.Where(k => k.Id == kisiId).FirstOrDefault();
            eski.Ad = kisim.Ad;
            eski.Soyad = kisim.Soyad;
            eski.Yas = kisim.Yas;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Sil(int Kisiid)
        {
            Kisiler kisi = db.Kisiler.Where(k => k.Id == Kisiid).FirstOrDefault();
            return View(kisi);
        }
        [HttpPost,ActionName("Sil")]
        public ActionResult Sil1(int kisiId)
        {
            Kisiler sil = db.Kisiler.Where(k => k.Id == kisiId).FirstOrDefault();
            if (sil != null)
            {
                db.Kisiler.Remove(sil);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
      
        public ActionResult Login()
        {
            return View(new Kullanici());
        }
        [HttpPost]
        public ActionResult Login(Kullanici kul)
        {
            bool kullaniciadi = false;
            bool sifre = false;

            Kullanici k = db.Kullanicis.FirstOrDefault(x => x.Eposta.Equals(kul.Eposta));

            if (k != null)
            {
                kullaniciadi = true;

                if (db.Kullanicis.FirstOrDefault(x => x.Sifre.Equals(kul.Sifre)) != null)
                {
                    sifre = true;
                }
            }


            if (!kullaniciadi)
            {
                ModelState.AddModelError("", "Hatalı e-posta adresi");
                return View(kul);
            }

            else if (!sifre)
            {
                ModelState.AddModelError("", "Hatalı sifre");
                return View(kul);
            }
            else
            {
                Session["kul"] = k;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Error()
        {
            if (TempData["error"] == null)
            {
                return View();//baska bi hata mesajı vercek aslında
            }

            Exception model = TempData["error"] as Exception;

           
            return View(model);
        }

    }
}