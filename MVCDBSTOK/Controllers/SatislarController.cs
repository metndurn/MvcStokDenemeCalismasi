using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBSTOK.Models.Entity;

namespace MVCDBSTOK.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            //var satislar = db.TblSatislar.ToList();
            return View(/*satislar*/);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatislar yeniSatis)
        {
            db.TblSatislar.Add(yeniSatis);
            db.SaveChanges();
            return View("Index");
        }
    }
}