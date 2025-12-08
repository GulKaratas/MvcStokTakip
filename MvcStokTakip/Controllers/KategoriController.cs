using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORILER.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategoriler()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategoriler(TBLKATEGORILER kategoriler)
        {
            db.TBLKATEGORILER.Add(kategoriler);
            db.SaveChanges();
            return View();

        }
    }
}