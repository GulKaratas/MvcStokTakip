using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var musteriler = db.TBLMUSTERILER.ToList();
            return View(musteriler);
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();       
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int? id)
        {   if(id==null)
            {
                return RedirectToAction("Index");
            }
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(TBLMUSTERILER musteri)
        { 
            var musteriler = db.TBLMUSTERILER.Find(musteri.MUSTERIID);
            musteriler.MUSTERIAD = musteri.MUSTERIAD;
            musteriler.MUSTERISOYAD = musteri.MUSTERISOYAD; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}