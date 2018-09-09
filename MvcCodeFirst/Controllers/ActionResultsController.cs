using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class ActionResultsController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: ActionResults
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult Home()
        {
            return Redirect("http://www.google.com");
        }

        public ActionResult Index3()
        {
            return View();
        }
        public JsonResult Index4()
        {
            Kisiler k = new Kisiler();
            k.Ad = "Berkay";
            k.Soyad = "Akdeniz";
            k.Yas = 26;
            return Json(k,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dosyalar()
        {
            ViewBag.id = TempData["id"];
            int id = Convert.ToInt32(ViewBag.id);
            List<Adresler> Adresler = (from x in db.Adresler where x.KisiId == id select x).ToList();
            return View(Adresler);
        }

        public ActionResult Dosyalar4(int Kisi)
        {
            TempData["id"] = Kisi;
            List<Adresler> Adresler = (from x in db.Adresler where x.KisiId == Kisi select x).ToList();
            return RedirectToAction("Dosyalar",Adresler);
        }
        public FileResult Dosyalar2()
        {
            string pdf = Server.MapPath("~/Files/CVim (1).pdf");
            return new FilePathResult(pdf,"application/pdf");
        }

        public FileStreamResult Dosyalar3()
        {
            string metin = "Denem Mesajı";
            System.IO.MemoryStream memo = new System.IO.MemoryStream();

            byte[] bytemetin = System.Text.Encoding.UTF8.GetBytes(metin);

            memo.Write(bytemetin, 0, bytemetin.Length);
            memo.Position = 0;
            FileStreamResult stream = new FileStreamResult(memo, "text/plain");

            stream.FileDownloadName = "Deneme.txt";

            return stream;
        }

        public PartialViewResult KategoriPartial()
        {
            return PartialView("_KategorilerPartial");
        }
        public JavaScriptResult JavaScript()
        {
            return JavaScript("alert('JavaScriptResult Örneği')");
        }
    }
}