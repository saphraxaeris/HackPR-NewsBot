using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Lottery
    {
        public string date { get; set; }
        public string[] winners { get; set; }

        public override string ToString()
        {
            var result = "Date: " + date + " - Winners: ";
            foreach(var winner in winners) {
                result += winner + ", ";
            }
            return result.Substring(0, result.Length-2) + General.NewLine();
        }
    }
    
}