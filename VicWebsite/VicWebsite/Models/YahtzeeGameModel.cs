﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VicWebsite.Models
{
    public class YahtzeeGameModel
    {
        public string Catagory { get; set; }
        public bool Reroll1 { get; set; }
        public bool Reroll2 { get; set; }
        public bool Reroll3 { get; set; }
        public bool Reroll4 { get; set; }
        public bool Reroll5 { get; set; }
        public int TimesReRolled { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public int Dice3 { get; set; }
        public int Dice4 { get; set; }
        public int Dice5 { get; set; }
        public int Score { get; set; }
    }
}