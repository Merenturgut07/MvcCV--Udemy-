using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<TblHakkımda> repo=new GenericRepository<TblHakkımda> ();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkımda p)
        {
            var t=repo.Find(x=>x.ID==1);
            t.Ad=p.Ad;
            t.Soyad=p.Soyad;
            t.Adres=p.Adres;
            t.Mail=p.Mail;
            t.Telefon=p.Telefon;
            t.Aciklama=p.Aciklama;
            t.Resim=p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}