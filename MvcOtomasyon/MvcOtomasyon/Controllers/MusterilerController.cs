using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;

namespace MvcOtomasyon.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        SatisVTEntities db = new SatisVTEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERI select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteriler =db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir",musteri);
        }
        public ActionResult Guncelle(TBLMUSTERI p1) 
        { 
            
            var mus = db.TBLMUSTERI.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISEHIR=p1.MUSTERISEHIR;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}