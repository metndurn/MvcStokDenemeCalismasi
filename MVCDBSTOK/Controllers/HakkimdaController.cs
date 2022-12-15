using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBSTOK.Models.Entity;

namespace MVCDBSTOK.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}