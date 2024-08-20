using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo=new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();  
        }


        [HttpPost]
        public ActionResult YeniDeneyim(TblDeneyimlerim p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t=repo.Find(x=>x.ID==id);   
            repo.TDelete(t);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}