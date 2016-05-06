using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VicWebsite.Models
{
    public class YahtzeeGameModel
    {
        public string Catagory { get; set; }
        [DisplayName("Dice 1")]
        public int Dice1 { get; set; }
        [DisplayName("Dice 2")]
        public int Dice2 { get; set; }
        [DisplayName("Dice 3")]
        public int Dice3 { get; set; }
        [DisplayName("Dice 4")]
        public int Dice4 { get; set; }
        [DisplayName("Dice 5")]
        public int Dice5 { get; set; }
        public int Score { get; set; }
    }
}