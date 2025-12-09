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

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
                        db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var kategori = db.TBLKATEGORILER.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View("KategoriGetir", kategori);
        }

        [HttpPost]
        public ActionResult Guncelle(TBLKATEGORILER kategoriler)
        {
            var kategori = db.TBLKATEGORILER.Find(kategoriler.KATEGORIID);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            kategori.KATEGORIAD = kategoriler.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}