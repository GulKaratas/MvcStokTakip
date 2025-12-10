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
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER urunler)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == urunler.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urunler.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var urun = db.TBLURUNLER.Find(id);


            List<SelectListItem> deger1 = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View("UrunGetir", urun);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLURUNLER urunler)
        {
            var urun = db.TBLURUNLER.Find(urunler.URUNID);
            if (urun == null)
            {
                return HttpNotFound();
            }
            urun.URUNAD = urunler.URUNAD;
            urun.MARKA = urunler.MARKA;
            urun.FIYAT = urunler.FIYAT;
            urun.STOK = urunler.STOK;
            
            // Kategori güncellemesi
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == urunler.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            if (ktg != null)
            {
                urun.URUNKATEGORİ = ktg.KATEGORIID;
            }
            
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}