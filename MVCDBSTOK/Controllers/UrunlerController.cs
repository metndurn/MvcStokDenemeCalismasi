using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBSTOK.Models.Entity;

namespace MVCDBSTOK.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TblUrunler.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            /*dropdownlist kullanımıdır liste icindeki degerleri alıp en altta viewbag
             degıskenıne atayıp view kısmında gosterecegız*/
            List<SelectListItem> urunler=(from urun in db.TblKategori.ToList()
                                          select new SelectListItem
                                          {
                                            Text = urun.KategoriAd,
                                            Value = urun.KategoriId.ToString()
                                          }).ToList();
            ViewBag.urn = urunler;
            return View();
        }
        [HttpPost]
        /*yenıurun ekleme kısmıdır ve butona basıldıgı zamankı kodlar buraya yazılır
         yukarıda kategorıyı dropdowndan cektırırken buradanda eslestırme yaptırıyoruz*/
        public ActionResult YeniUrun(TblUrunler yeniUrun)
        {
            /*linqu sorgusu yaptırdık*/
            var ktg = db.TblKategori.Where(k => k.KategoriId == yeniUrun.TblKategori.KategoriId).FirstOrDefault();
            yeniUrun.TblKategori = ktg;
            db.TblUrunler.Add(yeniUrun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*Urunler sayfasındakı tıklama yapıldıgı zamankı kod blogunu calıstırır*/
        public ActionResult UrunGuncelle(int id)
        {
            var urun = db.TblUrunler.Find(id);

            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.KategoriAd,
                                                Value = i.KategoriId.ToString()
                                            }).ToList();
            ViewBag.urn = degerler;

            return View("UrunGuncelle", urun);
        }

        public ActionResult UrnGuncelle(TblUrunler urun)
        {
            var urn = db.TblUrunler.Find(urun.UrunId);
            urn.UrunAd = urun.UrunAd;
            urn.Marka = urun.Marka;//urn.stok=urun.stok eklenmedi burası eksıktır
            urn.Fiyat = urun.Fiyat;
            // urn.UrunKategori = urun.UrunKategori;
            var ktg = db.TblKategori.Where(k => k.KategoriId == urun.TblKategori.KategoriId).FirstOrDefault();
            urn.UrunKategori = ktg.KategoriId;//burada atama islemi yaptırıp kullandık bu kodu arastır
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}