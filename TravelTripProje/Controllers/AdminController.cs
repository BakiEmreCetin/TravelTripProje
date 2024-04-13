using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult YeniBlog(Blog p)
        {
            context.Blogs.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var b = context.Blogs.Find(id);
            context.Blogs.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var bl = context.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = context.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }
        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var b = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(b);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yrm = context.Yorumlars.Find(id);
            return View("YorumGetir", yrm);
        }
        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yr = context.Yorumlars.Find(y.ID);
            yr.KullaniciAdi = y.KullaniciAdi;
            yr.Mail = y.Mail;
            yr.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult iletisim()
        {
            var degerler = context.iletisims.ToList();
            return View(degerler);
        }

        [Authorize]
        public ActionResult Hakkimizda()
        {
            var degerler = context.Hakkimizdas.FirstOrDefault();

            return View(degerler);
        }

        [Authorize]

        public ActionResult HakkimizdaGuncelle(Hakkimizda p)
        {
            var hakkimizda = context.Hakkimizdas.Find(p.ID);
            hakkimizda.FotoUrl = p.FotoUrl;
            hakkimizda.Aciklama = p.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}