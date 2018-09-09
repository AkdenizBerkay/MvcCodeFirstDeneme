using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Ajax()
        {
            List<string> Veriler = new List<string>() { "Berkay", "Deniz", "Bahtiyar", "Ali", "Bıcırık", "Veli" };
            Session["Listem"] = Veriler;
            return View();
        }

        public PartialViewResult LoadData()
        {
            List<string> Veriler = Session["Listem"] as List<string>;

            System.Threading.Thread.Sleep(3000);

            return PartialView("_VerilerPartial",Veriler);
        }

        public MvcHtmlString RemoveData(string ad)
        {
            List<string> Veriler = Session["Listem"] as List<string>;
            Veriler.Remove(Veriler.Where(k => k == ad).FirstOrDefault());
            Session["Listem"] = Veriler;
            System.Threading.Thread.Sleep(3000);
            return MvcHtmlString.Empty;
        }

    }
}