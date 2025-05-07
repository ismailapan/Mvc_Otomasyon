using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcOtomasyon.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        SatisVTEntities db = new SatisVTEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLURUNLER.ToList();
            var degerler = db.TBLURUNLER.ToList().ToPagedList(1, 20);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler =(from i  in db.TBLKATEGORI.ToList()
                                            select new SelectListItem
                                            {
                                                Text=i.KATEGORIAD,
                                                Value=i.KATEGORIID.ToString()
                                            }).ToList();  
            ViewBag.dgr=degerler;
                                             
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORI.Where(m=>m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORI = ktg;
            
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urunler = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
           var urunler = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urunler);
        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urn = db.TBLURUNLER.Find(p1.URUNID);
            urn.URUNAD = p1.URUNAD;
            urn.URUNMARKA = p1.URUNMARKA;
            //urn.KATEGORI = p1.KATEGORI;
            var ktg = db.TBLKATEGORI.Where(m => m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            urn.KATEGORI = ktg.KATEGORIID;
            urn.URUNALISFIYAT = p1.URUNALISFIYAT;
            urn.URUNSATISFIYAT= p1.URUNSATISFIYAT;
            urn.URUNSTOK= p1.URUNSTOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}