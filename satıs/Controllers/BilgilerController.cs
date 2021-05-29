using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace satıs.Controllers
{
    public class BilgilerController : Controller
    {
        //
        // GET: /Bilgiler/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkında()
        {
            return View();
        }

        public ActionResult İletisim()
        {
            return View();
        }
	}
}