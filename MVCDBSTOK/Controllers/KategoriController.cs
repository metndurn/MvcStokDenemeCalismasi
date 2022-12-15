using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBSTOK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCDBSTOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var kategoriler = db.TblKategori.ToList(); deneme amaclı kapatıldı
            var kategoriler = db.TblKategori.ToList().ToPagedList(sayfa, 5);
            return View(kategoriler);
        }
        //sayfa yuklenince burayı calıstırır
        [HttpGet]//yenikategori ekleme isleminde herhangı bır ıslem yapılmadıysa bunu ılk basta gosterır eger ekleme ıslemı yapılacaksa burası calısmaz
        //yenikategori ekleme işleminin tekrarlanmaması ıcın kullanılıyor nır nevı ındex gorevı gorur
        public ActionResult YeniKategori()
        {
            return View();
        }
        //yuklenen sayfada ekleme veya gonderme ıslemı olacaksa burası calıstırılır
        [HttpPost]//uygulama ıcınde herhangi bir ekleme yapıldıgı surece calıs demektır bos yere verı eklemeyi engeller aksi durumda [httpget] calısır
        //yeni kategori ekleme kodu
        public ActionResult YeniKategori(TblKategori yeniKategori)//deger donduren ve parametreli koddur
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKategori.Add(yeniKategori);
            db.SaveChanges();
            return View();
        }
        /*kategori sılme metodu geriye deger donduren metoddur ve int ile id degerine gore silme yapacak*/
        public ActionResult KategoriSil(int id)//degeri int olarak id alıyor
        {
            var kategori = db.TblKategori.Find(id);//kategorinin icindeki id degerini bul demektir
            db.TblKategori.Remove(kategori);//bulunan id sil demektir
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*kategorı sayfasındakı tıklama yapıldıgı zamankı kod blogunu calıstırır*/
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.TblKategori.Find(id);
            return View("KategoriGuncelle", kategori);
        }
        public ActionResult KtgGuncelle(TblKategori kategori)
        {
            var ktg = db.TblKategori.Find(kategori.KategoriId);
            ktg.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}