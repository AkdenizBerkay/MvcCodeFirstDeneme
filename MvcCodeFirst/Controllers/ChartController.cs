using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chart()
        {
            return View();
        }

        public ActionResult ChartOlustur()
        {
            Chart chart = new Chart(500, 500);
            chart.AddTitle("Gün Bazlı Ürün Satış Miktarı Grafiği");
            chart.AddLegend(title: "Ürünler");
            chart.AddSeries(name: "Product A", chartType: "Column", xValue: new[] { 20, 40, 60 }, yValues: new[] { 800, 1200, 2300 });
            chart.AddSeries(name: "Product B", chartType: "Column", xValue: new[] { 20, 40, 60 }, yValues: new[] { 900, 1600, 3300 });

            string path = Server.MapPath("~/grafiks/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imgpath = path + "chart1.jpeg";
            string xmlpath = path + "chart1.xml";

            chart.Save(imgpath, format: "jpeg");
            chart.SaveXml(xmlpath);

            return View(chart);

        }

        public ActionResult PieChartOlustur()
        {
            Chart chart = new Chart(500, 500);
            chart.AddTitle("Gün Bazlı Ürün Satış Miktarı Grafiği");
            chart.AddLegend(title: "Ürünler");
            chart.AddSeries(name: "Ürünler", chartType: "pie", xValue: new[] { "Kivi", "Çilek", "Muz" }, yValues: new[] { 800, 1200, 2300 });
            

            string path = Server.MapPath("~/grafiks/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imgpath = path + "chart2.jpeg";
            string xmlpath = path + "chart2.xml";

            chart.Save(imgpath, format: "jpeg");
            chart.SaveXml(xmlpath);

            return View("ChartOlustur",chart);

        }
    }
}