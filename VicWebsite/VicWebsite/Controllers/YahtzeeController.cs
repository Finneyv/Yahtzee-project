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
        [HttpGet]
        public ActionResult Game()
        {
            AddCollectionsToViewBag();
            return View();
        }

        //POST: GameLogic
        [HttpPost]
        public ActionResult GameLogic(int[] Dices, string Catagory)
        {
            var score = 0;
            int val = Dices.First();
            if(Catagory == "" || Catagory == "Chance")
            {
                score = Dices.Sum();
            }
            else if (Catagory == "Yahtzee")
            {
                if (Dices.All(x => x == val)) score = 50;
            }
            else if(Catagory == "Small Straight")
            {
                int[] array = { 1, 2, 3, 4, 5 };
                if (Dices.OrderBy(x => x).ToArray() == array) score = 15;
            }
            else if(Catagory == "Large Straight")
            {
                int[] array = { 2, 3, 4, 5, 6 };
                if (Dices.OrderBy(x => x).ToArray() == array) score = 20;
            }
            else if(Catagory == "Pair")
            {
                if(Dices.GroupBy(x => x).Select(x => x.Count() == 2).FirstOrDefault(x => x == true))
                {
                    score = Dices.OrderByDescending(x => x).GroupBy(x => x).FirstOrDefault(x => x.Count() == 2).First() * 2;
                }
            }
            else if(Catagory == "Two Pairs")
            {
                if(Dices.GroupBy(x => x).Select(x => x.Count() == 2).Where(x => x == true).Count() == 2)
                {
                    score = Dices.GroupBy(x => x).Where(x => x.Count() == 2).Select(x => x.Key).Sum()*2;
                }
            }
            else if(Catagory == "Three of a kind")
            {
                if(Dices.GroupBy(x => x).Select(x => x.Count() == 3).FirstOrDefault(x => x == true))
                {
                    score = Dices.GroupBy(x => x).Where(x => x.Count() == 3).Select(x => x.Key).SingleOrDefault() * 3;
                }
            }
            else if(Catagory == "Four of a kind")
            {
                if(Dices.GroupBy(x => x).Select(x => x.Count()==4).FirstOrDefault(x => x == true))
                {
                    score = Dices.GroupBy(x => x).Where(x => x.Count() == 4).Select(x => x.Key).SingleOrDefault() * 4;
                }
            }
            else if(Catagory == "Full House")
            {
                var grouped = Dices.GroupBy(x => x);
                if(grouped.Select(x => x.Count() == 2).FirstOrDefault(x => x == true) && grouped.Select(x => x.Count() == 3).FirstOrDefault(x => x==true))
                {
                    score = Dices.Sum();
                }
            }
            var obj = new {  value = score };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        private void AddCollectionsToViewBag()
        {
            List<string> catagories = new List<string> { "Chance", "Yahtzee", "Small Straight", "Large Straight", "Pair",
            "Two Pairs", "Three of a kind", "Four of a kind", "Full House"};
            ViewBag.Catagories = new SelectList(catagories);
        }
    }
}