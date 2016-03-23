using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VicWebsite.Controllers
{
    public class YahtzeeController : Controller
    {
        // GET: Yahtzee
        public ActionResult Game()
        {
            return View();
        }
    }
}