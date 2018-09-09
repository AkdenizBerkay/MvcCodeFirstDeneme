using MvcCodeFirst.Models;
using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Filter
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db = new DatabaseContext();

        //çalıştıktan sonra
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            db.Loglar.Add(new Models.Log()
            {
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Bilgi = "OnActionExecuted",
                KisiAdi = (filterContext.HttpContext.Session["kul"] as Kullanici).Ad,
                Tarih = DateTime.Now
            });

            db.SaveChanges();
        }

        //çalışmadan önce
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.Loglar.Add(new Models.Log()
            {
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Bilgi = "OnActionExecuting",
                KisiAdi = (filterContext.HttpContext.Session["kul"] as Kullanici).Ad,
                Tarih = DateTime.Now
            });

            db.SaveChanges();
        }
    }
}