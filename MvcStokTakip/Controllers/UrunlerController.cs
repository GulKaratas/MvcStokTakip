using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class UrunlerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index()
        {
            var urunler = db.TBLURUNLER.ToList();

            return View(urunler);
        }
    }
}