using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = context.Blogs.Take(4).ToList();
            return View(degerler);
        }    
        public PartialViewResult Partial1()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = context.Blogs.Where(x => x.ID == 2).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = context.Blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = context.Blogs.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = context.Blogs.Take(3).OrderByDescending(x=>x.ID).ToList();
            return PartialView(deger);
        }
    }
}