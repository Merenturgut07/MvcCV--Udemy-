using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {

        GenericRepository<TblYeteneklerim> repo=new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }


        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
		public ActionResult YeniYetenek(TblYeteneklerim p)
		{
            repo.Add(p);
			return RedirectToAction("Index");
		}

        public ActionResult YetenekSil(int id)
        {
            var yetenek=repo.Find(x=>x.ID==id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }



		[HttpGet]
		public ActionResult YetenekGetir(int id)
		{
			TblYeteneklerim y = repo.Find(x => x.ID == id);
			return View(y);
		}

		[HttpPost]
		public ActionResult YetenekGetir(TblYeteneklerim p)
		{
			TblYeteneklerim t = repo.Find(x => x.ID == p.ID);
			t.Yetenek = p.Yetenek;
			t.Oran = p.Oran;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}