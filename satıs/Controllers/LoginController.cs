using satıs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace satıs.Controllers
{
    public class LoginController : Controller
    {
        karaca_teknolojiEntities3 db = new karaca_teknolojiEntities3();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
         [HttpGet]
        public ActionResult giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult giris(kullanıcılar kul)
        {
            var sonuc = db.kullanıcılar.Where(x => x.kulad == kul.kulad && x.kulsifre == kul.kulsifre).SingleOrDefault();
            if (sonuc != null)
            {
                Session["kulid"] = sonuc.kulid;
                Session["kulad"] = kul.kulad;
                return RedirectToAction("Ürünlistele", "Satıslar");
            }
            return View();
        }

          [HttpGet]
        public ActionResult kullaniciekle()
        {
            return View();
        }

        [HttpPost]
          public ActionResult kullaniciekle(kullanıcılar kul)
        {
            db.kullanıcılar.Add(kul);
            db.SaveChanges();
            return RedirectToAction("giris","Login");
        }
        public ActionResult cikis()
        {
            Session.Clear();

            return RedirectToAction("giris", "Login");
        }


	}
}