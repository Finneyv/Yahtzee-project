﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VicWebsite.Controllers
{
    public class YahtzeeController : Controller
    {
        // GET: Yahtzee
        [HttpGet]
        public ActionResult Game()
        {
            return View();
        }

        //POST: GameLogic
        [HttpPost]
        public ActionResult GameLogic(int[] Dices)
        {
            var score = Dices.Sum();
            var obj = new {  value = score };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}