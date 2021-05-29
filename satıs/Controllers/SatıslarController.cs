using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data;
using System.IO;
using satıs.Models;
using System.Drawing;
using System.Net;
using System.Data.Entity;
using System.Web.Helpers;

namespace satıs.Controllers
{
  
    public class SatıslarController : Controller
    {
        karaca_teknolojiEntities3 db = new karaca_teknolojiEntities3();
        //
        // GET: /Satıslar/
      
        public ActionResult Anasayfa()
        {
            if (Session["kulid"] != null)
            {
            return View();
            }
        else
        {
            return RedirectToAction("giris", "Login");
        }
        }

         [HttpGet]
        public ActionResult Ürünekle()
        {
               if (Session["kulid"] != null)
            {
            ViewBag.Kategoriler = db.kategorilers.ToList();
             return View();
            }
               else
               {
                   return RedirectToAction("giris", "Login");
               }
        }
     
         [HttpPost]
         public ActionResult Ürünekle(ürünler u, HttpPostedFileBase foto)
         {
             if (foto != null)
             {
                 WebImage img = new WebImage(foto.InputStream);
                 FileInfo fotoinfo = new FileInfo(foto.FileName);

                 string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                 img.Resize(150, 150);
                 img.Save("~/resim/ürünfoto/" + newfoto);
                 u.ürünfoto = "/resim/ürünfoto/" + newfoto;
               
             }
             db.ürünler.Add(u);
             db.SaveChanges();
                 return RedirectToAction("Ürünekle");
             }
        
           
        public ActionResult Ürünlistele()
        { 
       if (Session["kulid"] != null)
            {
            List<ürünler> ürunler = db.ürünler.ToList();
            return View(ürunler);
            }
       else
       {
           return RedirectToAction("giris", "Login");
       }
        }
        public ActionResult Ürünsil(int id)
        {
             if (Session["kulid"] != null)
            {
            ürünler u = db.ürünler.FirstOrDefault(x => x.ürünid == id);
            return View (u);
            }
             else
             {
                 return RedirectToAction("giris", "Login");
             }
        }
        [HttpPost]
        public ActionResult Ürünsil(ürünler u)
        {
            ürünler urn = db.ürünler.FirstOrDefault(x => x.ürünid == u.ürünid);
            db.ürünler.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Ürünlistele");
        }


        [HttpGet]
        public ActionResult Ürüngüncelle(int id)
        {  
            if (Session["kulid"] != null)
            {
         
            ViewBag.Kategoriler = db.kategorilers.ToList();
            var urn = db.ürünler.Where(x => x.ürünid == id).SingleOrDefault();
            return View(urn);
            }
        else
        {
            return RedirectToAction("giris", "Login");
        }
        }

        [HttpPost]
        public ActionResult Ürüngüncelle(ürünler u, int id)
        {
            
            var urn = db.ürünler.Where(x => x.ürünid == id).SingleOrDefault();
          
            urn.katid = u.katid;
            urn.ürünbarkod = u.ürünbarkod;
            urn.ürünfoto = u.ürünfoto;
            urn.ürünad = u.ürünad;
            urn.ürünozellik = u.ürünozellik;
            urn.ürünfiyat = u.ürünfiyat;

            db.SaveChanges();
            return RedirectToAction("Ürünlistele");
        }
      


        public ActionResult Arama(string ürünad)
        {
             if (Session["kulid"] != null)
            {
         
            var ara = from s in db.ürünler
                      select s;
            if (!string.IsNullOrEmpty(ürünad))
            {
                ara = ara.Where(x => x.ürünad.Contains(ürünad));

            }
            return View(ara);
            }
             else
             {
                 return RedirectToAction("giris", "Login");
             }
        }
	}
}