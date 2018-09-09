using MvcCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Filter
{
    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db = new DatabaseContext();

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            db.Loglar.Add(new Models.Log()
            {
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Bilgi = "OnActionExecuted",
                KisiAdi = "system",
                Tarih = DateTime.Now
            });

            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            db.Loglar.Add(new Models.Log()
            {
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Bilgi = "OnActionExecuting",
                KisiAdi = "system",
                Tarih = DateTime.Now
            });

            db.SaveChanges();
        }
    }
}