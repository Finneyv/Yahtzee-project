using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VicWebsite.Models
{
    public class YahtzeeGameModel
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public int Dice3 { get; set; }
        public int Dice4 { get; set; }
        public int Dice5 { get; set; }
        public int Dice6 { get; set; }
        public int Total { get; set; }
    }
}