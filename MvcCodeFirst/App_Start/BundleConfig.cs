using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcCodeFirst.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/all").Include(
                "~/Scripts/bootstrap.js",
                //{version} wild card ı ile surekli burdan elle değiştirmemize gerek yok otomatık alır
                "~/Scripts/jquery-{version}.js",
                //iki versiyon varsa ıkısını de yukler 
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/modernizr-{version}.js",
                "~/Scripts/modal-login.js"));


            //Tüm script dosyaları için:
            //bundles.Add(new ScriptBundle("~/js/all").Include("~/Scripts/*.js"));

            bundles.Add(new StyleBundle("~/css/all").Include(
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap.css",
                "~/Content/modal-login.css",
                "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}