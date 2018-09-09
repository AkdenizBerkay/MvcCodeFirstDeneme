using MvcCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class AnnotationController : Controller
    {
        // GET: Annotation
        public ActionResult Index()
        {
            Kullanici kul = new Kullanici();
            return View(kul);
        }
        [HttpPost]
        public ActionResult Index(Kullanici kul)
        {
            //eğer eklenecek kullanıcının email adresi zaten varsa db de kendı uyarı mesajımızı vermek ıcın:
            if (kul.Eposta.Equals("akdenizberkay@gmail.com"))
            {
                ModelState.AddModelError("Eposta", "Bu email zaten var");
                //ilk parametreyi "" (bu sekılde verırsen) verirsen hata mesajını valıdatıon summaryde gösterir
            }
            return View(kul);
        }
    }
}