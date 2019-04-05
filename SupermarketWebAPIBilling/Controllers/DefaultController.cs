using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupermarketWebAPIBilling.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        SupermarketWebAPIBilling.Models.supermarketDBEntities2 obj = new Models.supermarketDBEntities2();
        public ActionResult Index()
        {
          

            return View(obj);
        }
    }
}