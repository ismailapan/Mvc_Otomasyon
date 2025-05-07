using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;

namespace MvcOtomasyon.Controllers
{
    public class HareketlerController : Controller
    {
        // GET: Hareketler
        SatisVTEntities db = new SatisVTEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}