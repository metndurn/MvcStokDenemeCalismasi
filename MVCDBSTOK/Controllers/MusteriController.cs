using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBSTOK.Models.Entity;

namespace MVCDBSTOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var musteri = db.TblMusteri.ToList();
            return View(musteri);
        }
        //sayfayı oldugu gıbı getırır
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        //sayfanın ekleme ve islem yapıldıgında calısacak kod
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri yeniMusteri)
        {
            if (!ModelState.IsValid/*==!ModelState.IsValid*/)
            {
                return View("YeniMusteri");
            }
            db.TblMusteri.Add(yeniMusteri);
            db.SaveChanges();
            return View();
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = db.TblMusteri.Find(id);
            db.TblMusteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //musteri guncelleye tıklatır
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.TblMusteri.Find(id);
            return View("MusteriGuncelle",musteri);
        }
        //tıklanan musterının ıcerıgını burası doldurur burada hata var
        public ActionResult MusGuncelle(TblMusteri musteri)
        {
            var mus = db.TblMusteri.Find(musteri.MusteriId);
            mus.MusteriAd = musteri.MusteriAd;
            mus.MusteriSoyad = musteri.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}