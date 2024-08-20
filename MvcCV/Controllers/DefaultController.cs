using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db=new DbCvEntities();
        public ActionResult Index()
        {
           var degerler= db.TblHakkımda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimlerim.ToList(); 
            return PartialView(deneyimler);
        }

		public PartialViewResult Egitim()
		{
			var egitimlerim = db.TblEgitim.ToList();
			return PartialView(egitimlerim);
		}


		public PartialViewResult Yeteneklerim()
		{
			var yeteneklerim = db.TblYeteneklerim.ToList();
			return PartialView(yeteneklerim);
		}

		public PartialViewResult Hobilerim()
		{
			var hobilerim = db.TblHobilerim.ToList();
			return PartialView(hobilerim);
		}

		public PartialViewResult Sertifikalar()
		{
			var sertifikalar = db.TblSertifikalarım.ToList();
			return PartialView(sertifikalar);
		}

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }


        [HttpGet]
		public PartialViewResult İletisim()
		{
			return PartialView();
		}


		[HttpPost]
		public PartialViewResult İletisim(TblIletisim t )
		{
			t.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
			db.TblIletisim.Add(t);
			db.SaveChanges();
			return PartialView();
		}
	}
}