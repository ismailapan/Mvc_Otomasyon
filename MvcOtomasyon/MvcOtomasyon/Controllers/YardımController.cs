using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;


namespace MvcOtomasyon.Controllers
{
    public class YardımController : Controller
    {
        SatisVTEntities db = new SatisVTEntities();

        // GET: Yardım
        public ActionResult Index()
        {
            var deger = db.TBLHAREKET.ToList();
            return View(deger);
        }
       
    }
}